﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PayRollCalculation
{
    public class PayrollOut
    {
        public string Name { get; set; }
        public string PayPeriod { get; set; }
        public int GrossIncome { get; set; }
        public int IncomeTax { get; set; }
        public int NetIncome { get; set; }
        public int Super { get; set; }
    }
}