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
    public class ToolsCheckOutController : ApiController
    {
        private toolsInventoryEntities1 db = new toolsInventoryEntities1();

        // GET: api/ToolsCheckOut
        public IQueryable<check_out> Getcheck_out()
        {
            return db.check_out;
        }

        // GET: api/ToolsCheckOut/5
        [ResponseType(typeof(check_out))]
        public IHttpActionResult Getcheck_out(int id)
        {
            check_out check_out = db.check_out.Find(id);
            if (check_out == null)
            {
                return NotFound();
            }

            return Ok(check_out);
        }

        // PUT: api/ToolsCheckOut/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcheck_out(int id, check_out check_out)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != check_out.id)
            {
                return BadRequest();
            }

            db.Entry(check_out).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!check_outExists(id))
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

        // POST: api/ToolsCheckOut
        [ResponseType(typeof(check_out))]
        public IHttpActionResult Postcheck_out(check_out check_out)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.check_out.Add(check_out);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = check_out.id }, check_out);
        }

        // DELETE: api/ToolsCheckOut/5
        [ResponseType(typeof(check_out))]
        public IHttpActionResult Deletecheck_out(int id)
        {
            check_out check_out = db.check_out.Find(id);
            if (check_out == null)
            {
                return NotFound();
            }

            db.check_out.Remove(check_out);
            db.SaveChanges();

            return Ok(check_out);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool check_outExists(int id)
        {
            return db.check_out.Count(e => e.id == id) > 0;
        }
    }
}