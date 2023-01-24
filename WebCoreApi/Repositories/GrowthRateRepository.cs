using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using WebCoreApi.DAORespositories;
using WebCoreApi.Models;
using WebCoreApi.Oracle;

namespace WebCoreApi.Repositories
{
    public class GrowthRateRepository : IGrowthRateRepository
    {
        IConfiguration Configuration;
        public GrowthRateRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public object GET_GROWTH_RATE_LIST()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                dyParam.Add("GROWTHRTCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GROWTHRTS.MAIN_PROCEDURE";

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
        public object GET_GROWTH_RATE_DETAILS(int growthID)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                dyParam.Add("P_FSPGR_PRODGRTHRAT_ID", OracleDbType.Int32, ParameterDirection.Input, growthID);
                dyParam.Add("GROWTHRTCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GROWTHRTS.MAIN_PROCEDURE";

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
        public object GET_GROWTH_RATE_DETAILS_BY_DESCP(string growthDescp)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G3");
                dyParam.Add("P_FSPGR_GROWTH_DESCRIP", OracleDbType.Varchar2, ParameterDirection.Input, growthDescp);
                dyParam.Add("GROWTHRTCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GROWTHRTS.MAIN_PROCEDURE";

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
        public object GET_GROWTH_RATE_DETAILS_BY_PRODUCT(int productID, int growthRate)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "S");
                dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, productID);
                dyParam.Add("P_FSPGR_GROWTH_RATE", OracleDbType.Int32, ParameterDirection.Input, growthRate);

                dyParam.Add("GROWTHRTCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GROWTHRTS.MAIN_PROCEDURE";

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
        public object POST_GROWTH_RATES(GROWTH_RATE growth_rate)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                dyParam.Add("P_FSPGR_PRODGRTHRAT_ID", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_PRODGRTHRAT_ID);
                dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPM_PRODUCT_ID);
                dyParam.Add("P_FSPGR_GROWTH_DESCRIP", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_GROWTH_DESCRIP);
                dyParam.Add("P_FSPGR_GROWTH_SHORT_DESC", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_GROWTH_SHORT_DESC);
                dyParam.Add("P_FSPGR_GROWTH_RATE", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_GROWTH_RATE);
                dyParam.Add("P_FSPGR_EFFCTDATE_FROM", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_EFFCTDATE_FROM);
                dyParam.Add("P_FSPGR_EFFCTDATE_TO", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_EFFCTDATE_TO);
                dyParam.Add("P_FSPGR_REAL_RATE", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_REAL_RATE);
                dyParam.Add("P_FSPGR_INFLTCUM_CONTRYN", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_INFLTCUM_CONTRYN);
                dyParam.Add("P_FSPGR_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_STATUS);
                dyParam.Add("P_FSPGR_FLXFLD_DATE", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_FLXFLD_DATE);
                dyParam.Add("P_FSPGR_FLXFLD_VCHAR", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_FLXFLD_VCHAR);
                dyParam.Add("P_FSPGR_FLXFLD_NUMBER", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_FLXFLD_NUMBER);
                dyParam.Add("P_FSPGR_CRUSER", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_CRUSER);
                dyParam.Add("P_FSPGR_CRDATE", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_CRDATE);
                dyParam.Add("P_FSPGR_CHKUSER", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_CHKUSER);
                dyParam.Add("P_FSPGR_CHKDATE", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_CHKDATE);
                dyParam.Add("P_FSPGR_AUTHUSER", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_AUTHUSER);
                dyParam.Add("P_FSPGR_AUTHDATE", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_AUTHDATE);
                dyParam.Add("P_FSPGR_CNCLUSER", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_CNCLUSER);
                dyParam.Add("P_FSPGR_CNCLDATE", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_CNCLDATE);
                dyParam.Add("P_FSPGR_AUDIT_COMMENTS", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_AUDIT_COMMENTS);
                dyParam.Add("P_FSPGR_USER_IPADDR", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_USER_IPADDR);

                dyParam.Add("GROWTHRTCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GROWTHRTS.MAIN_PROCEDURE";

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
        public object UPDATE_GROWTH_RATES(GROWTH_RATE growth_rate)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                dyParam.Add("P_FSPGR_PRODGRTHRAT_ID", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_PRODGRTHRAT_ID);
                dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPM_PRODUCT_ID);
                dyParam.Add("P_FSPGR_GROWTH_DESCRIP", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_GROWTH_DESCRIP);
                dyParam.Add("P_FSPGR_GROWTH_SHORT_DESC", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_GROWTH_SHORT_DESC);
                dyParam.Add("P_FSPGR_GROWTH_RATE", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_GROWTH_RATE);
                dyParam.Add("P_FSPGR_EFFCTDATE_FROM", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_EFFCTDATE_FROM);
                dyParam.Add("P_FSPGR_EFFCTDATE_TO", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_EFFCTDATE_TO);
                dyParam.Add("P_FSPGR_REAL_RATE", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_REAL_RATE);
                dyParam.Add("P_FSPGR_INFLTCUM_CONTRYN", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_INFLTCUM_CONTRYN);
                dyParam.Add("P_FSPGR_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_STATUS);
                dyParam.Add("P_FSPGR_FLXFLD_DATE", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_FLXFLD_DATE);
                dyParam.Add("P_FSPGR_FLXFLD_VCHAR", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_FLXFLD_VCHAR);
                dyParam.Add("P_FSPGR_FLXFLD_NUMBER", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_FLXFLD_NUMBER);
                dyParam.Add("P_FSPGR_CRUSER", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_CRUSER);
                dyParam.Add("P_FSPGR_CRDATE", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_CRDATE);
                dyParam.Add("P_FSPGR_CHKUSER", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_CHKUSER);
                dyParam.Add("P_FSPGR_CHKDATE", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_CHKDATE);
                dyParam.Add("P_FSPGR_AUTHUSER", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_AUTHUSER);
                dyParam.Add("P_FSPGR_AUTHDATE", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_AUTHDATE);
                dyParam.Add("P_FSPGR_CNCLUSER", OracleDbType.Int32, ParameterDirection.Input, growth_rate.FSPGR_CNCLUSER);
                dyParam.Add("P_FSPGR_CNCLDATE", OracleDbType.Date, ParameterDirection.Input, growth_rate.FSPGR_CNCLDATE);
                dyParam.Add("P_FSPGR_AUDIT_COMMENTS", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_AUDIT_COMMENTS);
                dyParam.Add("P_FSPGR_USER_IPADDR", OracleDbType.Varchar2, ParameterDirection.Input, growth_rate.FSPGR_USER_IPADDR);

                dyParam.Add("GROWTHRTCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GROWTHRTS.MAIN_PROCEDURE";

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

        public IDbConnection GetConnection()
        {
            var connectionString = Configuration.GetSection("ConnectionStrings").GetSection("GlobalConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}
