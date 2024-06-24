using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobFinder_appl.Models
{
    public class JobsearchCls
    {
        public JobsearchCls()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }
        public jsearch insertse { set; get; }
        public List<jsearch> selectjob { set; get; }
    }

   
    public class jsearch
    {
        public int job_id { set; get; }
        public int c_id { set; get; }


        public string skills { set; get; }
        public string experience { set; get; }
        public string Job_title { set; get; }

        public string job_sts { get; set; }
        public DateTime lastdate { set; get; }
        public string jmsg { set; get; }



    }
}