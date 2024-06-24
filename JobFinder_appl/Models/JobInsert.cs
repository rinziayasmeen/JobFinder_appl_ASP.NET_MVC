using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobFinder_appl.Models
{
    public class checkBoxListSkillscls
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class JobInsert
    {
        [Required(ErrorMessage ="Enter job title")]
        public string Job_title { get; set; }
        [Required(ErrorMessage = "Enter experience required")]

        public string Experience { get; set; }
        //[Required(ErrorMessage = "Enter skills required")]

        public string Skills { get; set; }

        public List<checkBoxListSkillscls> MyFavouriteSkills { get; set; }
        public string[] SelectedSkills { get; set; }

        public int No_of_vacancy { get; set; }
        [Required(ErrorMessage = "Enter date")]

        //public DateTime ldate { get; set; }
        [Display(Name ="Laste Date")]
        [DataType(DataType.Date)]
        
        public DateTime ? ldate { get; set; }
        public string msg1 { get; set; }
        public string msg { get; set; }
    }
}