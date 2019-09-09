using CsvOps.Contracts;
using LoggerService;
using System;
using System.IO;

namespace CsvOps
{
    public class MatchFileExtension : IMatchFileExtensions
    {
        private ILoggerManager _logger;

        public MatchFileExtension(ILoggerManager logger)
        {
            _logger = logger;
        }
        public bool FileExtExists(string path, string ExtType)
        {
            try
            {
                return new DirectoryInfo(path).GetFiles(ExtType).Length > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in FilePrefixExists " + ex.Message);
                return false;
            }
        }
    }
}
