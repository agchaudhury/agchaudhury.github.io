using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyobSalaryUI.Models
{
    public class HomeViewModel
    {
        [Required]
        [Display(Name = "Import CSV File")]
        public HttpPostedFileBase FileAttach { get; set; }

        [Required]
        [Display(Name = "Has Header")]
        public bool HasHeader { get; set; }

        public DataTable Data { get; set; }
    }
}