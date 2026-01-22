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
    public class VentasController : Controller
    {

       
          private PanaderiaModel db = new PanaderiaModel();

            // GET: Ventas
            public ActionResult Index()
            {
                var ventas = db.Ventas.Include(v => v.Producto).Select(v => new VentaDTO
                {
                    VentaID = v.VentaID,
                    ProductoID = v.ProductoID,
                    Cantidad = v.Cantidad,
                    Precio = v.Precio,
                    Fecha = v.Fecha,
                   // NombreProducto = v.Producto.NombreProducto
                }).ToList();

                return View(ventas);
            }

            // GET: Ventas/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var venta = db.Ventas.Include(v => v.Producto).FirstOrDefault(v => v.VentaID == id);
                if (venta == null)
                {
                    return HttpNotFound();
                }

                var ventaDTO = new VentaDTO
                {
                    VentaID = venta.VentaID,
                    ProductoID = venta.ProductoID,
                    Cantidad = venta.Cantidad,
                    Precio = venta.Precio,
                    Fecha = venta.Fecha,
                    //NombreProducto = venta.Producto?.NombreProducto
                };

                return View(ventaDTO);
            }

            // GET: Ventas/Create
            public ActionResult Create()
            {
                ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto");
                return View();
            }

            // POST: Ventas/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(VentaDTO ventaDTO)
            {
                if (ModelState.IsValid)
                {
                    var venta = new Venta
                    {
                        ProductoID = ventaDTO.ProductoID,
                        Cantidad = ventaDTO.Cantidad,
                        Precio = ventaDTO.Precio,
                        Fecha = ventaDTO.Fecha
                    };

                    db.Ventas.Add(venta);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto", ventaDTO.ProductoID);
                return View(ventaDTO);
            }

            // GET: Ventas/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var venta = db.Ventas.Find(id);
                if (venta == null)
                {
                    return HttpNotFound();
                }

                var ventaDTO = new VentaDTO
                {
                    VentaID = venta.VentaID,
                    ProductoID = venta.ProductoID,
                    Cantidad = venta.Cantidad,
                    Precio = venta.Precio,
                    Fecha = venta.Fecha
                };

                ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto", ventaDTO.ProductoID);
                return View(ventaDTO);
            }

            // POST: Ventas/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(VentaDTO ventaDTO)
            {
                if (ModelState.IsValid)
                {
                    var venta = db.Ventas.Find(ventaDTO.VentaID);
                    if (venta == null)
                    {
                        return HttpNotFound();
                    }

                    venta.ProductoID = ventaDTO.ProductoID;
                    venta.Cantidad = ventaDTO.Cantidad;
                    venta.Precio = ventaDTO.Precio;
                    venta.Fecha = ventaDTO.Fecha;

                    db.Entry(venta).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ProductoID = new SelectList(db.Productos, "ProductoID", "NombreProducto", ventaDTO.ProductoID);
                return View(ventaDTO);
            }

            // GET: Ventas/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var venta = db.Ventas.Include(v => v.Producto).FirstOrDefault(v => v.VentaID == id);
                if (venta == null)
                {
                    return HttpNotFound();
                }

                var ventaDTO = new VentaDTO
                {
                    VentaID = venta.VentaID,
                    ProductoID = venta.ProductoID,
                    Cantidad = venta.Cantidad,
                    Precio = venta.Precio,
                    Fecha = venta.Fecha,
                   // NombreProducto = venta.Producto?.NombreProducto
                };

                return View(ventaDTO);
            }

            // POST: Ventas/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                var venta = db.Ventas.Find(id);
                if (venta != null)
                {
                    db.Ventas.Remove(venta);
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
