using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SalaryCreationService.Model;
using SalaryCreationService.Model.InFileStrategy;
using SalaryCreationService.Model.SalaryCal;

namespace SalaryCreationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private IHostingEnvironment _env;
        public SalaryController(IHostingEnvironment env)
        {
            _env = env;
        }

        // GET api/salary/csv
        [HttpGet("{fileType}")]
        public ActionResult<IEnumerable<SalaryDataOut>> Get(string fileType)
        {
            var webRoot = _env.ContentRootPath;
            var objSalaryCal = new SalaryCalculation();
            var fileContext = new InputFileContext();

            if(string.Equals(fileType, "csv", StringComparison.OrdinalIgnoreCase))
                fileContext = new InputFileContext(new InputFileCSV());
            else
                fileContext = new InputFileContext(new InputFileText());

            return objSalaryCal.SalCal(fileContext.GetDataFromInputFile(webRoot), webRoot);
        }
    }
}
