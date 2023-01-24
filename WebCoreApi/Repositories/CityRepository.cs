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
    public class CityRepository : ICityRepository
    {
        IConfiguration configuration;
        public CityRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetCityDetails(int cityId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, cityId);
                    dyParam.Add("CITYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_CITY.MAIN_PROCEDURE";

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

        public object GetCityDetailsByProvCont(int provinceId, int countryId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G3");
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, provinceId);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, countryId);
                    dyParam.Add("CITYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_CITY.MAIN_PROCEDURE";

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

        public object PostCity(City city)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, city.FSCT_CITY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, city.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, city.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSCT_CITY_NAME", OracleDbType.Varchar2, ParameterDirection.Input, city.FSCT_CITY_NAME);
                    dyParam.Add("P_FSCT_CITY_SHORT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, city.FSCT_CITY_SHORT_NAME);
                    dyParam.Add("P_FSCT_CITY_DIAL_CODE", OracleDbType.Varchar2, ParameterDirection.Input, city.FSCT_CITY_DIAL_CODE);
                    dyParam.Add("P_FSCT_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, city.FSCT_STATUS);
                    dyParam.Add("P_FSCT_CRUSER", OracleDbType.Int32, ParameterDirection.Input, city.FSCT_CRUSER);
                    dyParam.Add("P_FSCT_CRDATE", OracleDbType.Date, ParameterDirection.Input, city.FSCT_CRDATE);
                    dyParam.Add("CITYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_CITY.MAIN_PROCEDURE";

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

        public object PutCity(City city)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, city.FSCT_CITY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, city.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, city.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSCT_CITY_NAME", OracleDbType.Varchar2, ParameterDirection.Input, city.FSCT_CITY_NAME);
                    dyParam.Add("P_FSCT_CITY_SHORT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, city.FSCT_CITY_SHORT_NAME);
                    dyParam.Add("P_FSCT_CITY_DIAL_CODE", OracleDbType.Varchar2, ParameterDirection.Input, city.FSCT_CITY_DIAL_CODE);
                    dyParam.Add("P_FSCT_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, city.FSCT_STATUS);
                    dyParam.Add("P_FSCT_CRUSER", OracleDbType.Int32, ParameterDirection.Input, city.FSCT_CRUSER);
                    dyParam.Add("P_FSCT_CRDATE", OracleDbType.Date, ParameterDirection.Input, city.FSCT_CRDATE);
                    dyParam.Add("CITYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_CITY.MAIN_PROCEDURE";

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

        public object DeleteCity(int cityId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, cityId);
                    dyParam.Add("CITYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_CITY.MAIN_PROCEDURE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to Delete list or operation " + ex.Message;
            }

            return result;
        }

        public object GetCityList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                    dyParam.Add("CITYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_CITY.MAIN_PROCEDURE";

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
