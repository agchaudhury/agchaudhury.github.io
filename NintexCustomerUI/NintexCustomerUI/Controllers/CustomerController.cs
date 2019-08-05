using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using NintexCustomerUI.Models;

namespace NintexCustomerUI.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerData _customerData = new CustomerData();

        public ActionResult Index()
        {
            var customerList = _customerData.GetAllCustomers();
            if (customerList == null)
                return View(new List<Customer>());
            return View(customerList);
        }

        public ActionResult Detail(int? id)
        {
            var customerPhone = _customerData.GetCustomerData(id.Value);
            if (customerPhone.Count() == 0)
            {
                var defaultData = new CustomerPhone();
                defaultData.Cust_ID = id.Value;
                defaultData.Phone_Number = String.Empty;
                customerPhone.Add(defaultData);

                return View(customerPhone);
            }
            return View(customerPhone);
        }

        public ActionResult CreatePhone(int? id)
        {
            var customerPhone = _customerData.GetCustomerData(id.Value);
            if (customerPhone.Count() == 0)
            {
                var defaultData = new CustomerPhone();
                defaultData.Cust_ID = id.Value;
                defaultData.Phone_Number = String.Empty;
                customerPhone.Add(defaultData);

                return View(defaultData);
            }
            return View(customerPhone.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult CreatePhone(CustomerPhone custPhone)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("CustomerPhone", custPhone).Result;
            return RedirectToAction("Index");
        }

        public ActionResult EditPhone(int? id, int? phoneId)
        {
            if(phoneId == 0)
                return RedirectToAction("Detail", new { id = id.Value });
            var customerPhone = _customerData.GetCustomerData(id.Value);
            return View(customerPhone.Where(d => d.Cust_Phone_ID == phoneId).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditPhone(CustomerPhone custPhone)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("CustomerPhone/" + custPhone.Cust_Phone_ID, custPhone).Result;
            return RedirectToAction("Detail", new { id = custPhone.Cust_ID });
        }
     
        public ActionResult DeletePhone(int? id, int? cust_id)
        {
            if (id == 0)
                return RedirectToAction("Detail", new { id = cust_id.Value });
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("CustomerPhone/" + id).Result;
            return RedirectToAction("Detail", new { id = cust_id });
        }
    }
}