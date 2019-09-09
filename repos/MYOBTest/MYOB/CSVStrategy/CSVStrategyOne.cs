using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVStrategy
{
    public class CSVStrategyOne : ICSVStrategy
    {
        public List<CSVDataClass> ReadCSVFromFile(string path, string delimiter)
        {
            List<CSVDataClass> pList = new List<CSVDataClass>();
            try
            {
                using (TextReader reader = File.OpenText(path))
                {
                    pList = File.ReadAllLines(path).Skip(1).Select(d => LoadFromCsv(d, delimiter)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pList;
        }

        public CSVDataClass LoadFromCsv(string value, string delimiter)
        {
            string[] values = value.Split(Convert.ToChar(delimiter));
            CSVDataClass pFile = new CSVDataClass();
            pFile.FirstName = values[0];
            pFile.LastName =  values[1];
            pFile.AnnualSalary = int.Parse(values[2]);
            pFile.SuperRate = values[3].IndexOf('%') >= 0 ? int.Parse(values[3].Replace("%","")) : int.Parse(values[3]);
            pFile.PaymentDate = values[4];
            return pFile;
        }
    }
}
