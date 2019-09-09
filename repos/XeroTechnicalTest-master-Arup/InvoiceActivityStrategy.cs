using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroTechnicalTest
{
    public class InvoiceActivityStrategy
    {
        private IActivity _activity;

        public void SetInvoiceActivity(IActivity activity)
        {
            this._activity = activity;
        }

        public void InitiateInvoiceActivity()
        {
            _activity.InvoiceActivity();
        }
    }
}
