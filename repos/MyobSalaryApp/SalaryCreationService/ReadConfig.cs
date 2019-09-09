using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCreationService
{
    public class ReadConfig
    {
        public int GetDataFromConfig(string path)
        {
            var data = new ConfigClass();
            using (StreamReader r = new StreamReader(path + "\\Files\\ConfigFiles\\myconfig.json"))
            {
                var json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<ConfigClass>(json);
            }
            return data.PayYear;
        }
    }
}
