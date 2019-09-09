using CsvOps;
using LoggerService;
using MedianCalculation;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeTestMedian.Test
{
    [TestClass]
    public class MedianCalcTest
    {
        ILoggerManager mockLoggerWrapper;

        public MedianCalcTest()
        {
          mockLoggerWrapper = new LoggerManager();
        }


        #region Positive Testing Calculate Median
        [TestMethod]
        public void Func_ShouldGetMedianOfEvenCount()
        {
            // Arrange
            List<double> records = new List<double>();
            for (int i = 1; i <= 8; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian(mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.CalcMedian(records);

            // Assert
            Assert.AreEqual(result, 2.75);
        }

        [TestMethod]
        public void Func_ShouldGetMedianOfOddCount()
        {
            // Arrange
            List<double> records = new List<double>();
            for (int i = 1; i <= 7; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian(mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.CalcMedian(records);

            // Assert
            Assert.AreEqual(result, 2.0);
        }

        [TestMethod]
        public void Func_ShouldGetMedianOfOnly2Count()
        {
            // Arrange
            List<double> records = new List<double>();
            for (int i = 1; i <= 2; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian(mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.CalcMedian(records);

            // Assert
            Assert.AreEqual(result, .75);
        }

        [TestMethod]
        public void Func_ShouldGetMedianOfOnlyOneCount()
        {
            // Arrange
            List<double> records = new List<double>();
            for (int i = 1; i <= 1; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian( mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.CalcMedian(records);

            // Assert
            Assert.AreEqual(result, .5);
        }

        [TestMethod]
        public void Func_ShouldGetMedianOfOnlyZeroCount()
        {
            // Arrange
            List<double> records = new List<double>();
            var mockcalcMedian = new CalculateMedian( mockLoggerWrapper);
            
            // Act
            double result = mockcalcMedian.CalcMedian(records);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Func_ShouldGet20AboveAnd20BelowMedianCount()
        {
            // Arrange
            List<double> records = new List<double>();
            double above20 = 0;
            double below20 = 0;
            for (int i = 1; i <= 2; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian( mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.GetMedianValueWith20AboveAndBelow(ref above20, ref below20, records);

            // Assert
            Assert.AreEqual(above20, .90);
            Assert.AreEqual(below20, .60);
        }

        [TestMethod]
        public void Func_ShouldPrintDesiredResult()
        {
            // Arrange
            List<double> records = new List<double>();
            double above20 = 0;
            double below20 = 0;
            bool recordPrinted = false;
            string fileName = "LP_210095893_20150901T011608049.csv";
            for (int i = 1; i <= 8; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian(mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.GetMedianValueWith20AboveAndBelow(ref above20, ref below20, records);
            foreach (double d in records.Where(d=>d==above20 || d==below20))
            {
                Console.WriteLine("{" + fileName + "}" + "{" + DateTime.Now + "}" + "{" + d + "}" + "{" + result + "}");
                recordPrinted = true;
            }
            Assert.AreNotEqual(true, recordPrinted);
        }
        #endregion

        #region Nagative Testing Calculate Median
        [TestMethod]
        public void Func_ShouldGetWrongMedianOfEvenCount()
        {
            // Arrange
            List<double> records = new List<double>();
            for (int i = 1; i <= 8; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian( mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.CalcMedian(records);

            // Assert
            Assert.AreNotEqual(result, 2.5);
        }

        [TestMethod]
        public void Func_ShouldGetWrongMedianOfOddCount()
        {
            // Arrange
            List<double> records = new List<double>();
            for (int i = 1; i <= 7; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian( mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.CalcMedian(records);

            // Assert
            Assert.AreNotEqual(result, 2.9);
        }

        [TestMethod]
        public void Func_ShouldGetWrongMedianOfOnly2Count()
        {
            // Arrange
            List<double> records = new List<double>();
            for (int i = 1; i <= 2; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian( mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.CalcMedian(records);

            // Assert
            Assert.AreNotEqual(result, .5);
        }

        [TestMethod]
        public void Func_ShouldGetWrongMedianOfOnlyOneCount()
        {
            // Arrange
            List<double> records = new List<double>();
            for (int i = 1; i <= 1; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian( mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.CalcMedian(records);

            // Assert
            Assert.AreNotEqual(result,0);
        }

        [TestMethod]
        public void Func_ShouldGetWrongMedianOfOnlyZeroCount()
        {
            // Arrange
            List<double> records = new List<double>();
            var mockcalcMedian = new CalculateMedian( mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.CalcMedian(records);

            // Assert
            Assert.AreNotEqual(result, 5);
        }

        [TestMethod]
        public void Func_ShouldGetWrong20AboveAnd20BelowMedianCount()
        {
            // Arrange
            List<double> records = new List<double>();
            double above20 = 0;
            double below20 = 0;
            for (int i = 1; i <= 2; i++)
            {
                records.Add(i * .5);
            }
            var mockcalcMedian = new CalculateMedian(mockLoggerWrapper);

            // Act
            double result = mockcalcMedian.GetMedianValueWith20AboveAndBelow(ref above20, ref below20, records);

            // Assert
            Assert.AreNotEqual(above20, .70);
            Assert.AreNotEqual(below20, .50);
        }
        #endregion

    }
}
