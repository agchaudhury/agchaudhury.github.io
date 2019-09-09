using CsvOps.Contracts;
using LoggerService;
using Microsoft.Extensions.Configuration;
using System;

namespace CsvOps
{
    public class CheckConfigSettings : ICheckConfigSettings
    {
        private IConfiguration config;
        private ILoggerManager _logger;
        public string strFilePath { get; set; }
        public string strFileExt { get; set; }
        public string strDelimiter { get; set; }
        public string strFilePreFix { get; set; }

        public CheckConfigSettings(ILoggerManager logger)
        {
            config = new ConfigurationBuilder().AddJsonFile("my-config.json").Build();
            _logger = logger;
            strFilePath = config["FilePath"];
            strFilePreFix = config["FilePreFix"];
            strFileExt = config["FileExt"];
            strDelimiter = config["Delimiter"];
        }

        public bool CheckConfigSetting()
        {
            bool valid = true;
            try
            {
                if (string.IsNullOrEmpty(strFilePath))
                {
                    _logger.LogError($"File path is not provided in Config file");
                    valid = false;
                }
                if (string.IsNullOrEmpty(strFileExt))
                {
                    _logger.LogError($"File ext is not provided in Config file");
                    valid = false;
                }

                if (string.IsNullOrEmpty(strFilePreFix))
                {
                    _logger.LogError($"File prefix is not provided in Config file");
                    valid = false;
                }
                if (string.IsNullOrEmpty(strDelimiter))
                {
                    _logger.LogError($"Delimiter  is not provided in Config file");
                    valid = false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in CheckConfigSetting " + ex.Message);
                valid = false;
            }
            return valid;
        }
    }

}
