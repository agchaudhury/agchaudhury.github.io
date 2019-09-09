using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class CloneInvoiceData
    {
        /// <summary>
        /// Creates a deep clone of the current invoice (all fields and properties)
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Invoice Clone(Invoice invoice)
        {
            return invoice.DeepClone();
        }
    }
}
