using MyobSalaryApp.OutFileStrategy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
//using System.Net.Http.Formatting;

namespace MyobSalaryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultList = new List<SalaryDataOut>();

            Console.WriteLine("Kindly enter the file type:");
            var fileType = Console.ReadLine();
            var fileContext = new OutputFileContext();
            var outFilePath = @"C:\Users\arupc\source\repos\MyobSalaryApp\MyobSalaryApp\Files\CSVOutput\OutFile.csv";

            if (string.Equals(fileType, "csv", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    var client = new HttpClient();
                    var getDataTask = client.GetAsync("https://localhost:44342/api/salary/csv")
                        .ContinueWith(response =>
                        {
                            var result = response.Result;
                            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var readResult = result.Content.ReadAsAsync<List<SalaryDataOut>>();
                                readResult.Wait();
                                resultList = readResult.Result;
                            }
                        });
                    getDataTask.Wait();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                fileContext = new OutputFileContext(new OutputFileCSV());
            }
            else
                fileContext = new OutputFileContext(new OutputFileExcel());

            fileContext.WriteData(outFilePath, resultList);

            Console.ReadKey();
        }
    }
}
