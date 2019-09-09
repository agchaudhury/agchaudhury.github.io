using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    /// <summary>
    /// All data per Invoice activity are stored here
    /// </summary>
    public class InvoiceRawData
    {
        public List<InvoiceLine> CreateInvoiceDataMultiple()
        {
            var lineItems = new List<InvoiceLine>();
            var addInvoice = new AddInvoiceLineData();

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 10.21m,
                Quantity = 4,
                Description = "Banana"
            }, lineItems);

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            }, lineItems);

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 3,
                Cost = 5.21m,
                Quantity = 5,
                Description = "Pineapple"
            }, lineItems);

            return lineItems;
        }

        public List<InvoiceLine> CreateInvoiceDataSingle()
        {
            var lineItems = new List<InvoiceLine>();
            var addInvoice = new AddInvoiceLineData();

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99m,
                Quantity = 1,
                Description = "Apple"
            }, lineItems);

            return lineItems;
        }

        public List<InvoiceLine> CreateInvoiceDataClone()
        {
            var lineItems = new List<InvoiceLine>();
            var addInvoice = new AddInvoiceLineData();

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99m,
                Quantity = 1,
                Description = "Apple"
            }, lineItems);

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 6.27m,
                Quantity = 3,
                Description = "Blueberries"
            }, lineItems);

            return lineItems;
        }

        public Invoice CreateInvoiceDataToString()
        {
            var invoice = new Invoice()
            {
                InvoiceDate = DateTime.Now,
                InvoiceNumber = 1000,
                LineItems = new List<InvoiceLine>()
                {
                    new InvoiceLine()
                    {
                        InvoiceLineId = 1,
                        Cost = 6.99m,
                        Quantity = 1,
                        Description = "Apple"
                    }
                }
            };

            return invoice;
        }

        public List<InvoiceLine> CreateInvoiceDataMerge()
        {
            var lineItems = new List<InvoiceLine>();
            var addInvoice = new AddInvoiceLineData();

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 10.33m,
                Quantity = 4,
                Description = "Banana"
            }, lineItems);

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.22m,
                Quantity = 1,
                Description = "Orange"
            }, lineItems);

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 3,
                Cost = 6.27m,
                Quantity = 3,
                Description = "Blueberries"
            }, lineItems);

            return lineItems;
        }

        public List<InvoiceLine> CreateInvoiceDataRemove()
        {
            var lineItems = new List<InvoiceLine>();
            var addInvoice = new AddInvoiceLineData();

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            }, lineItems);

            lineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 10.99m,
                Quantity = 4,
                Description = "Banana"
            }, lineItems);

            return lineItems;
        }
    }
}
