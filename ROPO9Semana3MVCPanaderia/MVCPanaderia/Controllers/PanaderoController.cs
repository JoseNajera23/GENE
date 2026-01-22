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
    public class PanaderosController : Controller
    {
        private PanaderiaModel db = new PanaderiaModel();

        // GET: Panaderos
        public ActionResult Index()
        {
            var panaderos = db.Panaderoes.Include(p => p.Producto).Select(p => new PanaderoDTO
            {
                EmpleadoID = p.EmpleadoID,
                ProductoID = (int)p.ProductoID,
                Nombre = p.Nombre,
                Ocupacion = p.Ocupacion,
                TipoPan = p.TipoPan,
                Cantidad = p.Cantidad,
                Stock = p.Stock
            }).ToList();

            return View(panaderos);
        }

        // GET: Panaderos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var panadero = db.Panaderoes.Include(p => p.Producto).FirstOrDefault(p => p.EmpleadoID == id);
            if (panadero == null)
            {
                return HttpNotFound();
            }

            var panaderoDTO = new PanaderoDTO
            {
                EmpleadoID = panadero.EmpleadoID,
                ProductoID = (int)panadero.ProductoID,
                Nombre = panadero.Nombre,
                Ocupacion = panadero.Ocupacion,
                TipoPan = panadero.TipoPan,
                Cantidad = panadero.Cantidad,
                Stock = panadero.Stock
            };

            return View(panaderoDTO);
        }

        // GET: Panaderos/Create
        public ActionResult Create()
        {
            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto");
            return View();
        }

        // POST: Panaderos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PanaderoDTO panaderoDTO)
        {
            if (ModelState.IsValid)
            {
                var panadero = new Panadero
                {
                    ProductoID = panaderoDTO.ProductoID,
                    Nombre = panaderoDTO.Nombre,
                    Ocupacion = panaderoDTO.Ocupacion,
                    TipoPan = panaderoDTO.TipoPan,
                    Cantidad = panaderoDTO.Cantidad,
                    Stock = panaderoDTO.Stock
                };

                db.Panaderoes.Add(panadero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto", panaderoDTO.ProductoID);
            return View(panaderoDTO);
        }

        // GET: Panaderos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var panadero = db.Panaderoes.Find(id);
            if (panadero == null)
            {
                return HttpNotFound();
            }

            var panaderoDTO = new PanaderoDTO
            {
                EmpleadoID = panadero.EmpleadoID,
                ProductoID = (int)panadero.ProductoID,
                Nombre = panadero.Nombre,
                Ocupacion = panadero.Ocupacion,
                TipoPan = panadero.TipoPan,
                Cantidad = panadero.Cantidad,
                Stock = panadero.Stock
            };

            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto", panaderoDTO.ProductoID);
            return View(panaderoDTO);
        }

        // POST: Panaderos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PanaderoDTO panaderoDTO)
        {
            if (ModelState.IsValid)
            {
                var panadero = db.Panaderoes.Find(panaderoDTO.EmpleadoID);
                if (panadero == null)
                {
                    return HttpNotFound();
                }

                panadero.ProductoID = panaderoDTO.ProductoID;
                panadero.Nombre = panaderoDTO.Nombre;
                panadero.Ocupacion = panaderoDTO.Ocupacion;
                panadero.TipoPan = panaderoDTO.TipoPan;
                panadero.Cantidad = panaderoDTO.Cantidad;
                panadero.Stock = panaderoDTO.Stock;

                db.Entry(panadero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto", panaderoDTO.ProductoID);
            return View(panaderoDTO);
        }

        // GET: Panaderos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var panadero = db.Panaderoes.Include(p => p.Producto).FirstOrDefault(p => p.EmpleadoID == id);
            if (panadero == null)
            {
                return HttpNotFound();
            }

            var panaderoDTO = new PanaderoDTO
            {
                EmpleadoID = panadero.EmpleadoID,
                ProductoID = (int)panadero.ProductoID,
                Nombre = panadero.Nombre,
                Ocupacion = panadero.Ocupacion,
                TipoPan = panadero.TipoPan,
                Cantidad = panadero.Cantidad,
                Stock = panadero.Stock
            };

            return View(panaderoDTO);
        }

        // POST: Panaderos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var panadero = db.Panaderoes.Find(id);
            if (panadero != null)
            {
                db.Panaderoes.Remove(panadero);
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