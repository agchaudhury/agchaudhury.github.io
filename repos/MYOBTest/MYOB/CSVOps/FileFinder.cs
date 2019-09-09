using CSVOps.Contracts;
using LoggerService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVOps
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

        public List<string> GetAllFiles(string path,string ext)
        {
            List<string> allFiles = new List<string>();
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo fi in di.GetFiles(ext))
                {
                    allFiles.Add(fi.Name);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in GetAllFiles " + ex.Message);
            }
            return allFiles;
        }
    }
}
