using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCreationService.Model.SalaryCal
{
    public class SalaryCalculation
    {
        public List<SalaryDataOut> SalCal(List<SalaryDataIn> list, string path)
        {
            List<SalaryDataOut> newList = new List<SalaryDataOut>();
            try
            {
                var readConfig = new ReadConfig();
                var payYear = readConfig.GetDataFromConfig(path);
                int PayYear = payYear == 0 ? DateTime.Now.Year : payYear;
                var taxDetails = new TaxDetails();
                var TaxRatesList = taxDetails.GetTaxRates(PayYear, path);
                if (TaxRatesList.Count > 0)
                {
                    foreach (SalaryDataIn csvData in list)
                    {
                        SalaryDataOut payroll = new SalaryDataOut();

                        payroll.Name = csvData.FirstName + " " + csvData.LastName;
                        payroll.PayPeriod = csvData.PaymentStartDate;
                        payroll.GrossIncome = CalculateGrossPay(csvData.AnnualSalary);

                        var TaxRateSlab = TaxRatesList.Where(d => d.TaxIncomeLow <= csvData.AnnualSalary && d.TaxIncomeHigh >= csvData.AnnualSalary).FirstOrDefault();

                        if (TaxRateSlab == null)
                        {
                            payroll.IncomeTax = 0;
                        }
                        else
                        {
                            payroll.IncomeTax = CalculateIncomeTax(csvData.AnnualSalary, TaxRateSlab.TaxPercent, TaxRateSlab.TaxAmount, TaxRateSlab.TaxIncomeLow);
                        }
                        payroll.NetIncome = payroll.GrossIncome - payroll.IncomeTax;
                        payroll.Super = CalculateSuper(payroll.GrossIncome, csvData.SuperRate);
                        newList.Add(payroll);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newList;
        }

        public int CalculateGrossPay(decimal annualSalary)
        {
            if (annualSalary == 0) return 0;
            else if (annualSalary < 0)
                throw new Exception("invalid negative value");

            return (int)Math.Round(annualSalary / 12, 0);
        }

        public int CalculateIncomeTax(decimal annualSalary, decimal taxPercentage, int taxAmount, int taxIncomeLow)
        {
            if (taxAmount < 0 || annualSalary < 0 || taxIncomeLow < 0 || taxPercentage < 0)
                throw new Exception("invalid negative value");
            return (int)Math.Round((taxAmount + ((annualSalary - (taxIncomeLow == 0 ? 0 : taxIncomeLow - 1)) * (taxPercentage / 100))) / 12, 0);
        }

        public int CalculateSuper(int grossPay, decimal superRate)
        {
            if (grossPay < 0 || superRate < 0 || superRate > 50)
                throw new Exception("invalid value");
            return (int)Math.Round(grossPay * superRate / 100, 0);
        }
    }
}
