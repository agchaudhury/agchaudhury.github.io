using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCreationService.Model.InFileStrategy
{
    public class InputFileCSV : IInputFile
    {
        public List<SalaryDataIn> ReadDataFromFile(string path)
        {
            List<SalaryDataIn> list = new List<SalaryDataIn>();
            
            using (var reader = new StreamReader(path + "\\Files\\CSVInput\\Input.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var obj = new SalaryDataIn();
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    obj.FirstName = values[0];
                    obj.LastName = values[1];
                    obj.AnnualSalary = int.Parse(values[2]);
                    obj.SuperRate = values[3].IndexOf('%') >= 0 ? int.Parse(values[3].Replace("%", "")) : int.Parse(values[3]);
                    obj.PaymentStartDate = values[4];

                    list.Add(obj);
                }
            }
            return list;
        }
    }
}
