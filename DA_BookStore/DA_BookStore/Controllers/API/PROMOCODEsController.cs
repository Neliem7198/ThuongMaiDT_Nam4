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
    public class PROMOCODEsController : ApiController
    {
        private BookStore db = new BookStore();

        // GET: api/PROMOCODEs
        //public IQueryable<PROMOCODE> GetPROMOCODEs()
        //{
        //    return db.PROMOCODEs;
        //}

        // GET: api/PROMOCODEs/5
        [ResponseType(typeof(PROMOCODE))]
        public IHttpActionResult GetPROMOCODE(string id)
        {
            PROMOCODE pROMOCODE = db.PROMOCODEs.Find(id);
            if (pROMOCODE == null)
            {
                return NotFound();
            }

            return Ok(pROMOCODE);
        }

        // PUT: api/PROMOCODEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPROMOCODE(string id, PROMOCODE pROMOCODE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pROMOCODE.CODE)
            {
                return BadRequest();
            }

            db.Entry(pROMOCODE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PROMOCODEExists(id))
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

        // POST: api/PROMOCODEs
        [ResponseType(typeof(PROMOCODE))]
        public IHttpActionResult PostPROMOCODE(PROMOCODE pROMOCODE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PROMOCODEs.Add(pROMOCODE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PROMOCODEExists(pROMOCODE.CODE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pROMOCODE.CODE }, pROMOCODE);
        }

        // DELETE: api/PROMOCODEs/5
        [ResponseType(typeof(PROMOCODE))]
        public IHttpActionResult DeletePROMOCODE(string id)
        {
            PROMOCODE pROMOCODE = db.PROMOCODEs.Find(id);
            if (pROMOCODE == null)
            {
                return NotFound();
            }

            db.PROMOCODEs.Remove(pROMOCODE);
            db.SaveChanges();

            return Ok(pROMOCODE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PROMOCODEExists(string id)
        {
            return db.PROMOCODEs.Count(e => e.CODE == id) > 0;
        }
    }
}