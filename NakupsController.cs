using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DSRtri.Models;

namespace DSRtri.Controllers
{
    public class NakupsController : ApiController
    {
        private DSRtriContext db = new DSRtriContext();

        // GET: api/Nakups
        [Authorize(Roles = "Admin")]
        public IQueryable<Nakup> GetNakups()
        {
            return db.Nakups;
        }

        // GET: api/Nakups/5
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(Nakup))]
        public async Task<IHttpActionResult> GetNakup(int id)
        {
            Nakup nakup = await db.Nakups.FindAsync(id);
            if (nakup == null)
            {
                return NotFound();
            }

            return Ok(nakup);
        }

        // PUT: api/Nakups/5
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNakup(int id, Nakup nakup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nakup.Id)
            {
                return BadRequest();
            }

            db.Entry(nakup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NakupExists(id))
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

        // POST: api/Nakups
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(Nakup))]
        public async Task<IHttpActionResult> PostNakup(Nakup nakup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nakups.Add(nakup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = nakup.Id }, nakup);
        }

        // DELETE: api/Nakups/5
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(Nakup))]
        public async Task<IHttpActionResult> DeleteNakup(int id)
        {
            Nakup nakup = await db.Nakups.FindAsync(id);
            if (nakup == null)
            {
                return NotFound();
            }

            db.Nakups.Remove(nakup);
            await db.SaveChangesAsync();

            return Ok(nakup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NakupExists(int id)
        {
            return db.Nakups.Count(e => e.Id == id) > 0;
        }
    }
}