using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEWMYSOFAPPLICATION.Models
{
    public class RegisterMember
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ID { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email in not valid")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$", ErrorMessage = "Passwords must have at least one non letter, one digit character, at least one lowercase ('a'-'z'), at least one uppercase ('A'-'Z'),and must be at least 6 characters long.(Valid special characters are – @#$%^&+=)")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public string MemberType { get; set; }

        public string StaffService { get; set; }

        public string StaffDepartment { get; set; }
        public virtual ICollection<LostPosting> LostPostings { get; set; }
        public virtual ICollection<StudentReservedAppointment> StudentReservedAppointments { get; set; }
    }
}