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
    public class RegisterNewStudentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [Route("api/RegisterNewStudents/GetRegisterNewStudents")]
        // GET: api/RegisterNewStudents/GetRegisterNewStudents
        public IEnumerable<RegisterNewStudent> GetRegisterNewStudents()
        {
            return db.RegisterNewStudents;
        }


        [HttpPost]
        [Route("api/RegisterNewStudents/Post")]
        // api/RegisterNewStudents/Post
        public IHttpActionResult Post([FromBody] RegisterNewStudent registerNewStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RegisterNewStudent registerNew = new RegisterNewStudent()
            {
                AdmissionCenter = registerNewStudent.AdmissionCenter,
                Area = registerNewStudent.Area,
                BuildingAr = registerNewStudent.BuildingAr,
                BuildingEng = registerNewStudent.BuildingEng,
                City = registerNewStudent.City,
                CivilId = registerNewStudent.CivilId,
                Confirm = registerNewStudent.Confirm,
                ContactNameAR = registerNewStudent.ContactNameAR,
                ContactNameEng = registerNewStudent.ContactNameEng,
                DateExpirationCiviSecurityCard = registerNewStudent.DateExpirationCiviSecurityCard,
                DateofBirthG = registerNewStudent.DateofBirthG,
                DateofBirthH = registerNewStudent.DateofBirthH,
                FamilyName = registerNewStudent.FamilyName,
                FirstName = registerNewStudent.FirstName,
                FloorAR = registerNewStudent.FloorAR,
                FloorEng = registerNewStudent.FloorEng,
                Gender = registerNewStudent.Gender,
                HaveJob = registerNewStudent.HaveJob,
                IDType = registerNewStudent.IDType,
                KindDisability = registerNewStudent.KindDisability,
                KindDisabilitySpecify = registerNewStudent.KindDisabilitySpecify,
                KnowAOU = registerNewStudent.KnowAOU,
                MobilePhone = registerNewStudent.MobilePhone,
                MyPHomePhoneNumber = registerNewStudent.MyPHomePhoneNumber,
                Nationality = registerNewStudent.Nationality,
                PersonalEmail = registerNewStudent.PersonalEmail,
                PhoneNumberAR = registerNewStudent.PhoneNumberAR,
                PhoneNumberEng = registerNewStudent.PhoneNumberEng,
                PlaceOfBirth = registerNewStudent.PlaceOfBirth,
                Program = registerNewStudent.Program,
                SecondName = registerNewStudent.SecondName,
                Semesters = registerNewStudent.Semesters,
                StreetAR = registerNewStudent.StreetAR,
                StreetEng = registerNewStudent.StreetEng,
                ThirdName = registerNewStudent.ThirdName,
                Track = registerNewStudent.Track
            };
            db.RegisterNewStudents.Add(registerNew);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

    }
}