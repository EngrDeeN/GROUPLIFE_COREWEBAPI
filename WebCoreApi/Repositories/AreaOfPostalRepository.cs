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
    public class AreaOfPostalRepository : IAreaOfPostalRepository
    {
        readonly IConfiguration configuration;
        public AreaOfPostalRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetAreaOfPostalDetails(int areaOfPostalId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FSAP_AREA_ID", OracleDbType.Int32, ParameterDirection.Input, areaOfPostalId);
                    dyParam.Add("AREAOFPOSTALCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_AREAOFPOSTAL.MAIN_PROCEDURE";

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

        public object GetAreaOfPostalDtlByPostalCode(int postalCodeId /*, int cityId, int provinceId, int countryId*/)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G3");
                    dyParam.Add("P_FSPS_POSTAL_ID", OracleDbType.Int32, ParameterDirection.Input, postalCodeId);
                    dyParam.Add("AREAOFPOSTALCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_AREAOFPOSTAL.MAIN_PROCEDURE";

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

        public object PostAreaOfPostal(AreaOfPostal areaOfPostal)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                    dyParam.Add("P_FSAP_AREA_ID", OracleDbType.Int32, ParameterDirection.Input, areaOfPostal.FSAP_AREA_ID);
                    dyParam.Add("P_FSAP_AREA_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input, areaOfPostal.FSAP_AREA_DESCRIPTION);
                    dyParam.Add("P_FSAP_AREA_SHORT_DESCR", OracleDbType.Varchar2, ParameterDirection.Input, areaOfPostal.FSAP_AREA_SHORT_DESCR);
                    dyParam.Add("P_FSAP_GEO_LONGITUDE", OracleDbType.Int32, ParameterDirection.Input, areaOfPostal.FSAP_GEO_LONGITUDE);
                    dyParam.Add("P_FSAP_GEO_LATITUDE", OracleDbType.Int32, ParameterDirection.Input, areaOfPostal.FSAP_GEO_LATITUDE);
                    dyParam.Add("P_FSAP_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, areaOfPostal.FSAP_STATUS);
                    dyParam.Add("P_FSAP_CRUSER", OracleDbType.Int32, ParameterDirection.Input, areaOfPostal.FSAP_CRUSER);
                    dyParam.Add("P_FSAP_CRDATE", OracleDbType.Date, ParameterDirection.Input, areaOfPostal.FSAP_CRDATE);
                    dyParam.Add("AREAOFPOSTALCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_AREAOFPOSTAL.MAIN_PROCEDURE";

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

        public object PutAreaOfPostal(AreaOfPostal areaOfPostal)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FSAP_AREA_ID", OracleDbType.Int32, ParameterDirection.Input, areaOfPostal.FSAP_AREA_ID);
                    dyParam.Add("P_FSAP_AREA_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input, areaOfPostal.FSAP_AREA_DESCRIPTION);
                    dyParam.Add("P_FSAP_AREA_SHORT_DESCR", OracleDbType.Varchar2, ParameterDirection.Input, areaOfPostal.FSAP_AREA_SHORT_DESCR);
                    dyParam.Add("P_FSAP_GEO_LONGITUDE", OracleDbType.Int32, ParameterDirection.Input, areaOfPostal.FSAP_GEO_LONGITUDE);
                    dyParam.Add("P_FSAP_GEO_LATITUDE", OracleDbType.Int32, ParameterDirection.Input, areaOfPostal.FSAP_GEO_LATITUDE);
                    dyParam.Add("P_FSAP_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, areaOfPostal.FSAP_STATUS);
                    dyParam.Add("P_FSAP_CRUSER", OracleDbType.Int32, ParameterDirection.Input, areaOfPostal.FSAP_CRUSER);
                    dyParam.Add("P_FSAP_CRDATE", OracleDbType.Date, ParameterDirection.Input, areaOfPostal.FSAP_CRDATE);
                    dyParam.Add("AREAOFPOSTALCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_AREAOFPOSTAL.MAIN_PROCEDURE";

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

        public object DeleteAreaOfPostal(int areaOfPostalId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FSPS_POSTAL_ID", OracleDbType.Int32, ParameterDirection.Input, areaOfPostalId);
                    dyParam.Add("AREAOFPOSTALCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_AREAOFPOSTAL.MAIN_PROCEDURE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to Delete operation " + ex.Message;
            }

            return result;
        }

        public object GetAreaOfPostalList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                    dyParam.Add("AREAOFPOSTALCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_AREAOFPOSTAL.MAIN_PROCEDURE";

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
