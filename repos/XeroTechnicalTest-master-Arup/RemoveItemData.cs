using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class RemoveItemData
    {
        public List<InvoiceLine> RemoveInvoiceLine(int lineId, List<InvoiceLine> lineItems)
        {
            try
            {
                var itemToRemove = lineItems.Single(x => x.InvoiceLineId == lineId);
                lineItems.Remove(itemToRemove);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Removing invalid line item");
            }
            catch (Exception ex)
            {
                throw new Exception("Error while removing InvoiceLine");
            }

            return lineItems;
        }
    }
}
