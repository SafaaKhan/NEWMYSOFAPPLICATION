using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEWMYSOFAPPLICATION.Models
{
    public class RegistrationForm
    {
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string EntSemesters { get; set; }
        public string EntCenter { get; set; }
        public string EntCivilID { get; set; }
        [Required]
        public string EntArabicName { get; set; }
        public string EntEnglishName { get; set; }
        public string EntArabicSecond { get; set; }
        public string EntEnglishSecond { get; set; }
        public string EntArabicThird { get; set; }
        public string EntEnglishThird { get; set; }
        [Required]
        public string EntArabicFamily { get; set; }
        public string EntEnglishFamily { get; set; }
        [Required]
        public string EntMale { get; set; }
        [Required]
        public string EntFemale { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string EntGregorian { get; set; }
        public string EntHijri { get; set; }
        public string EntBirthDay { get; set; }
        [Required]
        public string EntBirthPlace { get; set; }
        [Required]
        public string EntNationality { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string EntEXPDateID { get; set; }
        [Required]
        public string EntIDType { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string EntPhoneNumH { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string EntMobileNum { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email in not valid")]
        public string EntEmail { get; set; }
        [Required]
        public string EntArea { get; set; }
        [Required]
        public string EntCity { get; set; }
        [Required]
        public string EntArStreet { get; set; }
        public string EntEnStreet { get; set; }
        [Required]
        public string EntArBuilding { get; set; }
        public string EntEnBuilding { get; set; }
        [Required]
        public string EntArFloor { get; set; }
        public string EntEnFloor { get; set; }
        [Required]
        public string EntArtSience { get; set; }
        public string EntCuorses { get; set; }
        [Required]
        public string EntCertificateType { get; set; }
        [Required]
        public string EntAverage { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string EntGraduateYear { get; set; }
        [Required]
        public string EntCountry { get; set; }
        [Required]
        public string EntEnglishLevel { get; set; }
        public string EntQyasGrade { get; set; }
        [Required]
        public string EntTofelTest { get; set; }
        [Required]
        public string EntProgram { get; set; }
        [Required]
        public string EntTrack { get; set; }
        public string EntHaveAjob { get; set; }
        public string EntKnowingOfAOU { get; set; }
        [Required]
        public string EntHaveDisAbility { get; set; }
        [Required]
        public string EntContactName { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string EntPhoneNumEm { get; set; }
        public String FilePath { get; set; }
        public int Status { get; set; }

    }
}