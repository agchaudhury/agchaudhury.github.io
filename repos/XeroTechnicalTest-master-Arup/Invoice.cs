using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace XeroTechnicalTest
{
    [Serializable]
    public class Invoice 
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceLine> LineItems { get; set; }
    }
}