using System;

namespace CSVStrategy
{
    public class CSVDataClass
    {
        public string FileName { get; set; }
        public DateTime? RecordDate { get; set; }
        public double EnergyDataValue { get; set; }
        public double Median { get; set; }
    }
}
