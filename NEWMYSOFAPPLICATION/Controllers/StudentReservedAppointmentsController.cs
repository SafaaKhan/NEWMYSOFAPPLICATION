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
    public class StudentReservedAppointmentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //number with time//////////////


        // GET: api/StudentReservedAppointments
        public IEnumerable<StudentReservedAppointment> GetStudentReservedAppointments(string staffName)
        {
            return db.StudentReservedAppointments.Where(x => x.staffName == staffName);
        }


        public void PostIsDoneIsCancelledBy(string message)
        {

        }


        //test
        //post ReservedApoointment
        [Route("api/StudentReservedAppointments/ReservedApoointment")]
        public IHttpActionResult ReservedApoointment([FromBody] StudentReservedAppointment studentReservedAppointment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }



                StudentReservedAppointment _studentRA = new StudentReservedAppointment()
                {
                    serviceName = studentReservedAppointment.serviceName,
                    staffName = studentReservedAppointment.staffName,
                    Date = studentReservedAppointment.Date,
                    studentID = studentReservedAppointment.studentID,
                    Time = studentReservedAppointment.Time,
                    StudentEmail = GetEmail(studentReservedAppointment.studentID),
                    studentName = GetName(studentReservedAppointment.studentID),
                    availability = "unavailable",
                    isDone = "waiting",
                    roleNumber = studentReservedAppointment.roleNumber


                };
                db.StudentReservedAppointments.Add(_studentRA);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return StatusCode(HttpStatusCode.Created);
        }

        //Get the student name accoding its id
        public string GetEmail(string id)
        {
            var student = db.RegisterMembers.Where(x => x.ID == id);
            foreach (var _student in student)
            {
                return _student.Email;
            }
            return "";
        }

        //Get the student name accoding its id
        public string GetName(string id)
        {
            var student = db.RegisterMembers.Where(x => x.ID == id);
            foreach (var _student in student)
            {
                return _student.Name;
            }
            return "";
        }

        //update the state if isDone=done
        [HttpPut()]
        [Route("api/StudentReservedAppointments/UpdateState")]
        //api/StudentReservedAppointments/UpdateState
        public void UpdateState(int id, string who)
        {
            var appointment = db.StudentReservedAppointments.Find(id);
            appointment.isDone = "Done";
            if (who == "staff")
            {
                appointment.isDoneby = "Done is pressed by the staff";
            }
            else
            {
                appointment.isDoneby = "Done is pressed by the student";
            }
            db.SaveChanges();


        }



        //update the state if isDone=done
        [HttpPut()]
        [Route("api/StudentReservedAppointments/CancelState")]
        //api/StudentReservedAppointments/CancelState
        public void CancelState(int id, string who)
        {
            var appointment = db.StudentReservedAppointments.Find(id);
            appointment.isDone = "Cancel";
            if (who == "staff")
            {
                appointment.isCancelledby = "The appointment is cancelled by the staff";
            }
            else
            {
                appointment.isCancelledby = "The appointment is cancelled by the student";
            }
            db.SaveChanges();


        }

        //delete cancelled appointment
        //api/StudentReservedAppointments/DeleteAppoitment
        [HttpDelete()]
        [Route("api/StudentReservedAppointments/DeleteAppoitment")]
        public void DeleteAppoitment([FromUri] List<int> ids)
        {
            foreach (var id in ids)
            {
                var appointment = db.StudentReservedAppointments.Find(id);
                db.StudentReservedAppointments.Remove(appointment);
                db.SaveChanges();
            }

        }

        /// <summary>
        /// delete all the staff services
        /// </summary>
        /// <param name="ids"></param>
        [HttpDelete()]
        [Route("api/StudentReservedAppointments/Deleteservice")]
        public void Deleteservice([FromUri] List<int> ids)//staff_id/delete from many spaces in DB
        {
            foreach (var id in ids)
            {
                var service = db.TimeSlots.Find(id);
                //   var service

                db.TimeSlots.Remove(service);

                db.SaveChanges();
                CompeleteDeleteSpecificService(service);
            }

        }

        //https://api-testingsof.conveyor.cloud/api/StudentReservedAppointments/DeleteSpecificService?id=9
        /// <summary>
        /// delete the service was choosen? by staff
        /// </summary>
        /// <param name="id"></param>

        [HttpDelete()]
        [Route("api/StudentReservedAppointments/DeleteSpecificService")]
        public void DeleteSpecificService(int id)//staff_id/delete from many spaces in DB
        {
            var service = db.TimeSlots.Find(id);
            db.TimeSlots.Remove(service);
            db.SaveChanges();
            CompeleteDeleteSpecificService(service);



        }

        [HttpDelete()]
        [Route("api/StudentReservedAppointments/DeleteSpecificService")]
        public void CompeleteDeleteSpecificService(TimeSlots service__)
        {
            IEnumerable<TimeSlotDiv> services = db.TimeSlotDivs.Where(x => x.staffID == service__.staffID && x.dateType == service__.dateType
             && x.startDate == service__.startDate && x.endDate == service__.endDate && x.service == service__.service).ToList();
            foreach (var service_ in services)
            {
                db.TimeSlotDivs.Remove(service_);
                db.SaveChanges();
            }
        }
    }
}