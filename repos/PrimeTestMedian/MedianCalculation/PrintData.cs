using System;
using System.Collections.Generic;
using CSVStrategy;

namespace MedianCalculation
{
    public class PrintData : IPrintData
    {
        public void Printdata(List<CSVDataClass> lpFileList, double Median20Below, double Median20Above, string fileName, double median)
        {
            foreach (CSVDataClass file in lpFileList)
            {
                if (file.EnergyDataValue == Median20Below || file.EnergyDataValue == Median20Above)
                {
                    Console.WriteLine("{" + fileName + "}" + "{" + file.RecordDate + "}" + "{" + file.EnergyDataValue + "}" + "{" + median + "}");
                }
            }
        }
    }
}
