using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class CloneInvoice : IActivity
    {
        public void InvoiceActivity()
        {
            var invoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var getTotal = new GetTotalInvoice();
            var cloneData = new CloneInvoiceData();
            var invoiceData = new InvoiceRawData();

            foreach (InvoiceLine iLine in invoiceData.CreateInvoiceDataClone())
            {
                invoice.LineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
                {
                    InvoiceLineId = iLine.InvoiceLineId,
                    Cost = iLine.Cost,
                    Quantity = iLine.Quantity,
                    Description = iLine.Description
                }, invoice.LineItems);
            }

            var clonedInvoice = cloneData.Clone(invoice);
            Console.WriteLine("Total: " + getTotal.GetTotal(clonedInvoice.LineItems));
        }
    }
}
