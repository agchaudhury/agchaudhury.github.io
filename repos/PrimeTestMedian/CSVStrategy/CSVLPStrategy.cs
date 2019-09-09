using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVStrategy
{
    public class CSVLPStrategy : ICSVStrategy
    {
        public List<CSVDataClass> ReadCSVFromFile(string path,string delimiter)
        {
            List<CSVDataClass> lpList = new List<CSVDataClass>();
            try
            {
                using (TextReader reader = File.OpenText(path))
                {
                    lpList = File.ReadAllLines(path).Skip(1).Select(d => LoadFromCsv(d,delimiter)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lpList;
        }

        public CSVDataClass LoadFromCsv(string value, string delimiter)
        {
            string[] values = value.Split(Convert.ToChar(delimiter));
            CSVDataClass lpFile = new CSVDataClass();
            lpFile.RecordDate = Convert.ToDateTime(values[3]);
            lpFile.EnergyDataValue = Convert.ToDouble(values[5]);
            return lpFile;
        }
    }
}
