using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class RemoveItem : IActivity
    {
        public void InvoiceActivity()
        {
            var invoice = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var getTotal = new GetTotalInvoice();
            var removeItem = new RemoveItemData();
            var invoiceData = new InvoiceRawData();

            foreach (InvoiceLine iLine in invoiceData.CreateInvoiceDataRemove())
            {
                invoice.LineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
                {
                    InvoiceLineId = iLine.InvoiceLineId,
                    Cost = iLine.Cost,
                    Quantity = iLine.Quantity,
                    Description = iLine.Description
                }, invoice.LineItems);
            }

            invoice.LineItems = removeItem.RemoveInvoiceLine(1, invoice.LineItems);
            Console.WriteLine("Total: " + getTotal.GetTotal(invoice.LineItems));
        }
    }
}
