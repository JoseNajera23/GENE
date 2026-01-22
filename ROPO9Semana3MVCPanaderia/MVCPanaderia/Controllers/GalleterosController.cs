using MVCPanaderia.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCPanaderia.Controllers
{
    public class GalleterosController : Controller
    {
        private PanaderiaModel db = new PanaderiaModel();

        // GET: Galleteros
        public ActionResult Index()
        {
            var galleteros = db.Galleteroes.Select(g => new GalletoDTO
            {
                EmpleadoID = g.EmpleadoID,
                ProductoID = g.ProductoID,
                Nombre = g.Nombre,
                Ocupacion = g.Ocupacion,
                TipoGalleta = g.TipoGalleta,
                Cantidad = g.Cantidad,
                Stock = g.Stock
            }).ToList();

            return View(galleteros);
        }

        // GET: Galleteros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var galletero = db.Galleteroes.FirstOrDefault(g => g.EmpleadoID == id);
            if (galletero == null)
            {
                return HttpNotFound();
            }

            var galleteroDTO = new GalletoDTO
            {
                EmpleadoID = galletero.EmpleadoID,
                ProductoID = (int)galletero.ProductoID,
                Nombre = galletero.Nombre,
                Ocupacion = galletero.Ocupacion,
                TipoGalleta = galletero.TipoGalleta,
                Cantidad = galletero.Cantidad,
                Stock = galletero.Stock
            };

            return View(galleteroDTO);
        }

        // GET: Galleteros/Create
        public ActionResult Create()
        {
            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto");
            return View();
        }

        // POST: Galleteros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GalletoDTO galleteroDTO)
        {
            if (ModelState.IsValid)
            {
                var galletero = new Galletero
                {
                    ProductoID = galleteroDTO.ProductoID,
                    Nombre = galleteroDTO.Nombre,
                    Ocupacion = galleteroDTO.Ocupacion,
                    TipoGalleta = galleteroDTO.TipoGalleta,
                    Cantidad = galleteroDTO.Cantidad,
                    Stock = galleteroDTO.Stock
                };

                db.Galleteroes.Add(galletero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto", galleteroDTO.ProductoID);
            return View(galleteroDTO);
        }

        // GET: Galleteros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var galletero = db.Galleteroes.Find(id);
            if (galletero == null)
            {
                return HttpNotFound();
            }

            var galleteroDTO = new GalletoDTO
            {
                EmpleadoID = galletero.EmpleadoID,
                ProductoID = (int)galletero.ProductoID,
                Nombre = galletero.Nombre,
                Ocupacion = galletero.Ocupacion,
                TipoGalleta = galletero.TipoGalleta,
                Cantidad = galletero.Cantidad,
                Stock = galletero.Stock
            };

            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto", galleteroDTO.ProductoID);
            return View(galleteroDTO);
        }

        // POST: Galleteros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GalletoDTO galleteroDTO)
        {
            if (ModelState.IsValid)
            {
                var galletero = db.Galleteroes.Find(galleteroDTO.EmpleadoID);
                if (galletero == null)
                {
                    return HttpNotFound();
                }

                galletero.ProductoID = galleteroDTO.ProductoID;
                galletero.Nombre = galleteroDTO.Nombre;
                galletero.Ocupacion = galleteroDTO.Ocupacion;
                galletero.TipoGalleta = galleteroDTO.TipoGalleta;
                galletero.Cantidad = galleteroDTO.Cantidad;
                galletero.Stock = galleteroDTO.Stock;

                db.Entry(galletero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto", galleteroDTO.ProductoID);
            return View(galleteroDTO);
        }

        // GET: Galleteros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var galletero = db.Galleteroes.FirstOrDefault(g => g.EmpleadoID == id);
            if (galletero == null)
            {
                return HttpNotFound();
            }

            var galleteroDTO = new GalletoDTO
            {
                EmpleadoID = galletero.EmpleadoID,
                ProductoID = (int)galletero.ProductoID,
                Nombre = galletero.Nombre,
                Ocupacion = galletero.Ocupacion,
                TipoGalleta = galletero.TipoGalleta,
                Cantidad = galletero.Cantidad,
                Stock = galletero.Stock
            };

            return View(galleteroDTO);
        }

        // POST: Galleteros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var galletero = db.Galleteroes.Find(id);
            if (galletero != null)
            {
                db.Galleteroes.Remove(galletero);
                db.SaveChanges();
            }
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
