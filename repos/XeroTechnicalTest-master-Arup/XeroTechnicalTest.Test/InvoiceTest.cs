using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XeroTechnicalTest.Test
{
    /// <summary>
    /// Some basic test cases are included
    /// </summary>
    [TestClass]
    public class InvoiceTest
    {
        #region AddInvoice
        [TestMethod]
        public void Func_AddSingleInvoice()
        {
            // Arrange
            var invoiceline = new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            };

            // Act
            var invoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var getTotal = new GetTotalInvoice();
            invoice.LineItems = addInvoice.AddInvoiceLine(invoiceline, invoice.LineItems);

            // Assert
            Assert.AreEqual(invoice.LineItems.Count, 1);
            Assert.AreEqual(getTotal.GetTotal(invoice.LineItems), 5.21m);
        }

        [TestMethod]
        public void Func_AddMoreThanOneInvoice()
        {
            // Arrange
            var invoiceline1 = new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            };

            var invoiceline2 = new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Apple"
            };

            // Act
            var invoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var getTotal = new GetTotalInvoice();
            invoice.LineItems = addInvoice.AddInvoiceLine(invoiceline1, invoice.LineItems);
            invoice.LineItems = addInvoice.AddInvoiceLine(invoiceline1, invoice.LineItems);

            // Assert
            Assert.AreEqual(invoice.LineItems.Count, 2);
            Assert.AreEqual(getTotal.GetTotal(invoice.LineItems), 10.42m);
        }

        [TestMethod]
        public void Func_AddNullInvoice()
        {
            // Arrange

            // Act
            var invoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
         
            invoice.LineItems = addInvoice.AddInvoiceLine(null, invoice.LineItems);

            // Assert
            Assert.AreEqual(invoice.LineItems.Count, 1);
            Assert.AreEqual(invoice.LineItems[0], null);
        }

        #endregion

        #region RemoveInvoice
        [TestMethod]
        public void Func_RemoveSingleInvoice()
        {
            // Arrange
            var invoiceline = new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            };

            // Act
            var invoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var removeInvoice = new RemoveItemData();
            var getTotal = new GetTotalInvoice();
            invoice.LineItems = addInvoice.AddInvoiceLine(invoiceline, invoice.LineItems);
            invoice.LineItems = removeInvoice.RemoveInvoiceLine(invoiceline.InvoiceLineId, invoice.LineItems);

            // Assert
            Assert.AreEqual(invoice.LineItems.Count, 0);
            Assert.AreNotEqual(invoice.LineItems.Count, 1);
            Assert.AreEqual(getTotal.GetTotal(invoice.LineItems), 0.0m);
        }

        [TestMethod]
        public void Func_RemoveMultipleInvoices()
        {
            // Arrange
            var invoiceline1 = new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            };

            var invoiceline2 = new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Apple"
            };

            // Act
            var invoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var removeInvoice = new RemoveItemData();
            var getTotal = new GetTotalInvoice();

            invoice.LineItems = addInvoice.AddInvoiceLine(invoiceline1, invoice.LineItems);
            invoice.LineItems = addInvoice.AddInvoiceLine(invoiceline2, invoice.LineItems);

            try
            {
                invoice.LineItems = removeInvoice.RemoveInvoiceLine(invoiceline1.InvoiceLineId, invoice.LineItems);
                invoice.LineItems = removeInvoice.RemoveInvoiceLine(invoiceline2.InvoiceLineId, invoice.LineItems);
            }
            catch (InvalidOperationException ex)
            {
                // Assert
                Assert.AreEqual("Removing invalid line item", ex.Message);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Error while removing InvoiceLine", ex.Message);
            }

            Assert.AreEqual(invoice.LineItems.Count, 0);
            Assert.AreNotEqual(invoice.LineItems.Count, 2);
            Assert.AreEqual(getTotal.GetTotal(invoice.LineItems), 0.0m);
        }

        [TestMethod]
        public void Func_RemoveSingleInvoiceNotExists_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var invoiceline = new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            };

            // Act
            var invoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var removeInvoice = new RemoveItemData();
            invoice.LineItems = addInvoice.AddInvoiceLine(invoiceline, invoice.LineItems);
            
            try
            {
                invoice.LineItems = removeInvoice.RemoveInvoiceLine(2, invoice.LineItems);
            }
            catch (InvalidOperationException ex)
            {
                // Assert
                Assert.AreEqual("Removing invalid line item", ex.Message);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Error while removing InvoiceLine", ex.Message);
            }
        }

        #endregion

        #region MergeInvoice
        [TestMethod]
        public void Func_MergeSingleInvoice()
        {
            // Arrange
            var invoiceline1 = new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            };

            var invoiceline2 = new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Apple"
            };

            // Act
            var destinationInvoice = new Invoice();
            var sourceInvoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var mergeData = new MergeInvoicesData();
            var getTotal = new GetTotalInvoice();

            destinationInvoice.LineItems = addInvoice.AddInvoiceLine(invoiceline1, destinationInvoice.LineItems);
            sourceInvoice.LineItems = addInvoice.AddInvoiceLine(invoiceline2, sourceInvoice.LineItems);

            destinationInvoice = mergeData.MergeInvoices(sourceInvoice, destinationInvoice);


            // Assert
            Assert.AreEqual(destinationInvoice.LineItems.Count, 2);
            Assert.AreEqual(getTotal.GetTotal(destinationInvoice.LineItems), 10.42m);
        }

        [TestMethod]
        public void Func_MergeNullInvoice_ShouldThrowException()
        {
            // Arrange
            var invoiceline1 = new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            };

            var invoiceline2 = new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Apple"
            };

            // Act
            var destinationInvoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var mergeData = new MergeInvoicesData();
            
            destinationInvoice.LineItems = addInvoice.AddInvoiceLine(invoiceline1, destinationInvoice.LineItems);
            
            try
            {
                destinationInvoice = mergeData.MergeInvoices(null, destinationInvoice);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Null object passed for merging", ex.Message);
            }

            // Assert
            Assert.AreEqual(destinationInvoice.LineItems.Count, 1);
        }

        #endregion

        #region CloneInvoice
        [TestMethod]
        public void Func_CloneInvoice()
        {
            // Arrange
            var invoiceline = new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            };

            // Act
            var invoice = new Invoice();
            var invoiceClone = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var clone = new CloneInvoiceData();
            var getTotal = new GetTotalInvoice();

            invoice.LineItems = addInvoice.AddInvoiceLine(invoiceline, invoice.LineItems);
            invoiceClone = clone.Clone(invoice);

            // Assert
            Assert.AreEqual(invoiceClone.LineItems.Count, 1);
            Assert.AreEqual(getTotal.GetTotal(invoiceClone.LineItems), 5.21m);
        }

        #endregion
    }
}
