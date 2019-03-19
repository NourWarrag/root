using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelCore.HRMS.Admin.Recruitment;

namespace InterfaceCore
{
    public interface IHRMSRolesResponsibility
    {
        Task<HRMSRolesResponsibilityEntry> GetEntry(Int64 id);
        Task<List<HRMSRolesResponsibilityIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<SQLResult> Create(HRMSRolesResponsibilityEntry pModel);
        Task<SQLResult> Edit(HRMSRolesResponsibilityEntry pModel);
        Task<SQLResult> Delete(HRMSRolesResponsibilityEntry pModel);
    }
}
