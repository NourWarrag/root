using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public class HRMSAttributeViewModel
    {

    }

    [NotMapped]
    public class HRMSAttributeIndex
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSAttributeId")]
        public Int64 HRMSAttributeId { get; set; }

        [Required]
        [Display(Name = "AttributeName")]
        public string AttributeName { get; set; }

        [Required]
        [Display(Name = "UsedFor")]
        public string UsedFor { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }
    }

    [NotMapped]
    public class HRMSAttributeEntry
    {
        [Key]

        [Required]
        [Display(Name = "mHRMSAttributeId")]
        public Int64 HRMSAttributeId { get; set; }

        [Required]
        [Display(Name = "AttributeName")]
        public string AttributeName { get; set; }

        [Required]
        [Display(Name = "UsedFor")]
        public string UsedFor { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }


        [Required]
        public AuditColumns AuditColumns;
    }


}