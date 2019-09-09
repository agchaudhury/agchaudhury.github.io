using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HRM.Web.Models.Helper
{
    public class Department : IDepartment
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public List<Department> GetDepartments()
        {
            var departmentList = GetDepartmentFromAPI();
            return departmentList;
        }

        private List<Department> GetDepartmentFromAPI()
        {
            try
            {
                var resultList = new List<Department>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("http://localhost:55388/api/department")
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Department>>();
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
