using System;
using System.Collections.Generic;
using System.Text;

namespace CSVStrategy
{
    public interface ICSVStrategy
    {
        List<CSVDataClass> ReadCSVFromFile(string path, string delimiter);
    }
}
