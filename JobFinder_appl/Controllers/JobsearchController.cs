using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobFinder_appl.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace JobFinder_appl.Controllers
{
    public class JobsearchController : Controller
    {
        Job_finder_dbEntities dbobj = new Job_finder_dbEntities();
        // GET: Jobsearch
        public ActionResult JobSearch_Pageload()
        {
            return View(GetData());
        }


        //public List<JobsearchCls> getAlldata()
        //{
        //    JobsearchCls job = new JobsearchCls();
        //    var jobdata = dbobj.sp_SelectAllJobs().ToList();
        //    return jobdata;
        //}

        //public JobsearchCls getdata(JobsearchCls clsobj, string qry)
        //{
        //    var jobdata = dbobj.sp_jobsearches(qry).ToList();
        //    return jobdata;
        //}



        private JobsearchCls GetData()
        {
            var joblist = new JobsearchCls();
            List<string> lst = new List<string>();

            var job = dbobj.Job_Tabl.ToList();

            foreach (var e in job)
            {
                var jobcls = new jsearch();
                jobcls.job_id = e.Id;
                jobcls.c_id = e.C_id;
                jobcls.skills = e.Skills;
                jobcls.experience = e.Experience;
                jobcls.Job_title = e.Job_title;
                jobcls.job_sts = e.Status;
                jobcls.lastdate = e.Date;

                joblist.selectjob.Add(jobcls);

                var s = jobcls.skills;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
            }
            return joblist;
        }

        public ActionResult jobsearch_click(JobsearchCls clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.experience))
            {
                qry += " and Experience like '%" + clsobj.insertse.experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.skills))
            {
                qry += " and Skills like '%" + clsobj.insertse.skills + "%'";
            }
            

            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_title))
            {
                qry += " and Job_title like '%" + clsobj.insertse.Job_title + "%'";
            }
            return View("JobSearch_Pageload", getdata1(clsobj, qry));
        }


        private JobsearchCls getdata1(JobsearchCls clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobsearchCls();
                while (dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.c_id = Convert.ToInt32(dr["C_id"].ToString());
                    jobcls.skills = dr["Skills"].ToString();
                    jobcls.experience = dr["Experience"].ToString();
                    jobcls.Job_title = dr["Job_title"].ToString();
                    jobcls.job_sts = dr["Status"].ToString();
                    jobcls.lastdate = Convert.ToDateTime(dr["Date"].ToString());

                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;


            }
        }


    }
}