using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelCore.HRMS.Admin.Recruitment;

namespace InterfaceCore
{
public interface IHRMSInventory
    {
        Task<HRMSInventoryEntry> GetEntry(Int64 id);
        Task<List<HRMSInventoryIndex>> GetIndex(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage);
        Task<SQLResult> Create(HRMSInventoryEntry pModel);
        Task<SQLResult> Edit(HRMSInventoryEntry pModel);
      //  Task<SQLResult> Delete(HRMSInventoryEntry pModel);
     // Task<List<HRMSInventoryDetails>> GetHRMSInventoryDetails(Int64 pHRMSInventoryId);
    }

}