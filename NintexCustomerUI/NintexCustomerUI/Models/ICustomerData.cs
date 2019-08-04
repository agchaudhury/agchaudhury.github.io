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
        Customer GetCustomerData(int customerId);
        List<Customer> RemoveCustomerData(int customerId);
        Customer RemovePhoneData(int customerId, int PhoneId);
        Customer EditPhoneData(int customerId, int PhoneId, string Status);
    }
}
