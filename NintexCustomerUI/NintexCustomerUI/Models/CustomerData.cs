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

        public List<CustomerPhone> GetCustomerData(int customerId)
        {
            try
            {
                var resulData = new List<CustomerPhone>();
                var client = new HttpClient(); 
                var getDataTask = client.GetAsync("https://custphoneapi.azurewebsites.net/api/customerphone/" + customerId)
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<CustomerPhone>>();
                            readResult.Wait();
                            resulData = readResult.Result;
                        }
                    });
                getDataTask.Wait();
                return resulData.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}