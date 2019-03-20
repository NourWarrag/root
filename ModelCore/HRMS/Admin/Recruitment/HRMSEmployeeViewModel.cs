using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ModelCore.Misc.Enums;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public class HRMSEmployeeViewModel
    {
    }

    [NotMapped]
    public class HRMSEmployeeIndex
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "EmployeeCode")]
        public string EmployeeCode { get; set; }

        [Required]
        [Display(Name = "mCompanyId")]
        public Int64 CompanyId { get; set; }

        [Required]
        [Display(Name = "mBranchId")]
        public Int64 BranchId { get; set; }

        [Required]
        [Display(Name = "mDepartmentId")]
        public Int64 DepartmentId { get; set; }

        [Required]
        [Display(Name = "mDesignationId")]
        public Int64 DesignationId { get; set; }

        [Display(Name = "ManagerId")]
        public Int64 ManagerId { get; set; }

        [Display(Name = "SupervisorId")]
        public Int64 SupervisorId { get; set; }

        [Display(Name = "SubordinateId")]
        public Int64 SubordinateId { get; set; }

        [Required]
        [Display(Name = "DOJ")]
        public DateTime DOJ { get; set; }

        [Required]
        [Display(Name = "EmployeeType")]
        public Int64 EmployeeType { get; set; }

        [Required]
        [Display(Name = "EmployeeTreatedAs")]
        public Int64 EmployeeTreatedAs { get; set; }

        [Display(Name = "FingerprintId")]
        public Int64 FingerprintId { get; set; }

        [Display(Name = "mHRMSCVRepositoryId")]
        public Int64 HRMSCVRepositoryId { get; set; }

        [Display(Name = "mHRMSCTCId")]
        public Int64 HRMSCTCId { get; set; }

        [Display(Name = "mBankAccountDetailId")]
        public Int64 BankAccountDetailId { get; set; }

        [Required]
        [Display(Name = "EffectiveFrom")]
        public DateTime EffectiveFrom { get; set; }

        [Required]
        [Display(Name = "EffectiveTo")]
        public DateTime EffectiveTo { get; set; }

        [Required]
        [Display(Name = "VersionNo")]
        public int VersionNo { get; set; }

        [Required]
        [Display(Name = "MyParentId")]
        public Int64 MyParentId { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }
    }

    [NotMapped]
    public class HRMSEmployeeEntry
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "EmployeeCode")]
        public string EmployeeCode { get; set; }

        [Required]
        [Display(Name = "mCompanyId")]
        public Int64 CompanyId { get; set; }

        [Required]
        [Display(Name = "mBranchId")]
        public Int64 BranchId { get; set; }

        [Required]
        [Display(Name = "mDepartmentId")]
        public Int64 DepartmentId { get; set; }

        [Required]
        [Display(Name = "mDesignationId")]
        public Int64 DesignationId { get; set; }

        [Display(Name = "ManagerId")]
        public Int64 ManagerId { get; set; }

        [Display(Name = "SupervisorId")]
        public Int64 SupervisorId { get; set; }

        [Display(Name = "SubordinateId")]
        public Int64 SubordinateId { get; set; }

        [Required]
        [Display(Name = "DOJ")]
        public DateTime DOJ { get; set; }

        [Required]
        [Display(Name = "EmployeeType")]
        public Int64 EmployeeType { get; set; }

        [Required]
        [Display(Name = "EmployeeTreatedAs")]
        public Int64 EmployeeTreatedAs { get; set; }

        [Display(Name = "FingerprintId")]
        public Int64 FingerprintId { get; set; }

        [Display(Name = "mHRMSCVRepositoryId")]
        public Int64 HRMSCVRepositoryId { get; set; }

        [Display(Name = "mHRMSCTCId")]
        public Int64 HRMSCTCId { get; set; }

        [Display(Name = "mBankAccountDetailId")]
        public Int64 BankAccountDetailId { get; set; }

        [Required]
        [Display(Name = "EffectiveFrom")]
        public DateTime EffectiveFrom { get; set; }

        [Required]
        [Display(Name = "EffectiveTo")]
        public DateTime EffectiveTo { get; set; }

        [Required]
        [Display(Name = "VersionNo")]
        public int VersionNo { get; set; }

        [Required]
        [Display(Name = "MyParentId")]
        public Int64 MyParentId { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }


      //  public List<MobileDetail> MobileDetail { get; set; }

      //  public List<EmailDetail> EmailDetail { get; set; }

        public List<ContactDetail> ContactDetail { get; set; }

      //  public List<AddressDetail> AddressDetail { get; set; }

      //  public List<PhoneDetail> PhoneDetail { get; set; }


        public List<HRMSEmpEducation> HRMSEmpEducation { get; set; }

        public List<HRMSEmpExperience> HRMSEmpExperience { get; set; }

        public List<HRMSEmpSkill> HRMSEmpSkill { get; set; }

        public List<HRMSEmployeePersonalDetail> HRMSEmployeePersonalDetail { get; set; }

        public List<HRMSEmployeeRelatives> HRMSEmployeeRelatives { get; set; }

        public List<HRMSEmployeeCTC> HRMSEmployeeCTC { get; set; }

        public List<HRMSEmployeeNationalityDetail> HRMSEmployeeNationalityDetail { get; set; }

        public List<HRMSEmployeeAdditionalSkill> HRMSEmployeeAdditionalSkill { get; set; }

        [Required]
        public AuditColumns AuditColumns;


    }

    public class HRMSEmpEducation
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSEmpEducationId")]
        public Int64 HRMSEmpEducationId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "CertDegreeName")]
        public string CertDegreeName { get; set; }

        [Required]
        [Display(Name = "Major")]
        public string Major { get; set; }

        [Required]
        [Display(Name = "UniInstituteName")]
        public string UniInstituteName { get; set; }

        [Required]
        [Display(Name = "StartMonth")]
        public int StartMonth { get; set; }

        [Required]
        [Display(Name = "StartYear")]
        public int StartYear { get; set; }

        [Required]
        [Display(Name = "CompletionMonth")]
        public int CompletionMonth { get; set; }

        [Required]
        [Display(Name = "CompletionYear")]
        public int CompletionYear { get; set; }

        [Required]
        [Display(Name = "Grade")]
        public string Grade { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }

    public class HRMSEmpExperience
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSEmpExperienceId")]
        public Int64 HRMSEmpExperienceId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "CompanyName")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "JoinMonth")]
        public int JoinMonth { get; set; }

        [Required]
        [Display(Name = "JoinYear")]
        public int JoinYear { get; set; }

        [Required]
        [Display(Name = "LeaveMonth")]
        public int LeaveMonth { get; set; }

        [Required]
        [Display(Name = "LeaveYear")]
        public int LeaveYear { get; set; }

        [Required]
        [Display(Name = "MonthlySalary")]
        public decimal MonthlySalary { get; set; }

        [Required]
        [Display(Name = "mCountryId")]
        public Int64 CountryId { get; set; }

        [Required]
        [Display(Name = "mStateId")]
        public Int64 StateId { get; set; }

        [Required]
        [Display(Name = "mCityId")]
        public Int64 CityId { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }

    public class HRMSEmpSkill
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSEmpSkillId")]
        public Int64 HRMSEmpSkillId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "mHRMSSkillSetId")]
        public Int64 HRMSSkillSetId { get; set; }

        [Required]
        [Display(Name = "SkillLevel")]
        public Int64 SkillLevel { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }

    public class HRMSEmployeePersonalDetail
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSEmployeePersonalDetailId")]
        public Int64 HRMSEmployeePersonalDetailId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "mCompanyId")]
        public Int64 CompanyId { get; set; }

        [Required]
        [Display(Name = "mBranchId")]
        public Int64 BranchId { get; set; }

        [Required]
        [Display(Name = "EmployeeName")]
        public string EmployeeName { get; set; }

        [Required]
        [Display(Name = "FatherName")]
        public string FatherName { get; set; }

        [Required]
        [Display(Name = "GrandfatherName")]
        public string GrandfatherName { get; set; }

        [Required]
        [Display(Name = "FamilyName")]
        public string FamilyName { get; set; }

        [Required]
        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Int64 Gender { get; set; }

        [Required]
        [Display(Name = "MaritalStatus")]
        public Int64 MaritalStatus { get; set; }

        [Required]
        [Display(Name = "NumberOfFamilyMembers")]
        public Int32 NumberOfFamilyMembers { get; set; }

        [Required]
        [Display(Name = "mContactId")]
        public Int64 ContactId { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }

    public class HRMSEmployeeRelatives
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSEmployeeRelativesId")]
        public Int64 HRMSEmployeeRelativesId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "RelativeName")]
        public string RelativeName { get; set; }

        [Required]
        [Display(Name = "Relation")]
        public string Relation { get; set; }

        [Required]
        [Display(Name = "WorkingInCompany")]
        public bool WorkingInCompany { get; set; }

        [Required]
        [Display(Name = "RelativeEmployeeId")]
        public Int64 RelativeEmployeeId { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }

    public class HRMSEmployeeCTC
    {
        [Key]

        [Required]
        [Display(Name = "HRMSEmployeeCTCId")]
        public Int64 HRMSEmployeeCTCId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "mCompanyId")]
        public Int64 CompanyId { get; set; }

        [Required]
        [Display(Name = "mBranchId")]
        public Int64 BranchId { get; set; }

        [Required]
        [Display(Name = "mHRMSAllowanceId")]
        public Int64 HRMSAllowanceId { get; set; }

        [Required]
        [Display(Name = "AllowanceValue")]
        public decimal AllowanceValue { get; set; }

        [Required]
        [Display(Name = "EffectiveFrom")]
        public DateTime EffectiveFrom { get; set; }

        [Required]
        [Display(Name = "EffectiveTo")]
        public DateTime EffectiveTo { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }

    public class HRMSEmployeeNationalityDetail
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSEmployeeNationalityDetailId")]
        public Int64 HRMSEmployeeNationalityDetailId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public Int64 Nationality { get; set; }

        [Required]
        [Display(Name = "AlternateNationality")]
        public Int64 AlternateNationality { get; set; }

        [Required]
        [Display(Name = "IDNumber")]
        public string IDNumber { get; set; }

        [Required]
        [Display(Name = "IDIssuePlace")]
        public string IDIssuePlace { get; set; }

        [Required]
        [Display(Name = "IDIssueDate")]
        public DateTime IDIssueDate { get; set; }

        [Required]
        [Display(Name = "IDExpiryDate")]
        public DateTime IDExpiryDate { get; set; }

        [Required]
        [Display(Name = "AlternativeIDNumber")]
        public string AlternativeIDNumber { get; set; }

        [Required]
        [Display(Name = "AlternativeIDIssuePlace")]
        public string AlternativeIDIssuePlace { get; set; }

        [Required]
        [Display(Name = "AlternativeIDIssueDate")]
        public DateTime AlternativeIDIssueDate { get; set; }

        [Required]
        [Display(Name = "AlternativeIDExpiryDate")]
        public DateTime AlternativeIDExpiryDate { get; set; }

        [Required]
        [Display(Name = "PassportNumber")]
        public string PassportNumber { get; set; }

        [Required]
        [Display(Name = "PassportIssuePlace")]
        public string PassportIssuePlace { get; set; }

        [Required]
        [Display(Name = "PassportIssueDate")]
        public DateTime PassportIssueDate { get; set; }

        [Required]
        [Display(Name = "PassportExpiryDate")]
        public DateTime PassportExpiryDate { get; set; }

        [Required]
        [Display(Name = "VisaType")]
        public Int64 VisaType { get; set; }

        [Required]
        [Display(Name = "VisaNumber")]
        public string VisaNumber { get; set; }

        [Required]
        [Display(Name = "VisaIssuePlace")]
        public string VisaIssuePlace { get; set; }

        [Required]
        [Display(Name = "VisaIssueDate")]
        public DateTime VisaIssueDate { get; set; }

        [Required]
        [Display(Name = "VisaExpiryDate")]
        public DateTime VisaExpiryDate { get; set; }

        [Required]
        [Display(Name = "ExpatWorkPermitType")]
        public Int64 ExpatWorkPermitType { get; set; }

        [Required]
        [Display(Name = "ExpatWorkPermitIssuePlace")]
        public string ExpatWorkPermitIssuePlace { get; set; }

        [Required]
        [Display(Name = "ExpatWorkPermitIssueDate")]
        public DateTime ExpatWorkPermitIssueDate { get; set; }

        [Required]
        [Display(Name = "ExpatWorkPermitExpiryDate")]
        public DateTime ExpatWorkPermitExpiryDate { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }

    public class HRMSEmployeeAdditionalSkill
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSEmployeeAdditionalSkillId")]
        public Int64 HRMSEmployeeAdditionalSkillId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "Skill")]
        public string Skill { get; set; }

        [Required]
        [Display(Name = "SkillLevel")]
        public Int64 SkillLevel { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }

    public class ContactDetail
    {
        [Key]

        [Required]
        [Display(Name = "mContactDetailId")]
        public Int64 ContactDetailId { get; set; }

        //[Required]
        [Display(Name = "mContactId")]
        public Int64 ContactId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "mContactTypeId")]
        public Int64 ContactTypeId { get; set; }

        [Required]
        [Display(Name = "mTitleId")]
        public Int64 TitleId { get; set; }

        [Required]
        [Display(Name = "ContactName")]
        public string ContactName { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "mAddressId")]
        public Int64 AddressId { get; set; }

        [Required]
        [Display(Name = "mPhoneId")]
        public Int64 PhoneId { get; set; }

        [Required]
        [Display(Name = "mPhoneId")]
        public Int64 MobileId { get; set; }


        [Required]
        [Display(Name = "mEmailId")]
        public Int64 EmailId { get; set; }

        [Required]
        [Display(Name = "Default")]
        public bool Default { get; set; }

        public List<AddressDetail> AddressDetail { get; set; }

       public List<MobileDetail> MobileDetail { get; set; }

        public List<EmailDetail> EmailDetail { get; set; }

        public List<PhoneDetail> PhoneDetail { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }


    }

    public class AddressDetail
    {
        [Key]

        [Required]
        [Display(Name = "mAddressDetailId")]
        public Int64 AddressDetailId { get; set; }

        [Required]
        [Display(Name = "mAddressId")]
        public Int64 AddressId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Display(Name = "mContactId")]
        public Int64 ContactDetailId { get; set; }

    

        [Required]
        [Display(Name = "mAddressTypeId")]
        public Int64 AddressTypeId { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "mCountryId")]
        public Int64 CountryId { get; set; }

        [Required]
        [Display(Name = "mStateId")]
        public Int64 StateId { get; set; }

        [Required]
        [Display(Name = "mCityId")]
        public Int64 CityId { get; set; }

        [Required]
        [Display(Name = "PINCode")]
        public string PINCode { get; set; }

        [Required]
        [Display(Name = "DefaultFlag")]
        public bool DefaultFlag { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }

    }

    public class EmailDetail
    {
        [Key]

        [Required]
        [Display(Name = "mEmailDetailId")]
        public Int64 EmailDetailId { get; set; }

        [Required]
        [Display(Name = "mEmailId")]
        public Int64 EmailId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Display(Name = "mContactId")]
        public Int64 ContactDetailId { get; set; }

        //[Display(Name = "mContactId")]
        //public Int64 ContactId { get; set; }

        [Required]
        [Display(Name = "mEmailTypeId")]
        public Int64 EmailTypeId { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Default")]
        public bool Default { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }

    public class MobileDetail
    {
        [Key]

        [Required]
        [Display(Name = "mMobileDetailId")]
        public Int64 MobileDetailId { get; set; }

        [Required]
        [Display(Name = "mMobileId")]
        public Int64 MobileId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Display(Name = "mContactDetailId")]
        public Int64 ContactDetailId { get; set; }

        [Required]
        [Display(Name = "mMobileTypeId")]
        public Int64 MobileTypeId { get; set; }

        [Required]
        [Display(Name = "CountryCode")]
        public decimal CountryCode { get; set; }

        [Required]
        [Display(Name = "MobileNo")]
        public decimal MobileNo { get; set; }

        [Required]
        [Display(Name = "DefaultFlag")]
        public bool DefaultFlag { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }

    public class PhoneDetail
    {
        [Key]

        [Required]
        [Display(Name = "mPhoneDetailId")]
        public Int64 PhoneDetailId { get; set; }


        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Display(Name = "mContactId")]
        public Int64 ContactDetailId { get; set; }

        [Required]
        [Display(Name = "mPhoneId")]
        public Int64 PhoneId { get; set; }

        //[Display(Name = "mContactId")]
        //public Int64 ContactId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mPhoneTypeId")]
        public Int64 PhoneTypeId { get; set; }

        [Required]
        [Display(Name = "PhonePrefixCode")]
        public decimal PhonePrefixCode { get; set; }

        [Required]
        [Display(Name = "PhoneNo")]
        public decimal PhoneNo { get; set; }

        [Required]
        [Display(Name = "Extension")]
        public decimal Extension { get; set; }

        [Required]
        [Display(Name = "Default")]
        public bool Default { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public EntryStatus EntryStatus { get; set; }
    }


}
