using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CustomerDBModel;

namespace CustomerPhoneAPI.Models.Services
{
    public class EmployeePhoneService
    {
        ArupTestDatabaseEntities db = new ArupTestDatabaseEntities();
        public List<CustomerDetails> GetCustomers()
        {
            var dataCust = db.Customers.ToList();
            var dataPhone = db.CustomerPhones.ToList();
            List<CustomerDetails> custList = new List<CustomerDetails>();

            foreach (Customer cust in dataCust)
            {
                var dataCustPhone = dataPhone.Where(x => x.Cust_ID == cust.Cust_ID).ToList();
                custList.Add(GetCustomerDetails(cust, dataCustPhone));
            }
            return custList;
        }

        public CustomerDetails GetCustomer(int id)
        {
            var dataCust = db.Customers.FirstOrDefault(x => x.Cust_ID == id);
            var dataPhone = db.CustomerPhones.Where(x => x.Cust_ID == id).ToList();

            return GetCustomerDetails(dataCust, dataPhone);
        }

        public CustomerPhone GetPhonePerID(int id)
        {
            return db.CustomerPhones.Where(x => x.Cust_Phone_ID == id).FirstOrDefault();
        }

        public CustomerDetails AddPhoneNumberOfCustomer(CustomerPhone custPhone)
        {
            db.CustomerPhones.Add(custPhone);
            db.SaveChanges();

            var dataPhone = db.CustomerPhones.Where(x => x.Cust_ID == custPhone.Cust_ID).ToList();
            var dataCust = db.Customers.FirstOrDefault(x => x.Cust_ID == custPhone.Cust_ID);

            return GetCustomerDetails(dataCust, dataPhone);
        }

        public CustomerDetails UpdatePhoneNumberOfCustomer(int id, CustomerPhone custPhone)
        {
            var dataCust = db.Customers.FirstOrDefault(x => x.Cust_ID == custPhone.Cust_ID);
            var dataPhone = db.CustomerPhones.FirstOrDefault(x => x.Cust_Phone_ID == custPhone.Cust_Phone_ID);

            db.Entry(custPhone).State = EntityState.Modified;
            db.SaveChanges();

            var newDataPhone = db.CustomerPhones.Where(x => x.Cust_ID == custPhone.Cust_ID).ToList();

            return GetCustomerDetails(dataCust, newDataPhone);
        }

        public CustomerDetails DeletePhoneNumberOfCustomer(CustomerPhone custPhone)
        {
            var dataCust = db.Customers.FirstOrDefault(x => x.Cust_ID == custPhone.Cust_ID);

            db.CustomerPhones.Remove(custPhone);
            db.SaveChanges();

            var dataPhone = db.CustomerPhones.Where(x => x.Cust_ID == custPhone.Cust_ID).ToList();

            return GetCustomerDetails(dataCust, dataPhone);
        }

        private CustomerDetails GetCustomerDetails(Customer cust, List<CustomerPhone> custPhone)
        {
            CustomerDetails objCust = new CustomerDetails();
            if (cust != null)
            {
                objCust.Cust_ID = cust.Cust_ID;
                objCust.Cust_Name = cust.Cust_Name;
                objCust.Cust_Phone = custPhone;
            }
            return objCust;
        }
    }
}