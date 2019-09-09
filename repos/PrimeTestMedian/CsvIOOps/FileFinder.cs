using CsvOps.Contracts;
using LoggerService;
using System;
using System.IO;

namespace CsvOps
{
    public class FileFinder : IFileFinder
    {
        private ILoggerManager _logger;

        public FileFinder(ILoggerManager logger)
        {
            _logger = logger;
        }

        public bool FileExists(string path)
        {
            try
            {
                return new DirectoryInfo(path).GetFiles().Length > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in FileExists " + ex.Message);
                return false;
            }
        }
    }
}
