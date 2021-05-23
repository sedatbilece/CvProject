using CvProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models;

namespace CvProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {


        DbCvEntities db = new DbCvEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //ADMIN
        public ActionResult AdminUpdate()
        {
            var hkm = db.admin.FirstOrDefault();

            return View(hkm);
        }
        [HttpPost]
        public ActionResult AdminUpdate(admin adm)
        {
            var x = db.admin.FirstOrDefault();
            x.kullaniciadi = adm.kullaniciadi;
            x.sifre = adm.sifre;
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        //   HAKKIMDA
        public ActionResult HakkimdaUpdate()
        {
            var hkm = db.Hakkimda.FirstOrDefault();

            return View(hkm);
        }
        [HttpPost]
        public ActionResult HakkimdaUpdate(Hakkimda hkm)
        {
            var x=db.Hakkimda.FirstOrDefault();
            x.ad = hkm.ad;
            x.soyad = hkm.soyad;
            x.mail = hkm.mail;
            x.adres = hkm.adres;
            x.aciklama = hkm.aciklama;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // DENEYIMLER
        public ActionResult DeneyimlerGet()
        {
          List<Deneyimler> ld=  db.Deneyimler.ToList();

            return View(ld);
        }

        [HttpPost]
        public ActionResult DeneyimlerEkle(Deneyimler dd)
        {
            db.Deneyimler.Add(dd);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            var den = db.Deneyimler.Find(id);
            db.Deneyimler.Remove(den);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        //SOSYAL
        public ActionResult SosyalGetir()
        {
            List<egitim> ld = db.egitim.ToList();

            return View(ld);
        }
        [HttpPost]
        public ActionResult SosyalEkle(egitim dd)
        {
            db.egitim.Add(dd);
            db.SaveChanges();

           
            return RedirectToAction("Index");
        }
        public ActionResult SosyalSil(int id)
        {
            var den = db.egitim.Find(id);
            db.egitim.Remove(den);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        // SERTIFIKALAR
        public ActionResult SertifikalarGet()
        {
            List<Sertifikalar> ld = db.Sertifikalar.ToList();

            return View(ld);
        }

        [HttpPost]
        public ActionResult SertifikaEkle(Sertifikalar st)
        {
            db.Sertifikalar.Add(st);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var den = db.Sertifikalar.Find(id);
            db.Sertifikalar.Remove(den);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //YETENEKLER 
        public ActionResult YeteneklerGet()
        {
            List<Hobilerim> ld = db.Hobilerim.ToList();

            return View(ld);
        }
        [HttpPost]
        public ActionResult YetenekEkle(Hobilerim st)
        {
            db.Hobilerim.Add(st);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var den = db.Hobilerim.Find(id);
            db.Hobilerim.Remove(den);
            db.SaveChanges();

            return RedirectToAction("Index","Admin");
        }

        //ILETISIM
        public ActionResult MesajGetir()
        {
            List<iletisim> msj = db.iletisim.ToList();

            return View(msj);
        }

        public ActionResult MesajSil(int id)
        {
            var den = db.iletisim.Find(id);
            db.iletisim.Remove(den);
            db.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }


    }
}