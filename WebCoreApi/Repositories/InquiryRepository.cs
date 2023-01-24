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
    public class InquiryRepository : IInquiryRepository
    {
        readonly IConfiguration configuration;
        static string connectionString;

        public InquiryRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object GetInquiryDetails(string QUOTATHDR_CODE)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PIH");
                dyParam.Add("P_POLICY_QUOTATION", OracleDbType.Varchar2, ParameterDirection.Input, QUOTATHDR_CODE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_OPERATIONS.MAIN_PROCESS";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                result = "Failed to load list or operation " + ex.Message;
            }
            return result;
        }

        public object Get_Inquiry_Member_Details(string QUOTATHDR_CODE)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PID");
                dyParam.Add("P_POLICY_QUOTATION", OracleDbType.Varchar2, ParameterDirection.Input, QUOTATHDR_CODE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_OPERATIONS.MAIN_PROCESS";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                result = "Failed to load list or operation " + ex.Message;
            }
            return result;
        }

        public object Get_Inquiry_Pending_Member_Details(string QUOTATHDR_CODE)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PPD");
                dyParam.Add("P_POLICY_QUOTATION", OracleDbType.Varchar2, ParameterDirection.Input, QUOTATHDR_CODE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_OPERATIONS.MAIN_PROCESS";

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

        public object Get_Inquiry_Rider_Details(int quotationID)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "R1");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, quotationID);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_QUOTATIONGEN_EVRIDR.MAIN_PROCEDURE";

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
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("GlobalConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}

