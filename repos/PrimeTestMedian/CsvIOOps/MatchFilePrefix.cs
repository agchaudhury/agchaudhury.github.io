using CsvOps.Contracts;
using LoggerService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsvOps
{
    public class MatchFilePrefix : IMatchFilePrefix
    {
        private ILoggerManager _logger;
        public MatchFilePrefix(ILoggerManager logger)
        {
            _logger = logger;
        }
        public bool FilePrefixExists(string path, string prefix)
        {
            bool findAtLeastOne = false;
            try
            {
                var patterns = prefix.Split(',').ToList();
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (string pattern in patterns)
                {
                    findAtLeastOne = di.GetFiles(pattern).Length > 0;
                    if (findAtLeastOne) break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in FilePrefixExists " + ex.Message);
            }
            return findAtLeastOne;
        }

        public List<string> GetFilesWithPrefix(string path, string prefix)
        {
            List<string> allFiles = new List<string>();
            try
            {
                var patterns = prefix.Split(',').ToList();
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (string pattern in patterns)
                {
                    foreach (FileInfo fi in di.GetFiles(pattern))
                    {
                        allFiles.Add(fi.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in GetFilesWithPrefix " + ex.Message);
            }
            return allFiles;
        }
    }
}
