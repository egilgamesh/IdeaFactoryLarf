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
using Ideas_Factory.Models;

namespace Ideas_Factory.Controllers
{
    public class ideasController : ApiController
    {
        private ideasFacctoryDBEntities db = new ideasFacctoryDBEntities();

        //GET: api/ideas
        //public IQueryable<idea> Getideas()
        //{
        //    return db.ideas;
        //}
        public List<ideavw> Getideas()
        {
            var idealist = db.ideas.ToList();
            var response = new List<ideavw>();

            foreach (var ide in idealist)
            {
                response.Add(new ideavw()
                {
                    idea_id = ide.idea_id,
                    idea_title=ide.idea_title,
                    idea_description=ide.idea_description,
                    idea_creation_time=ide.idea_creation_time,
                    userid=ide.userid,
                    username = ide.loginuser.username
                });
            }
            return response; //Here CityName is not virtual so will not cause exception. 
        }

        // GET: api/ideas/5
        [ResponseType(typeof(idea))]
        public IHttpActionResult Getidea(int id)
        {
            idea idea = db.ideas.Find(id);
            if (idea == null)
            {
                return NotFound();
            }

            return Ok(idea);
        }

        // PUT: api/ideas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putidea(int id, [FromBody] idea idea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != idea.idea_id)
            {
                return BadRequest();
            }

            db.Entry(idea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ideaExists(id))
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


        //// POST: api/ideas
        [ResponseType(typeof(idea))]
        public IHttpActionResult Postidea(idea idea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ideas.Add(idea);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
 
        }
        //POST: api/ideas

        // DELETE: api/ideas/5
        [ResponseType(typeof(idea))]
        public IHttpActionResult Deleteidea(int id)
        {
            idea idea = db.ideas.Find(id);
            if (idea == null)
            {
                return NotFound();
            }

            db.ideas.Remove(idea);
            db.SaveChanges();

            return Ok(idea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ideaExists(int id)
        {
            return db.ideas.Count(e => e.idea_id == id) > 0;
        }
    }
}