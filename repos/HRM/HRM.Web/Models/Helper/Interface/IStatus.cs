using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Web.Models.Helper
{
    public interface IStatus
    {
      List<Status> GetStatus();
    }
}
