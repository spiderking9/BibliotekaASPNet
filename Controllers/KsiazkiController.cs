using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibliotekaProgmat.Models;
using Microsoft.AspNet.Identity;

namespace BibliotekaProgmat.Controllers
{
    public class KsiazkiController : Controller
    {
        private BibliotekaContext db = new BibliotekaContext();

        // GET: Ksiazki
        public ActionResult Index()
        {
            return View(db.Ksiazki.ToList());
        }

        // GET: Ksiazki/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }

        // GET: Ksiazki/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ksiazki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idksiazki,Nazwa,Autor,DataWydania,Opis")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Ksiazki.Add(ksiazka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ksiazka);
        }

        // GET: Ksiazki/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Ksiazka ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
                return HttpNotFound();

            return View(ksiazka);
        }

        // POST: Ksiazki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idksiazki,Nazwa,Autor,DataWydania,Opis")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ksiazka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ksiazka);
        }

        // GET: Ksiazki/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Ksiazka ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
                return HttpNotFound();
            return View(ksiazka);
        }

        // POST: Ksiazki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            db.Ksiazki.Remove(ksiazka);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Zarezerwuj(int id)
        {
            string userId = User.Identity.GetUserId();
            if (!db.Rezerwacje.Where(x => x.IdKsiazki == id && x.IdUser == userId).Any())
            {
                db.Rezerwacje.Add(new Rezerwacja { IdKsiazki = id, IdUser = userId, DataRezerwacji = DateTime.Now });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // GET: Ksiazki/ListaRezerwacji/5
        public ActionResult ListaRezerwacji(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
                return HttpNotFound();
            ViewBag.Ksiazka = "'" + ksiazka.Nazwa + "' autorstwa: " + ksiazka.Autor;
            IEnumerable<Rezerwacja> rezerwacje = db.Rezerwacje.Where(x => x.IdKsiazki == id).ToList();
            return View(rezerwacje);
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
