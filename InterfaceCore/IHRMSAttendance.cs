using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelCore.HRMS.Admin.Recruitment;
using System.Data;

namespace InterfaceCore
{
    public interface IHRMSAttendance
    {
        Task<HRMSAttendanceEntry> GetEntry(Int64 id);
        Task<List<HRMSAttendanceIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<SQLResult> Create(HRMSAttendanceEntry pModel);
        Task<SQLResult> Edit(HRMSAttendanceEntry pModel);
        SQLResult BulkCopy(DataTable table);
       // Task<SQLResult> Delete(HRMSAttendanceEntry pModel);
    }
}
