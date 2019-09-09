using System;
using System.Collections.Generic;
using System.Text;

namespace CSVOps.Contracts
{
    public interface IMatchFileExtensions
    {
        bool FileExtExists(string path, string ExtType);
    }
}
