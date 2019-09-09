using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CSVOps.Contracts;
using CSVStrategy;
using LoggerService;
using Newtonsoft.Json;

namespace PayRollCalculation
{


    public class CalculatePay : ICalculatePay
    {
        private ICheckConfigSettings _checkConfigSettings;
        private ILoggerManager _loggerManager;

        public CalculatePay(ICheckConfigSettings checkConfigSettings, ILoggerManager loggerManager)
        {
            _checkConfigSettings = checkConfigSettings;
            _loggerManager = loggerManager;
        }

        public List<PayrollOut> CalcPay(List<CSVDataClass> list)
        {
            List<PayrollOut> newList = new List<PayrollOut>();
            try
            {
                int PayYear = int.Parse(_checkConfigSettings.strPayYear) == 0 ? DateTime.Now.Year : int.Parse(_checkConfigSettings.strPayYear);

                var TaxRatesList = GetTaxRates(PayYear);
                if (TaxRatesList.Count > 0)
                {
                    foreach (CSVDataClass csvData in list)
                    {
                        PayrollOut payroll = new PayrollOut();

                        payroll.Name = csvData.FirstName + " " + csvData.LastName;
                        payroll.PayPeriod = csvData.PaymentDate;
                        var gIncome = Math.Round(csvData.AnnualSalary / 12, 0);
                        payroll.GrossIncome = (int)gIncome;

                        // find tax rate slab
                        var TaxRateSlab = TaxRatesList.Where(d => d.TaxIncomeLow <= csvData.AnnualSalary && d.TaxIncomeHigh >= csvData.AnnualSalary).FirstOrDefault();
                        //slab is not defind then maximum tax
                        if (TaxRateSlab == null)
                        {
                            payroll.IncomeTax = 0;
                        }
                        else
                        {
                            var incomeTax = Math.Round((TaxRateSlab.TaxAmount + ((csvData.AnnualSalary - TaxRateSlab.TaxIncomeLow - 1) * (TaxRateSlab.TaxPercent / 100))) / 12, 0);
                            payroll.IncomeTax = (int)incomeTax;
                        }
                        payroll.NetIncome = payroll.GrossIncome - payroll.IncomeTax;
                        payroll.Super = (int)Math.Round(payroll.GrossIncome * csvData.SuperRate / 100, 0);
                        newList.Add(payroll);
                    }
                }
                else
                {
                    _loggerManager.LogInfo("Tax rates for Year " + PayYear + " not provided");
                }
            }
            catch (Exception ex)
            {
                _loggerManager.LogInfo("Error in CalcPay " + ex.Message);
            }

            return newList;
        }

        public List<TaxRates> GetTaxRates(int PayYear)
        {
            List<TaxRates> items = new List<TaxRates>(); ;
            using (StreamReader r = new StreamReader("Tax.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<TaxRates>>(json);
            }
            return items.Where(d => d.Year == PayYear).ToList();
        }
    }
}
