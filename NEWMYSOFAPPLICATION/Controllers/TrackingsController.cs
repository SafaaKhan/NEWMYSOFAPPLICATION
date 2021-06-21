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
    public class TrackingsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Trackings
        [Route("api/Trackings/GetTrackingStaffStatus")]
        public string GetTrackingStaffStatus(string staffID)
        {
            var status = db.Trackings.Where(x => x.staffID == staffID).ToList();
            string _status = "";
            foreach (var item in status)
            {
                _status = item.status;
            }
            return _status;
        }

        [HttpPut()]
        [Route("api/Trackings/UpdateState")]
        //api/Trackings/UpdateState
        public bool UpdateState(string _staffID, string _status)
        {
            var staff = db.Trackings.Where(x => x.staffID == _staffID).ToList();
            if (staff.Count == 0)
            {
                Tracking tracking = new Tracking()
                {
                    staffID = _staffID,
                    status = _status
                };
                db.Trackings.Add(tracking);
                db.SaveChanges();
                return true;
            }
            else
            {
                foreach (var item in staff)
                {
                    item.status = _status;
                }

                db.SaveChanges();
                return true;
            }

            return false;
        }

    }
}