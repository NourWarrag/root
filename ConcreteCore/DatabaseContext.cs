using Microsoft.EntityFrameworkCore;
using ModelCore.FA.BK;
using ModelCore.FA.BK.Master;
using ModelCore.Misc;
using ModelCore.Security.Admin.Regional;
using ModelCore.Security.User;
using ModelCore.HRMS.Admin.Test;
using ModelCore.HRMS.Admin.Recruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        // Misc
        public DbSet<SQLResult> DBResult { get; set; }
        public DbSet<IDModel> IDModel { get; set; }

        // Common
        public DbSet<SelectDdl> SelectDdl { get; set; }

        // User
        public DbSet<SignInUserProfile> SignInUserProfile { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

        // Regional
        public DbSet<CountryIndex> CountryIndex { get; set; }
        public DbSet<StateIndex> StateIndex { get; set; }
        public DbSet<CityIndex> CityIndex { get; set; }

        // HRMS
        public DbSet<TRIALSpIndex> TRIALSpIndex {get; set;}

        // Menus
        public DbSet<SpMenus> SpMenus { get; set; }
        // Screen Rights
        public DbSet<ScreenRight> GetScreenRights { get; set; }

        // Bank
        public DbSet<BankIndex> BankIndex { get; set; }

        // Page Events
        public DbSet<PageSortEntry> PageSortEntry { get; set; }

        // Ledger
        public DbSet<LedgerIndex> LedgerIndex { get; set; }
        public DbSet<LedgerEntry> LedgerEntry { get; set; }

        // Currency
        public DbSet<CurrencyIndex> CurrencyIndex { get; set; }
        public DbSet<CurrencyEntry> CurrencyEntry { get; set; }

        // HRMS ROLES
        public DbSet<HRMSRolesResponsibilityIndex> HRMSRolesResponsibilityIndex { get; set; }
        public DbSet<HRMSRolesResponsibilityEntry> HRMSRolesResponsibilityEntry { get; set; }

        // Attribute
        public DbSet<HRMSAttributeIndex> HRMSAttributeIndex { get; set; }
        public DbSet<HRMSAttributeEntry> HRMSAttributeEntry { get; set; }

        //Employee
        public DbSet<HRMSEmployeeIndex> HRMSEmployeeIndex { get; set; }
        public DbSet<HRMSEmployeeEntry> HRMSEmployeeEntry { get; set; }
        public DbSet<HRMSEmpEducation> GetHRMSEmpEducation { get; set; }
        public DbSet<HRMSEmpExperience> GetHRMSEmpExperience { get; set; }
        public DbSet<HRMSEmpSkill> GetHRMSEmpSkill { get; set; }
        public DbSet<HRMSEmployeePersonalDetail> GetHRMSEmployeePersonalDetail { get; set; }
        public DbSet<HRMSEmployeeRelatives> GetHRMSEmployeeRelatives { get; set; }
        public DbSet<HRMSEmployeeAdditionalSkill> GetHRMSEmployeeAdditionalSkill { get; set; }
        public DbSet<HRMSEmployeeNationalityDetail> GetHRMSEmployeeNationalityDetail { get; set; }
        public DbSet<HRMSEmployeeCTC> GetHRMSEmployeeCTC { get; set; }

        //public DbSet<ContactEntry> GetContactEntry { get; set; }
        public DbSet<MobileDetail> GetMobileDetail { get; set; }
        public DbSet<EmailDetail> GetEmailDetail { get; set; }
        public DbSet<AddressDetail> GetAddressDetail { get; set; }
        public DbSet<ContactDetail> GetContactDetail { get; set; }
        public DbSet<PhoneDetail> GetPhoneDetail { get; set; }

        //Inventory
        public DbSet<HRMSInventoryIndex> HRMSInventoryIndex { get; set; }
        public DbSet<HRMSInventoryEntry> HRMSInventoryEntry { get; set; }
        public DbSet<HRMSInventoryDetails> GetHRMSInventoryDetails { get; set; }

        //Allowance
        public DbSet<HRMSAllowanceIndex> HRMSAllowanceIndex { get; set; }
        public DbSet<HRMSAllowanceEntry> HRMSAllowanceEntry { get; set; }
        public DbSet<HRMSAllowDependency> GetHRMSAllowDependency { get; set; }
        public DbSet<HRMSAllowSlab> GetHRMSAllowSlab { get; set; }
        public DbSet<HRMSAllowOthers> GetHRMSAllowOthers { get; set; }

        //Attendance
        public DbSet<HRMSAttendanceIndex> HRMSAttendanceIndex { get; set; }
        public DbSet<HRMSAttendanceEntry> HRMSAttendanceEntry { get; set; }

    }
}
