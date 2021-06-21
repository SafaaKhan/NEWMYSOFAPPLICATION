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
    public class RegisterMembersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("api/RegisterMembers/GetStaffName")]
        public IEnumerable<RegisterMember> GetStaffName()
        {
            return db.RegisterMembers.Include("StudentReservedAppointments").Where(x => x.MemberType == "Academic" || x.MemberType == "Adminstrator").ToList();
        }



        //https://api-testingsof.conveyor.cloud/api/RegisterMembers/GetCMember
        [HttpGet]

        // api/RegisterMembers/GetMember
        [Route("api/RegisterMembers/GetMember")]
        public IEnumerable<RegisterMember> GetMember()
        {
            return db.RegisterMembers.Include("StudentReservedAppointments").ToList();
        }

        [HttpPost]
        // api/RegisterMembers/RegisterMember
        //if the user was academic and didnot passed the department wrong...!
        //try multiple input
        [Route("api/RegisterMembers/Post")]
        public IHttpActionResult Post([FromBody] RegisterMember registerMember, string memberType, string __staffService = "_", string _staffDepartment = "_")
        {
            if (!ModelState.IsValid)
            {
                //  return ModelState.IsValid;
                return StatusCode(HttpStatusCode.BadRequest);
            }

            if (memberType == "club")
            {
                try
                {
                    var clubMe = MemberVerifyOnliesController.GetClubIDMVerify();

                    bool statusNotFound = true;
                    foreach (var ClubStudent in clubMe)
                    {
                        if (ClubStudent.ID == registerMember.ID)
                        {
                            statusNotFound = false;
                            RegisterMember _registerMember = new RegisterMember()
                            {
                                Name = registerMember.Name,
                                ID = registerMember.ID,
                                Email = registerMember.Email,
                                Password = registerMember.Password,
                                ConfirmPassword = registerMember.ConfirmPassword,
                                MemberType = memberType,
                                StaffService = "-",
                                StaffDepartment = "-"
                            };

                            db.RegisterMembers.Add(_registerMember);
                            db.SaveChanges();
                            return StatusCode(HttpStatusCode.Created);
                            //  return true;
                            statusNotFound = true;
                            break;
                        }
                        else
                        {
                            statusNotFound = false;

                        }

                    }
                    if (!statusNotFound)
                    {
                        return StatusCode(HttpStatusCode.Created);
                    }
                    else
                    {
                        return StatusCode(HttpStatusCode.BadRequest);

                    }
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    return StatusCode(HttpStatusCode.BadRequest);
                }
            }

            else if (memberType == "security")
            {
                try
                {
                    var securityMe = MemberVerifyOnliesController.GetSecurityIDMVerify();

                    bool statusNotFound = true;
                    foreach (var SecurityMember in securityMe)
                    {
                        if (SecurityMember.ID == registerMember.ID)
                        {
                            statusNotFound = false;
                            RegisterMember _registerMember = new RegisterMember()
                            {
                                Name = registerMember.Name,
                                ID = registerMember.ID,
                                Email = registerMember.Email,
                                Password = registerMember.Password,
                                ConfirmPassword = registerMember.ConfirmPassword,
                                MemberType = memberType,
                                StaffService = "-",
                                StaffDepartment = "-"
                            };

                            db.RegisterMembers.Add(_registerMember);
                            db.SaveChanges();
                            //return StatusCode(HttpStatusCode.Created);
                            //  return true;
                            statusNotFound = true;
                            break;
                        }
                        else
                        {
                            statusNotFound = false;

                        }

                    }
                    if (!statusNotFound)
                    {
                        return StatusCode(HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        return StatusCode(HttpStatusCode.Created);
                    }
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    return StatusCode(HttpStatusCode.BadRequest);

                }
            }
            else if (memberType == "Adminstrator" || memberType == "Academic")
            {
                try
                {
                    var adminstratorMe = MemberVerifyOnliesController.GetAdminstratorIDMVerify();

                    bool statusNotFound = false;
                    foreach (var adminstratorMember in adminstratorMe)
                    {
                        if (adminstratorMember.ID == registerMember.ID.Trim())
                        {
                            statusNotFound = true;
                            if (memberType == "Adminstrator")
                            {


                                RegisterMember _registerMember = new RegisterMember()
                                {
                                    Name = registerMember.Name,
                                    ID = registerMember.ID,
                                    Email = registerMember.Email,
                                    Password = registerMember.Password,
                                    ConfirmPassword = registerMember.ConfirmPassword,
                                    MemberType = memberType,
                                    StaffService = __staffService,
                                    StaffDepartment = "-"

                                };

                                db.RegisterMembers.Add(_registerMember);
                                db.SaveChanges();
                                statusNotFound = true;
                                break;
                            }

                            else if (memberType == "Academic")
                            {
                                RegisterMember _registerMember = new RegisterMember()
                                {
                                    Name = registerMember.Name,
                                    ID = registerMember.ID,
                                    Email = registerMember.Email,
                                    Password = registerMember.Password,
                                    ConfirmPassword = registerMember.ConfirmPassword,
                                    MemberType = memberType,
                                    StaffService = __staffService,
                                    StaffDepartment = _staffDepartment

                                };

                                db.RegisterMembers.Add(_registerMember);
                                db.SaveChanges();
                                statusNotFound = true;
                                break;
                            }
                            //return StatusCode(HttpStatusCode.Created);
                            //  return true;


                        }///correct
                        else
                        {
                            statusNotFound = false;

                        }

                    }
                    if (statusNotFound)
                    {
                        ServicesOfStaffs servicesOfStaffs = new ServicesOfStaffs()
                        {
                            staffID = registerMember.ID,
                            staffName = registerMember.Name,
                            staffServices = __staffService
                        };
                        db.ServicesOfStaffs.Add(servicesOfStaffs);
                        db.SaveChanges();
                        return StatusCode(HttpStatusCode.Created);
                    }
                    else
                    {
                        return StatusCode(HttpStatusCode.BadRequest);
                    }
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    return StatusCode(HttpStatusCode.BadRequest);

                }
            }
            else if (memberType == "Normal Student")//? how to ensure?
            {
                try
                {
                    RegisterMember _registerMember = new RegisterMember()
                    {
                        Name = registerMember.Name,
                        ID = registerMember.ID,
                        Email = registerMember.Email,
                        Password = registerMember.Password,
                        ConfirmPassword = registerMember.ConfirmPassword,
                        MemberType = memberType,
                        StaffService = "-",
                        StaffDepartment = "-"
                    };

                    db.RegisterMembers.Add(_registerMember);
                    db.SaveChanges();
                    //return StatusCode(HttpStatusCode.Created);
                    return StatusCode(HttpStatusCode.Created);

                }
                catch (Exception e)
                {
                    var error = e.Message;
                    return StatusCode(HttpStatusCode.BadRequest);

                }
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

        }



        string _staffservice;

        //api/RegisterMembers/GetStaffService
        [Route("api/RegisterMembers/GetStaffService")]
        [HttpGet]
        public void GetStaffService(string staffservice)
        {
            _staffservice = staffservice;
        }



        //api/RegisterMembers/GetClubMember
        [Route("api/RegisterMembers/GetClubMember")]
        [HttpGet]
        public List<RegisterMember> GetClubMember()
        {
            List<RegisterMember> registerMembers = new List<RegisterMember>();

            var _clubMember = db.RegisterMembers.Where(x => x.MemberType == "club").ToList();
            return _clubMember;

        }

        [HttpGet]
        // api/RegisterMembers/StudentLogin
        public string StudentLogin(string password, string Id)
        {

            try
            {
                var login = db.RegisterMembers.Where(x => x.ID == Id && x.Password == password).Single();
                if (login == null)
                {
                    return "login is invalid";//change 
                }
                else
                {
                    return login.Name;
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
                return "login is invalid";
            }

        }

        //api/RegisterMembers/GetClubMember
        [Route("api/RegisterMembers/GetSecurityMember")]
        [HttpGet]
        public List<RegisterMember> GetSecurityMember()
        {


            var securitystaff = db.RegisterMembers.Where(x => x.MemberType == "security").ToList();
            return securitystaff;

        }



        //fet adminstrator service
        [Route("api/RegisterMembers/GetAdminstratorService")]
        [HttpGet]
        public string GetAdminstratorService(string staffID)
        {


            var staff = db.RegisterMembers.Where(x => x.ID == staffID).ToList();
            string staffservice = "";
            foreach (var service in staff)
            {
                staffservice = service.StaffService;
            }
            return staffservice;

        }

        //Get Adminstrator and Acamenic members from RegisterMember Table
        //api/RegisterMembers/GetAdminstratorMember
        [Route("api/RegisterMembers/GetAdminstratorMember")]
        [HttpGet]
        public List<RegisterMember> GetAdminstratorMember()
        {


            var Adminstratorstaff = db.RegisterMembers.Where(x => x.MemberType == "Adminstrator" || x.MemberType == "Academic").ToList();
            return Adminstratorstaff;

        }


        //Get Adminstrator member from RegisterMember Table
        //api/RegisterMembers/GetStudentMember
        [Route("api/RegisterMembers/GetStudentMember")]
        [HttpGet]
        public List<RegisterMember> GetStudentMember()
        {
            List<RegisterMember> registerStudentsAppointment = new List<RegisterMember>();
            //هل لازم الكلب يسجل ثاني كطالب؟
            var student = db.RegisterMembers.Where(x => x.MemberType == "Normal Student" || x.MemberType == "club").ToList();
            foreach (var studentAppointment in student)
            {
                if (studentAppointment.StudentReservedAppointments != null)
                {
                    if (studentAppointment.StudentReservedAppointments.Count() != 0)
                        registerStudentsAppointment.Add(studentAppointment);
                }
            }

            return registerStudentsAppointment;

        }

        [Route("api/RegisterMembers/GetStudentMember2")]
        // api/RegisterMembers/GetStudentMember2
        public List<string> GetStudentMember2()
        {
            List<string> name = new List<string>();

            var student = db.RegisterMembers.Where(x => x.MemberType == "Normal Student" || x.MemberType == "club").ToList();
            foreach (var studentAppointment in student)
            {
                if (studentAppointment.StudentReservedAppointments != null)
                {
                    if (studentAppointment.StudentReservedAppointments.Count() != 0)
                        name.Add(studentAppointment.Name);
                }
            }

            return name;

        }


        public string GetTime(string id)//id
        {
            List<RegisterMember> registerMembers = GetStudentMember();
            var s = db.RegisterMembers.Where(a => a.ID == id).ToList();
            foreach (var i in s)
            {
                foreach (var w in i.StudentReservedAppointments)
                {
                    return w.Date.ToString();
                }
            }

            return "";
        }


        List<StudentReservedAppointment> registerStudentsAppointment;
        //Get Adminstrator member from RegisterMember Table
        //api/RegisterMembers/GetStudentMember_2
        [Route("api/RegisterMembers/GetStudentMember_2")]
        [HttpGet]
        public List<StudentReservedAppointment> GetStudentMember_2(string staffID)
        {
            string staffName = "";
            var member = db.RegisterMembers.Where(x => x.ID == staffID).ToList();
            foreach (var name in member)
            {
                staffName = name.Name;
            }
            //هل لازم club يسجل ثاني كطالب؟
            var student = db.StudentReservedAppointments.Where(x => x.staffName == staffName && x.isDone == "waiting").ToList();


            registerStudentsAppointment = student;

            return student;

        }



        //Get Adminstrator member from RegisterMember Table
        //api/RegisterMembers/GetStudentMember_2
        [Route("api/RegisterMembers/GetStaffName")]
        [HttpGet]
        public string GetStaffName(string staffID)
        {
            string staffName = "";
            var member = db.RegisterMembers.Where(x => x.ID == staffID).ToList();
            foreach (var name in member)
            {
                staffName = name.Name;
            }

            return staffName;



        }












        [Route("api/RegisterMembers/GetStudentMemberStudent_2")]
        [HttpGet]
        public List<StudentReservedAppointment> GetStudentMemberStudent_2(string studentID)
        {

            var student = db.StudentReservedAppointments.Where(x => x.studentID == studentID && x.isDone == "waiting").ToList();


            registerStudentsAppointment = student;

            return student;

        }



        List<StudentReservedAppointment> registerStudentsAppointment3;
        //get done  appointment
        //api/RegisterMembers/GetStudentMember_2
        [Route("api/RegisterMembers/GetStudentMember_3")]
        [HttpGet]
        public List<StudentReservedAppointment> GetStudentMember_3(string staffID)
        {
            string staffName = "";
            var member = db.RegisterMembers.Where(x => x.ID == staffID).ToList();
            foreach (var name in member)
            {
                staffName = name.Name;
            }
            //هل لازم club يسجل ثاني كطالب؟
            var student = db.StudentReservedAppointments.Where(x => x.staffName == staffName && x.isDone == "Done").ToList();


            registerStudentsAppointment3 = student;

            return student;

        }


        [Route("api/RegisterMembers/GetStudentMember_3Student")]
        [HttpGet]
        public List<StudentReservedAppointment> GetStudentMember_3Student(string studentID)
        {

            var student = db.StudentReservedAppointments.Where(x => x.studentID == studentID && x.isDone == "Done").ToList();


            registerStudentsAppointment3 = student;

            return student;

        }

        //get cancel appointment
        [Route("api/RegisterMembers/GetStudentMember_4")]
        public List<StudentReservedAppointment> GetStudentMember_4(string staffID)
        {
            string staffName = "";
            var member = db.RegisterMembers.Where(x => x.ID == staffID).ToList();
            foreach (var name in member)
            {
                staffName = name.Name;
            }
            //هل لازم club يسجل ثاني كطالب؟
            var student = db.StudentReservedAppointments.Where(x => x.staffName == staffName && x.isDone == "Cancel").ToList();

            return student;

        }


        //get cancel appointment
        [Route("api/RegisterMembers/GetStudentMemberStudent_4")]
        public List<StudentReservedAppointment> GetStudentMemberStudent_4(string studentID)
        {

            var student = db.StudentReservedAppointments.Where(x => x.studentID == studentID && x.isDone == "Cancel").ToList();

            return student;

        }
        /*   public string GetStudentName()
           {
               List<string> _id=new List<string>();
               foreach(var id in registerStudentsAppointment)
               {
                  _id.Add( id.studentID);
               }
               var student = db.RegisterMembers.Where(x => x.ID == _id);
           }*/

















        [HttpGet]
        // api/RegisterMembers/GetMemberEmail
        public List<RegisterMember> GetMemberEmail(string ID)
        {
            var memberEmail = db.RegisterMembers.Where(x => x.ID == ID).Include("LostPostings").ToList();
            return memberEmail;
        }

        [HttpGet]
        // api/RegisterMembers/GetStaffEmail

        [Route("api/RegisterMembers/GetStaffEmail")]
        public string GetStaffEmail(string staffName)
        {
            string email = "";
            var memberEmail = db.RegisterMembers.Where(x => x.Name == staffName).ToList();
            foreach (var element in memberEmail)
            {
                email = element.Email;
            }
            return email;

        }

        /* [HttpGet]
         // api/LostPostings/GetMemberEmail_2
         [Route("api/LostPostings/GetMemberEmail_2")]
         public List<LostPosting> GetMemberEmail_2()
         {

             var m = db.LostPostings.Include("RegisterMembers").ToList();
             return m;
         }*/


        /* [HttpGet]
         // api/RegisterMembers/GetMemberEmail
         public List<LostPosting> GetMemberEmail_2(string ID)
         {

             var m= db.LostPostings.Where(x =>x.RegisterMembers.Contains(ID) ==)
             return memberEmail;
         }*/



        // api/RegisterMembers/SecurityLogin
        [Route("api/RegisterMembers/SecurityLogin")]
        [HttpGet]
        public string SecurityLogin(string password, string Id)
        {

            try
            {
                var login = db.RegisterMembers.Where(x => x.ID == Id && x.Password == password).Single();
                if (login == null)
                {
                    return "login is invalid";//change 
                }
                else
                {
                    return login.Name;
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
                return "login is invalid";
            }

        }



        // api/RegisterMembers/AdminstratorLogin
        [Route("api/RegisterMembers/AdminstratorLogin")]
        [HttpGet]
        public string AdminstratorLogin(string password, string Id)
        {

            try
            {
                var login = db.RegisterMembers.Where(x => x.ID == Id && x.Password == password).Single();
                if (login == null)
                {
                    return "login is invalid";//change 
                }
                else
                {
                    return login.Name;
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
                return "login is invalid";
            }

        }


        //Get Information for staff List
        //Student name
        //ID t
        //Time t
        //Date t
        //email
        /*
        public string GetStudentAppointmentInfoForStaff()
        {
            List<string> email= 
            var m = db.RegisterMembers.ToList();
            foreach(var member in m)
            {
                
            }
        }
        */
    }
}