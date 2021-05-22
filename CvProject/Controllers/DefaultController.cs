﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models.Entity;

namespace CvProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        DbCvEntities db = new DbCvEntities();

        public ActionResult Index()
        {
            var degerler = db.Hakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyimler()
        {
            var deneyimler = db.Deneyimler.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Sertifikalar()
        {
            var Sertifikalar = db.Sertifikalar.ToList();
            return PartialView(Sertifikalar);
        }

        public PartialViewResult Yetenekler()
        {
            var yetenekler = db.Hobilerim.ToList();
            return PartialView(yetenekler);
        }
    }
}