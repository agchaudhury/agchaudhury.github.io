using System;
using System.Collections.Generic;
using System.IO;
using CSVOps;
using CSVOps.Contracts;
using CSVStrategy;
using LoggerService;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using PayRollCalculation;

namespace MYOBRun
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
                var services = new ServiceCollection();
                services.AddSingleton<ILoggerManager, LoggerManager>();
                services.AddTransient<IFileFinder, FileFinder>();
                services.AddTransient<IMatchFileExtensions, MatchFileExtension>();
                services.AddTransient<ICheckConfigSettings, CheckConfigSettings>();
                services.AddTransient<ICSVReader, CSVReader>();
                services.AddTransient<FileOpCheck>();
                services.AddTransient<CalculatePay>();
                services.AddTransient<PrintData>();
                services.AddTransient<CSVReader>();


                var provider = services.BuildServiceProvider();
                var _fileOpCheck = provider.GetService<FileOpCheck>();
                var _calcPay = provider.GetService<CalculatePay>();
                var _printData = provider.GetService<PrintData>();
                string path = System.IO.Directory.GetCurrentDirectory();

                if (_fileOpCheck.CheckFileStatus(path))
                {
                    
                    //Get all the files from the folder
                    List<string> fileList = _fileOpCheck.FilterAndReadFiles(path);
                    
                    //Read the data and perform the median logic
                    foreach (string fileName in fileList)
                    {
                        var aList = _fileOpCheck.ReadDataFromCsv(fileName, path + "/" + fileName);
                        var outList = _calcPay.CalcPay(aList);
                        _printData.Printdata(outList);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("check for log files for more about the errors " + ex.Message);
            }
           
            Console.ReadKey();
        }
    }
}
