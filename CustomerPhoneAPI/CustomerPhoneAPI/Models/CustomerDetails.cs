using CustomerDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPhoneAPI.Models
{
    public class CustomerDetails
    {
        public int Cust_ID { get; set; }
        public string Cust_Name { get; set; }
        public List<CustomerPhone> Cust_Phone { get; set; }
    }
}