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

        [Required]        [Display(Name = "HRMSAttendanceId")]        public Int64 HRMSAttendanceId { get; set; }

        [Required]        [Display(Name = "mHRMSEmployeeId")]        public Int64 HRMSEmployeeId { get; set; }

        [Required]        [Display(Name = "mHRMSShiftId")]        public Int64 HRMSShiftId { get; set; }

        [Required]        [Display(Name = "AttendanceDate")]        public DateTime AttendanceDate { get; set; }

        [Required]        [Display(Name = "WorkingDay")]        public bool WorkingDay { get; set; }

        [Display(Name = "CheckIn")]        public DateTime CheckIn { get; set; }

        [Display(Name = "CheckOut")]        public DateTime CheckOut { get; set; }

        [Required]        [Display(Name = "WeekEndOff")]        public bool WeekEndOff { get; set; }

        [Required]        [Display(Name = "Holiday")]        public bool Holiday { get; set; }

        [Required]        [Display(Name = "Absent")]        public bool Absent { get; set; }

        [Required]        [Display(Name = "IsValid")]        public bool IsValid { get; set; }

        [Required]        [Display(Name = "PayrollStatus")]        public bool PayrollStatus { get; set; }

        [Required]        [Display(Name = "DayStatusId")]        public Int64 DayStatusId { get; set; }

        [Required]        [Display(Name = "Active")]        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }

        public Int64 TotalRecords { get; set; }
    }

    [NotMapped]
    public class HRMSAttendanceEntry
    {
        [Key]

        [Required]        [Display(Name = "HRMSAttendanceId")]        public Int64 HRMSAttendanceId { get; set; }

        [Required]        [Display(Name = "mHRMSEmployeeId")]        public Int64 HRMSEmployeeId { get; set; }

        [Required]        [Display(Name = "mHRMSShiftId")]        public Int64 HRMSShiftId { get; set; }

        [Required]        [Display(Name = "AttendanceDate")]        public DateTime AttendanceDate { get; set; }

        [Required]        [Display(Name = "WorkingDay")]        public bool WorkingDay { get; set; }

        [Display(Name = "CheckIn")]        public DateTime CheckIn { get; set; }

        [Display(Name = "CheckOut")]        public DateTime CheckOut { get; set; }

        [Required]        [Display(Name = "WeekEndOff")]        public bool WeekEndOff { get; set; }

        [Required]        [Display(Name = "Holiday")]        public bool Holiday { get; set; }

        [Required]        [Display(Name = "Absent")]        public bool Absent { get; set; }

        [Required]        [Display(Name = "IsValid")]        public bool IsValid { get; set; }

        [Required]        [Display(Name = "PayrollStatus")]        public bool PayrollStatus { get; set; }

        [Required]        [Display(Name = "DayStatusId")]        public Int64 DayStatusId { get; set; }

        [Required]        [Display(Name = "Active")]        public bool Active { get; set; }

        [Required]
        public AuditColumns AuditColumns;

    }
}
