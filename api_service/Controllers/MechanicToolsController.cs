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
    public class MechanicToolsController : ApiController
    {
        private toolsInventoryEntities1 db = new toolsInventoryEntities1();

        // GET: api/MechanicTools
        public IQueryable<mechanic_tools> Getmechanic_tools()
        {
            return db.mechanic_tools;
        }

        // GET: api/MechanicTools/5
        [ResponseType(typeof(mechanic_tools))]
        public IHttpActionResult Getmechanic_tools(int id)
        {
            mechanic_tools mechanic_tools = db.mechanic_tools.Find(id);
            if (mechanic_tools == null)
            {
                return NotFound();
            }

            return Ok(mechanic_tools);
        }

        // PUT: api/MechanicTools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmechanic_tools(int id, mechanic_tools mechanic_tools)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mechanic_tools.id)
            {
                return BadRequest();
            }

            db.Entry(mechanic_tools).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mechanic_toolsExists(id))
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

        // POST: api/MechanicTools
        [ResponseType(typeof(mechanic_tools))]
        public IHttpActionResult Postmechanic_tools(mechanic_tools mechanic_tools)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mechanic_tools.Add(mechanic_tools);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mechanic_tools.id }, mechanic_tools);
        }

        // DELETE: api/MechanicTools/5
        [ResponseType(typeof(mechanic_tools))]
        public IHttpActionResult Deletemechanic_tools(int id)
        {
            mechanic_tools mechanic_tools = db.mechanic_tools.Find(id);
            if (mechanic_tools == null)
            {
                return NotFound();
            }

            db.mechanic_tools.Remove(mechanic_tools);
            db.SaveChanges();

            return Ok(mechanic_tools);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mechanic_toolsExists(int id)
        {
            return db.mechanic_tools.Count(e => e.id == id) > 0;
        }
    }
}