using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NintexCustomerUI.Models
{
    public class Customer
    {
        public int Cust_ID { get; set; }
        public string Cust_Name { get; set; }
        public List<CustomerPhone> Cust_Phone { get; set; }
        public string PhoneList
        {
            get
            {
                if (Cust_Phone != null)
                    return string.Join(", ", Cust_Phone.Select(i => i.Phone_Number));
                else
                    return string.Empty;
            }
        }
    }
}