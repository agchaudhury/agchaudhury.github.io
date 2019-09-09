using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyobSalaryApp.OutFileStrategy
{
    //This class is an example about how we can extend output file types and has nothing to do with the task logic
    public class OutputFileExcel : IOutputFile
    {
        public void WriteDataToFile(string path, List<SalaryDataOut> listData)
        {

        }
    }
}
