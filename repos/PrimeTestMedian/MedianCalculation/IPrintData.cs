using System.Collections.Generic;
using CSVStrategy;

namespace MedianCalculation
{
    public interface IPrintData
    {
        void Printdata(List<CSVDataClass> lpFileList, double Median20Below, double Median20Above, string fileName, double median);
    }
}
