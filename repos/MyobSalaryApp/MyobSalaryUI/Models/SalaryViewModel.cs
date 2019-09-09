using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyobSalaryUI.Models
{
    public class SalaryViewModel
    {
        public string Name { get; set; }
        public string PayPeriod { get; set; }
        public int GrossIncome { get; set; }
        public int IncomeTax { get; set; }
        public int NetIncome { get; set; }
        public int Super { get; set; }
    }
}