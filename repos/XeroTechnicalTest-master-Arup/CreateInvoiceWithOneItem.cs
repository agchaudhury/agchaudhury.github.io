using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class CreateInvoiceWithOneItem : IActivity
    {
        public void InvoiceActivity()
        {
            var invoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var getTotal = new GetTotalInvoice();
            var invoiceData = new InvoiceRawData();

            foreach (InvoiceLine iLine in invoiceData.CreateInvoiceDataSingle())
            {
                invoice.LineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
                {
                    InvoiceLineId = iLine.InvoiceLineId,
                    Cost = iLine.Cost,
                    Quantity = iLine.Quantity,
                    Description = iLine.Description
                }, invoice.LineItems);
            }

            Console.WriteLine("Total: " + getTotal.GetTotal(invoice.LineItems));
        }
    }
}
