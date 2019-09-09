using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCreationService.Model
{
    public class TaxRates
    {
        public int Year { get; set; }
        public int TaxIncomeLow { get; set; }
        public int TaxIncomeHigh { get; set; }
        public int TaxAmount { get; set; }
        public decimal TaxPercent { get; set; }
    }
}
