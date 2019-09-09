using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class InvoiceStringData
    {
        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Invoice Number: [InvoiceNumber], InvoiceDate: [DD/MM/YYYY], LineItemCount: [Number of items in LineItems] 
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public string ToString(Invoice invoice)
        {
            return "Invoice Number: " + invoice.InvoiceNumber + ", InvoiceDate: " + invoice.InvoiceDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ", LineItemCount: " + invoice.LineItems.Count();
        }
    }
}
