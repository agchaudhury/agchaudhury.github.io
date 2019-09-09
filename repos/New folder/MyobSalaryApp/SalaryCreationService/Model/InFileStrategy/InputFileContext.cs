using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCreationService.Model.InFileStrategy
{
    public class InputFileContext
    {
        private IInputFile _strategy;

        public InputFileContext()
        {
           
        }

        public InputFileContext(IInputFile strategy)
        {
            this._strategy = strategy;
        }

        public List<SalaryDataIn> GetDataFromInputFile(string path)
        {
            return _strategy.ReadDataFromFile(path);
        }
    }
}
