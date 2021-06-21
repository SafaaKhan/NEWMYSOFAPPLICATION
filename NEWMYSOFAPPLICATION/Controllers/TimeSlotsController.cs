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
    public class TimeSlotsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("api/TimeSlots/GetTimeSlots_2")]
        // GET: api/TimeSlots
        public IEnumerable<TimeSlots> GetTimeSlots_2(string id)
        {

            var timeSlotsID = db.TimeSlots.Where(x => x.staffID == id).ToList();
            return timeSlotsID;

        }


        //break time
        //rolenumber
        //10 min
        /// <summary>
        /// /////test
        /// this method take the name of the staff and return all info about the servic(time slot)
        /// </summary>
        /// <param name="staffName"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        [Route("api/TimeSlots/GetTimeSlots3")]
        // GET: api/TimeSlots
        public IEnumerable<TimeSlots> GetTimeSlots3(string staffName, string service)
        {
            string _staffID = "";

            var staff = db.ServicesOfStaffs.Where(x => x.staffName == staffName).ToList();
            foreach (var ID in staff)
            {
                _staffID = ID.staffID;
            }


            var timeSlotsID = db.TimeSlots.Where(x => x.staffID == _staffID && x.service == service).ToList();
            return timeSlotsID;

        }

        //update for disabling
        [HttpPut()]
        [Route("api/TimeSlots/UpdateDisabling")]
        //api/TimeSlots/UpdateDisabling


        public void UpdateDisabling(int _startTime, int _endTime, int _slot, string _staffID, string _service, DateTime _startDate, DateTime _endDate, string _dateType, string _day, string _WorkingDaysType, DateTime disableStartDate, DateTime disableEndDate, string disableMSG)
        {
            var ____timeSlot = db.TimeSlots.Where(x => x.startTime == _startTime && x.endtTime == _endTime && x.startDate == _startDate && x.endDate == _endDate && x.dateType == _dateType && x.Day == _day && x.WorkingDaysTupe == _WorkingDaysType && x.staffID == _staffID);
            foreach (var _timeslot in ____timeSlot)
            {
                _timeslot.disablestatus = true;
                _timeslot.disableStartDate = disableStartDate;
                _timeslot.disableEndDate = disableEndDate;
                _timeslot.disableMSG = disableMSG;


            }
            db.SaveChanges();


        }





        int _timeslotcount = 0;
        int _timeslotcountBreak = 0;
        // Get api/TimeSlots/GetTimeSlots
        [Route("api/TimeSlots/GetTimeSlots")]
        public string GetTimeSlots(int _startTime, int _endTime, int _slot, string _staffID, string _service, DateTime _startDate, DateTime _endDate, string _dateType, string _day, string _WorkingDaysType, int startBreak, int endBreak)
        {//try catch

            try
            {
                TimeSlots timeSlots = new TimeSlots()
                {
                    startTime = _startTime,
                    endtTime = _endTime,
                    slots = _slot,
                    staffID = _staffID,
                    service = _service,
                    endDate = _endDate,
                    startDate = _startDate,
                    dateType = _dateType,
                    Day = _day,
                    WorkingDaysTupe = _WorkingDaysType,
                    breakstartTime = startBreak,
                    breakendtTime = endBreak,
                    disableEndDate = DateTime.Parse("1 / 1 / 1900 12:00:00 AM"),
                    disableMSG = "_",
                    disableStartDate = DateTime.Parse("1 / 1 / 1900 12:00:00 AM"),
                    disablestatus = false


                };
                db.TimeSlots.Add(timeSlots);
                db.SaveChanges();

                int startTime = _startTime;
                int endTime = _endTime;
                int slot = _slot;
         

                var time = new DateTime(2020, 1, 1, startTime, 0, 0);
           
                List<string> timeCollection = new List<string>();
                int count = 0;
                for (int i = startTime; i < endTime; i++)
                {
                  

                    for (int y = 0; y < 50; y++)
                    {
                        
                        if (time.Hour >= startBreak && time.Hour < endBreak)
                        {
                            time = time.AddMinutes(60);
                            continue;

                        }
                        else
                        {
                            if (time.ToString("tt") == "AM")
                            {
                                timeCollection.Add(time.ToString("t") + " - " + time.AddMinutes(slot).ToString("t"));
                             
                                count++;
                            }
                            else
                            {
                                timeCollection.Add(time.ToString("t") + " - " + time.AddMinutes(slot).ToString("t"));
                                count++;
                            }
                            time = time.AddMinutes(slot);
                            _timeslotcount = (((endTime - startTime) * 60) / slot);
                            _timeslotcountBreak = (((endBreak - startBreak) * 60) / slot);
                            if (count == (_timeslotcount - _timeslotcountBreak))
                            {
                                break;
                            }

                        }
                        if (count == _timeslotcount)///subtract break
                        {
                            break;
                        }



                    }


                    int _rolenumber = 1;
                    foreach (string slotTime in timeCollection)
                    {
                        TimeSlotDiv timeSlotDiv = new TimeSlotDiv()
                        {
                            time = slotTime,

                            staffID = _staffID,
                            roleNumber = _rolenumber++,
                            availability = "Available",
                            service = _service,
                            endDate = _endDate,
                            startDate = _startDate,
                            dateType = _dateType,
                            Day = _day,
                            WorkingDaysTupe = _WorkingDaysType

                        };

                        db.TimeSlotDivs.Add(timeSlotDiv);
                        db.SaveChanges();
                    }
                    string _count = count.ToString();

                    return _count;

                }
                return "";

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return "Invalid";
            }


        }

   

        [Route("api/TimeSlots/GetDate")]
        public List<string> GetDate(string staffName)
        {
            var Date = db.StudentReservedAppointments.Where(x => x.staffName == staffName).ToList();
            List<string> date = new List<string>();
            foreach (var _date in Date)
            {

                date.Add(_date.Date);
            }

            return date;
        }

    }
}