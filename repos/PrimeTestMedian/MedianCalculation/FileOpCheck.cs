using CsvOps;
using CsvOps.Contracts;
using CSVStrategy;
using LoggerService;
using MedianCalculation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeTestMedian
{

    public class FileOpCheck : IFileOpCheck
    {
        private ILoggerManager _logger;
        private IFileFinder _fileFinder;
        private IPathFinder _pathFinder;
        private IMatchFileExtensions _extMatcher;
        private ICheckConfigSettings _checkConfigSettings;
        private IMatchFilePrefix _prefixMatcher;
        private ICSVReader _cSVReader;

        public FileOpCheck(ILoggerManager logger ,IFileFinder fileFinder, IPathFinder pathFinder,
            IMatchFileExtensions extMatcher, ICheckConfigSettings checkConfigSettings,
            IMatchFilePrefix prefixMatcher, ICSVReader cSVReader)
        {
            _logger = logger;
            _fileFinder = fileFinder;
            _pathFinder = pathFinder;
            _extMatcher = extMatcher;
            _checkConfigSettings = checkConfigSettings;
            _prefixMatcher = prefixMatcher;
            _cSVReader = cSVReader;
        }

        public bool CheckFileStatus(string path)
        {
            bool success = false;
            try
            {
                success = _checkConfigSettings.CheckConfigSetting();
                if(success)
                {
                    success = _pathFinder.PathExists(path);
                    //if(!success)
                    //success = _pathFinder.PathExists(_checkConfigSettings.strFilePath);

                    if (success)
                    {
                        _logger.LogInfo($"Path exists");
                        success = _fileFinder.FileExists(_checkConfigSettings.strFilePath);

                        if (success)
                        {
                            _logger.LogInfo($"File exists");
                            success = _extMatcher.FileExtExists(_checkConfigSettings.strFilePath, _checkConfigSettings.strFileExt);

                            if (success)
                            {
                                _logger.LogInfo($"Desired ext file exists");
                                success = _prefixMatcher.FilePrefixExists(_checkConfigSettings.strFilePath, _checkConfigSettings.strFilePreFix);
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
                    else
                    {
                        _logger.LogError($"Path doesn't exists");
                        throw new Exception("Path = " + path + " doesn't exists");
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

        public List<string> FilterAndReadFiles()
        {
            try
            {
                return _prefixMatcher.GetFilesWithPrefix(_checkConfigSettings.strFilePath, _checkConfigSettings.strFilePreFix);
            }
            catch(Exception ex)
            {
                _logger.LogError($"error in FilterReadFiles " + ex.Message);
                throw ex;
            }
           
        }

        public List<CSVDataClass> ReadDataFromCsv(string fileName,string path)
        {
            try
            {
                if (fileName.IndexOf("LP_") == 0)
                {
                    return _cSVReader.CSVReaderMethod(new CSVLPStrategy(), path, _checkConfigSettings.strDelimiter);
                }
                else if (fileName.IndexOf("TOU_") == 0)
                {
                    return _cSVReader.CSVReaderMethod(new CSVTOUStrategy(), path, _checkConfigSettings.strDelimiter);
                }
                else
                {
                    return new List<CSVDataClass>();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"error in FilterReadFiles " + ex.Message);
                throw ex;
            }
            
        }
    }
}
