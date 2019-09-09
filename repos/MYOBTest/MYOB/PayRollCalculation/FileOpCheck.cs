using CSVOps.Contracts;
using CSVStrategy;
using LoggerService;
using System;
using System.Collections.Generic;

namespace PayRollCalculation
{
    public class FileOpCheck : IFileOpCheck
    {
        private ILoggerManager _logger;
        private IFileFinder _fileFinder;
        private IMatchFileExtensions _extMatcher;
        private ICheckConfigSettings _checkConfigSettings;
        private ICSVReader _cSVReader;

        public FileOpCheck(ILoggerManager logger, IFileFinder fileFinder, 
            IMatchFileExtensions extMatcher, ICheckConfigSettings checkConfigSettings,
            ICSVReader cSVReader)
        {
            _logger = logger;
            _fileFinder = fileFinder;
            _extMatcher = extMatcher;
            _checkConfigSettings = checkConfigSettings;
            _cSVReader = cSVReader;
        }

        public bool CheckFileStatus(string path)
        {
            bool success = false;
            try
            {
                success = _checkConfigSettings.CheckConfigSetting();
                if (success)
                {
                        success = _fileFinder.FileExists(path);

                        if (success)
                        {
                            _logger.LogInfo($"File exists");
                            success = _extMatcher.FileExtExists(path, _checkConfigSettings.strFileExt);

                            if (success)
                            {
                                _logger.LogInfo($"Desired ext file exists");
                            }
                            else
                            {
                                _logger.LogError($"No file with desired prefix exists");
                                return false;
                            }
                        }
                        else
                        {
                            _logger.LogError($"No file exists");
                            return false;
                        }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in CheckFileStatus: {ex.Message}");
                throw ex;
            }
            return success;
        }

        public List<string> FilterAndReadFiles(string path)
        {
            try
            {
                return _fileFinder.GetAllFiles(path,_checkConfigSettings.strFileExt);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in FilterReadFiles " + ex.Message);
                throw ex;
            }

        }

        public List<CSVDataClass> ReadDataFromCsv(string fileName, string path)
        {
            try
            {
               return _cSVReader.CSVReaderMethod(new CSVStrategyOne(), path, _checkConfigSettings.strDelimiter);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in FilterReadFiles " + ex.Message);
                throw ex;
            }

        }
    }
}
