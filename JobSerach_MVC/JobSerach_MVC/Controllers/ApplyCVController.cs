    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using JobSerach_MVC.Models;

    namespace JobSerach_MVC.Controllers
    {
        public class ApplyCVController : Controller
        {
            Mvc_ProjectEntities db = new Mvc_ProjectEntities();
            // GET: ApplyCV
            public ActionResult ApplyCV_Load(int cid,int jid)
            {
                TempData["cid"] = cid;
                TempData["jid"] = jid;
                return View();
            }

            public ActionResult Apply_click(CVInsert cvobj, JobSearch jobj, HttpPostedFileBase file)
            {
                if (file == null || file.ContentLength == 0)
                {
                    ModelState.AddModelError("Resume", "Upload Your CV");
                    return View("ApplyCV_Load", cvobj);
                }
                if (ModelState.IsValid)
                {
                    if (file.ContentLength > 0)
                    {
                        string fname = Path.GetFileName(file.FileName);
                        var s = Server.MapPath("~/Resume");
                        string pa = Path.Combine(s, fname);
                        file.SaveAs(pa);

                        var fulpath = Path.Combine("~\\Resume", fname);
                        cvobj.Resume = fulpath;
                    }
                
                    cvobj.Sub_date = DateTime.Now;
                    db.sp_applycv(Convert.ToInt32(Session["usid"]), Convert.ToInt32(TempData["jid"]), Convert.ToInt32(TempData["cid"]), cvobj.Resume, cvobj.Sub_date, "Applied");
                    cvobj.msg = "Application Submitted";
                    return View("ApplyCV_Load", cvobj);
                }
                return View("ApplyCV_Load", cvobj);
            }

        }
    }