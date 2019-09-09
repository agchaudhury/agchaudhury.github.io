using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static HRM.Web.Models.Helper.Common;

namespace HRM.Web.Models.Helper
{
    public class Employee : IEmployee
    {
        public int? EID { get; set; }
        public string  FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        public int StatusID { get; set; }
        public int DepartmentID { get; set; }
        public List<Employee> GetEmployees()
        {
            var resourceList = GetResourceFromAPI();
            return resourceList;
        }

        private List<Employee> GetResourceFromAPI()
        {
            try
            {
                var resultList = new List<Employee>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("http://localhost:55388/api/employee")
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if(result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Employee>>();
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
    }
}
