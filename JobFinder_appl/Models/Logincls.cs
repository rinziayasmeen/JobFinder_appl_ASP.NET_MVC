using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobFinder_appl.Models
{
    public class Logincls
    {
        [Required(ErrorMessage ="Enter the username")]
        public string Uname { get; set; }
        [Required(ErrorMessage = "Enter the password")]

        public string Password { get; set; }
        //public string ltype { get; set; }
        public string msg { get; set; }
    }
}