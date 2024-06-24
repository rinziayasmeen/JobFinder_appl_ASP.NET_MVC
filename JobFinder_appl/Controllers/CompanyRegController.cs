using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobFinder_appl.Models;

namespace JobFinder_appl.Controllers
{
    public class CompanyRegController : Controller
    {
        Job_finder_dbEntities dbobj = new Job_finder_dbEntities();
        // GET: CompanyReg
        public ActionResult InsertComp_Pageload()
        {
            return View();
        }
        public ActionResult InsertComp_Click(CompInsert clsobj)
        {
            if (ModelState.IsValid)
            {
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
                dbobj.sp_compReg(regid, clsobj.cname, clsobj.address, clsobj.phone, clsobj.email, clsobj.websiteaddr, clsobj.location);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pwd, "company");
                clsobj.msg = "Successfully inserted";
                return View("InsertComp_Pageload", clsobj);
            }
            return View("InsertComp_Pageload", clsobj);         
        }
    }
}