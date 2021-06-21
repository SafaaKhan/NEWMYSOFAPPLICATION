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
    public class TimeSlotDivsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TimeSlotDivs
        public IEnumerable<TimeSlotDiv> GetTimeSlotDivs(string staffName, string service)
        {
            string _staffID = "";
            var staff = db.ServicesOfStaffs.Where(x => x.staffName == staffName).ToList();
            foreach (var ID in staff)
            {
                _staffID = ID.staffID;
            }


            var timeSlotsID = db.TimeSlotDivs.Where(x => x.staffID == _staffID && x.service == service).ToList();
            return timeSlotsID;
        }

        // GET: api/TimeSlotDivs
        [Route("api/TimeSlotDivs/GetTimeSlotDivs_2")]
        public IEnumerable<TimeSlotDiv> GetTimeSlotDivs_2(string staffName)
        {
            string _staffID = "";
            var staff = db.ServicesOfStaffs.Where(x => x.staffName == staffName).ToList();
            foreach (var ID in staff)
            {
                _staffID = ID.staffID;
            }


            var timeSlotsID = db.TimeSlotDivs.Where(x => x.staffID == _staffID).ToList();
            return timeSlotsID;
        }

        //status
        // GET: api/TimeSlotDivs
        //api/StudentReservedAppointments/GetStatus
        [Route("api/StudentReservedAppointments/GetStatus")]
        /*   public List<bool> GetStatus()
           {
               List<bool> _status = new List<bool>();

               var m = db.TimeSlotDivs.Where(x => x.status == true).ToList();
               foreach (var item in m)
               {
                   _status.Add(item.status);
               }
               return _status;
           }*/


        [Route("api/StudentReservedAppointments/GetSpecieficStaffTimeSlots")]
        public List<string> GetSpecieficStaffTimeSlots(string staffName)
        {
            string _staffID = "";
            var staff = db.ServicesOfStaffs.Where(x => x.staffName == staffName).ToList();
            foreach (var ID in staff)
            {
                _staffID = ID.staffID;
            }

            List<string> _time = new List<string>();
            var timeSlotsID = db.TimeSlotDivs.Where(x => x.staffID == _staffID).ToList();
            foreach (var time in timeSlotsID)
            {
                _time.Add(time.time);
            }

            return _time;
        }


        //staff name
        [Route("api/StudentReservedAppointments/GetSpecieficStaffEmail")]
        public string GetSpecieficStaffEmail(string staffName)
        {
            string _staffEmail = "";
            var staff = db.RegisterMembers.Where(x => x.Name == staffName).ToList();
            foreach (var email in staff)
            {
                _staffEmail = email.Email;
            }

            return _staffEmail;
        }


        //student Email
        [Route("api/StudentReservedAppointments/GetSpecieficstudentEmail")]
        public string GetSpecieficstudentEmail(string ID)
        {
            string _studentEmail = "";
            var staff = db.RegisterMembers.Where(x => x.ID == ID).ToList();
            foreach (var email in staff)
            {
                _studentEmail = email.Email;
            }

            return _studentEmail;
        }
    }
}