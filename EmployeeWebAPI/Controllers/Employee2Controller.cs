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
using EmployeeWebAPI.Models;
using EntityState = System.Data.Entity.EntityState;

namespace EmployeeWebAPI.Controllers
{
    public class Employee2Controller : ApiController
    {
        private DBModels db = new DBModels();

        // GET: api/Employee2
        public IQueryable<Employee2> GetEmployee2()
        {
            return db.Employee2;
        }

        // GET: api/Employee2/5
        [ResponseType(typeof(Employee2))]
        public IHttpActionResult GetEmployee2(int id)
        {
            Employee2 employee2 = db.Employee2.Find(id);
            if (employee2 == null)
            {
                return NotFound();
            }

            return Ok(employee2);
        }

        // PUT: api/Employee2/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee2(int id, Employee2 employee2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee2.EmployeeID)
            {
                return BadRequest();
            }

            db.Entry(employee2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee2Exists(id))
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

        // POST: api/Employee2
        [ResponseType(typeof(Employee2))]
        public IHttpActionResult PostEmployee2(Employee2 employee2)
        {
          
            db.Employee2.Add(employee2);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee2.EmployeeID }, employee2);
        }

        // DELETE: api/Employee2/5
        [ResponseType(typeof(Employee2))]
        public IHttpActionResult DeleteEmployee2(int id)
        {
            Employee2 employee2 = db.Employee2.Find(id);
            if (employee2 == null)
            {
                return NotFound();
            }

            db.Employee2.Remove(employee2);
            db.SaveChanges();

            return Ok(employee2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Employee2Exists(int id)
        {
            return db.Employee2.Count(e => e.EmployeeID == id) > 0;
        }
    }
}