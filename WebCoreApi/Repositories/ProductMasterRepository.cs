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
    public class ProductMasterRepository : IProductMasterRepository
    {
        IConfiguration configuration;
        public ProductMasterRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object GetRiderDetails(int FSPM_PRODUCT_TYPE)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G3");
                    dyParam.Add("P_FSPM_PRODUCT_TYPE", OracleDbType.Int32, ParameterDirection.Input, FSPM_PRODUCT_TYPE);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object DeleteProduct(int ProductId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, ProductId);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object GetProductDetails(int ProductId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, ProductId);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object GetProductDetails(string ProductName)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "S");
                  //  dyParam.Add("P_FSPM_PRODUCT_CODE", OracleDbType.Varchar2, ParameterDirection.Input, ProductCode);
                    dyParam.Add("P_FSPM_PRODUCT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, ProductName);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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
        public object GET_POLICY_TO_QUOTATION(string QU_PO_Code)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "PI");
                dyParam.Add("P_POLICY_QUOTATION", OracleDbType.Varchar2, ParameterDirection.Input, QU_PO_Code);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_OPERATIONS.MAIN_PROCESS";

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
        public object GetProductList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object PostProduct(ProductMaster product)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_PRODUCT_ID);
                    dyParam.Add("P_FSPM_PRODUCT_CODE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCT_CODE);
                    dyParam.Add("P_FSPM_PRODUCT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCT_NAME);
                    dyParam.Add("P_FSPM_PRODUCT_DESP", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCT_DESP);
                    dyParam.Add("P_FSPM_PRODUCTION_LINE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCTION_LINE);
                    dyParam.Add("P_FSPM_PRODUCT_TYPE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_PRODUCT_TYPE);
                    dyParam.Add("P_FSPM_PRODUCT_CATEG", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCT_CATEG);
                    dyParam.Add("P_FSPM_PRODUCT_NATURE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCT_NATURE);
                    dyParam.Add("P_FSPM_PRODLIFE_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODLIFE_FLAG);
                    dyParam.Add("P_FSPM_PRODINDEX_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODINDEX_TYPE);
                    dyParam.Add("P_FSPM_PRODINTREST_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODINTREST_YN);
                    dyParam.Add("P_FSPM_1STAGEENT_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_1STAGEENT_MIN);
                    dyParam.Add("P_FSPM_1STAGEENT_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_1STAGEENT_MAX);
                    dyParam.Add("P_FSPM_2NDAGEENT_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_2NDAGEENT_MIN);
                    dyParam.Add("P_FSPM_2NDAGEENT_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_2NDAGEENT_MAX);
                    dyParam.Add("P_FSPM_1STAGEMAT_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_1STAGEMAT_MIN);
                    dyParam.Add("P_FSPM_1STAGEMAT_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_1STAGEMAT_MAX);
                    dyParam.Add("P_FSPM_2NDAGEMAT_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_2NDAGEMAT_MIN);
                    dyParam.Add("P_FSPM_2NDAGEMAT_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_2NDAGEMAT_MAX);
                    dyParam.Add("P_FSPM_SUMASSURD_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_SUMASSURD_MIN);
                    dyParam.Add("P_FSPM_SUMASSURD_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_SUMASSURD_MAX);
                    dyParam.Add("P_FSPM_BENEFTERM_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_BENEFTERM_MIN);
                    dyParam.Add("P_FSPM_BENEFTERM_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_BENEFTERM_MAX);
                    dyParam.Add("P_FSPM_PREMITERM_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_PREMITERM_MIN);
                    dyParam.Add("P_FSPM_PREMITERM_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_PREMITERM_MAX);
                    dyParam.Add("P_FSPM_NONSMOKER_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_NONSMOKER_YN);
                    dyParam.Add("P_FSPM_FEMALEADJ_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_FEMALEADJ_YN);
                    dyParam.Add("P_FSPM_INDXATION_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_INDXATION_YN);
                    dyParam.Add("P_FSPM_CASHVALU_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_CASHVALU_YN);
                    dyParam.Add("P_FSPM_TOPUPCONTRB_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_TOPUPCONTRB_YN);
                    dyParam.Add("P_FSPM_LOAN_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_LOAN_YN);
                    dyParam.Add("P_FSPM_PERSISTBONS_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PERSISTBONS_YN);
                    dyParam.Add("P_FSPM_START_DATE", OracleDbType.Date, ParameterDirection.Input, product.FSPM_START_DATE);
                    dyParam.Add("P_FSPM_END_DATE", OracleDbType.Date, ParameterDirection.Input, product.FSPM_END_DATE);
                    dyParam.Add("P_FSPM_GROUPSIZE_FROM", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GROUPSIZE_FROM);
                    dyParam.Add("P_FSPM_GROUPSIZE_TO", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GROUPSIZE_TO);
                    dyParam.Add("P_FSPM_GROUPSA_FROM", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GROUPSA_FROM);
                    dyParam.Add("P_FSPM_GROUPSA_TO", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GROUPSA_TO);
                    dyParam.Add("P_FSPM_UNIT_RATE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_UNIT_RATE);
                    dyParam.Add("P_FSPM_SERVICE_RATE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_SERVICE_RATE);
                    dyParam.Add("P_FSPM_PREMIUM_BREAKUP", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PREMIUM_BREAKUP);
                    dyParam.Add("P_FSPM_POLICYLVL_COMM", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_POLICYLVL_COMM);
                    dyParam.Add("P_FSPM_RENEWAL_ALLW", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_RENEWAL_ALLW);
                    dyParam.Add("P_FSPM_GRACE_PERIOD", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GRACE_PERIOD);
                    dyParam.Add("P_FSPM_GROUPLVL_COMM", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GROUPLVL_COMM);
                    dyParam.Add("P_FSPM_MAXFAMILY_MEMB", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAXFAMILY_MEMB);
                    dyParam.Add("P_FSPM_MAXCERTIFICATES", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAXCERTIFICATES);
                    dyParam.Add("P_FSPM_PERLIFE_SAVALID", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_PERLIFE_SAVALID);
                    dyParam.Add("P_FSPM_MIN_COMMISSION", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MIN_COMMISSION);
                    dyParam.Add("P_FSPM_MAX_COMMISSION", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAX_COMMISSION);
                    dyParam.Add("P_FSPM_MIN_EXPERIENCE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MIN_EXPERIENCE);
                    dyParam.Add("P_FSPM_MAX_EXPERIENCE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAX_EXPERIENCE);
                    dyParam.Add("P_FSPM_MIN_SVCFEE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MIN_SVCFEE);
                    dyParam.Add("P_FSPM_MAX_SVCFEE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAX_SVCFEE);
                    dyParam.Add("P_FSPM_MIN_WAKALAFEE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MIN_WAKALAFEE);
                    dyParam.Add("P_FSPM_MAX_WAKALAFEE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAX_WAKALAFEE);
                    dyParam.Add("P_FSPM_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_STATUS);
                    dyParam.Add("P_FSPM_STATUS_USER", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_STATUS_USER);
                    dyParam.Add("P_FSPM_STATUS_DATE", OracleDbType.Date, ParameterDirection.Input, product.FSPM_STATUS_DATE);
                    dyParam.Add("P_FSPM_CRUSER", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_CRUSER);
                    dyParam.Add("P_FSPM_CRDATE", OracleDbType.Date, ParameterDirection.Input, product.FSPM_CRDATE);
                    dyParam.Add("P_FSPM_STATU_FUND", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_STATU_FUND);
                
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object PutProduct(ProductMaster product)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_PRODUCT_ID);
                    dyParam.Add("P_FSPM_PRODUCT_CODE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCT_CODE);
                    dyParam.Add("P_FSPM_PRODUCT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCT_NAME);
                    dyParam.Add("P_FSPM_PRODUCT_DESP", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCT_DESP);
                    dyParam.Add("P_FSPM_PRODUCTION_LINE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCTION_LINE);
                    dyParam.Add("P_FSPM_PRODUCT_TYPE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_PRODUCT_TYPE);
                    dyParam.Add("P_FSPM_PRODUCT_CATEG", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCT_CATEG);
                    dyParam.Add("P_FSPM_PRODUCT_NATURE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODUCT_NATURE);
                    dyParam.Add("P_FSPM_PRODLIFE_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODLIFE_FLAG);
                    dyParam.Add("P_FSPM_PRODINDEX_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODINDEX_TYPE);
                    dyParam.Add("P_FSPM_PRODINTREST_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PRODINTREST_YN);
                    dyParam.Add("P_FSPM_1STAGEENT_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_1STAGEENT_MIN);
                    dyParam.Add("P_FSPM_1STAGEENT_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_1STAGEENT_MAX);
                    dyParam.Add("P_FSPM_2NDAGEENT_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_2NDAGEENT_MIN);
                    dyParam.Add("P_FSPM_2NDAGEENT_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_2NDAGEENT_MAX);
                    dyParam.Add("P_FSPM_1STAGEMAT_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_1STAGEMAT_MIN);
                    dyParam.Add("P_FSPM_1STAGEMAT_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_1STAGEMAT_MAX);
                    dyParam.Add("P_FSPM_2NDAGEMAT_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_2NDAGEMAT_MIN);
                    dyParam.Add("P_FSPM_2NDAGEMAT_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_2NDAGEMAT_MAX);
                    dyParam.Add("P_FSPM_SUMASSURD_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_SUMASSURD_MIN);
                    dyParam.Add("P_FSPM_SUMASSURD_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_SUMASSURD_MAX);
                    dyParam.Add("P_FSPM_BENEFTERM_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_BENEFTERM_MIN);
                    dyParam.Add("P_FSPM_BENEFTERM_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_BENEFTERM_MAX);
                    dyParam.Add("P_FSPM_PREMITERM_MIN", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_PREMITERM_MIN);
                    dyParam.Add("P_FSPM_PREMITERM_MAX", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_PREMITERM_MAX);
                    dyParam.Add("P_FSPM_NONSMOKER_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_NONSMOKER_YN);
                    dyParam.Add("P_FSPM_FEMALEADJ_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_FEMALEADJ_YN);
                    dyParam.Add("P_FSPM_INDXATION_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_INDXATION_YN);
                    dyParam.Add("P_FSPM_CASHVALU_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_CASHVALU_YN);
                    dyParam.Add("P_FSPM_TOPUPCONTRB_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_TOPUPCONTRB_YN);
                    dyParam.Add("P_FSPM_LOAN_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_LOAN_YN);
                    dyParam.Add("P_FSPM_PERSISTBONS_YN", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PERSISTBONS_YN);
                    dyParam.Add("P_FSPM_START_DATE", OracleDbType.Date, ParameterDirection.Input, product.FSPM_START_DATE);
                    dyParam.Add("P_FSPM_END_DATE", OracleDbType.Date, ParameterDirection.Input, product.FSPM_END_DATE);
                    dyParam.Add("P_FSPM_GROUPSIZE_FROM", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GROUPSIZE_FROM);
                    dyParam.Add("P_FSPM_GROUPSIZE_TO", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GROUPSIZE_TO);
                    dyParam.Add("P_FSPM_GROUPSA_FROM", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GROUPSA_FROM);
                    dyParam.Add("P_FSPM_GROUPSA_TO", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GROUPSA_TO);
                    dyParam.Add("P_FSPM_UNIT_RATE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_UNIT_RATE);
                    dyParam.Add("P_FSPM_SERVICE_RATE", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_SERVICE_RATE);
                    dyParam.Add("P_FSPM_PREMIUM_BREAKUP", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_PREMIUM_BREAKUP);
                    dyParam.Add("P_FSPM_POLICYLVL_COMM", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_POLICYLVL_COMM);
                    dyParam.Add("P_FSPM_RENEWAL_ALLW", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_RENEWAL_ALLW);
                    dyParam.Add("P_FSPM_GRACE_PERIOD", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GRACE_PERIOD);
                    dyParam.Add("P_FSPM_GROUPLVL_COMM", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_GROUPLVL_COMM);
                    dyParam.Add("P_FSPM_MAXFAMILY_MEMB", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAXFAMILY_MEMB);
                    dyParam.Add("P_FSPM_MAXCERTIFICATES", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAXCERTIFICATES);
                    dyParam.Add("P_FSPM_PERLIFE_SAVALID", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_PERLIFE_SAVALID);
                    dyParam.Add("P_FSPM_MIN_COMMISSION", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MIN_COMMISSION);
                    dyParam.Add("P_FSPM_MAX_COMMISSION", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAX_COMMISSION);
                    dyParam.Add("P_FSPM_MIN_EXPERIENCE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MIN_EXPERIENCE);
                    dyParam.Add("P_FSPM_MAX_EXPERIENCE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAX_EXPERIENCE);
                    dyParam.Add("P_FSPM_MIN_SVCFEE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MIN_SVCFEE);
                    dyParam.Add("P_FSPM_MAX_SVCFEE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAX_SVCFEE);
                    dyParam.Add("P_FSPM_MIN_WAKALAFEE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MIN_WAKALAFEE);
                    dyParam.Add("P_FSPM_MAX_WAKALAFEE", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_MAX_WAKALAFEE);
                    dyParam.Add("P_FSPM_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_STATUS);
                    dyParam.Add("P_FSPM_STATUS_USER", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_STATUS_USER);
                    dyParam.Add("P_FSPM_STATUS_DATE", OracleDbType.Date, ParameterDirection.Input, product.FSPM_STATUS_DATE);
                    dyParam.Add("P_FSPM_STATU_FUND", OracleDbType.Varchar2, ParameterDirection.Input, product.FSPM_STATU_FUND);
                    dyParam.Add("P_FSPM_CRUSER", OracleDbType.Int32, ParameterDirection.Input, product.FSPM_CRUSER);
                    dyParam.Add("P_FSPM_CRDATE", OracleDbType.Date, ParameterDirection.Input, product.FSPM_CRDATE);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object GetProductFCLDetails(int ProductId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GF1");
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, ProductId);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object PostProductFCL(ProductFCL productFcl)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "FI");
                    dyParam.Add("P_FSPF_PRODFCL_ID", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_PRODFCL_ID);
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPM_PRODUCT_ID);
                    dyParam.Add("P_FSPF_PRODFCL_DESCR", OracleDbType.Varchar2, ParameterDirection.Input, productFcl.FSPF_PRODFCL_DESCR);
                    dyParam.Add("P_FSPF_GRPSIZE_MIN", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_GRPSIZE_MIN);
                    dyParam.Add("P_FSPF_GRPSIZE_MAX", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_GRPSIZE_MAX);
                    dyParam.Add("P_FSPF_GRPENTAGE_MIN", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_GRPENTAGE_MIN);
                    dyParam.Add("P_FSPF_GRPENTAGE_MAX", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_GRPENTAGE_MAX);
                    dyParam.Add("P_FSPF_FACTAMT_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, productFcl.FSPF_FACTAMT_FLAG);
                    dyParam.Add("P_FSPF_FCL_FACTAMT", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_FCL_FACTAMT);
                    dyParam.Add("P_FSPF_FCL_AMT_MAX", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_FCL_AMT_MAX);
                    dyParam.Add("P_FSPF_CALC_INDX1", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_CALC_INDX1);
                    dyParam.Add("P_FSPF_CALC_INDX2", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_CALC_INDX2);
                    dyParam.Add("P_FSPF_MODAL_FACTR1", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_MODAL_FACTR1);
                    dyParam.Add("P_FSPF_MODAL_FACTR2", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_MODAL_FACTR2);
                    dyParam.Add("P_FSPF_DFF_DESCR1", OracleDbType.Varchar2, ParameterDirection.Input, productFcl.FSPF_DFF_DESCR1);
                    dyParam.Add("P_FSPF_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, productFcl.FSPF_STATUS);
                    dyParam.Add("P_FSPF_CRUSER", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_CRUSER);
                    dyParam.Add("P_FSPF_CRDATE", OracleDbType.Date, ParameterDirection.Input, productFcl.FSPF_CRDATE);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object PutProductFCL(ProductFCL productFcl)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "FU");
                    dyParam.Add("P_FSPF_PRODFCL_ID", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_PRODFCL_ID);
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPM_PRODUCT_ID);
                    dyParam.Add("P_FSPF_PRODFCL_DESCR", OracleDbType.Varchar2, ParameterDirection.Input, productFcl.FSPF_PRODFCL_DESCR);
                    dyParam.Add("P_FSPF_GRPSIZE_MIN", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_GRPSIZE_MIN);
                    dyParam.Add("P_FSPF_GRPSIZE_MAX", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_GRPSIZE_MAX);
                    dyParam.Add("P_FSPF_GRPENTAGE_MIN", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_GRPENTAGE_MIN);
                    dyParam.Add("P_FSPF_GRPENTAGE_MAX", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_GRPENTAGE_MAX);
                    dyParam.Add("P_FSPF_FACTAMT_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, productFcl.FSPF_FACTAMT_FLAG);
                    dyParam.Add("P_FSPF_FCL_FACTAMT", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_FCL_FACTAMT);
                    dyParam.Add("P_FSPF_FCL_AMT_MAX", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_FCL_AMT_MAX);
                    dyParam.Add("P_FSPF_CALC_INDX1", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_CALC_INDX1);
                    dyParam.Add("P_FSPF_CALC_INDX2", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_CALC_INDX2);
                    dyParam.Add("P_FSPF_MODAL_FACTR1", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_MODAL_FACTR1);
                    dyParam.Add("P_FSPF_MODAL_FACTR2", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_MODAL_FACTR2);
                    dyParam.Add("P_FSPF_DFF_DESCR1", OracleDbType.Varchar2, ParameterDirection.Input, productFcl.FSPF_DFF_DESCR1);
                    dyParam.Add("P_FSPF_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, productFcl.FSPF_STATUS);
                    dyParam.Add("P_FSPF_CRUSER", OracleDbType.Int32, ParameterDirection.Input, productFcl.FSPF_CRUSER);
                    dyParam.Add("P_FSPF_CRDATE", OracleDbType.Date, ParameterDirection.Input, productFcl.FSPF_CRDATE);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object GetProdRelationDtls(int ProductId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GR1");
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, ProductId);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object PostProdRelationDtls(ProductRelationDtl prodRelationDtl)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "RI");
                    dyParam.Add("P_FSPR_PRODRELTN_ID", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_PRODRELTN_ID);
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPM_PRODUCT_ID);
                    dyParam.Add("P_FSPR_RELTN_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_RELTN_FSCD_DID);
                    dyParam.Add("P_FSPR_PRODRELTN_DESCR", OracleDbType.Varchar2, ParameterDirection.Input, prodRelationDtl.FSPR_PRODRELTN_DESCR);
                    dyParam.Add("P_FSPR_RELTNCOUNT_FRM", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_RELTNCOUNT_FRM);
                    dyParam.Add("P_FSPR_RELTNCOUNT_TO", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_RELTNCOUNT_TO);
                    dyParam.Add("P_FSPR_RELTYP_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, prodRelationDtl.FSPR_RELTYP_FLAG);
                    dyParam.Add("P_FSPR_PREMIUMFACTOR", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_PREMIUMFACTOR);
                    dyParam.Add("P_FSPR_CALC_INDX1", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_CALC_INDX1);
                    dyParam.Add("P_FSPR_CALC_INDX2", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_CALC_INDX2);
                    dyParam.Add("P_FSPR_MODAL_FACTR1", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_MODAL_FACTR1);
                    dyParam.Add("P_FSPR_MODAL_FACTR2", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_MODAL_FACTR2);
                    dyParam.Add("P_FSPR_DFF_DESCR1", OracleDbType.Varchar2, ParameterDirection.Input, prodRelationDtl.FSPR_DFF_DESCR1);
                    dyParam.Add("P_FSPR_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, prodRelationDtl.FSPR_STATUS);
                    dyParam.Add("P_FSPR_CRUSER", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_CRUSER);
                    dyParam.Add("P_FSPR_CRDATE", OracleDbType.Date, ParameterDirection.Input, prodRelationDtl.FSPR_CRDATE);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public object PutProdRelationDtls(ProductRelationDtl prodRelationDtl)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "RU");
                    dyParam.Add("P_FSPR_PRODRELTN_ID", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_PRODRELTN_ID);
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPM_PRODUCT_ID);
                    dyParam.Add("P_FSPR_RELTN_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_RELTN_FSCD_DID);
                    dyParam.Add("P_FSPR_PRODRELTN_DESCR", OracleDbType.Varchar2, ParameterDirection.Input, prodRelationDtl.FSPR_PRODRELTN_DESCR);
                    dyParam.Add("P_FSPR_RELTNCOUNT_FRM", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_RELTNCOUNT_FRM);
                    dyParam.Add("P_FSPR_RELTNCOUNT_TO", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_RELTNCOUNT_TO);
                    dyParam.Add("P_FSPR_RELTYP_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, prodRelationDtl.FSPR_RELTYP_FLAG);
                    dyParam.Add("P_FSPR_PREMIUMFACTOR", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_PREMIUMFACTOR);
                    dyParam.Add("P_FSPR_CALC_INDX1", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_CALC_INDX1);
                    dyParam.Add("P_FSPR_CALC_INDX2", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_CALC_INDX2);
                    dyParam.Add("P_FSPR_MODAL_FACTR1", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_MODAL_FACTR1);
                    dyParam.Add("P_FSPR_MODAL_FACTR2", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_MODAL_FACTR2);
                    dyParam.Add("P_FSPR_DFF_DESCR1", OracleDbType.Varchar2, ParameterDirection.Input, prodRelationDtl.FSPR_DFF_DESCR1);
                    dyParam.Add("P_FSPR_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, prodRelationDtl.FSPR_STATUS);
                    dyParam.Add("P_FSPR_CRUSER", OracleDbType.Int32, ParameterDirection.Input, prodRelationDtl.FSPR_CRUSER);
                    dyParam.Add("P_FSPR_CRDATE", OracleDbType.Date, ParameterDirection.Input, prodRelationDtl.FSPR_CRDATE);
                    dyParam.Add("PRODUCTMCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_PRODUCTMASTER.MAIN_PROCEDURE";

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

        public System.Data.IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("GlobalConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}