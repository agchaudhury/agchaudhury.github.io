using System;
using System.Collections.Generic;
using System.Text;

namespace CSVStrategy
{
    public class CSVReader :ICSVReader
    {
        private ICSVStrategy _strategy;

        public List<CSVDataClass> CSVReaderMethod(ICSVStrategy strategy,string path,string delimeter)
        {
            _strategy = strategy;
            return _strategy.ReadCSVFromFile(path,delimeter);
        }
    }
}
