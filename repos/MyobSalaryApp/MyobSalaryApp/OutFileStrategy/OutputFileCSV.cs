using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyobSalaryApp.OutFileStrategy
{
    public class OutputFileCSV : IOutputFile
    {
        public void WriteDataToFile(string path, List<SalaryDataOut> listData)
        {
            using (var w = new StreamWriter(path))
            {
                foreach (SalaryDataOut data in listData)
                {
                    var newLine = $"{data.Name},{data.PayPeriod},{data.GrossIncome},{data.IncomeTax},{data.NetIncome},{data.Super}";
                    w.WriteLine(newLine);
                    w.Flush();
                }
            }
        }
    }
}
