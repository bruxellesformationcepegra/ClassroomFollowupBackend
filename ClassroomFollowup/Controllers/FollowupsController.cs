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
using ClassroomFollowup.Models;

namespace ClassroomFollowup.Controllers
{
    public class FollowupsController : ApiController
    {
        private ClassroomFollowupContext db = new ClassroomFollowupContext();

        // GET: api/Followups
        public IQueryable<Followup> GetFollowups()
        {
            return db.Followups;
        }

        // GET: api/Followups/5
        [ResponseType(typeof(Followup))]
        public IHttpActionResult GetFollowup(int id)
        {
            Followup followup = db.Followups.Find(id);
            if (followup == null)
            {
                return NotFound();
            }

            return Ok(followup);
        }

        // PUT: api/Followups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFollowup(int id, Followup followup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != followup.ID)
            {
                return BadRequest();
            }

            db.Entry(followup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowupExists(id))
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

        // POST: api/Followups
        [ResponseType(typeof(Followup))]
        public IHttpActionResult PostFollowup(Followup followup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Followups.Add(followup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = followup.ID }, followup);
        }

        // DELETE: api/Followups/5
        [ResponseType(typeof(Followup))]
        public IHttpActionResult DeleteFollowup(int id)
        {
            Followup followup = db.Followups.Find(id);
            if (followup == null)
            {
                return NotFound();
            }

            db.Followups.Remove(followup);
            db.SaveChanges();

            return Ok(followup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FollowupExists(int id)
        {
            return db.Followups.Count(e => e.ID == id) > 0;
        }
    }
}