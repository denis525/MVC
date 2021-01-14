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
    public class StrankasController : ApiController
    {
        private DSRtriContext db = new DSRtriContext();

        // GET: api/Strankas
        [Authorize(Roles = "Admin")]
        public IQueryable<Stranka> GetStrankas()
        {
            return db.Strankas;
        }

        // GET: api/Strankas/5
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(Stranka))]
        public async Task<IHttpActionResult> GetStranka(int id)
        {
            Stranka stranka = await db.Strankas.FindAsync(id);
            if (stranka == null)
            {
                return NotFound();
            }

            return Ok(stranka);
        }

        // PUT: api/Strankas/5
        [Authorize(Roles = "Admin, User")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStranka(int id, Stranka stranka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stranka.Id)
            {
                return BadRequest();
            }

            db.Entry(stranka).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StrankaExists(id))
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

        // POST: api/Strankas
        [Authorize(Roles = "Admin, User")]
        [ResponseType(typeof(Stranka))]
        public async Task<IHttpActionResult> PostStranka(Stranka stranka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Strankas.Add(stranka);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stranka.Id }, stranka);
        }

        // DELETE: api/Strankas/5
        [Authorize(Roles = "Admin, User")]
        [ResponseType(typeof(Stranka))]
        public async Task<IHttpActionResult> DeleteStranka(int id)
        {
            Stranka stranka = await db.Strankas.FindAsync(id);
            if (stranka == null)
            {
                return NotFound();
            }

            db.Strankas.Remove(stranka);
            await db.SaveChangesAsync();

            return Ok(stranka);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StrankaExists(int id)
        {
            return db.Strankas.Count(e => e.Id == id) > 0;
        }
    }
}