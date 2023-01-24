using WebCoreApi.Oracle;
using WebCoreApi.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using WebCoreApi.DAORespositories;

namespace WebCoreApi.Repositories
{
    public class QuotAgentDetlRepository : IQuotAgentDetlRepository
    {
        IConfiguration configuration;
        public QuotAgentDetlRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetQuotAgentDetDetails(int QuotAgentDetlID)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GA1");
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotAgentDetlID);
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

        public object PostQuotAgentDet(QuotAgentDetl quotAgentDetl)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "AI");
                    dyParam.Add("P_FGQA_COMPAGNT_ID", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FGQA_COMPAGNT_ID);
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FGQH_QUOTATHDR_ID);
                    dyParam.Add("P_FSAG_AGENT_CODE", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FSAG_AGENT_CODE);
                    // dyParam.Add("P_FSLO_LOCATION_ID", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FSLO_LOCATION_ID);
                    dyParam.Add("P_FGQA_COMMISSION_PERCENT", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FGQA_COMMISSION_PERCENT);
                    dyParam.Add("P_FGQA_WAKALA_ONPREM", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FGQA_WAKALA_ONPREM);
                    // dyParam.Add("P_FGQA_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, quotAgentDetl.FGQA_STATUS);
                    dyParam.Add("P_FGQA_CRUSER", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FGQA_CRUSER);
                    dyParam.Add("P_FGQA_CRDATE", OracleDbType.Date, ParameterDirection.Input, quotAgentDetl.FGQA_CRDATE);
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

        public object PutQuotAgentDet(QuotAgentDetl quotAgentDetl)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "AU");
                    dyParam.Add("P_FGQA_COMPAGNT_ID", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FGQA_COMPAGNT_ID);
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FGQH_QUOTATHDR_ID);
                    dyParam.Add("P_FSAG_AGENT_CODE", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FSAG_AGENT_CODE);
                    //dyParam.Add("P_FSLO_LOCATION_ID", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FSLO_LOCATION_ID);
                    dyParam.Add("P_FGQA_COMMISSION_PERCENT", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FGQA_COMMISSION_PERCENT);
                    dyParam.Add("P_FGQA_WAKALA_ONPREM", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FGQA_WAKALA_ONPREM);
                    //dyParam.Add("P_FGQA_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, quotAgentDetl.FGQA_STATUS);
                    dyParam.Add("P_FGQA_CRUSER", OracleDbType.Int32, ParameterDirection.Input, quotAgentDetl.FGQA_CRUSER);
                    dyParam.Add("P_FGQA_CRDATE", OracleDbType.Date, ParameterDirection.Input, quotAgentDetl.FGQA_CRDATE);
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
