using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestJsonData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader("Tax.json"))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
            }
            BuildWebHost(args).Run();
           
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }

    public class Item
    {
            public int Year;
            public int TaxIncomeLow;
            public int TaxIncomeHigh;
            public int TaxAmount;
            public float TaxPercent;
    }
}
