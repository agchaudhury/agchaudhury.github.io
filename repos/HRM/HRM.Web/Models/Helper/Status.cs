using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HRM.Web.Models.Helper
{
    public class Status : IStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }

        public List<Status> GetStatus()
        {
            var statusList = GetStatusFromAPI();
            return statusList;
        }

        private List<Status> GetStatusFromAPI()
        {
            try
            {
                var resultList = new List<Status>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("http://localhost:55388/api/status")
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Status>>();
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
