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
    public class HRMSAllowancViewModel
    {
    }

    [NotMapped]
    public class HRMSAllowanceIndex
    {

        [Key]

        [Required]
        [Display(Name = "mHRMSAllowanceId")]
        public Int64 HRMSAllowanceId { get; set; }

        [Required]
        [Display(Name = "AllowanceCode")]
        public string AllowanceCode { get; set; }

        [Required]
        [Display(Name = "AllowanceName")]
        public string AllowanceName { get; set; }

        [Required]
        [Display(Name = "AllowanceDescription")]
        public string AllowanceDescription { get; set; }

        [Required]
        [Display(Name = "AllowanceTypeId")]
        public Int64 AllowanceTypeId { get; set; }

        [Required]
        [Display(Name = "AllowanceGroup")]
        public Int64 AllowanceGroup { get; set; }

        [Required]
        [Display(Name = "GrossCheck")]
        public bool GrossCheck { get; set; }

        [Required]
        [Display(Name = "EffectiveDateFrom")]
        public DateTime EffectiveDateFrom { get; set; }

        [Required]
        [Display(Name = "EffectiveDateTo")]
        public DateTime EffectiveDateTo { get; set; }

        [Required]
        [Display(Name = "ValueTypeId")]
        public Int64 ValueTypeId { get; set; }

        [Required]
        [Display(Name = "Value")]
        public decimal Value { get; set; }

        [Required]
        [Display(Name = "DependencyStatus")]
        public bool DependencyStatus { get; set; }

        [Required]
        [Display(Name = "SlabStatus")]
        public bool SlabStatus { get; set; }

        [Required]
        [Display(Name = "OthersStatus")]
        public bool OthersStatus { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }

        public Int64 TotalRecords { get; set; }
    }

    [NotMapped]
    public class HRMSAllowanceEntry
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSAllowanceId")]
        public Int64 HRMSAllowanceId { get; set; }

        [Required]
        [Display(Name = "AllowanceCode")]
        public string AllowanceCode { get; set; }

        [Required]
        [Display(Name = "AllowanceName")]
        public string AllowanceName { get; set; }

        [Required]
        [Display(Name = "AllowanceDescription")]
        public string AllowanceDescription { get; set; }

        [Required]
        [Display(Name = "AllowanceTypeId")]
        public Int64 AllowanceTypeId { get; set; }

        [Required]
        [Display(Name = "AllowanceGroup")]
        public Int64 AllowanceGroup { get; set; }

        [Required]
        [Display(Name = "GrossCheck")]
        public bool GrossCheck { get; set; }

        [Required]
        [Display(Name = "EffectiveDateFrom")]
        public DateTime EffectiveDateFrom { get; set; }

        [Required]
        [Display(Name = "EffectiveDateTo")]
        public DateTime EffectiveDateTo { get; set; }

        [Required]
        [Display(Name = "ValueTypeId")]
        public Int64 ValueTypeId { get; set; }

        [Required]
        [Display(Name = "Value")]
        public decimal Value { get; set; }

        [Required]
        [Display(Name = "DependencyStatus")]
        public bool DependencyStatus { get; set; }

        [Required]
        [Display(Name = "SlabStatus")]
        public bool SlabStatus { get; set; }

        [Required]
        [Display(Name = "OthersStatus")]
        public bool OthersStatus { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        public List<HRMSAllowDependency> HRMSAllowDependency { get; set; }

        public List<HRMSAllowSlab> HRMSAllowSlab { get; set; }

        public List<HRMSAllowOthers> HRMSAllowOthers { get; set; }

        [Required]
        public AuditColumns AuditColumns;

    }

    public class HRMSAllowDependency
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSAllowDependencyId")]
        public Int64 HRMSAllowDependencyId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "ReferenceAllowanceId")]
        public Int64 ReferenceAllowanceId { get; set; }

        [Required]
        [Display(Name = "mHRMSAllowanceId")]
        public Int64 HRMSAllowanceId { get; set; }

        [Required]
        [Display(Name = "TreatedAs")]
        public Int64 TreatedAs { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public int EntryStatus { get; set; }

        //[Required]
        [Display(Name = "AllowanceName")]
        public string AllowanceName { get; set; }

        //[Required]
        [Display(Name = "AllowanceTypeId")]
        public Int64 AllowanceTypeId { get; set; }

        //[Required]
        [Display(Name = "EffectiveDateFrom")]
        public DateTime EffectiveDateFrom { get; set; }

       // [Required]
        [Display(Name = "EffectiveDateTo")]
        public DateTime EffectiveDateTo { get; set; }

       // [Required]
        [Display(Name = "ValueTypeId")]
        public Int64 ValueTypeId { get; set; }

    }
    public class HRMSAllowSlab
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSAllowSlabId")]
        public Int64 HRMSAllowSlabId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mHRMSAllowanceId")]
        public Int64 HRMSAllowanceId { get; set; }

        [Required]
        [Display(Name = "MinValue")]
        public decimal MinValue { get; set; }

        [Required]
        [Display(Name = "MaxValue")]
        public decimal MaxValue { get; set; }

        [Required]
        [Display(Name = "ValueTypeId")]
        public Int64 ValueTypeId { get; set; }

        [Required]
        [Display(Name = "SlabValue")]
        public decimal SlabValue { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public int EntryStatus { get; set; }
    }
    public class HRMSAllowOthers
    {

        [Key]

        [Required]
        [Display(Name = "mHRMSAllowOthersId")]
        public Int64 HRMSAllowOthersId { get; set; }

        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }

        [Required]
        [Display(Name = "mHRMSAllowanceId")]
        public Int64 HRMSAllowanceId { get; set; }


        [Required]
        [Display(Name = "PropertyType")]
        public Int64 PropertyType { get; set; }

        [Required]
        [Display(Name = "PropertyValue")]
        public string PropertyValue { get; set; }

        [Required]
        [Display(Name = "MinMaxCheck")]
        public bool MinMaxCheck { get; set; }

        [Required]
        [Display(Name = "MinValue")]
        public decimal MinValue { get; set; }

        [Required]
        [Display(Name = "MaxValue")]
        public decimal MaxValue { get; set; }

        [Required]
        [Display(Name = "ValueType")]
        public Int64 ValueType { get; set; }

        [Required]
        [Display(Name = "OthersValue")]
        public decimal OthersValue { get; set; }

        [Required]
        [Display(Name = "TreatedAs")]
        public Int64 TreatedAs { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }

        [Required]
        [Display(Name = "EntryStatus")]
        public int EntryStatus { get; set; }
    }
}
