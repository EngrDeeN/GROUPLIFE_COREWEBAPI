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
    public class CountryRepository : ICountryRepository
    {
        readonly IConfiguration configuration;
        static string connectionString;
        public CountryRepository (IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetCountryDetails(int countryId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, countryId);
                    dyParam.Add("COUNTRYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_COUNTRY.MAIN_PROCEDURE";

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

        public object PostCountry(Country country)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, country.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSC_COUNTRY_NAME", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_COUNTRY_NAME);
                    dyParam.Add("P_FSSC_COUNTRY_SHORT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_COUNTRY_SHORT_NAME);
                    dyParam.Add("P_FSSC_COUNTRY_NATIONALITY", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_COUNTRY_NATIONALITY);
                    dyParam.Add("P_FSSC_COUNTRY_DIAL_CODE", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_COUNTRY_DIAL_CODE);
                    dyParam.Add("P_FSSC_FATF_LISTED_YN", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_FATF_LISTED_YN);
                    dyParam.Add("P_FSSC_GREY_LISTED_YN", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_GREY_LISTED_YN);
                    dyParam.Add("P_FSSC_BLACK_LISTED_YN", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_BLACK_LISTED_YN);
                    dyParam.Add("P_FSSC_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_STATUS);
                    dyParam.Add("P_FSSC_CRUSER", OracleDbType.Int32, ParameterDirection.Input, country.FSSC_CRUSER);
                    dyParam.Add("P_FSSC_CRDATE", OracleDbType.Date, ParameterDirection.Input, country.FSSC_CRDATE);
                    dyParam.Add("COUNTRYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_COUNTRY.MAIN_PROCEDURE";

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

        public object PutCountry(Country country)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, country.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSC_COUNTRY_NAME", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_COUNTRY_NAME);
                    dyParam.Add("P_FSSC_COUNTRY_SHORT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_COUNTRY_SHORT_NAME);
                    dyParam.Add("P_FSSC_COUNTRY_NATIONALITY", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_COUNTRY_NATIONALITY);
                    dyParam.Add("P_FSSC_COUNTRY_DIAL_CODE", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_COUNTRY_DIAL_CODE);
                    dyParam.Add("P_FSSC_FATF_LISTED_YN", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_FATF_LISTED_YN);
                    dyParam.Add("P_FSSC_GREY_LISTED_YN", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_GREY_LISTED_YN);
                    dyParam.Add("P_FSSC_BLACK_LISTED_YN", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_BLACK_LISTED_YN);
                    dyParam.Add("P_FSSC_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, country.FSSC_STATUS);
                    dyParam.Add("P_FSSC_CRUSER", OracleDbType.Int32, ParameterDirection.Input, country.FSSC_CRUSER);
                    dyParam.Add("P_FSSC_CRDATE", OracleDbType.Date, ParameterDirection.Input, country.FSSC_CRDATE);
                    dyParam.Add("COUNTRYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_COUNTRY.MAIN_PROCEDURE";

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

        public object DeleteCountry(int countryId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, countryId);
                    dyParam.Add("COUNTRYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_COUNTRY.MAIN_PROCEDURE";

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

        public object GetCountryList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                    dyParam.Add("COUNTRYCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_COUNTRY.MAIN_PROCEDURE";

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
