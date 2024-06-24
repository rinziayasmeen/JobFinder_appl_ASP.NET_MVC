using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobFinder_appl.Models;

namespace JobFinder_appl.Controllers
{
    public class UserRegController : Controller
    {
        Job_finder_dbEntities dbobj = new Job_finder_dbEntities();

        // GET: UserReg
        public ActionResult InsertUser_Pageload()
        {
            //checkboclist
            UserInsert user = new UserInsert();
            user.MyFavouriteQual = getQualificationData();
            user.MyFavouriteSkills = getSkillsData();
            return View(user);
        }
        public List<checkBoxListHelper> getQualificationData()
        {
            List<checkBoxListHelper> sts = new List<checkBoxListHelper>()
            {
                new checkBoxListHelper { Value = "SSLC", Text = "SSLC", IsChecked = true },
                new checkBoxListHelper { Value = "PLUSTWO", Text = "PLUSTWO", IsChecked = false },
                new checkBoxListHelper { Value = "BCA", Text = "BCA", IsChecked = false },
                new checkBoxListHelper { Value = "MCA", Text = "MCA", IsChecked = false },
                new checkBoxListHelper { Value = "BTECH", Text = "BTECH", IsChecked = false }

            };
            return sts;       
        }

        public List<checkBoxListSkills> getSkillsData()
        {
            List<checkBoxListSkills> sts = new List<checkBoxListSkills>()
            {
                new checkBoxListSkills { Value = "C#", Text = "C#", IsChecked = true },
                new checkBoxListSkills { Value = "ASP.NET", Text = "ASP.NET", IsChecked = false },
                new checkBoxListSkills { Value = "ASP.NET MVC", Text = "ASP.NET MVC", IsChecked = false },
                new checkBoxListSkills { Value = "HTML", Text = "HTML", IsChecked = false },
                new checkBoxListSkills { Value = "CSS", Text = "CSS", IsChecked = false },
                new checkBoxListSkills { Value = "JAVASCRIPT", Text = "JAVASCRIPT", IsChecked = false }

            };
            return sts;
        }
        public ActionResult InsertUser_Click(UserInsert clsobj,HttpPostedFileBase file1,HttpPostedFileBase file2)
        {
            if (ModelState.IsValid)
            {
                if (file1.ContentLength > 0)
                {
                    //folder save
                    string fname = Path.GetFileName(file1.FileName);
                    var s = Server.MapPath("~/Photos");
                    string pa = Path.Combine(s, fname);
                    file1.SaveAs(pa);

                    //for table save
                    var fullpath = Path.Combine("~\\Photos", fname);
                    clsobj.photo = fullpath;   //set
                }

                if (file2.ContentLength > 0)
                {
                    //folder save
                    string fname = Path.GetFileName(file2.FileName);
                    var s = Server.MapPath("~/Photos");
                    string pa = Path.Combine(s, fname);
                    file2.SaveAs(pa);

                    //for table save
                    var fullpath = Path.Combine("~\\Photos", fname);
                    clsobj.resume = fullpath;   //set
                }

                var quid = string.Join(",", clsobj.SelectedQual);
                clsobj.qualifictn = quid; //set
                clsobj.MyFavouriteQual = getQualificationData();//get


                var skill = string.Join(",", clsobj.SelectedSkills);
                clsobj.skills = skill;
                clsobj.MyFavouriteSkills = getSkillsData();


                //insert
                var getmaxid = dbobj.sp_Maxidlogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_userReg(regid, clsobj.name, clsobj.age, clsobj.address, clsobj.phone, clsobj.email, clsobj.qualifictn, clsobj.experience, clsobj.skills, clsobj.photo, clsobj.resume);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.Cpassword, "user");
                clsobj.msg = "Successfully Registered";
                return View("InsertUser_Pageload", clsobj);

            }
            else
            {
                clsobj.MyFavouriteQual = getQualificationData();
                clsobj.MyFavouriteSkills = getSkillsData();
            }
            return View("InsertUser_Pageload", clsobj);

               
        }
    }
}