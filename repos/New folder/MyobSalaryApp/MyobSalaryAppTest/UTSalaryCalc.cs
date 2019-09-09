using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCreationService.Model.SalaryCal;
using System;

namespace MyobSalaryAppTest
{
    [TestClass]
    public class UTSalaryCalc
    {
        private SalaryCalculation _calculatePay;
        public UTSalaryCalc()
        {
            _calculatePay = new SalaryCalculation();
        }
        [TestMethod]
        public void CalculateGrossPaywithValidValue()
        {
            //Arrange
            decimal annualSalary = 60050;
            //Act
            var grossPay = _calculatePay.CalculateGrossPay(annualSalary);
            //Assert
            Assert.AreEqual(5004, grossPay);
        }

        [TestMethod]
        public void CalculateGrossPaywithValidValueWhenSalary0()
        {
            //Arrange
            decimal annualSalary = 0;
            //Act
            var grossPay = _calculatePay.CalculateGrossPay(annualSalary);
            //Assert
            Assert.AreEqual(0, grossPay);
        }

        [TestMethod]
        public void CalculateGrossPaywithValidValueWhenSalaryNegative()
        {
            //Arrange
            decimal annualSalary = -1500;
            //Act
            try
            {
                var grossPay = _calculatePay.CalculateGrossPay(annualSalary);
                //Assert
                Assert.AreEqual(0, grossPay);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("invalid negative value", ex.Message);
            }
        }

        [TestMethod]
        public void CalculateNetTaxSalary60050()
        {
            //Arrange
            decimal annualSalary = 60050;
            int fixTaxAmount = 3572;
            decimal taxPercent = 32.5m;
            int taxLowSlab = 37001;
            //Act
            var netTax = _calculatePay.CalculateIncomeTax(annualSalary, taxPercent, fixTaxAmount, taxLowSlab);
            //Assert
            Assert.AreEqual(922, netTax);
        }
        [TestMethod]
        public void CalculateNetTaxSalary18200()
        {
            //Arrange
            decimal annualSalary = 18200;
            int fixTaxAmount = 0;
            decimal taxPercent = 0;
            int taxLowSlab = 0;
            //Act
            var netTax = _calculatePay.CalculateIncomeTax(annualSalary, taxPercent, fixTaxAmount, taxLowSlab);
            //Assert
            Assert.AreEqual(0, netTax);
        }

        [TestMethod]
        public void CalculateNetSalary120000()
        {
            //Arrange
            decimal annualSalary = 120000;
            int fixTaxAmount = 19822;
            decimal taxPercent = 37;
            int taxLowSlab = 87001;
            //Act
            int grossPay = _calculatePay.CalculateGrossPay(annualSalary);
            var netTax = _calculatePay.CalculateIncomeTax(annualSalary, taxPercent, fixTaxAmount, taxLowSlab);
            //Assert
            Assert.AreEqual(7331, grossPay - netTax);
        }

        [TestMethod]
        public void CalculateNetSalaryNegativeData120000()
        {
            //Arrange
            decimal annualSalary = 120000;
            int fixTaxAmount = 19822;
            decimal taxPercent = -1;
            int taxLowSlab = 87001;
            //Act
            try
            {
                int grossPay = _calculatePay.CalculateGrossPay(annualSalary);
                var netTax = _calculatePay.CalculateIncomeTax(annualSalary, taxPercent, fixTaxAmount, taxLowSlab);
                //Assert
                Assert.AreEqual(7331, grossPay - netTax);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("invalid negative value", ex.Message);
            }
        }

        [TestMethod]
        public void CalculateNetSuper()
        {
            //Arrange
            decimal annualSalary = 120000;
            decimal superPer = 10;
            //Act
            int grossPay = _calculatePay.CalculateGrossPay(annualSalary);
            var super = _calculatePay.CalculateSuper(grossPay, superPer);
            //Assert
            Assert.AreEqual(1000, super);
        }

        [TestMethod]
        public void CalculateNetSalaryNegativePercentage120000()
        {
            //Arrange
            decimal annualSalary = 120000;
            decimal superPer = -10;
            //Act
            try
            {
                int grossPay = _calculatePay.CalculateGrossPay(annualSalary);
                var super = _calculatePay.CalculateSuper(grossPay, superPer);
                //Assert
                Assert.AreEqual(450, super);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("invalid negative value", ex.Message);
            }
        }
        //[TestMethod]
        //public void ReadDataFromCsv()
        //{
        //    //Arrange 
        //    var filePath = Directory.GetCurrentDirectory() + "\\data.csv";
        //    //Act
        //    var filesextExists = _fileOpCheck.ReadDataFromCsv(filePath);
        //    //Assert
        //    Assert.AreEqual(2, filesextExists.Count);
        //}
    }
}
