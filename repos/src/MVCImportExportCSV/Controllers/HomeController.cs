//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="None">
//     Copyright (c) Allow to distribute this code and utilize this code for personal or commercial purpose.
// </copyright>
// <author>Asma Khalid</author>
//-----------------------------------------------------------------------

namespace MVCImportExportCSV.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CSVLibraryAK;
    using Models;

    /// <summary>
    /// Home controller class.
    /// </summary>
    public class HomeController : Controller
    {      
        #region Index view method.

        #region Get: /Home/Index method.

        /// <summary>
        /// Get: /Home/Index method.
        /// </summary>        
        /// <returns>Return index view</returns>
        public ActionResult Index()
        {
            // Initialization.
            HomeViewModel model = new HomeViewModel { FileAttach = null, Data = new DataTable(), HasHeader = true };

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

        #endregion

        #region POST: /Home/Index

        /// <summary>
        /// POST: /Home/Index
        /// </summary>
        /// <param name="model">Model parameter</param>
        /// <returns>Return - Response information</returns>
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
                    string folderPath = "~/Content/temp_upload_files/";
                    string filename = "download.csv";

                    // Uploading file.
                    this.WriteBytesToFile(this.Server.MapPath(folderPath), uploadedFile, model.FileAttach.FileName);

                    // Settings.
                    importFilePath = this.Server.MapPath(folderPath + model.FileAttach.FileName);
                    exportFilePath = this.Server.MapPath(folderPath + filename);

                    // Impot CSV file.
                    model.Data = CSVLibraryAK.Import(importFilePath, model.HasHeader);

                    // Export CSV file.
                    CSVLibraryAK.Export(exportFilePath, model.Data);

                    // Deleting Extra files.
                    System.IO.File.Delete(importFilePath);
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

        #endregion

        #endregion

        #region Download file methods

        #region GET: /Home/DownloadFile

        /// <summary>
        /// GET: /Home/DownloadFile
        /// </summary>
        /// <returns>Return download file</returns>
        public ActionResult DownloadFile()
        {
            // Model binding.
            HomeViewModel model = new HomeViewModel { FileAttach = null, Data = new DataTable(), HasHeader = true };

            try
            {
                // Initialization.
                string filePath = "~/Content/temp_upload_files/download.csv";

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

        #endregion

        #endregion

        #region Helpers

        #region Get file method.

        /// <summary>
        /// Get file method.
        /// </summary>
        /// <param name="filePath">File path parameter.</param>
        /// <returns>Returns - File.</returns>
        private FileResult GetFile(string filePath)
        {
            // Initialization.
            FileResult file = null;

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

        #endregion

        #region Write to file

        /// <summary>
        /// Write content to file.
        /// </summary>
        /// <param name="rootFolderPath">Root folder path parameter</param>
        /// <param name="fileBytes">File bytes parameter</param>
        /// <param name="filename">File name parameter</param>
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

        #endregion

        #endregion
    }
}