using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Atividade_Douglas.Models;
using Atividade_Douglas.Models.Contexto;

namespace Atividade_Douglas.Controllers
{
    public class Modelos3DController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Modelos3D
        public ActionResult Index()
        {
            return View(db.Modelo3D.ToList());
        }

        // GET: Modelos3D/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo3D modelo3D = db.Modelo3D.Find(id);
            if (modelo3D == null)
            {
                return HttpNotFound();
            }
            return View(modelo3D);
        }

        // GET: Modelos3D/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modelos3D/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Modelo3DID,Nome,Idade,Altura,Peso,Historia,Habilidades")] Modelo3D modelo3D)
        {
            if (ModelState.IsValid)
            {
                db.Modelo3D.Add(modelo3D);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelo3D);
        }

        // GET: Modelos3D/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo3D modelo3D = db.Modelo3D.Find(id);
            if (modelo3D == null)
            {
                return HttpNotFound();
            }
            return View(modelo3D);
        }

        // POST: Modelos3D/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Modelo3DID,Nome,Idade,Altura,Peso,Historia,Habilidades")] Modelo3D modelo3D)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelo3D).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelo3D);
        }

        // GET: Modelos3D/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo3D modelo3D = db.Modelo3D.Find(id);
            if (modelo3D == null)
            {
                return HttpNotFound();
            }
            return View(modelo3D);
        }

        // POST: Modelos3D/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelo3D modelo3D = db.Modelo3D.Find(id);
            db.Modelo3D.Remove(modelo3D);
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
