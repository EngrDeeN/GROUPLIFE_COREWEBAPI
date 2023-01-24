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
    public class PostalCodesRepository : IPostalCodesRepository
    {
        IConfiguration configuration;
        public PostalCodesRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetPostalCodeDetails(int postalCodeId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FSPS_POSTAL_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodeId);
                    dyParam.Add("POSTALCODESCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_POSTALCODE.MAIN_PROCEDURE";

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

        public object GetPostCodeDtlByCtyProvCont(int cityId, int provinceId, int countryId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G3");
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, cityId);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, provinceId);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, countryId);
                    dyParam.Add("POSTALCODESCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_POSTALCODE.MAIN_PROCEDURE";

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

        public object PostPostalCode(PostalCodes postalCodes)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                    dyParam.Add("P_FSPS_POSTAL_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodes.FSPS_POSTAL_ID);
                    dyParam.Add("P_FSPS_POSTAL_CODE", OracleDbType.Varchar2, ParameterDirection.Input, postalCodes.FSPS_POSTAL_CODE);
                    dyParam.Add("P_FSPS_POSTAL_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input, postalCodes.FSPS_POSTAL_DESCRIPTION);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodes.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodes.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodes.FSCT_CITY_ID);
                    dyParam.Add("P_FSPS_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, postalCodes.FSPS_STATUS);
                    dyParam.Add("P_FSPS_CRUSER", OracleDbType.Int32, ParameterDirection.Input, postalCodes.FSPS_CRUSER);
                    dyParam.Add("P_FSPS_CRDATE", OracleDbType.Date, ParameterDirection.Input, postalCodes.FSPS_CRDATE);
                    dyParam.Add("POSTALCODESCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_POSTALCODE.MAIN_PROCEDURE";

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

        public object PutPostalCode(PostalCodes postalCodes)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FSPS_POSTAL_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodes.FSPS_POSTAL_ID);
                    dyParam.Add("P_FSPS_POSTAL_CODE", OracleDbType.Varchar2, ParameterDirection.Input, postalCodes.FSPS_POSTAL_CODE);
                    dyParam.Add("P_FSPS_POSTAL_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input, postalCodes.FSPS_POSTAL_DESCRIPTION);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodes.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodes.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodes.FSCT_CITY_ID);
                    dyParam.Add("P_FSPS_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, postalCodes.FSPS_STATUS);
                    dyParam.Add("P_FSPS_CRUSER", OracleDbType.Int32, ParameterDirection.Input, postalCodes.FSPS_CRUSER);
                    dyParam.Add("P_FSPS_CRDATE", OracleDbType.Date, ParameterDirection.Input, postalCodes.FSPS_CRDATE);
                    dyParam.Add("POSTALCODESCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_POSTALCODE.MAIN_PROCEDURE";

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

        public object DeletePostalCode(int postalCodeId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FSPS_POSTAL_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodeId);
                    dyParam.Add("POSTALCODESCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_POSTALCODE.MAIN_PROCEDURE";

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

        public object GetPostalCodeList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                    dyParam.Add("POSTALCODESCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_POSTALCODE.MAIN_PROCEDURE";

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
