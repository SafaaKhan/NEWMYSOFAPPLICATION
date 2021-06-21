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
    public class RegistrationFormsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        //public static Image Base64ToImage(string base64String)
        //{
        //    // Convert Base64 String to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0,
        //      imageBytes.Length);

        //    // Convert byte[] to Image
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    Image image = Image.FromStream(ms, true);
        //    return image;
        //}



        // GET: api/RegistrationForms
        //public IEnumerable<RegistrationForm> GetRegistrationForms()
        //{
        //    return db.RegistrationForms;
        //}



        [HttpGet]
        [Route("api/RegistrationForms/ChangeStatus")]
        //"api/registrationform/Get"
        public IHttpActionResult ChangeStatus(String FormID, String Status, String email)
        {
            int id = Convert.ToInt32(FormID);
            db.RegistrationForms.FirstOrDefault(r => r.ID == id).Status = Status == "1" ? 1 : 2;
            db.SaveChanges();
            EmailMessenger emailMessenger = new EmailMessenger();
            emailMessenger.sendEmail(email, "Registration", Status == "1" ? "Your Registration form has been approved by administrator," +
              " you can come to University to take the placement test and complete the rigistration procedures, Thank you ^_^" : "Your Registration form has been declined by administrator, thank you");
            return Ok(1);
        }



        [HttpPost]
        [Route("api/RegistrationForms/Post")]
        //"api/registrationform/Post"
        public IHttpActionResult Post([FromBody] RegistrationForm RegistrationForm)
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
            byte[] imageBytes = Convert.FromBase64String(RegistrationForm.FilePath);
            RegistrationForm.FilePath = DateTime.Now.ToString("yyyy-MM-dd_HHmm") + ".pdf";
            photopath = photopath + "/" + RegistrationForm.FilePath;
            //save photo to folder 
            File.WriteAllBytes(photopath, imageBytes);
            //chech if photo saved correctlly into folder
            bool result = File.Exists(photopath);


            if (!result)
                throw new Exception("failed");// new WebFaultException<string>("failed", HttpStatusCode.ExpectationFailed);



            //RegistrationForm Form = new RegistrationForm()
            //{
            //    EntCenter = RegistrationForm.EntCenter,
            //    EntArea = RegistrationForm.EntArea,
            //    EntAverage = RegistrationForm.EntAverage,
            //    EntArBuilding = RegistrationForm.EntArBuilding,
            //    EntEnBuilding = RegistrationForm.EntEnBuilding,
            //    EntCertificateType = RegistrationForm.EntCertificateType,
            //    EntCity = RegistrationForm.EntCity,
            //    EntCivilID = RegistrationForm.EntCivilID,
            //    EntContactName = RegistrationForm.EntContactName,
            //    EntCountry = RegistrationForm.EntCountry,
            //    EntBirthDay = RegistrationForm.EntBirthDay,
            //    EntHijri = RegistrationForm.EntHijri,
            //    EntEXPDateID = RegistrationForm.EntEXPDateID,
            //    EntHaveAjob = RegistrationForm.EntHaveAjob,
            //    EntEnglishLevel = RegistrationForm.EntEnglishLevel,
            //    EntArabicFamily = RegistrationForm.EntArabicFamily,
            //    EntEnglishFamily = RegistrationForm.EntEnglishFamily,
            //    EntArabicName = RegistrationForm.EntArabicName,
            //    EntArabicSecond = RegistrationForm.EntArabicSecond,
            //    EntArFloor = RegistrationForm.EntArFloor,
            //    EntEnFloor = RegistrationForm.EntEnFloor,
            //    EntFemale = RegistrationForm.EntFemale,
            //    EntMale = RegistrationForm.EntMale,
            //    EntGraduateYear = RegistrationForm.EntGraduateYear,
            //    EntTofelTest = RegistrationForm.EntTofelTest,
            //    EntPhoneNumH = RegistrationForm.EntPhoneNumH,
            //    ID = RegistrationForm.ID,
            //    EntIDType = RegistrationForm.EntIDType,
            //    EntHaveDisAbility = RegistrationForm.EntHaveDisAbility,
            //    EntKnowingOfAOU = RegistrationForm.EntKnowingOfAOU,
            //    EntMobileNum = RegistrationForm.EntMobileNum,
            //    EntNationality = RegistrationForm.EntNationality,
            //    EntPhoneNumEm = RegistrationForm.EntPhoneNumEm,
            //    EntEnglishName = RegistrationForm.EntEnglishName,
            //    EntBirthPlace = RegistrationForm.EntBirthPlace,
            //    EntProgram = RegistrationForm.EntProgram,
            //    EntQyasGrade = RegistrationForm.EntQyasGrade,
            //    EntEnglishSecond = RegistrationForm.EntSemesters,
            //    EntSemesters = RegistrationForm.EntSemesters,
            //    EntArabicThird = RegistrationForm.EntArabicThird,
            //    EntArStreet = RegistrationForm.EntArStreet,
            //    EntEnStreet = RegistrationForm.EntEnStreet,
            //    EntArtSience = RegistrationForm.EntArtSience,
            //    EntCuorses = RegistrationForm.EntCuorses,
            //    EntTrack = RegistrationForm.EntTrack,
            //    EntEmail = RegistrationForm.EntEmail,
            //    EntEnglishThird = RegistrationForm.EntEnglishThird,
            //    EntGregorian = RegistrationForm.EntGregorian,
            //    FilePath = RegistrationForm.FilePath,
            //    Status = 0
            //};

            db.RegistrationForms.Add(RegistrationForm);
            db.SaveChanges();

            EmailMessenger emailMessenger = new EmailMessenger();
            emailMessenger.sendEmail(RegistrationForm.EntEmail, "Registration forms", "You Registration form under review...");

            return Ok(RegistrationForm.ID);//StatusCode(HttpStatusCode.Created);
        }



        //[HttpPost]
        //[Route("api/registrationform/GetFile")]
        //public HttpResponseMessage GetFile(FileHelper fileHelper)
        //{
        //    try
        //    {
        //        //get photofolder path
        //        string photofolderName = "Files";
        //        string photopath = "";
        //        photopath = System.Web.Hosting.HostingEnvironment.MapPath("~/" + photofolderName);
        //        photopath = photopath + "/" + fileHelper.FilePath;

        //        var bytes = default(byte[]);
        //        using (System.IO.StreamReader file = new System.IO.StreamReader(photopath))
        //        {
        //            //if (file.Read())
        //            using (var memstream = new MemoryStream())
        //            {
        //                file.BaseStream.CopyTo(memstream);
        //                bytes = memstream.ToArray();
        //            }
        //        }
        //        GC.Collect();
        //        return Request.CreateResponse(HttpStatusCode.OK, bytes);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message);
        //    }
        //}



        // GET: api/RegistrationForms
        //public IEnumerable<RegistrationForm> PostRegistrationForms()
        //{
        //    return db.RegistrationForms;
        //}
        [HttpGet]
        [Route("api/RegistrationForms/Get")]
        //"api/registrationform/Get"
        public IHttpActionResult Get()
        {

            return Ok(db.RegistrationForms);
        }

        [HttpGet]
        [Route("api/RegistrationForms/GetTransactionStatus")]
        public IHttpActionResult GetTransactionStatus(String FormID)
        {
            int id = Convert.ToInt32(FormID);
            return Ok(db.RegistrationForms.FirstOrDefault(r => r.ID == id));
        }


        // private ApplicationDbContext db = new ApplicationDbContext();

        //public IEnumerable<NormalTransaction> GetNormalTransaction()
        //{
        //    return db.NormalTransaction;
        //}
        //[HttpPost]
        //[Route("api/registrationform/Post")]
        ////"api/NormalStudent/Post"
        //public IHttpActionResult Post([FromBody] NormalTransaction normalTransaction)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);

        //    }

        //    NormalTransaction transaction = new NormalTransaction()
        //    {

        //        EntContinuingSt = normalTransaction.EntContinuingSt,
        //        EntGraduateSt = normalTransaction.EntGraduateSt,
        //        ID = normalTransaction.ID,

        //    };
        //    db.Normal.Add(NormalTransaction);
        //    db.SaveChanges();
        //}
    }
}