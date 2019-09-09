using CsvOps.Contracts;
using LoggerService;
using System;
using System.IO;

namespace CsvOps
{
    public class PathFinder : IPathFinder
    {
        private ILoggerManager _logger;

        public PathFinder(ILoggerManager logger)
        {
            _logger = logger;
        }
        public bool PathExists(string path)
        {
            try
            {
                return Directory.Exists(path);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in PathExists " + ex.Message);
                return false;
            }
           
        }
    }
}
