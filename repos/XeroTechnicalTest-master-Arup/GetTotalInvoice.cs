using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class GetTotalInvoice
    {
        /// <summary>
        /// GetTotal should return the sum of (Cost * Quantity) for each line item
        /// </summary>
        /// <param name="lineItems"></param>
        /// <returns></returns>
        public decimal GetTotal(List<InvoiceLine> lineItems)
        {
            decimal totalCount = 0.00m;
            foreach (InvoiceLine iLine in lineItems)
            {
                totalCount += (iLine.Cost * iLine.Quantity);
            }
            return totalCount;
        }
    }
}
