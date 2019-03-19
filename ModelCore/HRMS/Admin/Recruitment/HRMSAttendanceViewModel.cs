using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public class HRMSAttendanceViewModel
    {
    }
    
    [NotMapped]
    public class HRMSAttendanceIndex
    {
        [Key]

        [Required]
        [Display(Name = "HRMSAttendanceId")]
        public Int64 HRMSAttendanceId { get; set; }

        [Required]
        [Display(Name = "mHRMSEmployeeId")]
        public Int64 HRMSEmployeeId { get; set; }

        [Required]
        [Display(Name = "mHRMSShiftId")]
        public Int64 HRMSShiftId { get; set; }

        [Required]
        [Display(Name = "AttendanceDate")]
        public DateTime AttendanceDate { get; set; }

        [Display(Name = "WorkingDay")]
        public bool WorkingDay { get; set; }

        [Required]
        [Display(Name = "CheckIn")]
        public DateTime CheckIn { get; set; }

        [Required]
        [Display(Name = "CheckOut")]
        public DateTime CheckOut { get; set; }

        [Display(Name = "WeekEndOff")]
        public bool WeekEndOff { get; set; }

        [Display(Name = "Holiday")]
        public bool Holiday { get; set; }

        [Display(Name = "Absent")]
        public bool Absent { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }

        public Int64 TotalRecords { get; set; }
    }
    [NotMapped]
    public class HRMSAttendanceEntry
    {
            [Key]

            [Required]
            [Display(Name = "HRMSAttendanceId")]
            public Int64 HRMSAttendanceId { get; set; }

            [Required]
            [Display(Name = "mHRMSEmployeeId")]
            public Int64 HRMSEmployeeId { get; set; }

            [Required]
            [Display(Name = "mHRMSShiftId")]
            public Int64 HRMSShiftId { get; set; }

            [Required]
            [Display(Name = "AttendanceDate")]
            public DateTime AttendanceDate { get; set; }

            [Display(Name = "WorkingDay")]
            public bool WorkingDay { get; set; }

            [Required]
            [Display(Name = "CheckIn")]
            public DateTime CheckIn { get; set; }

            [Required]
            [Display(Name = "CheckOut")]
            public DateTime CheckOut { get; set; }

            [Display(Name = "WeekEndOff")]
            public bool WeekEndOff { get; set; }

            [Display(Name = "Holiday")]
            public bool Holiday { get; set; }

            [Display(Name = "Absent")]
            public bool Absent { get; set; }

            [Required]
            [Display(Name = "Status")]
            public string Status { get; set; }

            [Required]
            [Display(Name = "Remarks")]
            public string Remarks { get; set; }

            [Required]
            [Display(Name = "Active")]
            public bool Active { get; set; }

            [Required]
            public AuditColumns AuditColumns;

        }

    }
