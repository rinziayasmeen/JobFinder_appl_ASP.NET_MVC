using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobFinder_appl.Models
{
    public class checkBoxListSkills
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class checkBoxListHelper
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }

    public class UserInsert
    {
        [Required(ErrorMessage = "Enter the company name")]

        public string name { get; set; }
        [Range(20,60,ErrorMessage ="Enter age between 20 and 60")]
        public int age { get; set; }
        [Required(ErrorMessage = "Enter the address")]

        public string address { get; set; }
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter the valid phone number")]

        public string phone { get; set; }
        [EmailAddress(ErrorMessage = "Enter the email id")]

        public string email { get; set; }
        public string qualifictn { get; set; }

        public List<checkBoxListHelper> MyFavouriteQual { get; set; }
        public string[] SelectedQual { get; set; }
        [Required(ErrorMessage = "Enter the experience")]

        public int experience { get; set; }
        

        public string skills { get; set; }
        public List<checkBoxListSkills> MyFavouriteSkills { get; set; }
        public string[] SelectedSkills { get; set; }
        public string photo { get; set; }


        public string resume { get; set; }
        [Required(ErrorMessage = "Enter the username")]

        public string username { get; set; }
        public string pwd { get; set; }
        [Compare("pwd",ErrorMessage ="Password mismatch")]
        public string Cpassword { get; set; }
        public string msg { get; set; }
    }
}