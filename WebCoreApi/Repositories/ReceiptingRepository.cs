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
    public class ReceiptingRepository : IReceiptingRepository
    {
        IConfiguration configuration;
        public ReceiptingRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetReceiptingDetails(int ReceiptId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FSSC_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, ReceiptId);
                    dyParam.Add("FINANCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_FIN_OPERATIONS.MAIN_PROCEDURE";

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

        public object GetReceiptingDetailsByQuotation(string QuotationCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G3");
                    dyParam.Add("P_QuotationCode", OracleDbType.Int32, ParameterDirection.Input, QuotationCode);
                    dyParam.Add("FINANCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_FIN_OPERATIONS.MAIN_PROCEDURE";

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

        public object PostReceipting(Receipting Receipting)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "TR");
                    dyParam.Add("p_ftpr_rcpt_valudate", OracleDbType.Date, ParameterDirection.Input, Receipting.FTPR_RCPT_VALUDATE);
                    dyParam.Add("p_ftpr_rcpt_refno1", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.ftpr_rcpt_refno1);
                    dyParam.Add("P_FTPR_RECEIPT_TYPE", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_RECEIPT_TYPE);
                    dyParam.Add("p_ftpr_pymet_fscd_did", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_PYMET_FSCD_DID);
                    dyParam.Add("p_ftpr_instr_no", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_INSTR_NO);
                    dyParam.Add("p_ftpr_instr_date", OracleDbType.Date, ParameterDirection.Input, Receipting.FTPR_INSTR_DATE);
                    dyParam.Add("p_fscr_currency_code", OracleDbType.Int32, ParameterDirection.Input, Receipting.FSCR_CURRENCY_CODE);
                    dyParam.Add("p_FSBK_BANK_ID", OracleDbType.Int32, ParameterDirection.Input, Receipting.FSBK_BANK_ID);
                    dyParam.Add("p_ftpr_instr_bnk_brchname", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_INSTR_BNK_BRCHNAME);
                    dyParam.Add("P_FTPR_ACCOUNT_TYPE", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_ACCOUNT_TYPE);
                    dyParam.Add("P_FTPR_ACCOUNT_TITLE", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_ACCOUNT_TITLE);
                    dyParam.Add("P_FTPR_ACCOUNT_NO", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_ACCOUNT_NO);
                    dyParam.Add("p_ftpr_coll_amount", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_COLL_AMOUNT);
                    dyParam.Add("p_ftpr_due_amount", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_DUE_AMOUNT);
                    dyParam.Add("p_ftpr_approvd_amt", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_APPROVD_AMT);
                    dyParam.Add("P_FTPR_RCPT_POSTD_YN", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_RCPT_POSTD_YN);
                    //dyParam.Add("P_FGQH_WITHRCPT_YN", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_RCPT_POSTD_YN);
                    dyParam.Add("P_FTPR_CRUSER", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_CRUSER);
                    dyParam.Add("P_FTPR_CRDATE", OracleDbType.Date, ParameterDirection.Input, Receipting.FTPR_CRDATE);
                    dyParam.Add("FINANCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_FIN_OPERATIONS.MAIN_PROCEDURE";

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

        public object PutReceipting(Receipting Receipting)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "TP");
                    dyParam.Add("p_ftpr_rcpt_valudate", OracleDbType.Date, ParameterDirection.Input, Receipting.FTPR_RCPT_VALUDATE);
                    dyParam.Add("P_FTPR_RECEIPT_TYPE", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_RECEIPT_TYPE);
                    dyParam.Add("p_ftpr_pymet_fscd_did", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_PYMET_FSCD_DID);
                    dyParam.Add("p_ftpr_instr_no", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_INSTR_NO);
                    dyParam.Add("p_ftpr_instr_date", OracleDbType.Date, ParameterDirection.Input, Receipting.FTPR_INSTR_DATE);
                    dyParam.Add("p_fscr_currency_code", OracleDbType.Int32, ParameterDirection.Input, Receipting.FSCR_CURRENCY_CODE);
                    dyParam.Add("p_FSBK_BANK_ID", OracleDbType.Int32, ParameterDirection.Input, Receipting.FSBK_BANK_ID);
                    dyParam.Add("p_ftpr_instr_bnk_brchname", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_INSTR_BNK_BRCHNAME);
                    dyParam.Add("P_FTPR_ACCOUNT_TYPE", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_ACCOUNT_TYPE);
                    dyParam.Add("P_FTPR_ACCOUNT_TITLE", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_ACCOUNT_TITLE);
                    dyParam.Add("P_FTPR_ACCOUNT_NO", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_ACCOUNT_NO);
                    dyParam.Add("p_ftpr_coll_amount", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_COLL_AMOUNT);
                    dyParam.Add("p_ftpr_due_amount", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_DUE_AMOUNT);
                    dyParam.Add("p_ftpr_approvd_amt", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_APPROVD_AMT);
                    dyParam.Add("P_FTPR_CRUSER", OracleDbType.Int32, ParameterDirection.Input, Receipting.FTPR_CRUSER);
                    dyParam.Add("P_FTPR_CRDATE", OracleDbType.Date, ParameterDirection.Input, Receipting.FTPR_CRDATE);
                    dyParam.Add("p_ftpr_rcpt_refno1", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.ftpr_rcpt_refno1);
                    dyParam.Add("P_FTPR_GLVOUCHR_NO", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_GLVOUCHR_NO);
                    dyParam.Add("P_FTPR_RCPT_POSTD_YN", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_RCPT_POSTD_YN);
                    //dyParam.Add("P_FGQH_WITHRCPT_YN", OracleDbType.Varchar2, ParameterDirection.Input, Receipting.FTPR_RCPT_POSTD_YN);
                    dyParam.Add("FINANCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_FIN_OPERATIONS.MAIN_PROCEDURE";

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

        public object DeleteReceipting(int ReceiptId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, ReceiptId);
                    dyParam.Add("FINANCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_FIN_OPERATIONS.MAIN_PROCEDURE";

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

        public object GetReceiptingList()
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
                    var query = "ACT_GTS_FIN_OPERATIONS.MAIN_PROCEDURE";

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


        public object Get_Bank_List()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "BL");
                    dyParam.Add("FINANCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_FIN_OPERATIONS.MAIN_PROCEDURE";

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

        public object GET_VOUCHER_LIST()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "VL");
                dyParam.Add("FINANCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_FIN_OPERATIONS.MAIN_PROCEDURE";

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

        public object Get_Valid_Quotation_List(string Document_Id, string VoucherId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                string[] Voucher = VoucherId.Split('-');
                string Voucher_No = Voucher[0];                             //Edit by Shizra
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "QL");
                dyParam.Add("P_DOCUMENT_ID", OracleDbType.Varchar2, ParameterDirection.Input, Document_Id);
                dyParam.Add("P_FTPR_GLVOUCHR_NO", OracleDbType.Varchar2, ParameterDirection.Input, Voucher_No);
                dyParam.Add("FINANCECURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_FIN_OPERATIONS.MAIN_PROCEDURE";

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
