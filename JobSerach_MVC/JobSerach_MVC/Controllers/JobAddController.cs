using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSerach_MVC.Models;

namespace JobSerach_MVC.Controllers
{
    public class JobAddController : Controller
    {
        Mvc_ProjectEntities db = new Mvc_ProjectEntities();
        // GET: JobAdd
        public ActionResult JobAdd_PageLoad()
        {
            return View();
        }

        public ActionResult JobAdd_Click(AddJob clsobj)
        {
            if (ModelState.IsValid)
            {
                int companyId = Convert.ToInt32(Session["cid"]);

                db.sp_companyJobAdd(companyId, clsobj.Job_Title, clsobj.Job_Description, clsobj.Job_Skills, clsobj.Jobexp_Year, clsobj.Min_Qulification, "Hiring", clsobj.Job_EndDate);
                //clsobj.msg = "Job Added Successfully";

                return RedirectToAction("CompanyHome", "Login");
            }

            return View("JobAdd_PageLoad", clsobj);
        }


    }
}