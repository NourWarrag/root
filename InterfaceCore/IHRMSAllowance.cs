using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelCore.HRMS.Admin.Recruitment;

namespace InterfaceCore
{
    public interface IHRMSAllowance
    {
        Task<HRMSAllowanceEntry> GetEntry(Int64 id);
        Task<List<HRMSAllowanceIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<SQLResult> Create(HRMSAllowanceEntry pModel);
        Task<SQLResult> Edit(HRMSAllowanceEntry pModel);
    }
}
