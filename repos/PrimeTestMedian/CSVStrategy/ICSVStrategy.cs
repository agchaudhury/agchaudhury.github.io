using System.Collections.Generic;

namespace CSVStrategy
{
    public interface ICSVStrategy
    {
        List<CSVDataClass> ReadCSVFromFile(string path,string delimiter);
    }
}