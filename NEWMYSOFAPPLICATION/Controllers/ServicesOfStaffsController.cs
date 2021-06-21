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
    public class ServicesOfStaffsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ServicesOfStaffs
        public List<string> GetServicesOfStaffs()
        {
            var service = db.ServicesOfStaffs;
            List<string> services = new List<string>();
            foreach (var _service in service)
            {
                services.Add(_service.staffServices);
            }

            return services;
        }

        // GET: 
        [Route("api/ServicesOfStaffs/GetNameOfStaffs")]
        public List<string> GetNameOfStaffs(string serviceType, string departmentType)
        {
            var name = db.RegisterMembers.ToList();
            if (departmentType == "_")
            {
                name = db.RegisterMembers.Where(x => x.StaffService == serviceType).ToList();
            }
            else
            {
                name = db.RegisterMembers.Where(x => x.StaffDepartment == departmentType).ToList();
            }
            List<string> names = new List<string>();
            foreach (var _name in name)
            {
                names.Add(_name.Name);
            }

            return names;
        }
    }
}