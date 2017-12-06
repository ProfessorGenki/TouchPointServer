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
using TouchPointServer;

namespace TouchPointServer.Controllers
{
    public class CoursesController : ApiController
    {
        private TouchPointDBContext db = new TouchPointDBContext();

        // GET: api/Courses
        public IQueryable<CourseDB> GetCourseDBs()
        {
            return db.CourseDBs;
        }

        // GET: api/Courses/5
        [ResponseType(typeof(CourseDB))]
        public IHttpActionResult GetCourseDB(int id)
        {
            CourseDB courseDB = db.CourseDBs.Find(id);
            if (courseDB == null)
            {
                return NotFound();
            }

            return Ok(courseDB);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourseDB(int id, CourseDB courseDB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseDB.Course_ID)
            {
                return BadRequest();
            }

            db.Entry(courseDB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseDBExists(id))
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

        // POST: api/Courses
        [ResponseType(typeof(CourseDB))]
        public IHttpActionResult PostCourseDB(CourseDB courseDB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CourseDBs.Add(courseDB);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CourseDBExists(courseDB.Course_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = courseDB.Course_ID }, courseDB);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(CourseDB))]
        public IHttpActionResult DeleteCourseDB(int id)
        {
            CourseDB courseDB = db.CourseDBs.Find(id);
            if (courseDB == null)
            {
                return NotFound();
            }

            db.CourseDBs.Remove(courseDB);
            db.SaveChanges();

            return Ok(courseDB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseDBExists(int id)
        {
            return db.CourseDBs.Count(e => e.Course_ID == id) > 0;
        }
    }
}