using System.Collections.Generic;

namespace CsvOps.Contracts
{
    public interface IMatchFilePrefix
    {
        bool FilePrefixExists(string path,string prefix);
        List<string> GetFilesWithPrefix(string path, string prefix);
    }
}
