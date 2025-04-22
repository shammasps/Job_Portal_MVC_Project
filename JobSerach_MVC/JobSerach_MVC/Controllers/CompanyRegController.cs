using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSerach_MVC.Models;

namespace JobSerach_MVC.Controllers
{
    public class CompanyRegController : Controller
    {
        Mvc_ProjectEntities db = new Mvc_ProjectEntities();
        // GET: CompanyReg
        public ActionResult InsertCompany_PageLoad()
        {

            return View();
        }

        public ActionResult InsertCompany_Click(CompanyInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = db.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regId = 0;
                if (mid == 0)
                {
                    regId = 1;
                }
                else
                {
                    regId = mid + 1;
                }
                db.sp_companyInsert(regId, clsobj.Cmp_Name, clsobj.Cmp_Address, clsobj.Cmp_Email, clsobj.Cmp_WebAddress, clsobj.Cmp_Phone);
                db.sp_logInsert(regId, clsobj.username, clsobj.password, "Company");
                clsobj.Cmp_msg = "successfully inserted";
                return RedirectToAction("Login_PageLoad", "Login");
            }
            return View("InsertCompany_PageLoad", clsobj);
        }
    }
}