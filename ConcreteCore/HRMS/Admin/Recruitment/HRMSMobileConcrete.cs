using InterfaceCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using ModelCore.FA.BK.Master;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConcreteCore.HRMS.Admin.Recruitment
{
    public class HRMSMobileConcrete
    {
        


        //public async Task<SQLResult> Create(HRMSMobileEntry pModel, DatabaseContext pContext)
        //{
        //    SQLResult result = new SQLResult();
        //    try
        //    {
        //        // typ_mMobileDetailtable type parameter declartaion with parameter name and table type name
        //        SqlParameter ptyp_mMobileDetailParameter = new SqlParameter("@pi_typ_mMobileDetail", SqlDbType.Structured)
        //        {
        //            Direction = ParameterDirection.Input,
        //            TypeName = "typ_mMobileDetail"
        //        };
        //        var pRowCollection_typ_mMobileDetail = new List<SqlDataRecord>();
        //        foreach (var item in pModel.mMobileDetail)
        //        {

        //            SqlDataRecord pRow = new SqlDataRecord(
        //                                        new SqlMetaData("mMobileDetailId", SqlDbType.BigInt)
        //                                        ,new SqlMetaData("mMobileId", SqlDbType.BigInt)
        //                                        ,new SqlMetaData("SrNo", SqlDbType.Int)
        //                                        ,new SqlMetaData("mMobileTypeId", SqlDbType.BigInt)
        //                                        ,new SqlMetaData("CountryCode", SqlDbType.Numeric)
        //                                        ,new SqlMetaData("MobileNo", SqlDbType.Numeric)
        //                                        ,new SqlMetaData("DefaultFlag", SqlDbType.Bit)
        //                                        ,new SqlMetaData("Active", SqlDbType.Bit)
        //                                        ,new SqlMetaData("Deleted", SqlDbType.Bit)
        //                                        ,new SqlMetaData("EntryStatus", SqlDbType.Int)
        //                                    );

        //            pRow.SetInt64(0, item.mMobileDetailId);
        //            pRow.SetInt64(1, item.mMobileId);
        //            pRow.SetInt32(2, item.SrNo);
        //            pRow.SetInt64(3, item.mMobileTypeId);
        //            pRow.SetDouble(4, item.CountryCode);
        //            pRow.SetDouble(5, item.MobileNo);
        //            pRow.SetBoolean(6, item.DefaultFlag);
        //            pRow.SetBoolean(7, item.Active);
        //            pRow.SetBoolean(8, item.Deleted);
        //            pRow.SetInt32(9, item.EntryStatus);

        //            pRowCollection_typ_mMobileDetail.Add(pRow);
        //        }

        //        ptyp_mMobileDetailParameter.Value = pRowCollection_typ_mMobileDetail;
        //        string csql = @" EXEC spmMobileInsert
        //            @pi_Active
        //            , @pi_UserId
        //            , @pi_HostName
        //            , @pi_IPAddress
        //            , @pi_DeviceType
        //            , @pi_MACAddress
        //            , @pi_typ_mMobileDetail
        //            ";
        //                            List<SqlParameter> sqlparam = new List<SqlParameter>() {
        //             new SqlParameter("@pi_Active", pModel.Active) ,
        //             new SqlParameter("@pi_UserId", pModel.AuditColumns.UserId) ,
        //             new SqlParameter("@pi_HostName", pModel.AuditColumns.HostName) ,
        //             new SqlParameter("@pi_IPAddress", pModel.AuditColumns.IPAddress) ,
        //             new SqlParameter("@pi_DeviceType", pModel.AuditColumns.DeviceType) ,
        //             new SqlParameter("@pi_MACAddress", pModel.AuditColumns.MACAddress) ,
        //            ptyp_mMobileDetailParameter
        //            };
        //                        result = await pContext.DBResult.FromSql(csql, sqlparam.ToArray()).SingleOrDefaultAsync();

        //                    }
        //             catch (Exception ex)
        //             {
        //             result.ErrorNo = 9999999999;
        //             result.ErrorMessage = ex.Message.ToString();
        //             result.SQLErrorNumber = ex.HResult;
        //             result.SQLErrorMessage = ex.Source.ToString();
        //             }
        //             return result;
        //             }


    }
}
