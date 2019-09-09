using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyobSalaryUI.Models;

namespace MyobSalaryUI.Controllers
{
    using CSVLibraryAK;
    using System.Net.Http;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Initialization.
            HomeViewModel model = new HomeViewModel { FileAttach = null, Data = new DataTable(), HasHeader = false };

            try
            {
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Info.
            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HomeViewModel model)
        {
            // Initialization.
            string importFilePath = string.Empty;
            string exportFilePath = string.Empty;

            try
            {
                // Verification
                if (ModelState.IsValid)
                {
                    // Converting to bytes.
                    byte[] uploadedFile = new byte[model.FileAttach.InputStream.Length];
                    model.FileAttach.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

                    // Initialization.
                    string folderPath = @"C:\Users\arupc\source\repos\MyobSalaryApp\SalaryCreationService\Files\CSVInput\";
                    string filename = "input.csv";

                    // Uploading file.
                    this.WriteBytesToFile(folderPath, uploadedFile, model.FileAttach.FileName);

                    importFilePath = folderPath + model.FileAttach.FileName;
                    exportFilePath = folderPath + filename;

                    // Impot CSV file.
                    model.Data = CSVLibraryAK.Import(importFilePath, model.HasHeader);

                    // Export CSV file.
                    CSVLibraryAK.Export(exportFilePath, model.Data);
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Info
            return this.View(model);
        }

        public ActionResult DownloadFile()
        {
            // Model binding.
            HomeViewModel model = new HomeViewModel { FileAttach = null, Data = new DataTable(), HasHeader = true };

            try
            {
                // Initialization.
                string filePath = @"C:\Users\arupc\source\repos\MyobSalaryApp\MyobSalaryApp\Files\CSVOutput\OutFile.csv";

                // Info.
                return this.GetFile(filePath);
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Info.
            return this.View(model);
        }

        private FileResult GetFile(string filePath)
        {
            // Initialization.
            FileResult file = null;

            var resultList = new List<SalaryViewModel>();

            try
            {
                var client = new HttpClient();
                var getDataTask = client.GetAsync("https://localhost:44342/api/salary/csv")
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<SalaryViewModel>>();
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

            using (var w = new StreamWriter(filePath))
            {
                foreach (SalaryViewModel data in resultList)
                {
                    var newLine = $"{data.Name},{data.PayPeriod},{data.GrossIncome},{data.IncomeTax},{data.NetIncome},{data.Super}";
                    w.WriteLine(newLine);
                    w.Flush();
                }
            }

            try
            {
                // Initialization.
                FileInfo info = new FileInfo(filePath);
                string contentType = MimeMapping.GetMimeMapping(filePath);

                // Get file.
                file = this.File(filePath, contentType, info.Name);
            }
            catch (Exception ex)
            {
                // Info.
                throw ex;
            }

            // info.
            return file;
        }

        private void WriteBytesToFile(string rootFolderPath, byte[] fileBytes, string filename)
        {
            try
            {
                // Verification.
                if (!Directory.Exists(rootFolderPath))
                {
                    // Initialization.
                    string fullFolderPath = rootFolderPath;

                    // Settings.
                    string folderPath = new Uri(fullFolderPath).LocalPath;

                    // Create.
                    Directory.CreateDirectory(folderPath);
                }

                // Initialization.                
                string fullFilePath = rootFolderPath + filename;

                // Create.
                FileStream fs = System.IO.File.Create(fullFilePath);

                // Close.
                fs.Flush();
                fs.Dispose();
                fs.Close();

                // Write Stream.
                BinaryWriter sw = new BinaryWriter(new FileStream(fullFilePath, FileMode.Create, FileAccess.Write));

                // Write to file.
                sw.Write(fileBytes);

                // Closing.
                sw.Flush();
                sw.Dispose();
                sw.Close();
            }
            catch (Exception ex)
            {
                // Info.
                throw ex;
            }
        }
    }
}