using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyobSalaryApp.OutFileStrategy
{
    public class OutputFileContext
    {
        private IOutputFile _strategy;

        public OutputFileContext()
        {
           
        }

        public OutputFileContext(IOutputFile strategy)
        {
            this._strategy = strategy;
        }

        public void WriteData(string path, List<SalaryDataOut> listData)
        {
            _strategy.WriteDataToFile(path, listData);
        }
    }
}
