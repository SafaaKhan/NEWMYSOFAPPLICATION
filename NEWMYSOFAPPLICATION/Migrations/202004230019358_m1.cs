namespace NEWMYSOFAPPLICATION.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        department = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FullDates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        date = c.String(),
                        staffName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LostPostings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ResponsibleName = c.String(),
                        Information = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RegisterMembers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        MemberType = c.String(),
                        StaffService = c.String(),
                        StaffDepartment = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentReservedAppointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        studentID = c.String(),
                        studentName = c.String(),
                        StudentEmail = c.String(),
                        staffName = c.String(),
                        serviceName = c.String(),
                        Date = c.String(),
                        Time = c.String(),
                        status = c.Boolean(nullable: false),
                        isDone = c.String(),
                        availability = c.String(),
                        isVisibale = c.Boolean(nullable: false),
                        roleNumber = c.Int(nullable: false),
                        WorkingDaysTupe = c.String(),
                        Day = c.String(),
                        isDoneby = c.String(),
                        isCancelledby = c.String(),
                        RegisterMember_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RegisterMembers", t => t.RegisterMember_ID)
                .Index(t => t.RegisterMember_ID);
            
            CreateTable(
                "dbo.MemberVerifyOnlies",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Membertype = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NormalTransactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        lbContinuing = c.String(),
                        EntIdC = c.String(),
                        EntNameC = c.String(),
                        EntEmailC = c.String(),
                        lbGraduate = c.String(),
                        EntIdG = c.String(),
                        EntNameG = c.String(),
                        EntContinuingSt = c.String(),
                        EntEmailG = c.String(),
                        EntGraduateSt = c.String(),
                        FilePath = c.String(),
                        EntcontinuosTransaction = c.String(),
                        EntGraduateTransaction = c.String(),
                        GraduatedORContinuing = c.String(),
                        Status = c.Int(nullable: false),
                        FileExtension = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostingEvents_N",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(),
                        Title = c.String(),
                        Information = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RegisterNewStudents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Semesters = c.String(nullable: false),
                        AdmissionCenter = c.String(),
                        CivilId = c.String(),
                        FirstName = c.String(nullable: false),
                        SecondName = c.String(),
                        ThirdName = c.String(),
                        FamilyName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        DateofBirthG = c.String(nullable: false),
                        DateofBirthH = c.String(nullable: false),
                        IDType = c.String(nullable: false),
                        PlaceOfBirth = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        DateExpirationCiviSecurityCard = c.String(nullable: false),
                        MyPHomePhoneNumber = c.String(nullable: false),
                        PersonalEmail = c.String(nullable: false),
                        MobilePhone = c.String(nullable: false),
                        Area = c.String(nullable: false),
                        City = c.String(nullable: false),
                        StreetEng = c.String(nullable: false),
                        BuildingEng = c.String(nullable: false),
                        FloorEng = c.String(nullable: false),
                        StreetAR = c.String(nullable: false),
                        BuildingAr = c.String(nullable: false),
                        FloorAR = c.String(nullable: false),
                        Program = c.String(nullable: false),
                        Track = c.String(nullable: false),
                        HaveJob = c.String(),
                        KindDisability = c.String(),
                        KindDisabilitySpecify = c.String(),
                        KnowAOU = c.String(),
                        ContactNameEng = c.String(nullable: false),
                        PhoneNumberEng = c.String(nullable: false),
                        ContactNameAR = c.String(nullable: false),
                        PhoneNumberAR = c.String(nullable: false),
                        Confirm = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RegistrationForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntSemesters = c.String(nullable: false),
                        EntCenter = c.String(),
                        EntCivilID = c.String(),
                        EntArabicName = c.String(nullable: false),
                        EntEnglishName = c.String(),
                        EntArabicSecond = c.String(),
                        EntEnglishSecond = c.String(),
                        EntArabicThird = c.String(),
                        EntEnglishThird = c.String(),
                        EntArabicFamily = c.String(nullable: false),
                        EntEnglishFamily = c.String(),
                        EntMale = c.String(nullable: false),
                        EntFemale = c.String(nullable: false),
                        EntGregorian = c.String(nullable: false),
                        EntHijri = c.String(),
                        EntBirthDay = c.String(),
                        EntBirthPlace = c.String(nullable: false),
                        EntNationality = c.String(nullable: false),
                        EntEXPDateID = c.String(nullable: false),
                        EntIDType = c.String(nullable: false),
                        EntPhoneNumH = c.String(nullable: false),
                        EntMobileNum = c.String(nullable: false),
                        EntEmail = c.String(nullable: false),
                        EntArea = c.String(nullable: false),
                        EntCity = c.String(nullable: false),
                        EntArStreet = c.String(nullable: false),
                        EntEnStreet = c.String(),
                        EntArBuilding = c.String(nullable: false),
                        EntEnBuilding = c.String(),
                        EntArFloor = c.String(nullable: false),
                        EntEnFloor = c.String(),
                        EntArtSience = c.String(nullable: false),
                        EntCuorses = c.String(),
                        EntCertificateType = c.String(nullable: false),
                        EntAverage = c.String(nullable: false),
                        EntGraduateYear = c.String(nullable: false),
                        EntCountry = c.String(nullable: false),
                        EntEnglishLevel = c.String(nullable: false),
                        EntQyasGrade = c.String(),
                        EntTofelTest = c.String(nullable: false),
                        EntProgram = c.String(nullable: false),
                        EntTrack = c.String(nullable: false),
                        EntHaveAjob = c.String(),
                        EntKnowingOfAOU = c.String(),
                        EntHaveDisAbility = c.String(nullable: false),
                        EntContactName = c.String(nullable: false),
                        EntPhoneNumEm = c.String(nullable: false),
                        FilePath = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ServicesOfStaffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        staffName = c.String(),
                        staffID = c.String(),
                        staffServices = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TimeSlotDivs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        time = c.String(),
                        staffID = c.String(),
                        roleNumber = c.Int(nullable: false),
                        availability = c.String(),
                        service = c.String(),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        dateType = c.String(),
                        WorkingDaysTupe = c.String(),
                        Day = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TimeSlots",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        staffID = c.String(),
                        startTime = c.Int(nullable: false),
                        endtTime = c.Int(nullable: false),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        dateType = c.String(),
                        slots = c.Int(nullable: false),
                        service = c.String(),
                        WorkingDaysTupe = c.String(),
                        Day = c.String(),
                        breakstartTime = c.Int(nullable: false),
                        breakendtTime = c.Int(nullable: false),
                        disableStartDate = c.DateTime(nullable: false),
                        disableEndDate = c.DateTime(nullable: false),
                        disablestatus = c.Boolean(nullable: false),
                        disableMSG = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trackings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        staffID = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RegisterMemberLostPostings",
                c => new
                    {
                        RegisterMember_ID = c.String(nullable: false, maxLength: 128),
                        LostPosting_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RegisterMember_ID, t.LostPosting_ID })
                .ForeignKey("dbo.RegisterMembers", t => t.RegisterMember_ID, cascadeDelete: true)
                .ForeignKey("dbo.LostPostings", t => t.LostPosting_ID, cascadeDelete: true)
                .Index(t => t.RegisterMember_ID)
                .Index(t => t.LostPosting_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.StudentReservedAppointments", "RegisterMember_ID", "dbo.RegisterMembers");
            DropForeignKey("dbo.RegisterMemberLostPostings", "LostPosting_ID", "dbo.LostPostings");
            DropForeignKey("dbo.RegisterMemberLostPostings", "RegisterMember_ID", "dbo.RegisterMembers");
            DropIndex("dbo.RegisterMemberLostPostings", new[] { "LostPosting_ID" });
            DropIndex("dbo.RegisterMemberLostPostings", new[] { "RegisterMember_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.StudentReservedAppointments", new[] { "RegisterMember_ID" });
            DropTable("dbo.RegisterMemberLostPostings");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Trackings");
            DropTable("dbo.TimeSlots");
            DropTable("dbo.TimeSlotDivs");
            DropTable("dbo.ServicesOfStaffs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RegistrationForms");
            DropTable("dbo.RegisterNewStudents");
            DropTable("dbo.PostingEvents_N");
            DropTable("dbo.NormalTransactions");
            DropTable("dbo.MemberVerifyOnlies");
            DropTable("dbo.StudentReservedAppointments");
            DropTable("dbo.RegisterMembers");
            DropTable("dbo.LostPostings");
            DropTable("dbo.FullDates");
            DropTable("dbo.Departments");
        }
    }
}
