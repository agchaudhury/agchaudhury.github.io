using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCreationService.Model.InFileStrategy
{
    //This class is an example about how we can extend input file types and has nothing to do with the task logic
    public class InputFileText : IInputFile
    {
        public List<SalaryDataIn> ReadDataFromFile(string path)
        {
            return new List<SalaryDataIn>();
        }
    }
}
