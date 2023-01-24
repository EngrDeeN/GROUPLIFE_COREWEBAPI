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
    public class QuotCompyGrpDetlRepository : IQuotCompyGrpDetlRepository
    {
        IConfiguration configuration;
        public QuotCompyGrpDetlRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetQuotCompyGrpDetlDetails(int QuotCompyGrpDetlId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GC1");
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, QuotCompyGrpDetlId);
                    dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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

        public object PostQuotCompyGrpDetl(QuotCompyGrpDetl quotCompyGrpDetl)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "CI");
                    dyParam.Add("P_FGQG_COMPGRP_ID", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_COMPGRP_ID);
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQH_QUOTATHDR_ID);
                    dyParam.Add("P_FGQH_QTGRC_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQH_QTGRC_FSCD_DID);
                    dyParam.Add("P_FGQG_PREMIUM", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_PREMIUM);
                    dyParam.Add("P_FGQG_SUMASSRD_CRITRIA", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_SUMASSRD_CRITRIA);
                    dyParam.Add("P_FGQG_NOOFSALARY_AMT", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_NOOFSALARY_AMT);
                    dyParam.Add("P_FGQG_FIXED_AMOUNT", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_FIXED_AMOUNT);
                    dyParam.Add("P_FGQG_HEADCONT_TOTSALARY", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_HEADCONT_TOTSALARY);
                    dyParam.Add("P_FGQG_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, quotCompyGrpDetl.FGQG_STATUS);
                    dyParam.Add("P_FGQG_MIN_SUMASSURD", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_MIN_SUMASSURD);
                    dyParam.Add("P_FGQG_MAX_SUMASSURD", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_MAX_SUMASSURD);
                    dyParam.Add("P_FGQG_PER_FREQNCY", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_PER_FREQNCY);
                    dyParam.Add("P_FGQG_CRUSER", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_CRUSER);
                    dyParam.Add("P_FGQG_CRDATE", OracleDbType.Date, ParameterDirection.Input, quotCompyGrpDetl.FGQG_CRDATE);
                    dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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

        public object PutQuotCompyGrpDetl(QuotCompyGrpDetl quotCompyGrpDetl)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "CU");
                    dyParam.Add("P_FGQG_COMPGRP_ID", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_COMPGRP_ID);
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQH_QUOTATHDR_ID);
                    dyParam.Add("P_FGQH_QTGRC_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQH_QTGRC_FSCD_DID);
                    dyParam.Add("P_FGQG_PREMIUM", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_PREMIUM);
                    dyParam.Add("P_FGQG_SUMASSRD_CRITRIA", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_SUMASSRD_CRITRIA);
                    dyParam.Add("P_FGQG_NOOFSALARY_AMT", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_NOOFSALARY_AMT);
                    dyParam.Add("P_FGQG_FIXED_AMOUNT", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_FIXED_AMOUNT);
                    dyParam.Add("P_FGQG_HEADCONT_TOTSALARY", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_HEADCONT_TOTSALARY);
                    dyParam.Add("P_FGQG_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, quotCompyGrpDetl.FGQG_STATUS);
                    dyParam.Add("P_FGQG_MIN_SUMASSURD", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_MIN_SUMASSURD);
                    dyParam.Add("P_FGQG_MAX_SUMASSURD", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_MAX_SUMASSURD);
                    dyParam.Add("P_FGQG_PER_FREQNCY", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_PER_FREQNCY);
                    dyParam.Add("P_FGQG_CRUSER", OracleDbType.Int32, ParameterDirection.Input, quotCompyGrpDetl.FGQG_CRUSER);
                    dyParam.Add("P_FGQG_CRDATE", OracleDbType.Date, ParameterDirection.Input, quotCompyGrpDetl.FGQG_CRDATE);
                    dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_ENT_QUOTATIONGEN.MAIN_PROCEDURE";

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
