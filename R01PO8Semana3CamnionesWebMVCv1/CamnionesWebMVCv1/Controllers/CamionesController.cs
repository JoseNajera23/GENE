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
    public class CamionesController : Controller
    {
        private GeNeContext1 db = new GeNeContext1();

        // GET: Camiones
        public ActionResult Index()
        {
            return View(db.Camiones.ToList());
        }

        // GET: Camiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camione camione = db.Camiones.Find(id);
            if (camione == null)
            {
                return HttpNotFound();
            }
            return View(camione);
        }

        // GET: Camiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCamion,Matricula,TipoCamion,Modelo,Marca,Capacidad,Kilometraje,Disponibilidad,UrlFoto,FechaRegistro")] Camione camione)
        {
            if (ModelState.IsValid)
            {
                db.Camiones.Add(camione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(camione);
        }

        // GET: Camiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camione camione = db.Camiones.Find(id);
            if (camione == null)
            {
                return HttpNotFound();
            }
            return View(camione);
        }

        // POST: Camiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCamion,Matricula,TipoCamion,Modelo,Marca,Capacidad,Kilometraje,Disponibilidad,UrlFoto,FechaRegistro")] Camione camione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camione);
        }

        // GET: Camiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camione camione = db.Camiones.Find(id);
            if (camione == null)
            {
                return HttpNotFound();
            }
            return View(camione);
        }

        // POST: Camiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Camione camione = db.Camiones.Find(id);
            db.Camiones.Remove(camione);
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
