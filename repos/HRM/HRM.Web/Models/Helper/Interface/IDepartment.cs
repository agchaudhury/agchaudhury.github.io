using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Web.Models.Helper
{
    public interface IDepartment
    {
      List<Department> GetDepartments();
    }
}
