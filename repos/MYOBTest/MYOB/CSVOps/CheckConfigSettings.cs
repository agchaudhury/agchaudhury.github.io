using CSVOps.Contracts;
using LoggerService;
using Microsoft.Extensions.Configuration;
using System;

namespace CSVOps
{
    public class CheckConfigSettings : ICheckConfigSettings
    {
        private ILoggerManager _logger;
        private IConfiguration config;
        public string strFileExt { get; set; }
        public string strDelimiter { get; set; }
        public string strPayYear { get; set; }

        public CheckConfigSettings(ILoggerManager logger)
        {
            _logger = logger;
            config = new ConfigurationBuilder().AddJsonFile("myconfig.json").Build();
            strFileExt = config["FileExt"];
            strDelimiter = config["Delimiter"];
            strPayYear = config["PayYear"];
        }

        public bool CheckConfigSetting()
        {
            bool valid = true;
            try
            {
                if (string.IsNullOrEmpty(strFileExt))
                {
                    _logger.LogError($"File ext is not provided in Config file");
                    valid = false;
                }
                if (string.IsNullOrEmpty(strDelimiter))
                {
                    _logger.LogError($"Delimiter  is not provided in Config file");
                    valid = false;
                }
                if (string.IsNullOrEmpty(strPayYear))
                {
                    _logger.LogError($" PayYear is not provided in Config file");
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
