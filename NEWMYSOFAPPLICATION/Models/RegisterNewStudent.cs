using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEWMYSOFAPPLICATION.Models
{
    public class RegisterNewStudent
    {
        public int ID { get; set; }
        [Required]
        public string Semesters { get; set; }
        public string AdmissionCenter { get; set; }
        public string CivilId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string DateofBirthG { get; set; }
        [Required]
        public string DateofBirthH { get; set; }//DateTime
        [Required]
        public string IDType { get; set; }
        [Required]
        public string PlaceOfBirth { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string DateExpirationCiviSecurityCard { get; set; }
        [Required]
        public string MyPHomePhoneNumber { get; set; }
        [Required]

        public string PersonalEmail { get; set; }
        [Required]
        public string MobilePhone { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string StreetEng { get; set; }
        [Required]
        public string BuildingEng { get; set; }
        [Required]
        public string FloorEng { get; set; }
        [Required]
        public string StreetAR { get; set; }
        [Required]
        public string BuildingAr { get; set; }
        [Required]
        public string FloorAR { get; set; }
        [Required]
        public string Program { get; set; }
        [Required]
        public string Track { get; set; }

        public string HaveJob { get; set; }
        public string KindDisability { get; set; }
        public string KindDisabilitySpecify { get; set; }
        public string KnowAOU { get; set; }
        [Required]
        public string ContactNameEng { get; set; }
        [Required]
        public string PhoneNumberEng { get; set; }
        [Required]
        public string ContactNameAR { get; set; }
        [Required]
        public string PhoneNumberAR { get; set; }
        public string Confirm { get; set; }
    }
}