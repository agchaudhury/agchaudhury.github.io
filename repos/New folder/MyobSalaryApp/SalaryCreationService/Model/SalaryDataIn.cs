using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCreationService.Model
{
    public class SalaryDataIn
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal SuperRate { get; set; }
        public string PaymentStartDate { get; set; }
    }
}
