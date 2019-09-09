using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCreationService.Model.SalaryCal
{
    public class TaxDetails
    {
        public List<TaxRates> GetTaxRates(int PayYear, string path)
        {
            List<TaxRates> items = new List<TaxRates>(); 
            using (StreamReader r = new StreamReader(path + "\\Files\\ConfigFiles\\Tax.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<TaxRates>>(json);
            }
            return items.Where(d => d.Year == PayYear).ToList();
        }
    }
}
