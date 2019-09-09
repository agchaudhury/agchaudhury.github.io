using System;
using System.Collections.Generic;
using System.Text;

namespace CSVOps.Contracts
{
    public interface IFileFinder
    {
        bool FileExists(string path);
        List<string> GetAllFiles(string path,string ext);
        
    }
}
