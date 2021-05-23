using CvProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CvProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(admin p)
        {
            DbCvEntities db = new DbCvEntities();
            var info = db.admin.FirstOrDefault(x=>x.kullaniciadi==p.kullaniciadi && x.sifre==p.sifre );


            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.kullaniciadi, false);
                Session["kullaniciadi"] = info.kullaniciadi.ToString();
                return RedirectToAction("Index", "Admin");

            }

            else
            {
                return RedirectToAction("Index", "Login");
            }

           
        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();

            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}