using CSVStrategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayRollCalculation
{
    public interface ICalculatePay
    {
        List<PayrollOut> CalcPay(List<CSVDataClass> list);
    }
}
