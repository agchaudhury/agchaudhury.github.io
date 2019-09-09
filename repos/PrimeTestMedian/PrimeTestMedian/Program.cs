using LoggerService;
using MedianCalculation;
using NLog;
using System;
using System.IO;
using CsvOps.Contracts;
using CsvOps;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using CSVStrategy;

namespace PrimeTestMedian
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
                services.AddTransient<IMatchFilePrefix, MatchFilePrefix>();
                services.AddTransient<IPathFinder, PathFinder>();
                services.AddTransient<ICheckConfigSettings, CheckConfigSettings>();
                services.AddTransient<ICSVReader, CSVReader>();
                services.AddTransient<FileOpCheck>();
                services.AddTransient<CalculateMedian>();
                services.AddTransient<PrintData>();
                services.AddTransient<CSVReader>();

                var provider = services.BuildServiceProvider();
                var _fileOpCheck = provider.GetService<FileOpCheck>();
                var _calcMedian = provider.GetService<CalculateMedian>();
                var _printData = provider.GetService<PrintData>();
                
                string path = Console.ReadLine();

                if (_fileOpCheck.CheckFileStatus(path))
                {
                    //Get all the files from the folder
                    List<string> fileList = _fileOpCheck.FilterAndReadFiles();
                    //Read the data and perform the median logic
                    foreach (string fileName in fileList)
                    {
                        var aList = _fileOpCheck.ReadDataFromCsv(fileName, path + "/" + fileName);
                        var dataList = aList.Select(d => d.EnergyDataValue).ToList();
                        double above20 = 0;
                        double below20 = 0;
                        var median = _calcMedian.GetMedianValueWith20AboveAndBelow(ref above20, ref below20, dataList);
                        _printData.Printdata(aList, below20, above20, fileName, median);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("check for log files for more about the errors " + ex.Message);
            }
            Console.WriteLine("check log files for more about the errors if No result shown at c:\\log ");
            Console.ReadKey();
        }
    }
}
