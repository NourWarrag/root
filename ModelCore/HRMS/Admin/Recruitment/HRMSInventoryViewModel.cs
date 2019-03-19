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
     public class HRMSInventoryViewModel
    {

    }

    [NotMapped]
        public class HRMSInventoryIndex
    {
        [Key]
        [Required]
        [Display(Name = "mHRMSInventoryId")]
        public Int64 HRMSInventoryId { get; set; }
        
        [Required]
        [Display(Name = "InventoryName")]
        public string InventoryName { get; set; }
        
        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }

        public Int64 TotalRecords { get; set; }
    }

[NotMapped]
        public class HRMSInventoryEntry
    {
        [Key]
        [Required]
        [Display(Name = "mHRMSInventoryId")]
        public Int64 HRMSInventoryId { get; set; }
        
        [Required]
        [Display(Name = "InventoryName")]
        public string InventoryName { get; set; }
        
        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }


    public List<HRMSInventoryDetails> HRMSInventoryDetail { get; set; }


        [Required]
        public AuditColumns AuditColumns;

    }

    public class HRMSInventoryDetails
    {
         [Key]
        
        [Required]
        [Display(Name = "HRMSInventoryDetailId")]
        public Int64 HRMSInventoryDetailId { get; set; }
        
        [Required]
        [Display(Name = "SrNo")]
        public int SrNo { get; set; }
        
        [Required]
        [Display(Name = "mHRMSInventoryId")]
        public Int64 HRMSInventoryId { get; set; }
        
        [Required]
        [Display(Name = "mHRMSAttributeId")]
        public Int64 HRMSAttributeId { get; set; }
        
        [Required]
        [Display(Name = "AttributeValue")]
        public string AttributeValue { get; set; }
        
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