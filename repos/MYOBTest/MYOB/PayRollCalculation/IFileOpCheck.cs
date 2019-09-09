using CSVStrategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayRollCalculation
{
    public interface IFileOpCheck
    {
        bool CheckFileStatus(string path);
        List<string> FilterAndReadFiles(string path);
        List<CSVDataClass> ReadDataFromCsv(string fileName, string path);
    }
}
