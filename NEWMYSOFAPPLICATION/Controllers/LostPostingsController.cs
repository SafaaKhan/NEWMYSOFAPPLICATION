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
    public class LostPostingsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //post Lost things
        [Route("api/LostPostings/Post")]
        public IHttpActionResult Post([FromBody] LostPosting lostPosting, string _memberID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                LostPosting _lostPosting = new LostPosting()
                {
                    Information = lostPosting.Information,
                    ResponsibleName = lostPosting.ResponsibleName,
                    Date = lostPosting.Date

                };
                db.LostPostings.Add(_lostPosting);
                db.SaveChanges();
                int postID = 0;
                var post = db.LostPostings.Where(x => x.ID == _lostPosting.ID).Include("RegisterMembers").ToList();
                foreach (var item in post)
                {
                    postID = item.ID;
                }
                db.SaveChanges();
                update(_memberID, postID);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return StatusCode(HttpStatusCode.Created);
        }


        [Route("api/LostPostings/Get")]
        //Get list of the lostThing
        public IEnumerable<LostPosting> Get()
        {
            var postLost = db.LostPostings.Include("RegisterMembers").ToList();

            return postLost;
        }




        [HttpGet]
        // api/RegisterMembers/GetMemberEmail
        public List<RegisterMember> GetMemberEmail(string ID)
        {
            var memberEmail = db.RegisterMembers.Where(x => x.ID == ID).Include("LostPostings").ToList();
            return memberEmail;
        }


        [HttpGet]
        // api/LostPostings/GetMemberEmail_2
        [Route("api/LostPostings/GetMemberEmail_2")]
        public string GetMemberEmail_2(int ID)
        {
            string email = "";
            var m = db.LostPostings.Where(x => x.ID == ID).Include("RegisterMembers").ToList();
            foreach (var item in m)
            {
                foreach (var i in item.RegisterMembers)
                {
                    email = i.Email;

                }
            }
            return email;
        }


        [HttpGet]
        // api/LostPostings/GetMemberName_2
        [Route("api/LostPostings/GetMemberName_2")]
        public string GetMemberName_2(int ID)
        {
            string name = "";
            var m = db.LostPostings.Where(x => x.ID == ID).Include("RegisterMembers").ToList();
            foreach (var item in m)
            {
                foreach (var i in item.RegisterMembers)
                {
                    name = i.Name;

                }
            }
            return name;
        }




        //update many to many relationShip post and member
        public void update(string memberID, int postID)
        {
            try
            {
                RegisterMember member = db.RegisterMembers.FirstOrDefault(x => x.ID == memberID);
                db.LostPostings.FirstOrDefault(x => x.ID == postID).RegisterMembers.Add(member);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

        }
    }
}