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
    public class DepartmentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [Route("api/Departments/GetDepartments")]
        // GET: api/Departments
        public IEnumerable<Department> GetDepartments()
        {
            return db.Departments;
        }



        /* public string GetDepartments()
         {
             string department = "";
             var m = db.Departments.Include("RegisterMembers").ToList();
             foreach (var item in m)
             {
                 department=item.department;
             }
             return department;
         }*/
    }
}