using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class InvoiceToString : IActivity
    {
        public void InvoiceActivity()
        {
            var stringInvoice = new InvoiceStringData();
            var invoiceData = new InvoiceRawData();

            Console.WriteLine(stringInvoice.ToString(invoiceData.CreateInvoiceDataToString()));
        }
    }
}
