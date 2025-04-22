using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSerach_MVC.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            selectjob = new List<Jsearch>();
            insertse = new Jsearch();
        }
        public Jsearch insertse { get; set; }
        public List<Jsearch> selectjob { get; set; }
    }

    public class Jsearch
    {
        public int Jobid { get; set; }
        public int companyId { get; set; }
        public string CompanyName { get; set; }
        public string Jobtitle { get; set; }
        public string skills { get; set; }
        public int? JobExp { get; set; }
        public string JobStatus { get; set; }
        public DateTime JobEndDate { get; set; }
        public string Jobmsg { get; set; }

    }
}