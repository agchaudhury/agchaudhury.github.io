//-----------------------------------------------------------------------
// <copyright file="HomeViewModel.cs" company="None">
//     Copyright (c) Allow to distribute this code and utilize this code for personal or commercial purpose.
// </copyright>
// <author>Asma Khalid</author>
//-----------------------------------------------------------------------

namespace MVCImportExportCSV.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Web;

    /// <summary>
    /// Home view model class.
    /// </summary>
    public class HomeViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets CSV file.
        /// </summary>
        [Required]
        [Display(Name = "Import CSV File")]
        public HttpPostedFileBase FileAttach { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether CSV has header or not.
        /// </summary>
        [Required]
        [Display(Name = "Has Header")]
        public bool HasHeader { get; set; }

        /// <summary>
        /// Gets or sets Data table.
        /// </summary>
        public DataTable Data { get; set; }

        #endregion
    }
}