using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobFinder_appl.Models
{
    public class CompInsert
    {
        [Required(ErrorMessage ="Enter the company name")]
        public string cname { get; set; }
        [Required(ErrorMessage = "Enter the address")]

        public string address { get; set; }
        [RegularExpression(@"^(\d{10})$",ErrorMessage = "Enter the valid phone number")]

        public string phone { get; set; }
        [EmailAddress(ErrorMessage = "Enter the email id")]

        public string email { get; set; }
        public string websiteaddr { get; set; }
        [Required(ErrorMessage = "Enter the location")]

        public string location { get; set; }
        [Required(ErrorMessage = "Enter the username")]

        public string username { get; set; }
        [Required(ErrorMessage = "Enter the Password")]

        public string pwd { get; set; }
        [Compare("pwd",ErrorMessage = "password mismatch")]

        public string Cpwd { get; set; }
        public string msg { get; set; }
    }
}