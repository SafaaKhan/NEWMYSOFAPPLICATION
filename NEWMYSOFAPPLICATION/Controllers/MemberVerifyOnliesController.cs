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
    public class MemberVerifyOnliesController : ApiController
    {
        

        static private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MemberVerifyOnlies
        public IQueryable<MemberVerifyOnly> GetMemberVerifyOnlies()
        {
            return db.MemberVerifyOnlies;
        }

        public static List<MemberVerifyOnly> GetClubIDMVerify()
        {
            var _clubMember = db.MemberVerifyOnlies.Where(x => x.Membertype == "club").ToList();
            return _clubMember;
        }

        public static List<MemberVerifyOnly> GetSecurityIDMVerify()
        {
            var _securityMember = db.MemberVerifyOnlies.Where(x => x.Membertype == "security").ToList();
            return _securityMember;
        }

        public static List<MemberVerifyOnly> GetAdminstratorIDMVerify()
        {
            var _AdminstratorMember = db.MemberVerifyOnlies.Where(x => x.Membertype == "Adminstrator" || x.Membertype == "Academic").ToList();
            return _AdminstratorMember;
        }
    }
}