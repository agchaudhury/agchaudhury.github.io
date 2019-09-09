using LoggerService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayRollCalculation
{
    public class PrintData : IPrintData
    {
        private readonly ILoggerManager loggerManager;
        public PrintData(ILoggerManager _loggerManager)
        {
            loggerManager = _loggerManager;
        }
        public void Printdata(List<PayrollOut> pFileList)
        {
            foreach (PayrollOut file in pFileList)
            {
                Console.WriteLine("{" + file.Name + "}" + "{" + file.PayPeriod + "}" + "{" + file.GrossIncome + "}" + "{" + file.IncomeTax + "}" + "{" + file.NetIncome + "}" + "{" + file.Super + "}");
                //loggerManager.LogInfo("median= " + median + ",20%AboveMedian =" + Median20Above + ",20%BelowMedian = " + Median20Below + ",EnergyValue=" + file.EnergyDataValue);
            }
        }
    }
}
