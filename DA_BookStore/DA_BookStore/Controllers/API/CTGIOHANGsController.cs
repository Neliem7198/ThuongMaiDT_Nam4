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
using DA_BookStore.Models;

namespace DA_BookStore.Controllers.API
{
    public class CTGIOHANGsController : ApiController
    {
        private BookStore db = new BookStore();

        // GET: api/CTGIOHANGs
        public IQueryable<CTGIOHANG> GetCTGIOHANGs()
        {
            return db.CTGIOHANGs;
        }

        // GET: api/CTGIOHANGs/5
        [ResponseType(typeof(CTGIOHANG))]
        public IHttpActionResult GetCTGIOHANG(string id)
        {
            CTGIOHANG cTGIOHANG = db.CTGIOHANGs.Find(id);
            if (cTGIOHANG == null)
            {
                return NotFound();
            }

            return Ok(cTGIOHANG);
        }

        // PUT: api/CTGIOHANGs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCTGIOHANG(string id, CTGIOHANG cTGIOHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cTGIOHANG.MaSach)
            {
                return BadRequest();
            }

            db.Entry(cTGIOHANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CTGIOHANGExists(id))
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

        // POST: api/CTGIOHANGs
        [ResponseType(typeof(CTGIOHANG))]
        public IHttpActionResult PostCTGIOHANG(CTGIOHANG cTGIOHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CTGIOHANGs.Add(cTGIOHANG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CTGIOHANGExists(cTGIOHANG.MaSach))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cTGIOHANG.MaSach }, cTGIOHANG);
        }

        // DELETE: api/CTGIOHANGs/5
        [ResponseType(typeof(CTGIOHANG))]
        public IHttpActionResult DeleteCTGIOHANG(string id)
        {
            CTGIOHANG cTGIOHANG = db.CTGIOHANGs.Find(id);
            if (cTGIOHANG == null)
            {
                return NotFound();
            }

            db.CTGIOHANGs.Remove(cTGIOHANG);
            db.SaveChanges();

            return Ok(cTGIOHANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CTGIOHANGExists(string id)
        {
            return db.CTGIOHANGs.Count(e => e.MaSach == id) > 0;
        }
    }
}