using WebCoreApi.Oracle;
using WebCoreApi.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using WebCoreApi.DAORespositories;

namespace WebCoreApi.Repositories
{
    public class ProductRateRepository : IProductRateRepository
    {
        IConfiguration configuration;
        public ProductRateRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetProductRateDetails(int productRateId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FSPRM_RATE_ID", OracleDbType.Int32, ParameterDirection.Input, productRateId);
                    dyParam.Add("GLRATECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GLRATE.MAIN_PROCEDURE";

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

        public object GetProductRateDetailsByName(string productRateName)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G3");
                    dyParam.Add("P_FSPRM_NAME", OracleDbType.Int32, ParameterDirection.Input, productRateName);
                    dyParam.Add("GLRATECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GLRATE.MAIN_PROCEDURE";

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

        public object PostProductRate(ProductRate productRate)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FSPRM_RATE_ID", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_RATE_ID);
                    dyParam.Add("P_FSPRM_NAME", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_NAME);
                    dyParam.Add("P_FSPRM_DESCRIPTION", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_DESCRIPTION);
                    dyParam.Add("P_FSPRM_TYPE", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_TYPE);
                    dyParam.Add("P_FSPRM_STATUS", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_STATUS);
                    dyParam.Add("P_FSPRM_REMARKS", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_REMARKS);
                    dyParam.Add("GLRATECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GLRATE.MAIN_PROCEDURE";

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

        public object PutProductRate(ProductRate productRate)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FSPRM_RATE_ID", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_RATE_ID);
                    dyParam.Add("P_FSPRM_NAME", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_NAME);
                    dyParam.Add("P_FSPRM_DESCRIPTION", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_DESCRIPTION);
                    dyParam.Add("P_FSPRM_TYPE", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_TYPE);
                    dyParam.Add("P_FSPRM_STATUS", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_STATUS);
                    dyParam.Add("P_FSPRM_REMARKS", OracleDbType.Int32, ParameterDirection.Input, productRate.FSPRM_REMARKS);
                    dyParam.Add("GLRATECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GLRATE.MAIN_PROCEDURE";

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

        public object DeleteProductRate(int productRateId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FSPRM_RATE_ID", OracleDbType.Int32, ParameterDirection.Input, productRateId);
                    dyParam.Add("GLRATECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GLRATE.MAIN_PROCEDURE";

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

        public object GetProductRateList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                    dyParam.Add("GLRATECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GLRATE.MAIN_PROCEDURE";

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