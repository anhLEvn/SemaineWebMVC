using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVCDemo.Models;

namespace WebAppMVCDemo.Controllers
{
    public class AbonnesController : Controller
    {
        List<Abonne> listeAbonnes; 

        public AbonnesController()
        {
            if(listeAbonnes == null)
            {
                listeAbonnes = new List<Abonne>();

            }
        }
        // GET: Anonnes
        public ActionResult Index()
        {
            Abonne ab = new Abonne();
            ab.Id = 15;    ab.Nom = "LE"; ab.Email = "Anh@mail"; 
            return View(ab); // ici on a un dossier Abonnes et que ce dossier contient un fichier index.html
        }

        public ActionResult Liste()
        {
           return View(GetListe()); 
        }

        public List<Abonne> GetListe()
        {
            Random x = new Random();
            //List<Abonne> listeAbonnes = new List<Abonne>(); 
            if(listeAbonnes.Count == 0)
            {
               
           
            for(int i = 0; i< 100; i++)
            {
                Abonne abn = new Abonne();
                int j = x.Next(1, 1000);
                abn.Id = j;
                abn.Nom = "Nom" + j;
                abn.Email = "Prénom" + j;
                listeAbonnes.Add(abn); 
            }
            }
            return listeAbonnes; 
        }

        public ActionResult Liste2()
        {
            return View(GetListe());
        }

        public ActionResult Liste3()
        {
            return View(GetListe());
        }

        [HttpGet]
        public ActionResult Saisie()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Saisie(Abonne abonne)
        {
            if(!ModelState.IsValid)
            {
                return View(abonne); 
            }
            ViewBag.Nom = abonne.Nom;
            ViewData["Email"] = abonne.Email;
            return View("Succes");
        }

        public ActionResult Formulaire(Abonne abonne)
        {
            return View();
        }


        [HttpGet]
        public ActionResult SaisieHelper()
        {

            return View(); 
        }

        [HttpPost]
        public ActionResult SaisieHelper(Abonne abonne)
        {
            if (!ModelState.IsValid)
            {
                return View(abonne);
            }
           
            return View("Succes");
           
        }


        [HttpGet]
        public ActionResult SaisieHelper2()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SaisieHelper2(Abonne abonne)
        {
            if (!ModelState.IsValid)
            {
                return View(abonne);
            }

            return View("Succes");
        }

        [HttpGet]
        public ActionResult Modif(int id)
        {
            Abonne abonneAModif = listeAbonnes.FirstOrDefault(x => x.Id == id);
            // TODO: tester s'il existe
            return View(abonneAModif); 
        }


        [HttpPost]
        public ActionResult Modif(Abonne abonne)
        {
            if (ModelState.IsValid)
            {
                Abonne abonneAModif = listeAbonnes.FirstOrDefault(x => x.Id == abonne.Id);
                abonneAModif.Nom = abonne.Nom;
                abonneAModif.Email = abonne.Email;

                //return View(abonneAModif); 
                return RedirectToAction("Liste3"); 
            }
            return View(abonne); 
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Abonne abonneASupprimer = listeAbonnes.FirstOrDefault(x => x.Id == id);

                listeAbonnes.Remove(abonneASupprimer);
                return Json(new { resultat = "OK" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { resultat = "NOK" }, JsonRequestBehavior.AllowGet); 
        }
        
    }
}