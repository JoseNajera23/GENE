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
    public class ProductosController : Controller
    {
        private PanaderiaModel db = new PanaderiaModel();
        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Select(p => new ProductoDTO
            {
                ProductoID = p.ProductoID,
                NombreProducto = p.NombreProducto,
                TipoProducto = p.TipoProducto
            }).ToList();

            return View(productos);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            var productoDTO = new ProductoDTO
            {
                ProductoID = producto.ProductoID,
                NombreProducto = producto.NombreProducto,
                TipoProducto = producto.TipoProducto
            };

            return View(productoDTO);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoDTO productoDTO)
        {
            if (ModelState.IsValid)
            {
                var producto = new Producto
                {
                    NombreProducto = productoDTO.NombreProducto,
                    TipoProducto = productoDTO.TipoProducto
                };

                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productoDTO);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            var productoDTO = new ProductoDTO
            {
                ProductoID = producto.ProductoID,
                NombreProducto = producto.NombreProducto,
                TipoProducto = producto.TipoProducto
            };

            return View(productoDTO);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoDTO productoDTO)
        {
            if (ModelState.IsValid)
            {
                var producto = db.Productos.Find(productoDTO.ProductoID);
                if (producto == null)
                {
                    return HttpNotFound();
                }

                producto.NombreProducto = productoDTO.NombreProducto;
                producto.TipoProducto = productoDTO.TipoProducto;

                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productoDTO);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            var productoDTO = new ProductoDTO
            {
                ProductoID = producto.ProductoID,
                NombreProducto = producto.NombreProducto,
                TipoProducto = producto.TipoProducto
            };

            return View(productoDTO);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var producto = db.Productos.Find(id);
            if (producto != null)
            {
                db.Productos.Remove(producto);
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
