using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class MergeInvoices : IActivity
    {
        public void InvoiceActivity()
        {
            var invoice1 = new Invoice();
            var addInvoice = new AddInvoiceLineData();
            var getTotal = new GetTotalInvoice();
            var mergeData = new MergeInvoicesData();
            var invoiceData = new InvoiceRawData();
            var firstData = invoiceData.CreateInvoiceDataMerge().FirstOrDefault();
            var data = invoiceData.CreateInvoiceDataMerge();
            var restData = new List<InvoiceLine>();
            restData = data.Where(x => x.InvoiceLineId != firstData.InvoiceLineId).ToList();

            invoice1.LineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = firstData.InvoiceLineId,
                Cost = firstData.Cost,
                Quantity = firstData.Quantity,
                Description = firstData.Description
            }, invoice1.LineItems);

            var invoice2 = new Invoice();

            foreach (InvoiceLine iLine in restData)
            {
                invoice2.LineItems = addInvoice.AddInvoiceLine(new InvoiceLine()
                {
                    InvoiceLineId = iLine.InvoiceLineId,
                    Cost = iLine.Cost,
                    Quantity = iLine.Quantity,
                    Description = iLine.Description
                }, invoice2.LineItems);
            }

            invoice1 = mergeData.MergeInvoices(invoice2, invoice1);
            Console.WriteLine("Total: " + getTotal.GetTotal(invoice1.LineItems));
        }
    }
}
