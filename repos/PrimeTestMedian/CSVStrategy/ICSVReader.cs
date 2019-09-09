using System;
using System.Collections.Generic;
using System.Text;

namespace CSVStrategy
{
    public interface ICSVReader
    {
        List<CSVDataClass> CSVReaderMethod(ICSVStrategy strategy, string path,string delimiter);
    }
}
