using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class MergeInvoicesData
    {
        /// <summary>
        /// MergeInvoices appends the items from the sourceInvoice to the current invoice
        /// </summary>
        /// <param name="sourceInvoice">Invoice to merge from</param>
        /// <param name="destinationInvoice">Invoice to merge to</param>
        /// <returns></returns>
        public Invoice MergeInvoices(Invoice sourceInvoice, Invoice destinationInvoice)
        {
            if (sourceInvoice == null)
                throw new Exception("Null object passed for merging");

            foreach (InvoiceLine line in sourceInvoice.LineItems)
            {
                destinationInvoice.LineItems.Add(new InvoiceLine()
                {
                    InvoiceLineId = line.InvoiceLineId,
                    Cost = line.Cost,
                    Quantity = line.Quantity,
                    Description = line.Description
                });
            }

            return destinationInvoice;
        }
    }
}
