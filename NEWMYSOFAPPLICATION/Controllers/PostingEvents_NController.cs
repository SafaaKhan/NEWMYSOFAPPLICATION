using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NEWMYSOFAPPLICATION.Helper;
using NEWMYSOFAPPLICATION.Models;

namespace NEWMYSOFAPPLICATION.Controllers
{
    public class PostingEvents_NController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public IHttpActionResult Post([FromBody] PostingEvents_N postingEvents_N)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var stream = new MemoryStream(postingEvents_N.ImageArray);
            var guid = Guid.NewGuid().ToString();
            var file = String.Format("{0}.jpg", guid);
            var folder = "~/Content/Events";
            var fullPath = string.Format("{0}/{1}", folder, file);
            var response = HelperFile.UploadImage(stream, folder, file);
            if (response)
            {
                postingEvents_N.ImagePath = fullPath;
            }

            var Event = new PostingEvents_N()
            {
                PublisherName = postingEvents_N.PublisherName,
                Title = postingEvents_N.Title,
                Information = postingEvents_N.Information,
                ImagePath = postingEvents_N.ImagePath
            };
            db.PostingEvents_N.Add(Event);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        [HttpGet]
        public IEnumerable<PostingEvents_N> Get()
        {
            return db.PostingEvents_N;

        }
    }
}