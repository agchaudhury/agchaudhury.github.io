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
            return View(customerList);
        }

        public ActionResult Detail(int? id)
        {
            var customer = _customerData.GetCustomerData(id.Value);
            return View(customer);
        }

        public ActionResult CreatePhone(int? id)
        {
            var customer = _customerData.GetCustomerData(id.Value);
            return View(customer);
        }

        [HttpPost]
        public ActionResult CreatePhone(CustomerPhone custPhone)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("CustomerPhone", custPhone).Result;

            return RedirectToAction("Index");
        }

        public ActionResult EditPhone(int? id, int? phoneId)
        {
            var customer = _customerData.GetCustomerData(id.Value);
            return View(customer.Cust_Phone.Where(d => d.Cust_Phone_ID == phoneId).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditPhone(int id, int phoneId, int? phoneNumber, string Status)
        {
            var customer = _customerData.GetCustomerData(id);
            customer = _customerData.EditPhoneData(id, phoneId, Status);
            return RedirectToAction("Detail", new { id = customer.Cust_ID });
        }

        public ActionResult DeletePhone(int? id, int phoneId)
        {
            var customer = _customerData.GetCustomerData(id.Value);
            return View(customer.Cust_Phone.Where(d => d.Cust_Phone_ID == phoneId).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult DeletePhone(int id, int phoneId)
        {
            var customer = _customerData.GetCustomerData(id);
            customer = _customerData.RemovePhoneData(id, phoneId);
            return RedirectToAction("Detail", new { id = customer.Cust_ID });
        }
    }
}