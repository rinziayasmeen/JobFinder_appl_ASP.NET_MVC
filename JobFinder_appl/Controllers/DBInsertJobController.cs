using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobFinder_appl.Models;

namespace JobFinder_appl.Controllers
{
    public class DBInsertJobController : Controller
    {
        Job_finder_dbEntities dbobj = new Job_finder_dbEntities();
        // GET: DBInsertJob
        public ActionResult InsertJob_Pageload()
        {
            JobInsert job = new JobInsert();
            
            job.MyFavouriteSkills = getSkillsData();
            return View(job);
            
        }

        public List<checkBoxListSkillscls> getSkillsData()
        {
            List<checkBoxListSkillscls> sts = new List<checkBoxListSkillscls>()
            {
                new checkBoxListSkillscls { Value = "C#", Text = "C#", IsChecked = true },
                new checkBoxListSkillscls { Value = "ASP.NET", Text = "ASP.NET", IsChecked = false },
                new checkBoxListSkillscls { Value = "ASP.NET MVC", Text = "ASP.NET MVC", IsChecked = false },
                new checkBoxListSkillscls { Value = "HTML", Text = "HTML", IsChecked = false },
                new checkBoxListSkillscls { Value = "CSS", Text = "CSS", IsChecked = false },
                new checkBoxListSkillscls { Value = "JAVASCRIPT", Text = "JAVASCRIPT", IsChecked = false }

            };
            return sts;
        }
        public ActionResult InsertJob_Click(JobInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var skill = string.Join(",", clsobj.SelectedSkills);
                clsobj.Skills = skill;
                clsobj.MyFavouriteSkills = getSkillsData();


                //string dt = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd");
                dbobj.sp_insertJob(Convert.ToInt32(Session["uid"].ToString()), clsobj.Job_title, clsobj.Experience, clsobj.Skills, clsobj.No_of_vacancy, clsobj.ldate, "available");
                clsobj.msg = "Successfully added";
                return View("InsertJob_Pageload", clsobj);
            }
            else
            {
                
                clsobj.MyFavouriteSkills = getSkillsData();
            }
            return View("InsertJob_Pageload", clsobj);
            
        }
    }
}