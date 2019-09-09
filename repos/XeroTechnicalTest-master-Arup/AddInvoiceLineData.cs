using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class AddInvoiceLineData
    {
        public List<InvoiceLine> AddInvoiceLine(InvoiceLine invoiceLine, List<InvoiceLine> lineItems)
        {
            if (lineItems == null)
                lineItems = new List<InvoiceLine>();
            lineItems.Add(invoiceLine);

            return lineItems;
        }
    }
}
