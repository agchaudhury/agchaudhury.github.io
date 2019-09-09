using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using MathNet.Numerics.Statistics;

namespace CSVReaderApplication
{
    class CsvTOUStrategy : ICsvStrategy
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<CsvData> ReadCsv(string path)
        {
            var TOUData = File.ReadAllLines(path);

            var TOUList = from csvData in TOUData
                          let data = csvData.Split(',')
                          select new CsvData
                          {
                              dateTime = Convert.ToDateTime(data[3]),
                              value = Convert.ToDouble(data[5])
                          };

            //double median = TOUList(x => x.

            //var mData = from medianData in TOUList
            //            select 

            //foreach (var csvData in TOUList)
            //{
            //    csvData.
            //}

            return TOUList.ToList();
        } 
    }
}
