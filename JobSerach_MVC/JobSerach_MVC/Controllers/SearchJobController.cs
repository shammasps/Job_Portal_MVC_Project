using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSerach_MVC.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JobSerach_MVC.Controllers
{
    public class SearchJobController : Controller
    {
        Mvc_ProjectEntities db = new Mvc_ProjectEntities();
        // GET: SearchJob
        public ActionResult searchJob_PageLoad()
        {
            return View(GetData());
        }
        private JobSearch GetData()
        {
            var joblist = new JobSearch();
            var job = db.Company_JobAdd_TB.ToList();
            foreach (var e in job)
            {
                var jobcls = new Jsearch();
                jobcls.Jobid = e.Job_Id;
                jobcls.companyId = e.Company_Id;
                jobcls.Jobtitle = e.Job_Title;
                jobcls.skills = e.Job_Skills;
                jobcls.JobExp = e.Jobexp_Year;
                jobcls.JobStatus = e.Job_Status;
                jobcls.JobEndDate =e.Job_EndDate;

                var company = db.CompanyRegTBs.FirstOrDefault(c => c.Company_Id == e.Company_Id);
                jobcls.CompanyName = company.Company_Name;

                joblist.selectjob.Add(jobcls);

            }
            return joblist;
        }

        public ActionResult Searchjob_Click(JobSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.skills))
            {
                qry += " and Job_Skills like '%" + clsobj.insertse.skills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.JobExp.ToString()))
            {
                qry += " and Jobexp_Year like '%" + clsobj.insertse.JobExp + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.CompanyName))
            {
                qry += " and Company_Name like '%" + clsobj.insertse.CompanyName + "%'";
            }

            return View("searchJob_PageLoad", getdata1(clsobj, qry));
        }

        private JobSearch getdata1(JobSearch clsobj,string qry)
        {
            using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while (dr.Read())
                {
                    var jobcls = new Jsearch();
                    jobcls.CompanyName = dr["Company_Name"].ToString();
                    jobcls.Jobtitle = dr["Job_Title"].ToString();
                    jobcls.skills = dr["Job_Skills"].ToString();
                    jobcls.JobExp = Convert.ToInt32(dr["Jobexp_Year"].ToString());
                    jobcls.JobStatus = dr["Job_Status"].ToString();
                    jobcls.JobEndDate = Convert.ToDateTime( dr["Job_EndDate"]);

                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }

    }

   
}