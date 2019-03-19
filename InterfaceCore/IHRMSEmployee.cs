using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelCore.HRMS.Admin.Recruitment;

namespace InterfaceCore
{
    public interface IHRMSEmployee
    {
        Task<HRMSEmployeeEntry> GetEntry(Int64 id);
        Task<List<HRMSEmployeeIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<SQLResult> Create(HRMSEmployeeEntry pModel);
        Task<SQLResult> Edit(HRMSEmployeeEntry pModel);
    }
}
