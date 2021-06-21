using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace NEWMYSOFAPPLICATION.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.FullDates> FullDates { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.LostPosting> LostPostings { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.MemberVerifyOnly> MemberVerifyOnlies { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.NormalTransaction> NormalTransactions { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.PostingEvents_N> PostingEvents_N { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.RegisterMember> RegisterMembers { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.RegisterNewStudent> RegisterNewStudents { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.RegistrationForm> RegistrationForms { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.ServicesOfStaffs> ServicesOfStaffs { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.StudentReservedAppointment> StudentReservedAppointments { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.TimeSlotDiv> TimeSlotDivs { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.TimeSlots> TimeSlots { get; set; }

        public System.Data.Entity.DbSet<NEWMYSOFAPPLICATION.Models.Tracking> Trackings { get; set; }
    }
}