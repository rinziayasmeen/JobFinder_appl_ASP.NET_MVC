using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobFinder_appl.Models
{

    public class ApplyjobCls
    {
        public int u_id { get; set; }
        public int job_id { get; set; }
        
        public string cv { get; set; }
        public DateTime appl_date { get; set; }
        
        public string msg { get; set; }
    }
}