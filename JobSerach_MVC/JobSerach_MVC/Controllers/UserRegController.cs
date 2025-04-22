using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSerach_MVC.Models;

namespace JobSerach_MVC.Controllers
{
    public class UserRegController : Controller
    {
        Mvc_ProjectEntities db = new Mvc_ProjectEntities();
        // GET: UserReg
        public ActionResult UserInsert_PageLoad()
        {
            UserInsert model = new UserInsert();
            model.MyQual = getQulification();
            return View(model);
        }
        public List<CheckBoxListBind> getQulification()
        {
            List<CheckBoxListBind> Checkobj = new List<CheckBoxListBind>()
            {
                new CheckBoxListBind{Values="1",Text="SSLC",IsChecked=true},
                new CheckBoxListBind{Values="2",Text="Plus Two",IsChecked=false},
                new CheckBoxListBind{Values="3",Text="BCA",IsChecked=false},
                new CheckBoxListBind{Values="4",Text="MCA",IsChecked=false},
                new CheckBoxListBind{Values="5",Text="BTECH",IsChecked=false},
                new CheckBoxListBind{Values="6",Text="Diploma",IsChecked=false},
                new CheckBoxListBind{Values="7",Text="ITI",IsChecked=false},
                new CheckBoxListBind{Values="8",Text="Others",IsChecked=false}
            };
            return Checkobj;
        }

        public ActionResult UserInsert_Click(UserInsert clsobj, HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("Photo", "Upload Your Photo");
                return View("UserInsert_PageLoad", clsobj);
            }
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
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/img");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fulpath = Path.Combine("~\\img", fname);
                    clsobj.uPhoto = fulpath;
                }

                var quid = string.Join(",", clsobj.selectedQual);
                clsobj.uQulfication = quid;
                clsobj.MyQual = getQulification();

                clsobj.uDOB.ToString("dd-MM-yyyy");
                db.sp_userInsert(regId, clsobj.uName, clsobj.uAddress, clsobj.uPhone, clsobj.uEmail, clsobj.uSkills, clsobj.uExp, clsobj.uQulfication, clsobj.uDOB, clsobj.uCountry, clsobj.uState, clsobj.uCity, clsobj.uGender, clsobj.uPhoto, clsobj.uPincode, clsobj.uLinkedIn_Profile);
                db.sp_logInsert(regId, clsobj.username, clsobj.password, "User");
                clsobj.usermsg = "successfully inserted";
                return RedirectToAction("Login_PageLoad", "Login");
            }
            return View("UserInsert_PageLoad", clsobj);
        }

        public ActionResult apply_jobs()
        {
            int userid = Convert.ToInt32(Session["usid"]);
            var viewJob = db.Database.SqlQuery<sp_viewApplayjobs_Result>(
             "sp_viewApplayjobs @uid",
             new SqlParameter("@uid", userid)).ToList();
            return View(viewJob);
        }
    }
}