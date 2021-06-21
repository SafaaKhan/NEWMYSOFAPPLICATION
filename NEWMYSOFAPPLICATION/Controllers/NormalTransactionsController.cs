using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NEWMYSOFAPPLICATION.Models;

namespace NEWMYSOFAPPLICATION.Controllers
{
    public class NormalTransactionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        [Route("api/NormalTransactions/PostNormalTransaction")]
        //"api/registrationform/Post"
        public IHttpActionResult PostNormalTransaction([FromBody] NormalTransaction NormalTransactionObj)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //get photofolder path
            string photofolderName = "Files";
            string photopath = "";
            photopath = System.Web.Hosting.HostingEnvironment.MapPath("~/" + photofolderName);
            if (!System.IO.Directory.Exists(photopath))
            {
                System.IO.Directory.CreateDirectory(photopath); //Create directory if it doesn't exist
            }
            //convert byte array to image
            //Image _photo = Base64ToImage(RegistrationForm.FilePath);
            byte[] imageBytes = Convert.FromBase64String(NormalTransactionObj.FilePath);
            NormalTransactionObj.FilePath = DateTime.Now.ToString("yyyy-MM-dd_HHmm") + NormalTransactionObj.FileExtension;
            photopath = photopath + "/" + NormalTransactionObj.FilePath;
            //save photo to folder 
            File.WriteAllBytes(photopath, imageBytes);
            //check if photo saved correctlly into folder
            bool result = File.Exists(photopath);


            if (!result)
                throw new Exception("failed");// new WebFaultException<string>("failed", HttpStatusCode.ExpectationFailed);



            //RegistrationForm Form = new RegistrationForm()
            //{ 
            //    ID = RegistrationForm.ID, 
            //    FilePath = RegistrationForm.FilePath,
            //    Status = 0
            //};

            db.NormalTransactions.Add(NormalTransactionObj);
            db.SaveChanges();

            EmailMessenger emailMessenger = new EmailMessenger();
            emailMessenger.sendEmail(NormalTransactionObj.GraduatedORContinuing == "Graduate Student" ? NormalTransactionObj.EntEmailG : NormalTransactionObj.EntEmailC, " Request Status", "You request under review ...");

            return Ok(NormalTransactionObj.ID);// StatusCode(HttpStatusCode.Created);
        }
        [HttpGet]
        [Route("api/NormalTransactions/GetNormalTransactionStatus")]
        public IHttpActionResult GetNormalTransactionStatus(String FormID)
        {
            int id = Convert.ToInt32(FormID);
            return Ok(db.NormalTransactions.FirstOrDefault(r => r.ID == id));
        }

        [HttpGet]
        [Route("api/NormalTransactions/GetNormalTransactionPhrase")]
        public string  GetNormalTransactionPhrase(String FormID)
        {
            int id = Convert.ToInt32(FormID);
            string phrase= db.NormalTransactions.FirstOrDefault(r => r.ID == id).phrase ;

            return phrase;
        }

        [HttpGet]
        [Route("api/NormalTransactions/GetNormalTransaction")]
        public IHttpActionResult GetNormalTransaction()
        {

            return Ok(db.NormalTransactions);
        }
        [HttpGet]
        [Route("api/NormalTransactions/ChangeNormalTransactionStatus")]
        public IHttpActionResult ChangeNormalTransactionStatus(String FormID, String Status, String email, String phrase)
        {
            int id = Convert.ToInt32(FormID);
            db.NormalTransactions.FirstOrDefault(r => r.ID == id).Status = Status == "1" ? 1 : 2;
            db.NormalTransactions.FirstOrDefault(r => r.ID == id).phrase=phrase;
            

            db.SaveChanges();
            EmailMessenger emailMessenger = new EmailMessenger();
            emailMessenger.sendEmail(email, " Request", Status == "1" ? "Your Request has been approved by administrator," +
              " you can come to University to receive your order, Thank you ^_^" : "Your Request has been declined by administrator, thank you");
            return Ok(1);
        }

    }
}