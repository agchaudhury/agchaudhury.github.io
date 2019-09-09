using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.Web.Models.Helper;

namespace HRM.Web.Models.Helper
{
    public interface ICommon
    {
        List<SelectListItem> GetPageListItem();
    }

   
}
