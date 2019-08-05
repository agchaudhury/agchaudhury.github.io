using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NintexCustomerUI.Models
{
    public interface ICustomerData
    {
        List<Customer> GetAllCustomers();
        List<CustomerPhone> GetCustomerData(int customerId);
    }
}
