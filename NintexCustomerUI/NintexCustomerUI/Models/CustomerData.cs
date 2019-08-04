using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Formatting;

namespace NintexCustomerUI.Models
{
    public class CustomerData : ICustomerData
    {
        public List<Customer> GetAllCustomers()
        {
            try
            {
                var resultList = new List<Customer>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("https://custphoneapi.azurewebsites.net/api/customerphone")
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Customer>>();
                            readResult.Wait();
                            resultList = readResult.Result;
                        }
                    });
                getDataTask.Wait();
                return resultList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer GetCustomerData(int customerId)
        {
            try
            {
                var resulData = new Customer();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("https://custphoneapi.azurewebsites.net/api/customerphone/" + customerId)
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<Customer>();
                            readResult.Wait();
                            resulData = readResult.Result;
                        }
                    });
                getDataTask.Wait();
                return resulData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Customer> RemoveCustomerData(int customerId)
        {
            var CustomerList = AddDummyData();
            Customer remCustomer = CustomerList.Where(d => d.Cust_ID == customerId).FirstOrDefault();
            CustomerList.Remove(remCustomer);
            return CustomerList;
        }
        public Customer RemovePhoneData(int customerId, int Cust_Phone_ID)
        {
            var CustomerList = AddDummyData();
            Customer remCustomer = CustomerList.Where(d => d.Cust_ID == customerId).FirstOrDefault();
            CustomerPhone custPhone = remCustomer.Cust_Phone.Where(d => d.Cust_Phone_ID == Cust_Phone_ID).FirstOrDefault();
            remCustomer.Cust_Phone.Remove(custPhone);
            return remCustomer;
        }

        public Customer EditPhoneData(int customerId, int Cust_Phone_ID, string Active)
        {
            var CustomerList = AddDummyData();
            Customer remCustomer = CustomerList.Where(d => d.Cust_ID == customerId).FirstOrDefault();
            CustomerPhone custPhone = remCustomer.Cust_Phone.Where(d => d.Cust_Phone_ID == Cust_Phone_ID).FirstOrDefault();
            remCustomer.Cust_Phone.Remove(custPhone);
            custPhone.Active = true;
            remCustomer.Cust_Phone.Add(custPhone);
            return remCustomer;
        }

        //public Customer AddPhoneData(CustomerPhone custPhone)
        //{
        //    var CustomerList = AddDummyData();
        //    Customer remCustomer = CustomerList.Where(d => d.Cust_ID == customerId).FirstOrDefault();
        //    CustomerPhone custPhone = remCustomer.Cust_Phone.Where(d => d.Cust_Phone_ID == Cust_Phone_ID).FirstOrDefault();
        //    remCustomer.Cust_Phone.Remove(custPhone);
        //    custPhone.Active = Active;
        //    remCustomer.Cust_Phone.Add(custPhone);
        //    return remCustomer;
        //}

        public List<Customer> AddDummyData()
        {
            var customerList = new List<Customer>();
            var Cust_Phone = new List<CustomerPhone>();
            Cust_Phone.Add(
                new CustomerPhone
                {
                    Cust_Phone_ID = 1,
                    Phone_Number = "12345",
                    Active = true,
                    Cust_ID = 1
                });
            Cust_Phone.Add(new CustomerPhone
            {
                Cust_Phone_ID = 2,
                Phone_Number = "12345",
                Active = true,
                Cust_ID = 1
            });
            Cust_Phone.Add(new CustomerPhone
            {
                Cust_Phone_ID = 3,
                Phone_Number = "12345",
                Active = false,
                Cust_ID = 1
            });
            customerList.Add(
                new Customer
                {
                    Cust_ID = 1,
                    Cust_Name = "Arup",
                    Cust_Phone = Cust_Phone
                }
            );

            Cust_Phone = new List<CustomerPhone>();
            Cust_Phone.Add(
                new CustomerPhone
                {
                    Cust_Phone_ID = 4,
                    Phone_Number = "12345",
                    Active = true,
                    Cust_ID = 2
                });
            Cust_Phone.Add(new CustomerPhone
            {
                Cust_Phone_ID = 5,
                Phone_Number = "12345",
                Active = true,
                Cust_ID = 2
            });
            Cust_Phone.Add(new CustomerPhone
            {
                Cust_Phone_ID = 6,
                Phone_Number = "12345",
                Active = false,
                Cust_ID = 2
            });
            customerList.Add(
                new Customer
                {
                    Cust_ID = 2,
                    Cust_Name = "Arup",
                    Cust_Phone = Cust_Phone
                }
            );

            Cust_Phone = new List<CustomerPhone>();
            Cust_Phone.Add(
                new CustomerPhone
                {
                    Cust_Phone_ID = 7,
                    Phone_Number = "12345",
                    Active = true,
                    Cust_ID = 3
                });
            Cust_Phone.Add(new CustomerPhone
            {
                Cust_Phone_ID = 8,
                Phone_Number = "12345",
                Active = true,
                Cust_ID = 3
            });
            Cust_Phone.Add(new CustomerPhone
            {
                Cust_Phone_ID = 8,
                Phone_Number = "12345",
                Active = false,
                Cust_ID = 3
            });
            customerList.Add(
                new Customer
                {
                    Cust_ID = 3,
                    Cust_Name = "Arup",
                    Cust_Phone = Cust_Phone
                }
            );

            return customerList;
        }
    }
}