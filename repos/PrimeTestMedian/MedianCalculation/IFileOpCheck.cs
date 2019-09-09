using CSVStrategy;
using System.Collections.Generic;

namespace MedianCalculation
{
    public interface IFileOpCheck
    {
        bool CheckFileStatus(string path);
        List<string> FilterAndReadFiles();
        List<CSVDataClass> ReadDataFromCsv(string fileName, string path);
    }
}
