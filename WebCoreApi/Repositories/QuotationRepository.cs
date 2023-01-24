using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.DAORespositories;
using WebCoreApi.Models;
using WebCoreApi.Oracle;

namespace WebCoreApi.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        IConfiguration configuration;
        public QuotationRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object Get_Quotat_Plan_Dtls(string QuotationCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GPP");
                    dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, QuotationCode);
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


        public object GetQuotationDetails(string QuotationId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, QuotationId);
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

        public object PostQuotations(QuotationHDR quotation)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_QUOTATHDR_ID);
                    dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATHDR_CODE);
                    dyParam.Add("P_FGQH_PFREQ_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_PFREQ_FSCD_DID);
                    dyParam.Add("P_FGQH_QUOTATION_DATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATION_DATE);
                    dyParam.Add("P_FGQH_QUOTATION_REQDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATION_REQDATE);
                    dyParam.Add("P_FGQH_QUOTATION_EXPDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATION_EXPDATE);
                    dyParam.Add("P_FGQH_QUOTATION_CONFIRM", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATION_CONFIRM);
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, quotation.FSPM_PRODUCT_ID);
                    dyParam.Add("P_FSLO_LOCATION_ID", OracleDbType.Int32, ParameterDirection.Input, quotation.FSLO_LOCATION_ID);
                    dyParam.Add("P_FSLO_LOCATION_ID2", OracleDbType.Int32, ParameterDirection.Input, quotation.FSLO_LOCATION_ID2);
                    dyParam.Add("P_FGQH_QUOTATION_INTRONAME", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATION_INTRONAME);
                    dyParam.Add("P_FGQH_QUOTATION_TOTALEMP", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_QUOTATION_TOTALEMP);
                    dyParam.Add("P_FGQH_QUOTATION_PEREMP", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_QUOTATION_PEREMP);
                    dyParam.Add("P_FGQH_QUOTATION_CONTNAME", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATION_CONTNAME);
                    dyParam.Add("P_FGQH_QUOTATION_PERSNAME", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATION_PERSNAME);
                    dyParam.Add("P_FGQH_QUOTATION_SVCTAX_YN", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATION_SVCTAX_YN);
                    dyParam.Add("P_FGQH_QUOTATION_SVCTAX_PERC", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_QUOTATION_SVCTAX_PERC); 
                    dyParam.Add("P_FSCR_CURRENCY_CODE", OracleDbType.Int32, ParameterDirection.Input, quotation.FSCR_CURRENCY_CODE);
                    dyParam.Add("P_FGQH_PYMET_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_PYMET_FSCD_DID);
                    dyParam.Add("P_FGQH_QUOTATCOMP_TERM", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_TERM);
                    dyParam.Add("P_FGQH_QUOTATCOMP_POLSTDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_POLSTDATE);
                    dyParam.Add("P_FGQH_QUOTATCOMP_POLENDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_POLENDATE);
                    dyParam.Add("P_FGQH_QUOTATCOMP_AGECALCDT", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_AGECALCDT);
                    dyParam.Add("P_FGQH_QUOTATCOMP_FCLTKOVR_YN", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_FCLTKOVR_YN);
                    dyParam.Add("P_FGQH_QUOTATCOMP_FCLTKOVR_DT", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_FCLTKOVR_DT);
                    dyParam.Add("P_FSLO_LOCATION_ID3", OracleDbType.Int32, ParameterDirection.Input, quotation.FSLO_LOCATION_ID3);
                    dyParam.Add("P_FSLO_LOCATION_ID4", OracleDbType.Int32, ParameterDirection.Input, quotation.FSLO_LOCATION_ID4);
                    dyParam.Add("P_FGQH_QUOTATCOMP_POLBKDATD_YN", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_POLBKDATD_YN);
                    dyParam.Add("P_FGQH_QUOTATCOMP_POLBAKDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_POLBAKDATE);
                    dyParam.Add("P_FGQH_REASON_BKDATE", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_REASON_BKDATE);
                    dyParam.Add("P_FGQH_QUOTATCOMP_HEADCOUNT_YN", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_HEADCOUNT_YN);
                    dyParam.Add("P_FGQH_QUOTATCOMP_HDCNT_CRTRIA", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_HDCNT_CRTRIA);
                    dyParam.Add("P_FGQH_WAKALA_PERC", OracleDbType.Decimal, ParameterDirection.Input, quotation.FGQH_WAKALA_PERC);
                    dyParam.Add("P_FGQH_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_STATUS); 
                    dyParam.Add("P_FGQH_CRUSER", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_CRUSER);
                    dyParam.Add("P_FGQH_CRDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_CRDATE);
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

        public object PutQuotations(QuotationHDR quotation)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_QUOTATHDR_ID);
                    dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATHDR_CODE);
                    dyParam.Add("P_FGQH_PFREQ_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_PFREQ_FSCD_DID);
                    dyParam.Add("P_FGQH_QUOTATION_DATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATION_DATE);
                    dyParam.Add("P_FGQH_QUOTATION_REQDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATION_REQDATE);
                    dyParam.Add("P_FGQH_QUOTATION_EXPDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATION_EXPDATE);
                    dyParam.Add("P_FGQH_QUOTATION_CONFIRM", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATION_CONFIRM);
                    dyParam.Add("P_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, quotation.FSPM_PRODUCT_ID);
                    dyParam.Add("P_FSLO_LOCATION_ID", OracleDbType.Int32, ParameterDirection.Input, quotation.FSLO_LOCATION_ID);
                    dyParam.Add("P_FSLO_LOCATION_ID2", OracleDbType.Int32, ParameterDirection.Input, quotation.FSLO_LOCATION_ID2);
                    dyParam.Add("P_FGQH_QUOTATION_INTRONAME", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATION_INTRONAME);
                    dyParam.Add("P_FGQH_QUOTATION_TOTALEMP", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_QUOTATION_TOTALEMP);
                    dyParam.Add("P_FGQH_QUOTATION_PEREMP", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_QUOTATION_PEREMP);
                    dyParam.Add("P_FGQH_QUOTATION_CONTNAME", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATION_CONTNAME);
                    dyParam.Add("P_FGQH_QUOTATION_PERSNAME", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATION_PERSNAME);
                    dyParam.Add("P_FGQH_QUOTATION_SVCTAX_YN", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATION_SVCTAX_YN);
                    dyParam.Add("P_FGQH_QUOTATION_SVCTAX_PERC", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_QUOTATION_SVCTAX_PERC);
                    dyParam.Add("P_FSCR_CURRENCY_CODE", OracleDbType.Int32, ParameterDirection.Input, quotation.FSCR_CURRENCY_CODE);
                    dyParam.Add("P_FGQH_PYMET_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_PYMET_FSCD_DID);
                    dyParam.Add("P_FGQH_QUOTATCOMP_TERM", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_TERM);
                    dyParam.Add("P_FGQH_QUOTATCOMP_POLSTDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_POLSTDATE);
                    dyParam.Add("P_FGQH_QUOTATCOMP_POLENDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_POLENDATE);
                    dyParam.Add("P_FGQH_QUOTATCOMP_AGECALCDT", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_AGECALCDT);
                    dyParam.Add("P_FGQH_QUOTATCOMP_FCLTKOVR_YN", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_FCLTKOVR_YN);
                    dyParam.Add("P_FGQH_QUOTATCOMP_FCLTKOVR_DT", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_FCLTKOVR_DT);
                    dyParam.Add("P_FSLO_LOCATION_ID3", OracleDbType.Int32, ParameterDirection.Input, quotation.FSLO_LOCATION_ID3);
                    dyParam.Add("P_FSLO_LOCATION_ID4", OracleDbType.Int32, ParameterDirection.Input, quotation.FSLO_LOCATION_ID4);
                    dyParam.Add("P_FGQH_QUOTATCOMP_POLBKDATD_YN", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_POLBKDATD_YN);
                    dyParam.Add("P_FGQH_QUOTATCOMP_POLBAKDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_POLBAKDATE);
                    dyParam.Add("P_FGQH_REASON_BKDATE", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_REASON_BKDATE);
                    dyParam.Add("P_FGQH_QUOTATCOMP_HEADCOUNT_YN", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_HEADCOUNT_YN);
                    dyParam.Add("P_FGQH_QUOTATCOMP_HDCNT_CRTRIA", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_QUOTATCOMP_HDCNT_CRTRIA);
                    dyParam.Add("P_FGQH_WAKALA_PERC", OracleDbType.Decimal, ParameterDirection.Input, quotation.FGQH_WAKALA_PERC);
                    dyParam.Add("P_FGQH_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, quotation.FGQH_STATUS);
                    dyParam.Add("P_FGQH_CRUSER", OracleDbType.Int32, ParameterDirection.Input, quotation.FGQH_CRUSER);
                    dyParam.Add("P_FGQH_CRDATE", OracleDbType.Date, ParameterDirection.Input, quotation.FGQH_CRDATE);
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

        public object DeleteQuotations(int QuotationId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FGQH_QUOTATHDR_CODE", OracleDbType.Int32, ParameterDirection.Input, QuotationId);
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


        public object GetAgentList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GA2");
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
        public object GetQuotationList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
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



        //public object GetQuotaRiderDetails(int QUOTATION_ID)
        //{
        //    object result = null;
        //    try
        //    {
        //        var dyParam = new OracleDynamicParameters();
        //            dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "R1");
        //            dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Output, QUOTATION_ID);
        //            dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

        //        var conn = this.GetConnection();
        //        if (conn.State == ConnectionState.Closed)
        //        {
        //            conn.Open();
        //        }

        //        if (conn.State == ConnectionState.Open)
        //        {
        //           var query = "ACT_GTS_QUOTATIONGEN_EVRIDR.MAIN_PROCEDURE";

        //            result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //        result = "Failed to load list or operation " + ex.Message;
        //    }

        //    return result;
        //}


        public object GetQuotaRiderDetails(int QUOTATION_ID, int FGQG_COMPGRP_ID)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "R1");
                dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Varchar2, ParameterDirection.Input, QUOTATION_ID);
                dyParam.Add("P_FGQG_COMPGRP_ID", OracleDbType.Varchar2, ParameterDirection.Input, FGQG_COMPGRP_ID);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_QUOTATIONGEN_EVRIDR.MAIN_PROCEDURE";

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

        public object PostQuotaRider(Quotation_Rider Quotation_Rider)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "RI");
                    dyParam.Add("p_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQH_QUOTATHDR_ID);
                    dyParam.Add("P_FGQR_QUOTRIDR_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_QUOTRIDR_ID);
                    dyParam.Add("p_FGQG_COMPGRP_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider._FGQG_COMPGRP_ID);
                    dyParam.Add("p_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FSPM_PRODUCT_ID);
                    dyParam.Add("p_FGQE_QUOTEVNT_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQE_QUOTEVNT_ID);
                    dyParam.Add("p_FGQR_RIDERST_DATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Rider.FGQR_RIDERST_DATE);
                    dyParam.Add("p_FGQR_RIDEREN_DATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Rider.FGQR_RIDEREN_DATE);
                    dyParam.Add("p_FGQR_PFREQ_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_PFREQ_FSCD_DID);
                    dyParam.Add("p_FGQR_PAYBLE_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, Quotation_Rider.FGQR_PAYBLE_FLAG);
                    dyParam.Add("p_FGQR_LOADING_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, Quotation_Rider.FGQR_LOADING_TYPE);
                    dyParam.Add("p_FGQR_LOADING_VALUE", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_LOADING_VALUE);
                    dyParam.Add("p_FGQR_RIDER_CONTRIB", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_RIDER_CONTRIB);
                    dyParam.Add("p_FGQR_NET_CONTRIB", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_NET_CONTRIB);
                    dyParam.Add("p_FGQR_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, Quotation_Rider.FGQR_STATUS);
                    dyParam.Add("p_FGQR_CRUSER", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_CRUSER);
                    dyParam.Add("p_FGQR_CRDATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Rider.FGQR_CRDATE);
                    dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_QUOTATIONGEN_EVRIDR.MAIN_PROCEDURE";

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

        public object PutQuotaRider(Quotation_Rider Quotation_Rider)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "RU");
                    dyParam.Add("p_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQH_QUOTATHDR_ID);
                    dyParam.Add("P_FGQR_QUOTRIDR_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_QUOTRIDR_ID);
                    dyParam.Add("p_FGQG_COMPGRP_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider._FGQG_COMPGRP_ID);
                    dyParam.Add("p_FSPM_PRODUCT_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FSPM_PRODUCT_ID);
                    dyParam.Add("p_FGQE_QUOTEVNT_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQE_QUOTEVNT_ID);
                    dyParam.Add("p_FGQR_RIDERST_DATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Rider.FGQR_RIDERST_DATE);
                    dyParam.Add("p_FGQR_RIDEREN_DATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Rider.FGQR_RIDEREN_DATE);
                    dyParam.Add("p_FGQR_PFREQ_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_PFREQ_FSCD_DID);
                    dyParam.Add("p_FGQR_PAYBLE_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, Quotation_Rider.FGQR_PAYBLE_FLAG);
                    dyParam.Add("p_FGQR_LOADING_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, Quotation_Rider.FGQR_LOADING_TYPE);
                    dyParam.Add("p_FGQR_LOADING_VALUE", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_LOADING_VALUE);
                    dyParam.Add("p_FGQR_RIDER_CONTRIB", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_RIDER_CONTRIB);
                    dyParam.Add("p_FGQR_NET_CONTRIB", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_NET_CONTRIB);
                    dyParam.Add("p_FGQR_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, Quotation_Rider.FGQR_STATUS);
                    dyParam.Add("p_FGQR_CRUSER", OracleDbType.Int32, ParameterDirection.Input, Quotation_Rider.FGQR_CRUSER);
                    dyParam.Add("p_FGQR_CRDATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Rider.FGQR_CRDATE);
                dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_QUOTATIONGEN_EVRIDR.MAIN_PROCEDURE";

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
        public object GetQuotaEventList(int ListCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GC3");
                    dyParam.Add("P_FSCE_COVREVENT_ID", OracleDbType.Int32, ParameterDirection.Input, ListCode);
                    dyParam.Add("GLOBPARAMSCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_BAS_GLOBPARAMS.MAIN_PROCEDURE";

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

        public object GetQuotaEventDetails(int QUOTATION_ID, int FGQG_COMPGRP_ID)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "E1");
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Varchar2, ParameterDirection.Input, QUOTATION_ID);
                    dyParam.Add("P_FGQG_COMPGRP_ID", OracleDbType.Int32, ParameterDirection.Input, FGQG_COMPGRP_ID);
                    dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_QUOTATIONGEN_EVRIDR.MAIN_PROCEDURE";

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

        public object PutQuotaEvent(Quotation_Event Quotation_Event)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "EU");
                    dyParam.Add("P_FGQE_QUOTEVNT_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_QUOTEVNT_ID);
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQH_QUOTATHDR_ID);
                    dyParam.Add("P_FGQG_COMPGRP_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event._FGQG_COMPGRP_ID);
                    dyParam.Add("P_FSCE_COVREVENT_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FSCE_COVREVENT_ID);
                    dyParam.Add("P_FGQE_EVENTST_DATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Event.FGQE_EVENTST_DATE);
                    dyParam.Add("P_FGQE_EVENTEN_DATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Event.FGQE_EVENTEN_DATE);
                    dyParam.Add("P_FGQE_PFREQ_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_PFREQ_FSCD_DID);
                    dyParam.Add("P_FGQE_PAYBLE_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, Quotation_Event.FGQE_PAYBLE_FLAG);
                    dyParam.Add("P_FGQE_EVNT_CONTRIB", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_EVNT_CONTRIB);
                    dyParam.Add("P_FGQE_EVNT_LOADING", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_EVNT_LOADING);
                    dyParam.Add("P_FGQE_NET_CONTRIB", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_NET_CONTRIB);
                    dyParam.Add("P_FGQE_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, Quotation_Event.FGQE_STATUS);
                    dyParam.Add("P_FGQE_CRUSER", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_CRUSER);
                    dyParam.Add("P_FGQE_CRDATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Event.FGQE_CRDATE);
                    dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_QUOTATIONGEN_EVRIDR.MAIN_PROCEDURE";

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

        public object PostQuotaEvent(Quotation_Event Quotation_Event)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "EI");
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQH_QUOTATHDR_ID);
                    dyParam.Add("P_FGQE_QUOTEVNT_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_QUOTEVNT_ID);
                    dyParam.Add("P_FGQG_COMPGRP_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event._FGQG_COMPGRP_ID);
                    dyParam.Add("P_FSCE_COVREVENT_ID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FSCE_COVREVENT_ID);
                    dyParam.Add("P_FGQE_EVENTST_DATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Event.FGQE_EVENTST_DATE);
                    dyParam.Add("P_FGQE_EVENTEN_DATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Event.FGQE_EVENTEN_DATE);
                    dyParam.Add("P_FGQE_PFREQ_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_PFREQ_FSCD_DID);
                    dyParam.Add("P_FGQE_PAYBLE_FLAG", OracleDbType.Varchar2, ParameterDirection.Input, Quotation_Event.FGQE_PAYBLE_FLAG);
                    dyParam.Add("P_FGQE_EVNT_CONTRIB", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_EVNT_CONTRIB);
                    dyParam.Add("P_FGQE_EVNT_LOADING", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_EVNT_LOADING);
                    dyParam.Add("P_FGQE_NET_CONTRIB", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_NET_CONTRIB);
                    dyParam.Add("P_FGQE_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, Quotation_Event.FGQE_STATUS);
                    dyParam.Add("P_FGQE_CRUSER", OracleDbType.Int32, ParameterDirection.Input, Quotation_Event.FGQE_CRUSER);
                    dyParam.Add("P_FGQE_CRDATE", OracleDbType.Date, ParameterDirection.Input, Quotation_Event.FGQE_CRDATE);
                    dyParam.Add("QUOTATIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GTS_QUOTATIONGEN_EVRIDR.MAIN_PROCEDURE";

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
