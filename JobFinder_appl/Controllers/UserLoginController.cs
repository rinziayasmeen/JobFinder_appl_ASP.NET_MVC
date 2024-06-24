using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobFinder_appl.Models;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;

namespace JobFinder_appl.Controllers
{
    public class UserLoginController : Controller
    {
        Job_finder_dbEntities dbobj = new Job_finder_dbEntities();
        // GET: UserLogin
        public ActionResult Login_Pageload()
        {
            return View();
        }

        public ActionResult CompanyHome()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult Login_Click(Logincls clsobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(clsobj.Uname, clsobj.Password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_loginid(clsobj.Uname, clsobj.Password).FirstOrDefault();
                    Session["uid"] = uid;
                    var ltype = dbobj.sp_logintype(clsobj.Uname, clsobj.Password).FirstOrDefault();
                    if (ltype == "user")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (ltype == "company")
                    {
                        return RedirectToAction("CompanyHome");
                    }
                }

            }
            else
            {
                ModelState.Clear();
                clsobj.msg = "Invalid login";
                return View("Login_Pageload", clsobj);
            }
            return View("Login_Pageload", clsobj);
        }




    }
}