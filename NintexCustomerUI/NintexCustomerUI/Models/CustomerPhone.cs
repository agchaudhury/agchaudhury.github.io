using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NintexCustomerUI.Models
{
    public class CustomerPhone
    {
        public int Cust_Phone_ID { get; set; }
        public int Cust_ID { get; set; }
        public string Phone_Number { get; set; }
        public bool Active { get; set; }
    }
}