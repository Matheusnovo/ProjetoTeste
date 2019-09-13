using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MatheusMonteiroTeste.Models;
using MatheusMonteiroTeste.Models.ViewModel;

namespace MatheusMonteiroTeste.Controllers
{
    public class ClientesController : Controller
    {
        private contexto db = new contexto();

        // GET: Clientes
        public JsonResult Index()
        {
            
            //if (!lista.Any())
            //{
            //    var novo = new Cliente {
            //        Id = 1,
            //        Nome = "Matheus",
            //        CPF_CNPJ = "12345678914",
            //        DataCadastro = DateTime.Now
            //    };
            //    db.Clientes.Add(novo);
            //    db.SaveChanges();
            //}
            var listaViewModel = db.Clientes.ToList().Select(x => new ClienteViewModel(x));
            return Json(listaViewModel, JsonRequestBehavior.AllowGet);
        }

        // GET: Clientes/Details/5
        public JsonResult Details(int? id)
        {
            if (id == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            var clienteViewModel = new ClienteViewModel(cliente);
            return Json(clienteViewModel, JsonRequestBehavior.AllowGet);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return Json(cliente);
            }

            return Json(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return Json(cliente, JsonRequestBehavior.AllowGet);
            }
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
