using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.DAORespositories;
using WebCoreApi.Models;
using WebCoreApi.Oracle;

namespace WebCoreApi.Repositories
{
    public class UnderWrittingRepository : IUnderWrittingRepository
    {
        IConfiguration configuration;
        public UnderWrittingRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetUnderWrittingList() {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPP");
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;
        }
        public object GetUnderWrittingDetails(int UnderWrittingId) {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "UQ");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, UnderWrittingId);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;
        }
        public object GetUnderWrittingDetailsByQuotation(string P_IDENTIF_NO) {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "UQ");
                dyParam.Add("P_IDENTIF_NO", OracleDbType.Varchar2, ParameterDirection.Input, P_IDENTIF_NO);
                dyParam.Add("PPOLUNDWCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;

        }
        //Added by Shizra Aijaz
        public object GetPendingPersons(string Policy_no) {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPP");
                dyParam.Add("P_FGPH_POLICY_NO", OracleDbType.Varchar2, ParameterDirection.Input, Policy_no);
                dyParam.Add("PPOLUNDWCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;
        }

        public object GetUnderWrittingDetailsByRider(string FGQH_QUOTATHDR_CODE, string IDENTIF_NO)
        {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "UR");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, FGQH_QUOTATHDR_CODE);
                dyParam.Add("P_IDENTIF_NO", OracleDbType.Varchar2, ParameterDirection.Input, IDENTIF_NO);
                dyParam.Add("PPOLUNDWCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;

        }

        
        public object PostUnderWritting(UnderWritting UnderWritting) {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "EU");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FGQH_QUOTATHDR_CODE);
                dyParam.Add("P_IDENTIF_NO", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.IDENTIF_NO);
                dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, UnderWritting.FSPM_PRODUCT_ID);
                dyParam.Add("P_FUPF_BASRIDR_YN", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_BASRIDR_YN);
                dyParam.Add("P_FUPF_LOADING_TYP", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_LOADING_TYPE);
                dyParam.Add("P_FUPF_LOADING_AMT", OracleDbType.Int32, ParameterDirection.Input, UnderWritting.FUPF_LOADING_AMT);
                dyParam.Add("P_FUPF_NEWFCL_AMT", OracleDbType.Int32, ParameterDirection.Input, UnderWritting.FUPF_NEWFCL_AMT);
                dyParam.Add("P_FUPF_UNDW_DESCD", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_UNDW_DESCD);
                dyParam.Add("P_FUPF_UNDW_DESREASN", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_UNDW_DESREASN);
                dyParam.Add("P_FUPF_SUBSTNDRD_YN", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_SUBSTNDRD_YN);
                dyParam.Add("P_FUPF_AGEUSR_RATE", OracleDbType.Int32, ParameterDirection.Input, UnderWritting.FUPF_AGEUSR_RATE);
                dyParam.Add("P_FUPF_AGEUSRAT_TYP", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_AGEUSRAT_TYP);
                dyParam.Add("P_FUPF_APPRV_DATE", OracleDbType.Date, ParameterDirection.Input, UnderWritting.FUPF_APPRV_DATE);
                dyParam.Add("P_FUPF_CRUSER", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_CRUSER);
                dyParam.Add("P_FUPF_CRDATE", OracleDbType.Date, ParameterDirection.Input, UnderWritting.FUPF_CRDATE);
                dyParam.Add("PPOLUNDWCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;

        }
        public object PutUnderWritting(UnderWritting UnderWritting) {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPP");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FGQH_QUOTATHDR_CODE);
                dyParam.Add("P_IDENTIF_NO", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.IDENTIF_NO);
                dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FSPM_PRODUCT_ID);
                dyParam.Add("P_FUPF_BASRIDR_YN", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_BASRIDR_YN);
                dyParam.Add("P_FUPF_UNDERWRT_ID", OracleDbType.Int32, ParameterDirection.Input, UnderWritting.FUPF_UNDERWRT_ID);
                dyParam.Add("P_FUPF_LOADING_TYPE", OracleDbType.Int32, ParameterDirection.Input, UnderWritting.FUPF_LOADING_TYPE);
                dyParam.Add("P_FUPF_LOADING_AMT", OracleDbType.Int32, ParameterDirection.Input, UnderWritting.FUPF_LOADING_AMT);
                dyParam.Add("P_FUPF_NEWFCL_AMT", OracleDbType.Int32, ParameterDirection.Input, UnderWritting.FUPF_NEWFCL_AMT);
                dyParam.Add("P_FUPF_UNDW_DESCD", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_UNDW_DESCD);
                dyParam.Add("P_FUPF_UNDW_DESREASN", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_UNDW_DESREASN);
                dyParam.Add("P_FUPF_SUBSTNDRD_YN", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_SUBSTNDRD_YN);
                dyParam.Add("P_FUPF_AGEUSR_RATE", OracleDbType.Int32, ParameterDirection.Input, UnderWritting.FUPF_AGEUSR_RATE);
                dyParam.Add("P_FUPF_AGEUSRAT_TYP", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_AGEUSRAT_TYP);
                dyParam.Add("P_FUPF_APPRV_DATE", OracleDbType.Date, ParameterDirection.Input, UnderWritting.FUPF_APPRV_DATE);
                dyParam.Add("P_FUPF_CRUSER", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritting.FUPF_CRUSER);
                dyParam.Add("P_FUPF_CRDATE", OracleDbType.Date, ParameterDirection.Input, UnderWritting.FUPF_CRDATE);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;
        }
        public object DeleteUnderWritting(int UnderWrittingId) {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPP");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, UnderWrittingId);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;
        }

        public object PostUnderWrittingDocument(UnderWritt_Doc UnderWritt_Doc)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPP");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritt_Doc.FGQH_QUOTATHDR_CODE);
                dyParam.Add("P_IDENTIF_NO", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritt_Doc.IDENTIF_NO);
                dyParam.Add("P_FGPD_UWDOC_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, UnderWritt_Doc.FGPD_UWDOC_FSCD_DID);
                dyParam.Add("P_FGPD_REQUEST_DATE", OracleDbType.Date, ParameterDirection.Input, UnderWritt_Doc.FGPD_REQUEST_DATE);
                dyParam.Add("P_FGPD_RECEIVD_DATE", OracleDbType.Date, ParameterDirection.Input, UnderWritt_Doc.FGPD_RECEIVD_DATE);
                dyParam.Add("P_FGPD_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritt_Doc.FGPD_STATUS);
                dyParam.Add("P_FGPD_CRUSER", OracleDbType.Int32, ParameterDirection.Input, UnderWritt_Doc.FGPD_CRUSER);
                dyParam.Add("P_FGPD_CRDATE", OracleDbType.Date, ParameterDirection.Input, UnderWritt_Doc.FGPD_CRDATE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;

        }
        public object PutUnderWrittingDocument(UnderWritt_Doc UnderWritt_Doc)
        {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPP");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritt_Doc);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;
        }
        public object DeleteUnderWrittingDocument(int UnderWritt_DocId)
        {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPP");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, UnderWritt_DocId);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_POSTPOL_UNDWTG.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            return result;
        }

        public object Get_NewOrDelete_Customer(string PolicyNo)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GP");
                dyParam.Add("P_FGPH_POLICY_NO", OracleDbType.Varchar2, ParameterDirection.Input, PolicyNo);
                dyParam.Add("P_IDENTIF_NO", OracleDbType.Varchar2, ParameterDirection.Input, "X");
                dyParam.Add("PFLUCTUATCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_FLUCTUATIONS.MAIN_PROCEDURE";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }
            return result;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("GlobalConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}
