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
using api_service.Models;

namespace api_service.Controllers
{
    public class MechanicController : ApiController
    {
        private toolsInventoryEntities1 db = new toolsInventoryEntities1();

        // GET: api/Mechanic
        public IQueryable<mechanic> Getmechanics()
        {
            return db.mechanics;
        }

        // GET: api/Mechanic/5
        [ResponseType(typeof(mechanic))]
        public IHttpActionResult Getmechanic(int id)
        {
            mechanic mechanic = db.mechanics.Find(id);
            if (mechanic == null)
            {
                return NotFound();
            }

            return Ok(mechanic);
        }

        // PUT: api/Mechanic/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmechanic(int id, mechanic mechanic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mechanic.id)
            {
                return BadRequest();
            }

            db.Entry(mechanic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mechanicExists(id))
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

        // POST: api/Mechanic
        [ResponseType(typeof(mechanic))]
        public IHttpActionResult Postmechanic(mechanic mechanic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mechanics.Add(mechanic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mechanic.id }, mechanic);
        }

        // DELETE: api/Mechanic/5
        [ResponseType(typeof(mechanic))]
        public IHttpActionResult Deletemechanic(int id)
        {
            mechanic mechanic = db.mechanics.Find(id);
            if (mechanic == null)
            {
                return NotFound();
            }

            db.mechanics.Remove(mechanic);
            db.SaveChanges();

            return Ok(mechanic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mechanicExists(int id)
        {
            return db.mechanics.Count(e => e.id == id) > 0;
        }
    }
}