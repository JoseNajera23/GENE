using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CamnionesWebMVCv1.Models.DTOs;

namespace CamnionesWebMVCv1.Controllers
{
    public class ChoferesController : Controller
    {
        private GeNeContext1 db = new GeNeContext1();

        // GET: Choferes
        public ActionResult Index()
        {
            return View(db.Choferes.ToList());
        }

        // GET: Choferes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chofere chofere = db.Choferes.Find(id);
            if (chofere == null)
            {
                return HttpNotFound();
            }
            return View(chofere);
        }

        // GET: Choferes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Choferes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdChofer,Nombre,ApPaterno,ApMaterno,Telefono,FechaNacimiento,Licencia,UrlFoto,Disponibilidad,FechaRegistro")] Chofere chofere)
        {
            if (ModelState.IsValid)
            {
                db.Choferes.Add(chofere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chofere);
        }

        // GET: Choferes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chofere chofere = db.Choferes.Find(id);
            if (chofere == null)
            {
                return HttpNotFound();
            }
            return View(chofere);
        }

        // POST: Choferes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdChofer,Nombre,ApPaterno,ApMaterno,Telefono,FechaNacimiento,Licencia,UrlFoto,Disponibilidad,FechaRegistro")] Chofere chofere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chofere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chofere);
        }

        // GET: Choferes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chofere chofere = db.Choferes.Find(id);
            if (chofere == null)
            {
                return HttpNotFound();
            }
            return View(chofere);
        }

        // POST: Choferes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chofere chofere = db.Choferes.Find(id);
            db.Choferes.Remove(chofere);
            db.SaveChanges();
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
