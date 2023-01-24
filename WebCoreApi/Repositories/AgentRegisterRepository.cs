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
    public class AgentRegisterRepository : IAgentRegisterRepository
    {
        readonly IConfiguration configuration;
        static string connectionString;

        public AgentRegisterRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object GetAgentList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                dyParam.Add("AGENTCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_AGENT.MAIN_PROCEDURE";

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

        public object GetAgentDetails(int AgentRegisterId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                dyParam.Add("P_FSAG_AGENT_CODE", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegisterId);
                dyParam.Add("AGENTCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_AGENT.MAIN_PROCEDURE";

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

        public object PostAgent(AgentRegister AgentRegister)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                dyParam.Add("P_FSAG_AGENT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_AGENT_NAME);
                dyParam.Add("P_FSAG_AGENT_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_AGENT_TYPE);
                dyParam.Add("P_FSNT_IDENTYPE_ID", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.FSNT_IDENTYPE_ID);
                dyParam.Add("P_FSAG_PRIMARY_IDENTITY_NO", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_PRIMARY_IDENTITY_NO);
                dyParam.Add("P_FSAG_DATE_OF_JOINING", OracleDbType.Date, ParameterDirection.Input, AgentRegister.FSAG_DATE_OF_JOINING);
                dyParam.Add("P_FSAG_DATE_OF_LEAVING", OracleDbType.Date, ParameterDirection.Input, AgentRegister.FSAG_DATE_OF_LEAVING);
                dyParam.Add("P_FSAG_HAS_CAR_YN", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_HAS_CAR_YN);
                dyParam.Add("P_FSAG_SERVICE_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_SERVICE_STATUS);
                dyParam.Add("P_FSAG_CHNLS_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.FSAG_CHNLS_FSCD_DID);
                dyParam.Add("P_FSHL_HIERCL_LEVEL_ID", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.FSHL_HIERCL_LEVEL_ID);
                dyParam.Add("P_FSAG_SALARIED_YN", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_SALARIED_YN);
                dyParam.Add("P_FSAG_STAR_RATED_YN", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_STAR_RATED_YN);
                dyParam.Add("P_FSAG_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_STATUS);
                dyParam.Add("P_fsag_date_of_confirm", OracleDbType.Date, ParameterDirection.Input, AgentRegister.fsag_date_of_confirm);
                dyParam.Add("P_fsbk_bank_id", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.fsbk_bank_id);
                dyParam.Add("P_fsag_ba_account_no", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.fsag_ba_account_no);
                dyParam.Add("P_fsag_direct_agent_yn", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.fsag_direct_agent_yn);
                dyParam.Add("P_fsag_target_salary", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.fsag_target_salary);
                dyParam.Add("P_fsag_probation_period", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.fsag_probation_period);
                dyParam.Add("P_fsag_immedt_supvsr_code", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.fsag_immedt_supvsr_code);
                dyParam.Add("P_fsag_remarks", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.fsag_remarks);
                dyParam.Add("P_FSAG_CRUSER", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_CRUSER);
                dyParam.Add("P_FSAG_CRDATE", OracleDbType.Date, ParameterDirection.Input, AgentRegister.FSAG_CRDATE);
                dyParam.Add("AGENTCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_AGENT.MAIN_PROCEDURE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to Save list or operation " + ex.Message;
            }

            return result;
        }

        public object PutAgent(AgentRegister AgentRegister)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                dyParam.Add("P_FSAG_AGENT_CODE", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_AGENT_CODE);
                dyParam.Add("P_FSAG_AGENT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_AGENT_NAME);
                dyParam.Add("P_FSAG_AGENT_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_AGENT_TYPE);
                dyParam.Add("P_FSNT_IDENTYPE_ID", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.FSNT_IDENTYPE_ID);
                dyParam.Add("P_FSAG_PRIMARY_IDENTITY_NO", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_PRIMARY_IDENTITY_NO);
                dyParam.Add("P_FSAG_DATE_OF_JOINING", OracleDbType.Date, ParameterDirection.Input, AgentRegister.FSAG_DATE_OF_JOINING);
                dyParam.Add("P_FSAG_DATE_OF_LEAVING", OracleDbType.Date, ParameterDirection.Input, AgentRegister.FSAG_DATE_OF_LEAVING);
                dyParam.Add("P_FSAG_HAS_CAR_YN", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_HAS_CAR_YN);
                dyParam.Add("P_FSAG_SERVICE_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_SERVICE_STATUS);
                dyParam.Add("P_FSAG_CHNLS_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.FSAG_CHNLS_FSCD_DID);
                dyParam.Add("P_FSHL_HIERCL_LEVEL_ID", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.FSHL_HIERCL_LEVEL_ID);
                dyParam.Add("P_FSAG_SALARIED_YN", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_SALARIED_YN);
                dyParam.Add("P_FSAG_STAR_RATED_YN", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_STAR_RATED_YN);
                dyParam.Add("P_FSAG_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_STATUS);
                dyParam.Add("P_fsag_date_of_confirm", OracleDbType.Date, ParameterDirection.Input, AgentRegister.fsag_date_of_confirm);
                dyParam.Add("P_fsbk_bank_id", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.fsbk_bank_id);
                dyParam.Add("P_fsag_ba_account_no", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.fsag_ba_account_no);
                dyParam.Add("P_fsag_direct_agent_yn", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.fsag_direct_agent_yn);
                dyParam.Add("P_fsag_target_salary", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.fsag_target_salary);
                dyParam.Add("P_fsag_probation_period", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.fsag_probation_period);
                dyParam.Add("P_fsag_immedt_supvsr_code", OracleDbType.Int32, ParameterDirection.Input, AgentRegister.fsag_immedt_supvsr_code);
                dyParam.Add("P_fsag_remarks", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.fsag_remarks);
                dyParam.Add("P_FSAG_CRUSER", OracleDbType.Varchar2, ParameterDirection.Input, AgentRegister.FSAG_CRUSER);
                dyParam.Add("P_FSAG_CRDATE", OracleDbType.Date, ParameterDirection.Input, AgentRegister.FSAG_CRDATE);
                dyParam.Add("AGENTCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_AGENT.MAIN_PROCEDURE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to Update list or operation " + ex.Message;
            }

            return result;
        }


        public IDbConnection GetConnection()
        {
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("GlobalConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}
