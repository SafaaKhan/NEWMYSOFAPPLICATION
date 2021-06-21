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
using NEWMYSOFAPPLICATION.Models;

namespace NEWMYSOFAPPLICATION.Controllers
{
    public class FullDatesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/FullDates
        public IEnumerable<FullDates> GetFullDates(string staffname)
        {
            return db.FullDates.Where(x => x.staffName == staffname).ToList();
        }


        //post Full Date
        [HttpPost]
        [Route("api/FullDates/Post")]
        public IHttpActionResult Post([FromBody] FullDates fullDates)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                FullDates _fullDates = new FullDates()
                {
                    date = fullDates.date,
                    staffName = fullDates.staffName

                };
                db.FullDates.Add(_fullDates);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return StatusCode(HttpStatusCode.Created);
        }



    }
}