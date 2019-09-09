using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReaderApplication
{
    public class CsvApplicationSelector
    {
        public ICsvStrategy _strategy;

        public CsvApplicationSelector(ICsvStrategy strategy)
        {
            _strategy = strategy;
        }

        public List<CsvData> GetCsv(string path)
        {
            return _strategy.ReadCsv(path);
        }
    }
}
