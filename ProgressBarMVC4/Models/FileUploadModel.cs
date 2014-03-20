using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Web;

namespace ProgressBarMVC4.Models
{
    public class FileUploadModel
    {
        [Required]
        [Display(Name = "User Name", Prompt = "User Name")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "API Key", Prompt = "API Key")]
        [DataType(DataType.Text)]
        public string Apikey { get; set; }

        [Required]
        [Display(Name = "Container", Prompt = "Container")]
        [DataType(DataType.Text)]
        public string Container { get; set; }

        [Required]
        [Display(Name = "Path to File", Prompt = "Path to File")]
        [DataType(DataType.Upload)]
        public HttpPostedFileWrapper Pathtofile { get; set; }

        [Required]
        [Display(Name = "Object Name", Prompt = "Object Name")]
        [DataType(DataType.Text)]
        public string Objectname { get; set; }

    }
}