using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobFinder_appl.Models;

namespace JobFinder_appl.Controllers
{
    public class ApplyJobController : Controller
    {
        Job_finder_dbEntities dbobj = new Job_finder_dbEntities();
        // GET: ApplyJob
        public ActionResult Applyjob_Pageload(int cid, int jid)
        {
            TempData["cid"] = cid;
            TempData["jid"] = jid;
            return View();
        }

        public ActionResult Applyjob_Click(ApplyjobCls clsobj, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                if (file1.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file1.FileName);
                    var s = Server.MapPath("~/PHS");
                    string pa = Path.Combine(s, fname);
                    file1.SaveAs(pa);

                    var fullpath = Path.Combine("~\\PHS", fname);
                    clsobj.cv = fullpath;
                }
                string dt=DateTime.Now.ToShortDateString();
                clsobj.appl_date =Convert.ToDateTime(DateTime.Now.ToShortDateString());
                

                dbobj.sp_applyjob_insert(Convert.ToInt32(Session["uid"]),Convert.ToInt32(TempData["cid"]),Convert.ToInt32(TempData["jid"]), clsobj.cv,clsobj.appl_date,"applied");
                clsobj.msg = "Uploaded";
                return View("Applyjob_Pageload",clsobj);
            }

            return View("Applyjob_Pageload",clsobj);
        }
    }
}