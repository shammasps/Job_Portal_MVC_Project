using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSerach_MVC.Models;

namespace JobSerach_MVC.Controllers
{
    public class LoginController : Controller
    {
        Mvc_ProjectEntities db = new Mvc_ProjectEntities();
        // GET: Login
        public ActionResult Login_PageLoad()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult CompanyHome()
        {
            return View();
        }

        public ActionResult Login_Click(Login clsobj)
        {
            if (ModelState.IsValid)
            {
                var val = db.sp_loginCountId(clsobj.username, clsobj.password).Single();
                if (val == 1)
                {
                    var uid = db.sp_loginId(clsobj.username, clsobj.password).FirstOrDefault();
                    

                    var LType = db.sp_loginType(clsobj.username, clsobj.password).FirstOrDefault();
                    if (LType == "User")
                    {
                        Session["usid"] = uid;
                        return RedirectToAction("UserHome");
                    }
                    else if (LType == "Company")
                    {
                        Session["cid"] = uid;
                        return RedirectToAction("CompanyHome");
                    }
                }
                else
                {
                    clsobj.msg = "Invalid Username Or Password";
                    return View("Login_PageLoad",clsobj);
                }
            }
            return View("Login_PageLoad");
        }

        public ActionResult ViewJobApplications()
        {
            int companyId = Convert.ToInt32(Session["cid"]);
            var applications = db.Database.SqlQuery<sp_getjobApllication_Result>(
             "sp_getjobApllication @cid",
             new SqlParameter("@cid", companyId)).ToList();
            return View(applications);
        }

        public ActionResult ViewJobs()
        {
            int companyId = Convert.ToInt32(Session["cid"]);
            var viewJob = db.Database.SqlQuery<sp_viewCompanyjobs_Result>(
             "sp_viewCompanyjobs @cid",
             new SqlParameter("@cid", companyId)).ToList();
            return View(viewJob);
        }
    }
}