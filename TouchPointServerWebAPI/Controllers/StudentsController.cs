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
using TouchPointServerWebAPI;

namespace TouchPointServerWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private TouchPointDBContext db = new TouchPointDBContext();

        // GET: api/Students
        public IQueryable<StudentDB> GetStudentDBs()
        {
            return db.StudentDBs;
        }

        // GET: api/Students/5
        [ResponseType(typeof(StudentDB))]
        public IHttpActionResult GetStudentDB(int id)
        {
            StudentDB studentDB = db.StudentDBs.Find(id);
            if (studentDB == null)
            {
                return NotFound();
            }

            return Ok(studentDB);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentDB(int id, StudentDB studentDB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentDB.Student_ID)
            {
                return BadRequest();
            }

            db.Entry(studentDB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDBExists(id))
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

        // POST: api/Students
        [ResponseType(typeof(StudentDB))]
        public IHttpActionResult PostStudentDB(StudentDB studentDB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentDBs.Add(studentDB);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentDBExists(studentDB.Student_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = studentDB.Student_ID }, studentDB);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(StudentDB))]
        public IHttpActionResult DeleteStudentDB(int id)
        {
            StudentDB studentDB = db.StudentDBs.Find(id);
            if (studentDB == null)
            {
                return NotFound();
            }

            db.StudentDBs.Remove(studentDB);
            db.SaveChanges();

            return Ok(studentDB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentDBExists(int id)
        {
            return db.StudentDBs.Count(e => e.Student_ID == id) > 0;
        }
    }
}