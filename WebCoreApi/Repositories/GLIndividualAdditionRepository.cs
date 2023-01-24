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
    public class GLIndividualAdditionRepository : IGLIndividualAdditionRepository
    {

        readonly IConfiguration configuration;
        static string connectionString;
        public GLIndividualAdditionRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object GetGLIndiAddiDetailsByPolicyNo(string ByPolicyNo)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPR");
                dyParam.Add("P_FGPH_POLICY_NO", OracleDbType.Varchar2, ParameterDirection.Input, ByPolicyNo);
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

        public object GetGLIndiAddiDetails(string CustomerCNIC, string ByPolicyNo)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GP");
                dyParam.Add("P_IDENTIF_NO", OracleDbType.Varchar2, ParameterDirection.Input, CustomerCNIC);
                dyParam.Add("P_FGPH_POLICY_NO", OracleDbType.Varchar2, ParameterDirection.Input, ByPolicyNo);
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

        public object PostGLIndiAddi(GLIndividualAddition GLIndividualAddition)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "MI");
                dyParam.Add("P_FGPH_POLICY_NO", OracleDbType.Varchar2, ParameterDirection.Input, GLIndividualAddition.FGPH_POLICY_NO);
                dyParam.Add("P_FGBU_CUST_CODE", OracleDbType.Varchar2, ParameterDirection.Input, "0");
                dyParam.Add("P_FGBU_CUST_CNIC", OracleDbType.Varchar2, ParameterDirection.Input, GLIndividualAddition.FGBU_CUST_CNIC);
                dyParam.Add("P_FGBU_CUST_NAME", OracleDbType.Varchar2, ParameterDirection.Input, GLIndividualAddition.FGBU_CUST_NAME);
                dyParam.Add("P_FGBU_EMP_AGE", OracleDbType.Int32, ParameterDirection.Input, GLIndividualAddition.FGBU_EMP_AGE);
                dyParam.Add("P_FGBU_CUST_GENDER", OracleDbType.Varchar2, ParameterDirection.Input, GLIndividualAddition.FGBU_CUST_GENDER);
                dyParam.Add("P_FGBU_CUST_OCCUPATION", OracleDbType.Varchar2, ParameterDirection.Input, GLIndividualAddition.FGBU_CUST_OCCUPATION);
                dyParam.Add("P_FGBU_CUST_CATEGORY", OracleDbType.Varchar2, ParameterDirection.Input, GLIndividualAddition.FGBU_CUST_CATEGORY);

                dyParam.Add("P_FGBU_CUST_TITLE", OracleDbType.Varchar2, ParameterDirection.Input, GLIndividualAddition.FGBU_CUST_TITLE);
                dyParam.Add("P_FGBU_POL_COVGE_SUMASSURD", OracleDbType.Int32, ParameterDirection.Input, GLIndividualAddition.FGBU_POL_COVGE_SUMASSURD);
                dyParam.Add("P_FGBU_CUST_DOB", OracleDbType.Date, ParameterDirection.Input, GLIndividualAddition.FGBU_CUST_DOB);
                
                //dyParam.Add("P_FUPF_LOADING_TYP", OracleDbType.Varchar2, ParameterDirection.Input, GLIndividualAddition.FUPF_LOADING_TYP);
                //dyParam.Add("P_FUPF_LOADING_AMTPERC", OracleDbType.Int32, ParameterDirection.Input, GLIndividualAddition.FUPF_LOADING_AMTPERC);
                //dyParam.Add("P_FGBU_POL_COVGE_STDATE", OracleDbType.Date, ParameterDirection.Input, GLIndividualAddition.FGBU_POL_COVGE_STDATE);
                //dyParam.Add("P_FGBU_POL_COVGE_EDDATE", OracleDbType.Date, ParameterDirection.Input, GLIndividualAddition.FGBU_POL_COVGE_EDDATE);

                dyParam.Add("P_FGBU_CRUSER", OracleDbType.Int32, ParameterDirection.Input, GLIndividualAddition.FGBU_CRUSER);
                dyParam.Add("P_FGBU_CRDATE", OracleDbType.Date, ParameterDirection.Input, GLIndividualAddition.FGBU_CRDATE);
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
                result = "Failed to Save list or operation " + ex.Message;
            }
            return result;
        }

        public object PutGLIndiAddi(GLIndividualAddition GLIndividualAddition)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "MD");
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
                result = "Failed to Update list or operation " + ex.Message;
            }
            return result;
        }


        public object PurgeGLIndiAddi(GLIndividualAddition GLIndividualAddition)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "MD");
                dyParam.Add("P_FGPH_POLICY_NO", OracleDbType.Varchar2, ParameterDirection.Input, GLIndividualAddition.FGPH_POLICY_NO);
                dyParam.Add("P_IDENTIF_NO", OracleDbType.Varchar2, ParameterDirection.Input, GLIndividualAddition.FGBU_CUST_CNIC);
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

        public object FluctuatAddMmbrDtl(FluctuatAddMmbrDtl FluctuatAddMmbrDtl)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "MPI");
                dyParam.Add("P_FGPH_POLICY_NO", OracleDbType.Varchar2, ParameterDirection.Input, FluctuatAddMmbrDtl.FGPH_POLICY_NO);
                dyParam.Add("P_FGBU_CUST_CNIC", OracleDbType.Varchar2, ParameterDirection.Input, FluctuatAddMmbrDtl.FGBU_CUST_CNIC);
                dyParam.Add("P_FGBU_BATCH_ID", OracleDbType.Varchar2, ParameterDirection.Input, FluctuatAddMmbrDtl.FGBU_BATCH_ID);
                dyParam.Add("P_FGBU_POL_COVGE_STDATE", OracleDbType.Date, ParameterDirection.Input, FluctuatAddMmbrDtl.FGBU_POL_COVGE_STDATE);
                dyParam.Add("P_FGBU_POL_COVGE_EDDATE", OracleDbType.Date, ParameterDirection.Input, FluctuatAddMmbrDtl.FGBU_POL_COVGE_EDDATE);
                dyParam.Add("P_FGBU_POL_COVGE_SUMASSURD", OracleDbType.Varchar2, ParameterDirection.Input, FluctuatAddMmbrDtl.FGBU_POL_COVGE_SUMASSURD);
                dyParam.Add("P_FUPF_LOADING_TYP", OracleDbType.Int32, ParameterDirection.Input, FluctuatAddMmbrDtl.FUPF_LOADING_TYP);
                dyParam.Add("P_FUPF_LOADING_AMTPERC", OracleDbType.Varchar2, ParameterDirection.Input, FluctuatAddMmbrDtl.FUPF_LOADING_AMTPERC);
                dyParam.Add("P_FGQH_QTGRC_FSCD_DID", OracleDbType.Varchar2, ParameterDirection.Input, "0");
                
                dyParam.Add("P_FGBU_CRUSER", OracleDbType.Int32, ParameterDirection.Input, FluctuatAddMmbrDtl.FGBU_CRUSER);
                dyParam.Add("P_FGBU_CRDATE", OracleDbType.Date, ParameterDirection.Input, FluctuatAddMmbrDtl.FGBU_CRDATE);
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
                result = "Failed to Save list or operation " + ex.Message;
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
