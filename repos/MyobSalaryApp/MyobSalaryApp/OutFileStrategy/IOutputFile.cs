using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyobSalaryApp.OutFileStrategy
{
    public interface IOutputFile
    {
        void WriteDataToFile(string path, List<SalaryDataOut> listData);
    }
}
