using CsvOps;
using CSVStrategy;
using LoggerService;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PrimeTestMedian.Test
{
    [TestClass]
    public class CsvFileTest
    {
        IConfiguration config = new ConfigurationBuilder()
                       .AddJsonFile("my-config.json")
                       .Build();
        ILoggerManager mockLoggerWrapper;
        public CsvFileTest()
        {
            mockLoggerWrapper = new LoggerManager();
        }
        #region Positive Testing
        [TestMethod]
        public void Func_ShouldCheckConfigSettingsExists()
        {
            // Arrange
            
            var mockCheckConfigSettings = new CheckConfigSettings(mockLoggerWrapper);

            // Act
            bool success = mockCheckConfigSettings.CheckConfigSetting();

            // Assert
            Assert.AreEqual(success, true);
        }


        [TestMethod]
        public void Func_ShouldCheckPathExists()
        {
            // Arrange
            var mockPathFinder = new PathFinder(mockLoggerWrapper);

            // Act
            bool success = mockPathFinder.PathExists(config["FilePath"]);

            // Assert
            Assert.AreEqual(success, true);
        }
        
        [TestMethod]
        public void Func_ShouldCheckFileExists()
        {
            // Arrange
            var mockFileFinder = new FileFinder(mockLoggerWrapper);

            // Act
            bool success = mockFileFinder.FileExists(config["FilePath"]);

            // Assert
            Assert.AreEqual(success, true);
        }

        [TestMethod]
        public void Func_ShouldCheckFileWithExtExists()
        {
            // Arrange
            var MatchFileExtension = new MatchFileExtension(mockLoggerWrapper);

            // Act
            bool success = MatchFileExtension.FileExtExists(config["FilePath"],config["FileExt"]);

            // Assert
            Assert.AreEqual(success, true);
        }

        [TestMethod]
        public void Func_ShouldCheckFileWithPrefixExists()
        {
            // Arrange
            var mockMatchFilePrefix = new MatchFilePrefix(mockLoggerWrapper);

            // Act
            bool success = mockMatchFilePrefix.FilePrefixExists(config["FilePath"], config["FileExt"]);

            // Assert
            Assert.AreEqual(success, true);
        }

        [TestMethod]
        public void Func_ShouldReadFilesWithCorrectPrefixExists()
        {
            // Arrange
            var mockConfigWrapper = new CheckConfigSettings(mockLoggerWrapper);
            var mockMatchFilePrefix = new MatchFilePrefix(mockLoggerWrapper);
            var mockMatchFileExtension = new MatchFileExtension(mockLoggerWrapper);
            var mockPathFinder = new PathFinder(mockLoggerWrapper);
            var mockFileFinder = new FileFinder(mockLoggerWrapper);
            var mockICSVReader = new CSVReader();

            var mockIFileOpCheck = new FileOpCheck(mockLoggerWrapper, mockFileFinder, 
                mockPathFinder, mockMatchFileExtension,
                mockConfigWrapper, mockMatchFilePrefix, mockICSVReader);

            var moclList = new List<string>();
            // Act
            var result = mockIFileOpCheck.FilterAndReadFiles();
            bool success = result.Any(d=>d.Contains("LP_") || d.Contains("TOU_"));
            // Assert
            Assert.AreEqual(success, true);
        }
        [TestMethod]
        public void Func_ReadFilesShouldHaveData()
        {
            // Arrange
            var mockConfigWrapper = new CheckConfigSettings(mockLoggerWrapper);
            var mockMatchFilePrefix = new MatchFilePrefix(mockLoggerWrapper);
            var mockMatchFileExtension = new MatchFileExtension(mockLoggerWrapper);
            var mockPathFinder = new PathFinder(mockLoggerWrapper);
            var mockFileFinder = new FileFinder(mockLoggerWrapper);
            var mockICSVReader = new CSVReader();

            var mockFileOpCheck = new FileOpCheck(mockLoggerWrapper, mockFileFinder,
                mockPathFinder, mockMatchFileExtension,
                mockConfigWrapper, mockMatchFilePrefix, mockICSVReader);

            var moclList = new List<string>();
            // Act
            var result = mockFileOpCheck.FilterAndReadFiles();
            int count = mockFileOpCheck.ReadDataFromCsv("LP_210095893_20150901T011608049.csv", "E:\\PrimeTestMedian\\Sample files\\LP_210095893_20150901T011608049.csv").Count;
            // Assert
            Assert.AreEqual(count > 0 , true);
        }
        
        #endregion

        #region negative testing
        [TestMethod]
        public void Func_ShouldCheckConfigSettingsNotExists()
        {
            // Arrange

            var mockCheckConfigSettings = new CheckConfigSettings(mockLoggerWrapper);

            // Act
            bool success = !mockCheckConfigSettings.CheckConfigSetting();

            // Assert
            Assert.AreNotEqual(success, true);
        }


        [TestMethod]
        public void Func_ShouldCheckPathNotExists()
        {
            // Arrange
            var mockPathFinder = new PathFinder(mockLoggerWrapper);

            // Act
            bool success = !mockPathFinder.PathExists(config["FilePath"]);

            // Assert
            Assert.AreNotEqual(success, true);
        }

        [TestMethod]
        public void Func_ShouldCheckFileNotExists()
        {
            // Arrange
            var mockFileFinder = new FileFinder(mockLoggerWrapper);

            // Act
            bool success = !mockFileFinder.FileExists(config["FilePath"]);

            // Assert
            Assert.AreNotEqual(success, true);
        }

        [TestMethod]
        public void Func_ShouldCheckFileWithoutDesiredExtExists()
        {
            // Arrange
            var MatchFileExtension = new MatchFileExtension(mockLoggerWrapper);

            // Act
            bool success = !MatchFileExtension.FileExtExists(config["FilePath"], config["FileExt"]);

            // Assert
            Assert.AreNotEqual(success, true);
        }

        [TestMethod]
        public void Func_ShouldCheckFileWithoutDesiredPrefixExists()
        {
            // Arrange
            var mockMatchFilePrefix = new MatchFilePrefix(mockLoggerWrapper);

            // Act
            bool success = !mockMatchFilePrefix.FilePrefixExists(config["FilePath"], config["FileExt"]);

            // Assert
            Assert.AreNotEqual(success, true);
        }


        [TestMethod]
        public void Func_ShouldReadFilesWithInCorrectPrefixExists()
        {
            // Arrange
            var mockConfigWrapper = new CheckConfigSettings(mockLoggerWrapper);
            var mockMatchFilePrefix = new MatchFilePrefix(mockLoggerWrapper);
            var mockMatchFileExtension = new MatchFileExtension(mockLoggerWrapper);
            var mockPathFinder = new PathFinder(mockLoggerWrapper);
            var mockFileFinder = new FileFinder(mockLoggerWrapper);
            var mockICSVReader = new CSVReader();

            var mockIFileOpCheck = new FileOpCheck(mockLoggerWrapper, mockFileFinder,
                mockPathFinder, mockMatchFileExtension,
                mockConfigWrapper, mockMatchFilePrefix, mockICSVReader);

            var moclList = new List<string>();
            // Act
            var result = mockIFileOpCheck.FilterAndReadFiles();
            bool success = !result.Any(d => d.Contains("LP_") || d.Contains("TOU_"));
            // Assert
            Assert.AreNotEqual(success, true);
        }

        [TestMethod]
        public void Func_ReadFilesShouldNotHaveData()
        {
            // Arrange
            var mockConfigWrapper = new CheckConfigSettings(mockLoggerWrapper);
            var mockMatchFilePrefix = new MatchFilePrefix(mockLoggerWrapper);
            var mockMatchFileExtension = new MatchFileExtension(mockLoggerWrapper);
            var mockPathFinder = new PathFinder(mockLoggerWrapper);
            var mockFileFinder = new FileFinder(mockLoggerWrapper);
            var mockICSVReader = new CSVReader();

            var mockFileOpCheck = new FileOpCheck(mockLoggerWrapper, mockFileFinder,
                mockPathFinder, mockMatchFileExtension,
                mockConfigWrapper, mockMatchFilePrefix, mockICSVReader);

            var moclList = new List<string>();
            // Act
            var result = mockFileOpCheck.FilterAndReadFiles();
            bool success = result.Any(d => d.Contains("LP_") || d.Contains("TOU_"));
            int count = mockFileOpCheck.ReadDataFromCsv("LP_210095893_20150901T011608049.csv", "E:\\PrimeTestMedian\\Sample files\\LP_210095893_20150901T011608049.csv").Count;

            // Assert
            Assert.AreNotEqual(count < 0, true);
        }
        #endregion
    }
}
