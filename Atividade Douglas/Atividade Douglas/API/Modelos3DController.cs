using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Atividade_Douglas.Models;
using Atividade_Douglas.Models.Contexto;

namespace Atividade_Douglas.API
{
    public class Modelos3DController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Modelos3D
        public IQueryable<Modelo3D> GetModelo3D()
        {
            return db.Modelo3D;
        }

        // GET: api/Modelos3D/5
        [ResponseType(typeof(Modelo3D))]
        public IHttpActionResult GetModelo3D(int id)
        {
            Modelo3D modelo3D = db.Modelo3D.Find(id);
            if (modelo3D == null)
            {
                return NotFound();
            }

            return Ok(modelo3D);
        }

        // PUT: api/Modelos3D/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModelo3D(int id, Modelo3D modelo3D)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelo3D.Modelo3DID)
            {
                return BadRequest();
            }

            db.Entry(modelo3D).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Modelo3DExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Modelos3D
        [ResponseType(typeof(Modelo3D))]
        public IHttpActionResult PostModelo3D(Modelo3D modelo3D)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modelo3D.Add(modelo3D);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modelo3D.Modelo3DID }, modelo3D);
        }

        // DELETE: api/Modelos3D/5
        [ResponseType(typeof(Modelo3D))]
        public IHttpActionResult DeleteModelo3D(int id)
        {
            Modelo3D modelo3D = db.Modelo3D.Find(id);
            if (modelo3D == null)
            {
                return NotFound();
            }

            db.Modelo3D.Remove(modelo3D);
            db.SaveChanges();

            return Ok(modelo3D);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Modelo3DExists(int id)
        {
            return db.Modelo3D.Count(e => e.Modelo3DID == id) > 0;
        }
    }
}