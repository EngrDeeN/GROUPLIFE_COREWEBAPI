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
    public class QuotaProcessRepository : IQuotaProcessRepository
    {
        IConfiguration configuration;
        public QuotaProcessRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object PostQuotaProcessPolicyGenrtWithQuotationId(PolicyGeneration PolicyGeneration)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                //    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PP");
                //    dyParam.Add("P_REFRNCID3", OracleDbType.Int32, ParameterDirection.Input, PolicyGeneration.FGQH_QUOTATHDR_ID);
                //    dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, PolicyGeneration.FGQH_QUOTATHDR_ID);
                //dyParam.Add("P_GROSS_PREMIUM", OracleDbType.Int32, ParameterDirection.Output, null);
                //dyParam.Add("P_NET_PREMIUM", OracleDbType.Int32, ParameterDirection.Output, null);
                //dyParam.Add("P_SUMASSURED", OracleDbType.Int32, ParameterDirection.Output, null);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    //var query = "ACT_GTS_OPERATIONS.MAIN_PROCESS";
                    var query = "ACT_GTS_OPERATIONS.PRE_POL_VALUES";

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

        public object PostQuotaProcessPolicy(PolicyGeneration policyGeneration)
        {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, policyGeneration.FGQH_QUOTATHDR_ID);
                //dyParam.Add("P_GROSS_PREMIUM", OracleDbType.Int32, ParameterDirection.Output, null);
                //dyParam.Add("P_NET_PREMIUM", OracleDbType.Int32, ParameterDirection.Output, null);
                //dyParam.Add("P_SUMASSURED", OracleDbType.Int32, ParameterDirection.Output, null);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_OPERATIONS.PRE_POL_VALUES";

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

        public object GetQuotaProcessList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GA2");
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object GetQuotaProcessDetails(string QuotationCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPP");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, QuotationCode);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object PostQuotaProcess(QuotaProcess QuotaProcess)
        {

            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "QUP");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FGQH_QUOTATHDR_ID);
                dyParam.Add("P_FGQH_POLCISSUD_YN", OracleDbType.Varchar2, ParameterDirection.Input, "N");
                dyParam.Add("P_FGQH_QUOTATION_CONFIRM", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcess.FGQH_QUOTATION_CONFIRM);
                dyParam.Add("P_FGQH_WITHRCPT_YN", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcess.FGQH_WITHRCPT_YN);
                dyParam.Add("p_fgqr_cruser", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_CRUSER);
                dyParam.Add("p_fgqr_crdate", OracleDbType.Date, ParameterDirection.Input, QuotaProcess.FPQP_CRDATE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query_ = "ACT_GTS_QUOTATIONGEN_EVRIDR.MAIN_PROCEDURE";

                    result = SqlMapper.Query(conn, query_, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PLI");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FGQH_QUOTATHDR_ID);
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcess.FGQH_QUOTATHDR_CODE);
                dyParam.Add("P_FPQP_GROSSPREMIUM", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_GROSSPREMIUM);
                //dyParam.Add("P_FGQH_QUOTATION_CONFIRM", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FGQH_QUOTATION_CONFIRM);
                //dyParam.Add("P_FPQP_SUMASSURED", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_SUMASSURED);
                dyParam.Add("P_FPQP_SERVICETAX", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_SERVICETAX);
                dyParam.Add("P_FPQP_DISCOUNT_AMT", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_DISCOUNT_AMT);
                dyParam.Add("P_FPQP_CHARGES_AMT", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_CHARGES_AMT);
                dyParam.Add("P_FPQP_OTHER_AMT", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_OTHER_AMT);
                //dyParam.Add("P_FPQP_OTHER_DESCR", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcess.FPQP_OTHER_DESCR);
                dyParam.Add("P_FPQP_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcess.FPQP_STATUS);
                dyParam.Add("P_FPQP_WAKALA_PERC", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_WAKALA_PERC);
                //dyParam.Add("P_FGQH_WITHRCPT_YN", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FGQH_WITHRCPT_YN);
                dyParam.Add("P_FPQP_CRUSER", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_CRUSER);
                dyParam.Add("P_FPQP_CRDATE", OracleDbType.Date, ParameterDirection.Input, QuotaProcess.FPQP_CRDATE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object PutQuotaProcess(QuotaProcess QuotaProcess)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "QUP");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FGQH_QUOTATHDR_ID);
                dyParam.Add("P_FGQH_POLCISSUD_YN", OracleDbType.Varchar2, ParameterDirection.Input, "N");
                dyParam.Add("P_FGQH_QUOTATION_CONFIRM", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcess.FGQH_QUOTATION_CONFIRM);
                dyParam.Add("P_FGQH_WITHRCPT_YN", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcess.FGQH_WITHRCPT_YN);
                dyParam.Add("p_fgqr_cruser", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_CRUSER);
                dyParam.Add("p_fgqr_crdate", OracleDbType.Date, ParameterDirection.Input, QuotaProcess.FPQP_CRDATE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query_ = "ACT_GTS_QUOTATIONGEN_EVRIDR.MAIN_PROCEDURE";

                    result = SqlMapper.Query(conn, query_, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to load list or operation " + ex.Message;
            }

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PLU");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FGQH_QUOTATHDR_ID);
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcess.FGQH_QUOTATHDR_CODE);
                dyParam.Add("P_FPQP_GROSSPREMIUM", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_GROSSPREMIUM);
                //dyParam.Add("P_FGQH_QUOTATION_CONFIRM", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FGQH_QUOTATION_CONFIRM);
                //dyParam.Add("P_FPQP_SUMASSURED", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_SUMASSURED);
                dyParam.Add("P_FPQP_SERVICETAX", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_SERVICETAX);
                dyParam.Add("P_FPQP_DISCOUNT_AMT", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_DISCOUNT_AMT);
                dyParam.Add("P_FPQP_CHARGES_AMT", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_CHARGES_AMT);
                dyParam.Add("P_FPQP_OTHER_AMT", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_OTHER_AMT);
                //dyParam.Add("P_FPQP_OTHER_DESCR", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcess.FPQP_OTHER_DESCR);
                dyParam.Add("P_FPQP_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcess.FPQP_STATUS);
                dyParam.Add("P_FPQP_WAKALA_PERC", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_WAKALA_PERC);
                //dyParam.Add("P_FGQH_WITHRCPT_YN", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FGQH_WITHRCPT_YN);
                dyParam.Add("P_FPQP_CRUSER", OracleDbType.Int32, ParameterDirection.Input, QuotaProcess.FPQP_CRUSER);
                dyParam.Add("P_FPQP_CRDATE", OracleDbType.Date, ParameterDirection.Input, QuotaProcess.FPQP_CRDATE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to Save operation " + ex.Message;
            }
            return result;
        }
        public object DeleteQuotaProcess(int QuotaProcessId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessId);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object GetQuotaProcessFLCList()
        {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object GetQuotatFCLDtls(string QuotaProcessCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPF");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessCode);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object PostQuotaFLCProcess(QuotationProcessFCL QuotaProcessFCL)
        {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PFI");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessFCL.FGQH_QUOTATHDR_ID);
                dyParam.Add("P_FPQF_QUOTFCL_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessFCL.FPQF_QUOTFCL_ID);
                dyParam.Add("P_FSPF_PRODFCL_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessFCL.FSPF_PRODFCL_ID);
                dyParam.Add("P_FPQF_SYS_FCL_AMT", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessFCL.FPQF_SYS_FCL_AMT);
                dyParam.Add("P_FPQF_SYSUSR_FCL_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessFCL.FPQF_SYSUSR_FCL_FLAG);
                dyParam.Add("P_FPQF_USER_FCL_AMT", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessFCL.FPQF_USER_FCL_AMT);
                dyParam.Add("P_FPQF_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessFCL.FPQF_STATUS);
                dyParam.Add("P_FPQF_CRUSER", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessFCL.FPQF_CRUSER);
                dyParam.Add("P_FPQF_CRDATE", OracleDbType.Date, ParameterDirection.Input, QuotaProcessFCL.FPQF_CRDATE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object PutQuotaFLCProcess(QuotationProcessFCL QuotaProcessFCL)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PFI");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessFCL.FGQH_QUOTATHDR_ID);
                dyParam.Add("P_FPQF_QUOTFCL_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessFCL.FPQF_QUOTFCL_ID);
                dyParam.Add("P_FSPF_PRODFCL_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessFCL.FSPF_PRODFCL_ID);
                dyParam.Add("P_FPQF_SYS_FCL_AMT", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessFCL.FPQF_SYS_FCL_AMT);
                dyParam.Add("P_FPQF_SYSUSR_FCL_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessFCL.FPQF_SYSUSR_FCL_FLAG);
                dyParam.Add("P_FPQF_USER_FCL_AMT", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessFCL.FPQF_USER_FCL_AMT);
                dyParam.Add("P_FPQF_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessFCL.FPQF_STATUS);
                dyParam.Add("P_FPQF_CRUSER", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessFCL.FPQF_CRUSER);
                dyParam.Add("P_FPQF_CRDATE", OracleDbType.Date, ParameterDirection.Input, QuotaProcessFCL.FPQF_CRDATE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object DeleteQuotaFLCProcess(int QuotaProFCLId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object GetQuotaProcessUnitRateList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPU");
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object GetQuotatUnitRateLimitDtls(string QuotaProcessUniteRateId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPU");
                dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessUniteRateId);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object PostQuotaProcessUR(QuotationProcessUnitRate QuotaProcessUnitRate)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PUI");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessUnitRate.FGQH_QUOTATHDR_ID);
                dyParam.Add("P_FPQR_EVENT_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_EVENT_ID);
                dyParam.Add("P_FSPR_PRODRELTN_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessUnitRate.FSPR_PRODRELTN_ID);
                dyParam.Add("P_FPQR_SYSTMUNIT_RATE", OracleDbType.Decimal, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_SYSTMUNIT_RATE);
                dyParam.Add("P_FPQR_USERUNIT_RATE", OracleDbType.Decimal, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_USERUNIT_RATE);
                dyParam.Add("P_FPQR_USERNET_RATE", OracleDbType.Decimal, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_USERNET_RATE);
                dyParam.Add("P_FPQR_BASPLN_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_BASPLN_FLAG);
                dyParam.Add("p_fpqr_rirate", OracleDbType.Decimal, ParameterDirection.Input, QuotaProcessUnitRate.fpqr_rirate);
                dyParam.Add("p_FPQR_SYSUSR_RATE_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_SYSUSR_RATE_FLAG);
                dyParam.Add("P_FPQR_CRUSER", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_CRUSER);
                dyParam.Add("P_FPQR_CRDATE", OracleDbType.Date, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_CRDATE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object PutQuotaProcessUR(QuotationProcessUnitRate QuotaProcessUnitRate)
        {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PUU");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessUnitRate.FGQH_QUOTATHDR_ID);
                dyParam.Add("P_FPQR_EVENT_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_EVENT_ID);
                dyParam.Add("P_FSPR_PRODRELTN_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessUnitRate.FSPR_PRODRELTN_ID);
                dyParam.Add("P_FPQR_SYSTMUNIT_RATE", OracleDbType.Decimal, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_SYSTMUNIT_RATE);
                dyParam.Add("P_FPQR_USERUNIT_RATE", OracleDbType.Decimal, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_USERUNIT_RATE);
                dyParam.Add("P_FPQR_USERNET_RATE", OracleDbType.Decimal, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_USERNET_RATE);
                dyParam.Add("P_FPQR_BASPLN_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_BASPLN_FLAG);
                dyParam.Add("p_fpqr_rirate", OracleDbType.Decimal, ParameterDirection.Input, QuotaProcessUnitRate.fpqr_rirate);
                dyParam.Add("P_FPQR_CRUSER", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_CRUSER);
                dyParam.Add("P_FPQR_CRDATE", OracleDbType.Date, ParameterDirection.Input, QuotaProcessUnitRate.FPQR_CRDATE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
        public object DeleteQuotaProcessUR(int QuotaProcessUniteRateId)
        {

            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotaProcessUniteRateId);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";
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
        public object CreateDuplicationQuoation(PolicyIssuance request)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "CQQ");
                dyParam.Add("P_REFRNCID1", OracleDbType.Int32, ParameterDirection.Input, request.FGQH_QUOTATHDR_ID);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);
                
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";
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
