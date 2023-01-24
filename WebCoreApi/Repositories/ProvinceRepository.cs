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
    public class ProvinceRepository : IProvinceRepository
    {
        IConfiguration configuration;
        public ProvinceRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetProvinceDetails(int provinceId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FSSC_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, provinceId);
                    dyParam.Add("PROVINCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_PROVINCE.MAIN_PROCEDURE";

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

        public object GetProvinceDetailsByCont(int countryId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G3");
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, countryId);
                    dyParam.Add("PROVINCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_PROVINCE.MAIN_PROCEDURE";

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

        public object PostProvince(Province province)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, province.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, province.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_NAME", OracleDbType.Varchar2, ParameterDirection.Input, province.FSSP_PROVINCE_NAME);
                    dyParam.Add("P_FSSP_PROVINCE_SHORT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, province.FSSP_PROVINCE_SHORT_NAME);
                    dyParam.Add("P_FSSP_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, province.FSSP_STATUS);
                    dyParam.Add("P_FSSP_CRUSER", OracleDbType.Int32, ParameterDirection.Input, province.FSSP_CRUSER);
                    dyParam.Add("P_FSSP_CRDATE", OracleDbType.Date, ParameterDirection.Input, province.FSSP_CRDATE);
                    dyParam.Add("PROVINCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_PROVINCE.MAIN_PROCEDURE";

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

        public object PutProvince(Province province)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, province.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, province.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_NAME", OracleDbType.Varchar2, ParameterDirection.Input, province.FSSP_PROVINCE_NAME);
                    dyParam.Add("P_FSSP_PROVINCE_SHORT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, province.FSSP_PROVINCE_SHORT_NAME);
                    dyParam.Add("P_FSSP_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, province.FSSP_STATUS);
                    dyParam.Add("P_FSSP_CRUSER", OracleDbType.Int32, ParameterDirection.Input, province.FSSP_CRUSER);
                    dyParam.Add("P_FSSP_CRDATE", OracleDbType.Date, ParameterDirection.Input, province.FSSP_CRDATE);
                    dyParam.Add("PROVINCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_PROVINCE.MAIN_PROCEDURE";

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

        public object DeleteProvince(int provinceId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, provinceId);
                    dyParam.Add("PROVINCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_PROVINCE.MAIN_PROCEDURE";

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

        public object GetProvinceList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                    dyParam.Add("PROVINCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_PROVINCE.MAIN_PROCEDURE";

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
