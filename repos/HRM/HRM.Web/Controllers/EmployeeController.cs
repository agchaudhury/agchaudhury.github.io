using HRM.Web.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace HRM.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IDepartment _department;
        private IEmployee _employee;
        private ICommon _common;
        private IStatus _status;

        public EmployeeController(IDepartment department, IEmployee employee, ICommon common, IStatus status)
        {
            _department = department;
            _employee = employee;
            _common = common;
            _status = status;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeList()
        {
            var employeeList = _employee.GetEmployees();
            ViewBag.StatusList = _status.GetStatus();
            ViewBag.DepartmentList = _department.GetDepartments();
            return View(employeeList);
        }

        public ActionResult Create()
        {
            ViewBag.StatusList = _status.GetStatus();
            ViewBag.DepartmentList = _department.GetDepartments();
            return View(_employee);
        }

        [HttpPost]
        public ActionResult Add(int? eID, string firstName, string lastName, DateTime? dOB, string email, int status, int departmentCode, int editFlag = 0)
        {
            Employee resource = null;
            try
            {
                // TODO: Add insert logic here
                if (eID == null)
                {
                    //insert or check if the RID exists in DB 
                }
                else
                    //Update

                    resource = new Employee
                    {
                        EID = eID,
                        FirstName = firstName,
                        Surname = lastName,
                        DateOfBirth = dOB,
                        Email = email,
                        StatusID = status,
                        DepartmentID = departmentCode
                    };
                HttpClient hClient = new HttpClient();
                hClient.BaseAddress = new Uri("http://localhost:55388/api/");
                hClient.DefaultRequestHeaders.Clear();
                hClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                if (editFlag == 0)
                    response = hClient.PostAsJsonAsync("Employee", resource).Result;
                else
                    response = hClient.PutAsJsonAsync("Employee/" + resource.EID, resource).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    throw new HttpException((int)response.StatusCode, responseBody);
                }
                return RedirectToAction("EmployeeList");
            }
            catch
            {
                return RedirectToAction("EmployeeList");
            }
        }

        public ActionResult Edit(int resourceId)
        {
            ViewBag.StatusList = _status.GetStatus();
            ViewBag.DepartmentList = _department.GetDepartments();
            return View("Create", _employee.GetEmployees().Where(d => d.EID == resourceId).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient hClient = new HttpClient();
                hClient.BaseAddress = new Uri("http://localhost:55388/api/");
                hClient.DefaultRequestHeaders.Clear();
                hClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = hClient.DeleteAsync("Employee/" + id).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    throw new HttpException((int)response.StatusCode, responseBody);
                }
                return RedirectToAction("EmployeeList");
            }
            catch
            {
                return RedirectToAction("EmployeeList");
            }
        }
    }
}