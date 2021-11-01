using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationASPAuth2.Models;
using System.IO;
using System.Configuration;

namespace WebApplicationASPAuth2.Controllers
{
    [Authorize] // la page est soumis à une authentifier
    public class ProduitsController : Controller
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produits
        [AllowAnonymous] // permet l'acces à des internautes (users non autorisé)
        public async Task<ActionResult> Index()
        {
            var produits = db.Produits.Include(p => p.Categorie);
            return View(await produits.ToListAsync());
        }

        // GET: Produits/Details/5
        [Authorize(Roles = "ADMIN, SAISIE")]
         public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = await db.Produits.FindAsync(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: Produits/Create
        [Authorize(Roles = "SAISIE")]
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Designation");
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Libelle,Photo,CategorieId")] Produit produit, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                //verfier que le fichier est valide = not null
                //copie l'image danse le dossier des images
                // on met la path dans produit.Photo 
                if(Photo != null && Photo.ContentLength > 0)
                {
                    //var fileName = Path.GetFileName(Photo.FileName);
                    //string dossierImg = ConfigurationManager.AppSettings["PhotosDossier"];
                    //var path = Path.Combine(Server.MapPath(dossierImg), fileName);
                    //Photo.SaveAs(path);
                    //produit.Photo = fileName; 

                    if (Photo != null && Photo.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(Photo.FileName);
                        string dossierImg = ConfigurationManager.AppSettings["photosDossier"];

                        var path = Path.Combine(Server.MapPath(dossierImg), fileName);
                        Photo.SaveAs(path);

                        produit.Photo = fileName;

                    }

                }
                db.Produits.Add(produit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Designation", produit.CategorieId);
            return View(produit);
        }

        // GET: Produits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = await db.Produits.FindAsync(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Designation", produit.CategorieId);
            return View(produit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Libelle,Photo,CategorieId")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Designation", produit.CategorieId);
            return View(produit);
        }

        // GET: Produits/Delete/5
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = await db.Produits.FindAsync(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Produit produit = await db.Produits.FindAsync(id);
            db.Produits.Remove(produit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
