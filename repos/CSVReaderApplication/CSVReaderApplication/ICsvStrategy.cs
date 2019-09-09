using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReaderApplication
{
    public interface ICsvStrategy : IDisposable
    {
        List<CsvData> ReadCsv(string path);
    }
}
