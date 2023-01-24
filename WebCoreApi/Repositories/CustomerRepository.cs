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
    public class CustomerRepository : ICustomerRepository
    {
        IConfiguration configuration;
        public CustomerRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetCustomerDetails(int customerCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerCode);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PostCustomer(Customer customer)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSNT_IDENTYPE_ID", OracleDbType.Int32, ParameterDirection.Input, customer.FSNT_IDENTYPE_ID);
                    dyParam.Add("P_FSCU_IDENTIFICATION_NO", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_IDENTIFICATION_NO);
                    dyParam.Add("P_FSCU_IDENTISSUE_DATE", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_IDENTISSUE_DATE);
                    dyParam.Add("P_FSCU_IDENTIEXPIRY_DATE", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_IDENTIEXPIRY_DATE);
                    dyParam.Add("P_FSCU_GROUP_CODE", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_GROUP_CODE);
                    dyParam.Add("P_FSCU_FAMILY_ID", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_FAMILY_ID);
                    dyParam.Add("P_FSCU_CLIENT_TYPE", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CLIENT_TYPE);
                    dyParam.Add("P_FSCU_TITLE_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_TITLE_FSCD_DID);
                    dyParam.Add("P_FSCU_FULL_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_FULL_NAME);
                    dyParam.Add("P_FSCU_FIRST_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_FIRST_NAME);
                    dyParam.Add("P_FSCU_MIDDLE_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_MIDDLE_NAME);
                    dyParam.Add("P_FSCU_LAST_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_LAST_NAME);
                    dyParam.Add("P_FSCU_FATHUSB_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_FATHUSB_NAME);
                    dyParam.Add("P_FSCU_MOTHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_MOTHER_NAME);
                    dyParam.Add("P_FSCU_RELTN_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_RELTN_FSCD_DID);
                    dyParam.Add("P_FSCU_GENDR_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_GENDR_FSCD_DID);
                    dyParam.Add("P_FSCU_MRTST_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_MRTST_FSCD_DID);
                    dyParam.Add("P_FSCU_NOOFDEPENDENTS", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_NOOFDEPENDENTS);
                    dyParam.Add("P_FSCU_CUOCP_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CUOCP_FSCD_DID);
                    dyParam.Add("P_FSCU_WORKEXP_YEARS", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_WORKEXP_YEARS);
                    dyParam.Add("P_FSCU_DATEOFBIRTH", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_DATEOFBIRTH);
                    dyParam.Add("P_FSCU_BIRTH_COUNTRY", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_BIRTH_COUNTRY);
                    dyParam.Add("P_FSCU_IDENTIFICTYPE2", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_IDENTIFICTYPE2);
                    dyParam.Add("P_FSCU_IDENTIFICATION_NO2", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_IDENTIFICATION_NO2);
                    dyParam.Add("P_FSCU_IDENTISSUE_DATE2", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_IDENTISSUE_DATE2);
                    dyParam.Add("P_FSCU_IDENTIEXPIRY_DATE2", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_IDENTIEXPIRY_DATE2);
                    dyParam.Add("P_FSCU_NTN_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_NTN_NUMBER);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, customer.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSCU_DUAL_NATIONAL_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_DUAL_NATIONAL_YN);
                    dyParam.Add("P_FSCU_RELGN_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_RELGN_FSCD_DID);
                    dyParam.Add("P_FSCU_RACES_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_RACES_FSCD_DID);
                    dyParam.Add("P_FSCU_VIP_CUSTOMER_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_VIP_CUSTOMER_YN);
                    dyParam.Add("P_FSCU_EXIST_CUST_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_EXIST_CUST_YN);
                    dyParam.Add("P_FSCU_WORKING_CUST_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_WORKING_CUST_YN);
                    dyParam.Add("P_FSCU_AGE_ADMITTED_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_AGE_ADMITTED_YN);
                    dyParam.Add("P_FSCU_CUST_ALIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_ALIVE_YN);
                    dyParam.Add("P_FSCU_CUST_DEATH_DATE", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_CUST_DEATH_DATE);
                    dyParam.Add("P_FSCU_CUST_SMOKER_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_SMOKER_YN);
                    dyParam.Add("P_FSCU_CUST_DRINKER_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_DRINKER_YN);
                    dyParam.Add("P_FSCU_CUST_CORRADDR", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_CORRADDR);
                    dyParam.Add("P_FSCU_AML_RISK_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_AML_RISK_TYPE);
                    dyParam.Add("P_FSCU_CUST_HEIGHT", OracleDbType.Decimal, ParameterDirection.Input, customer.FSCU_CUST_HEIGHT);
                    dyParam.Add("P_FSCU_MSUNT_HEIT_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_MSUNT_HEIT_FSCD_DID);
                    dyParam.Add("P_FSCU_CUST_WEIGHT", OracleDbType.Decimal, ParameterDirection.Input, customer.FSCU_CUST_WEIGHT);
                    dyParam.Add("P_FSCU_MSUNT_WEIT_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_MSUNT_WEIT_FSCD_DID);
                    dyParam.Add("P_FSCU_CUST_BMI", OracleDbType.Decimal, ParameterDirection.Input, customer.FSCU_CUST_BMI);
                    dyParam.Add("P_FSCU_CUST_TAX_EXEMPT_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_TAX_EXEMPT_YN);
                    dyParam.Add("P_FSCU_CUST_POLICY_ISSU_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_POLICY_ISSU_YN);
                    dyParam.Add("P_FSCU_CUST_SAR", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CUST_SAR);
                    dyParam.Add("P_FSCU_CUST_ANNUAL_INCOME", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CUST_ANNUAL_INCOME);
                    dyParam.Add("P_FSCR_CURRENCY_CODE", OracleDbType.Int32, ParameterDirection.Input, customer.FSCR_CURRENCY_CODE);
                    dyParam.Add("P_FSCU_CUST_ISEMPLOYEE_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_ISEMPLOYEE_YN);
                    dyParam.Add("P_FSCU_CUST_EMPLOYEE_CODE", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_EMPLOYEE_CODE);
                    dyParam.Add("P_FSCU_CUST_WEBSITE_ADDR", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_WEBSITE_ADDR);
                    dyParam.Add("P_FSCU_CUST_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_STATUS);
                    dyParam.Add("P_FSCU_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CRUSER);
                    dyParam.Add("P_FSCU_CRDATE", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PutCustomer(Customer customer)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSNT_IDENTYPE_ID", OracleDbType.Int32, ParameterDirection.Input, customer.FSNT_IDENTYPE_ID);
                    dyParam.Add("P_FSCU_IDENTIFICATION_NO", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_IDENTIFICATION_NO);
                    dyParam.Add("P_FSCU_IDENTISSUE_DATE", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_IDENTISSUE_DATE);
                    dyParam.Add("P_FSCU_IDENTIEXPIRY_DATE", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_IDENTIEXPIRY_DATE);
                    dyParam.Add("P_FSCU_GROUP_CODE", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_GROUP_CODE);
                    dyParam.Add("P_FSCU_FAMILY_ID", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_FAMILY_ID);
                    dyParam.Add("P_FSCU_CLIENT_TYPE", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CLIENT_TYPE);
                    dyParam.Add("P_FSCU_TITLE_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_TITLE_FSCD_DID);
                    dyParam.Add("P_FSCU_FULL_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_FULL_NAME);
                    dyParam.Add("P_FSCU_FIRST_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_FIRST_NAME);
                    dyParam.Add("P_FSCU_MIDDLE_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_MIDDLE_NAME);
                    dyParam.Add("P_FSCU_LAST_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_LAST_NAME);
                    dyParam.Add("P_FSCU_FATHUSB_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_FATHUSB_NAME);
                    dyParam.Add("P_FSCU_MOTHER_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_MOTHER_NAME);
                    dyParam.Add("P_FSCU_RELTN_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_RELTN_FSCD_DID);
                    dyParam.Add("P_FSCU_GENDR_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_GENDR_FSCD_DID);
                    dyParam.Add("P_FSCU_MRTST_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_MRTST_FSCD_DID);
                    dyParam.Add("P_FSCU_NOOFDEPENDENTS", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_NOOFDEPENDENTS);
                    dyParam.Add("P_FSCU_CUOCP_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CUOCP_FSCD_DID);
                    dyParam.Add("P_FSCU_WORKEXP_YEARS", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_WORKEXP_YEARS);
                    dyParam.Add("P_FSCU_DATEOFBIRTH", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_DATEOFBIRTH);
                    dyParam.Add("P_FSCU_BIRTH_COUNTRY", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_BIRTH_COUNTRY);
                    dyParam.Add("P_FSCU_IDENTIFICTYPE2", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_IDENTIFICTYPE2);
                    dyParam.Add("P_FSCU_IDENTIFICATION_NO2", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_IDENTIFICATION_NO2);
                    dyParam.Add("P_FSCU_IDENTISSUE_DATE2", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_IDENTISSUE_DATE2);
                    dyParam.Add("P_FSCU_IDENTIEXPIRY_DATE2", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_IDENTIEXPIRY_DATE2);
                    dyParam.Add("P_FSCU_NTN_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_NTN_NUMBER);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, customer.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSCU_DUAL_NATIONAL_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_DUAL_NATIONAL_YN);
                    dyParam.Add("P_FSCU_RELGN_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_RELGN_FSCD_DID);
                    dyParam.Add("P_FSCU_RACES_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_RACES_FSCD_DID);
                    dyParam.Add("P_FSCU_VIP_CUSTOMER_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_VIP_CUSTOMER_YN);
                    dyParam.Add("P_FSCU_EXIST_CUST_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_EXIST_CUST_YN);
                    dyParam.Add("P_FSCU_WORKING_CUST_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_WORKING_CUST_YN);
                    dyParam.Add("P_FSCU_AGE_ADMITTED_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_AGE_ADMITTED_YN);
                    dyParam.Add("P_FSCU_CUST_ALIVE_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_ALIVE_YN);
                    dyParam.Add("P_FSCU_CUST_DEATH_DATE", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_CUST_DEATH_DATE);
                    dyParam.Add("P_FSCU_CUST_SMOKER_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_SMOKER_YN);
                    dyParam.Add("P_FSCU_CUST_DRINKER_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_DRINKER_YN);
                    dyParam.Add("P_FSCU_CUST_CORRADDR", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_CORRADDR);
                    dyParam.Add("P_FSCU_AML_RISK_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_AML_RISK_TYPE);
                    dyParam.Add("P_FSCU_CUST_HEIGHT", OracleDbType.Decimal, ParameterDirection.Input, customer.FSCU_CUST_HEIGHT);
                    dyParam.Add("P_FSCU_MSUNT_HEIT_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_MSUNT_HEIT_FSCD_DID);
                    dyParam.Add("P_FSCU_CUST_WEIGHT", OracleDbType.Decimal, ParameterDirection.Input, customer.FSCU_CUST_WEIGHT);
                    dyParam.Add("P_FSCU_MSUNT_WEIT_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_MSUNT_WEIT_FSCD_DID);
                    dyParam.Add("P_FSCU_CUST_BMI", OracleDbType.Decimal, ParameterDirection.Input, customer.FSCU_CUST_BMI);
                    dyParam.Add("P_FSCU_CUST_TAX_EXEMPT_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_TAX_EXEMPT_YN);
                    dyParam.Add("P_FSCU_CUST_POLICY_ISSU_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_POLICY_ISSU_YN);
                    dyParam.Add("P_FSCU_CUST_SAR", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CUST_SAR);
                    dyParam.Add("P_FSCU_CUST_ANNUAL_INCOME", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CUST_ANNUAL_INCOME);
                    dyParam.Add("P_FSCR_CURRENCY_CODE", OracleDbType.Int32, ParameterDirection.Input, customer.FSCR_CURRENCY_CODE);
                    dyParam.Add("P_FSCU_CUST_ISEMPLOYEE_YN", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_ISEMPLOYEE_YN);
                    dyParam.Add("P_FSCU_CUST_EMPLOYEE_CODE", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_EMPLOYEE_CODE);
                    dyParam.Add("P_FSCU_CUST_WEBSITE_ADDR", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_WEBSITE_ADDR);
                    dyParam.Add("P_FSCU_CUST_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customer.FSCU_CUST_STATUS);
                    dyParam.Add("P_FSCU_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customer.FSCU_CRUSER);
                    dyParam.Add("P_FSCU_CRDATE", OracleDbType.Date, ParameterDirection.Input, customer.FSCU_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object DeleteCustomer(int customerCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerCode);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object SearchCustomer(string customerCNIC)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "CEX");
                    dyParam.Add("P_FSCU_IDENTIFICATION_NO", OracleDbType.Varchar2, ParameterDirection.Input, customerCNIC);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object GetCustomerList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object GetCustAddressDetails(int customerCode, string addressType)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GA1");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerCode);
                    dyParam.Add("P_FSCA_ADDRESS_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, addressType);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PostCustomerAddress(CustomerAddress customerAddress)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "AI");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSCA_ADDRESS_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_ADDRESS_TYPE);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSCT_CITY_ID);
                    dyParam.Add("P_FSPS_POSTAL_ID", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSPS_POSTAL_ID);
                    dyParam.Add("P_FSAP_AREA_ID", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSAP_AREA_ID);
                    dyParam.Add("P_FSCA_ADDRESS1", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_ADDRESS1);
                    dyParam.Add("P_FSCA_ADDRESS2", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_ADDRESS2);
                    dyParam.Add("P_FSCA_ADDRESS3", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_ADDRESS3);
                    dyParam.Add("P_FSCA_TELNO1", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_TELNO1);
                    dyParam.Add("P_FSCA_TELNO2", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_TELNO2);
                    dyParam.Add("P_FSCA_MOBILE1", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_MOBILE1);
                    dyParam.Add("P_FSCA_MOBILE2", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_MOBILE2);
                    dyParam.Add("P_FSCA_POBOX", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_POBOX);
                    dyParam.Add("P_FSCA_FAXNO", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_FAXNO);
                    dyParam.Add("P_FSCA_PAGER", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_PAGER);
                    dyParam.Add("P_FSCA_EMAIL1", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_EMAIL1);
                    dyParam.Add("P_FSCA_EMAIL2", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_EMAIL2);
                    dyParam.Add("P_FSCA_ADDR_ISCORSP", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_ADDR_ISCORSP);
                    dyParam.Add("P_FSCA_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_STATUS);
                    dyParam.Add("P_FSCA_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSCA_CRUSER);
                    dyParam.Add("P_FSCA_CRDATE", OracleDbType.Date, ParameterDirection.Input, customerAddress.FSCA_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                result = "Failed to Save list or operation of Customer Address" + ex.Message;
            }

            return result;
        }

        public object PutCustomerAddress(CustomerAddress customerAddress)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "AU");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSCA_ADDRESS_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_ADDRESS_TYPE);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSCT_CITY_ID);
                    dyParam.Add("P_FSPS_POSTAL_ID", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSPS_POSTAL_ID);
                    dyParam.Add("P_FSAP_AREA_ID", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSAP_AREA_ID);
                    dyParam.Add("P_FSCA_ADDRESS1", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_ADDRESS1);
                    dyParam.Add("P_FSCA_ADDRESS2", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_ADDRESS2);
                    dyParam.Add("P_FSCA_ADDRESS3", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_ADDRESS3);
                    dyParam.Add("P_FSCA_TELNO1", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_TELNO1);
                    dyParam.Add("P_FSCA_TELNO2", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_TELNO2);
                    dyParam.Add("P_FSCA_MOBILE1", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_MOBILE1);
                    dyParam.Add("P_FSCA_MOBILE2", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_MOBILE2);
                    dyParam.Add("P_FSCA_POBOX", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_POBOX);
                    dyParam.Add("P_FSCA_FAXNO", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_FAXNO);
                    dyParam.Add("P_FSCA_PAGER", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_PAGER);
                    dyParam.Add("P_FSCA_EMAIL1", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_EMAIL1);
                    dyParam.Add("P_FSCA_EMAIL2", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_EMAIL2);
                    dyParam.Add("P_FSCA_ADDR_ISCORSP", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_ADDR_ISCORSP);
                    dyParam.Add("P_FSCA_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerAddress.FSCA_STATUS);
                    dyParam.Add("P_FSCA_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customerAddress.FSCA_CRUSER);
                    dyParam.Add("P_FSCA_CRDATE", OracleDbType.Date, ParameterDirection.Input, customerAddress.FSCA_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object GetCustBankDetails(int customerCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GB1");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerCode);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PostCustBankDetails(CustomerBankDtls customerBankDtls)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "BI");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerBankDtls.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSBK_BANK_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSBK_BANK_NAME);
                    dyParam.Add("P_FSCB_BRANCH_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSCB_BRANCH_NAME);
                    dyParam.Add("P_FSCB_ACCOUNT_TITLE", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSCB_ACCOUNT_TITLE);
                    dyParam.Add("P_FSCB_ACCOUNT_NO", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSCB_ACCOUNT_NO);
                    dyParam.Add("P_FSCB_ACCOUNT_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSCB_ACCOUNT_TYPE);
                    dyParam.Add("P_FSCB_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSCB_STATUS);
                    dyParam.Add("P_FSCB_ACCOUNT_CATGRY", OracleDbType.Int32, ParameterDirection.Input, customerBankDtls.FSCB_ACCOUNT_CATGRY);
                    dyParam.Add("P_FSCB_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customerBankDtls.FSCB_CRUSER);
                    dyParam.Add("P_FSCB_CRDATE", OracleDbType.Date, ParameterDirection.Input, customerBankDtls.FSCB_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PutCustBankDetails(CustomerBankDtls customerBankDtls)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "BU");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerBankDtls.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSBK_BANK_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSBK_BANK_NAME);
                    dyParam.Add("P_FSCB_BRANCH_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSCB_BRANCH_NAME);
                    dyParam.Add("P_FSCB_ACCOUNT_TITLE", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSCB_ACCOUNT_TITLE);
                    dyParam.Add("P_FSCB_ACCOUNT_NO", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSCB_ACCOUNT_NO);
                    dyParam.Add("P_FSCB_ACCOUNT_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSCB_ACCOUNT_TYPE);
                    dyParam.Add("P_FSCB_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerBankDtls.FSCB_STATUS);
                    dyParam.Add("P_FSCB_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customerBankDtls.FSCB_CRUSER);
                    dyParam.Add("P_FSCB_CRDATE", OracleDbType.Date, ParameterDirection.Input, customerBankDtls.FSCB_CRDATE);
                    dyParam.Add("P_BANK_SERIAL_NO", OracleDbType.Int32, ParameterDirection.Input, customerBankDtls.FSCB_SERIAL_NO);
                    dyParam.Add("P_FSCB_ACCOUNT_CATGRY", OracleDbType.Int32, ParameterDirection.Input, customerBankDtls.FSCB_ACCOUNT_CATGRY);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object GetCustFamilyHist(int customerCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GF1");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerCode);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PostCustFamilyHist(CustomerFamlyHist customerFamilyHist)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "FI");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerFamilyHist.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSCF_MEMBER_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_MEMBER_NAME);
                    dyParam.Add("P_FSCF_SERIAL_NO", OracleDbType.Int32, ParameterDirection.Input, customerFamilyHist.FSCF_SERIAL_NO);
                    dyParam.Add("P_FSCU_RELTN_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customerFamilyHist.FSCU_RELTN_FSCD_DID);
                    dyParam.Add("P_FSCF_MEMBER_DOB", OracleDbType.Date, ParameterDirection.Input, customerFamilyHist.FSCF_MEMBER_DOB);
                    dyParam.Add("P_FSCF_MEMBER_CNIC", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_MEMBER_CNIC);
                    dyParam.Add("P_FSCF_FAMILY_ID", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_FAMILY_ID);
                    dyParam.Add("P_FSCF_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_STATUS);
                    dyParam.Add("P_FSCF_MEMBER_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_MEMBER_STATUS);
                    dyParam.Add("P_FSCF_AGE", OracleDbType.Int32, ParameterDirection.Input, customerFamilyHist.FSCF_AGE);
                    dyParam.Add("P_FSCF_STATOFHLTH", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_STATOFHLTH);
                    dyParam.Add("P_FSCF_YEAROFDTH", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_YEAROFDTH);
                    dyParam.Add("P_FSCF_AGEOFDTH", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_AGEOFDTH);
                    dyParam.Add("P_FSCF_CAUSOFDTH", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_CAUSOFDTH);
                    dyParam.Add("P_FSCF_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customerFamilyHist.FSCF_CRUSER);
                    dyParam.Add("P_FSCF_CRDATE", OracleDbType.Date, ParameterDirection.Input, customerFamilyHist.FSCF_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PutCustFamilyHist(CustomerFamlyHist customerFamilyHist)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "FU");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerFamilyHist.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSCF_MEMBER_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_MEMBER_NAME);
                    dyParam.Add("P_FSCF_SERIAL_NO", OracleDbType.Int32, ParameterDirection.Input, customerFamilyHist.FSCF_SERIAL_NO);
                    dyParam.Add("P_FSCU_RELTN_FSCD_DID", OracleDbType.Int32, ParameterDirection.Input, customerFamilyHist.FSCU_RELTN_FSCD_DID);
                    dyParam.Add("P_FSCF_MEMBER_DOB", OracleDbType.Date, ParameterDirection.Input, customerFamilyHist.FSCF_MEMBER_DOB);
                    dyParam.Add("P_FSCF_MEMBER_CNIC", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_MEMBER_CNIC);
                    dyParam.Add("P_FSCF_FAMILY_ID", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_FAMILY_ID);
                    dyParam.Add("P_FSCF_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_STATUS);
                    dyParam.Add("P_FSCF_MEMBER_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_MEMBER_STATUS);
                    dyParam.Add("P_FSCF_AGE", OracleDbType.Int32, ParameterDirection.Input, customerFamilyHist.FSCF_AGE);
                    dyParam.Add("P_FSCF_STATOFHLTH", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_STATOFHLTH);
                    dyParam.Add("P_FSCF_YEAROFDTH", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_YEAROFDTH);
                    dyParam.Add("P_FSCF_AGEOFDTH", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_AGEOFDTH);
                    dyParam.Add("P_FSCF_CAUSOFDTH", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyHist.FSCF_CAUSOFDTH);
                    dyParam.Add("P_FSCF_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customerFamilyHist.FSCF_CRUSER);
                    dyParam.Add("P_FSCF_CRDATE", OracleDbType.Date, ParameterDirection.Input, customerFamilyHist.FSCF_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object GetCustFamilyDoct(int customerCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GD1");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerCode);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PostCustFamilyDoct(CustomerFamlyDoctr customerFamilyDoct)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "DI");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSFD_DOCTOR_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_DOCTOR_NAME);
                    dyParam.Add("P_FSFD_DOCTOR_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_DOCTOR_TYPE);
                    dyParam.Add("P_FSFD_SERIAL_NO", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSFD_SERIAL_NO);
                    dyParam.Add("P_FSFD_HOSPCLINC_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_HOSPCLINC_NAME);
                    dyParam.Add("P_FSFD_HOSPCLINC_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_HOSPCLINC_ADDRESS);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSCT_CITY_ID);
                    dyParam.Add("P_FSFD_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_STATUS);
                    dyParam.Add("P_FSFD_DOCTR_CONTNO", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_DOCTR_CONTNO);
                    dyParam.Add("P_FSFD_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSFD_CRUSER);
                    dyParam.Add("P_FSFD_CRDATE", OracleDbType.Date, ParameterDirection.Input, customerFamilyDoct.FSFD_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PutCustFamilyDoct(CustomerFamlyDoctr customerFamilyDoct)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "DU");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSFD_DOCTOR_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_DOCTOR_NAME);
                    dyParam.Add("P_FSFD_DOCTOR_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_DOCTOR_TYPE);
                    dyParam.Add("P_FSFD_SERIAL_NO", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSFD_SERIAL_NO);
                    dyParam.Add("P_FSFD_HOSPCLINC_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_HOSPCLINC_NAME);
                    dyParam.Add("P_FSFD_HOSPCLINC_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_HOSPCLINC_ADDRESS);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSCT_CITY_ID);
                    dyParam.Add("P_FSFD_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_STATUS);
                    dyParam.Add("P_FSFD_DOCTR_CONTNO", OracleDbType.Varchar2, ParameterDirection.Input, customerFamilyDoct.FSFD_DOCTR_CONTNO);
                    dyParam.Add("P_FSFD_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customerFamilyDoct.FSFD_CRUSER);
                    dyParam.Add("P_FSFD_CRDATE", OracleDbType.Date, ParameterDirection.Input, customerFamilyDoct.FSFD_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object GetCustDocumUpload (int customerCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GDU1");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerCode);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PostCustDocumUpload(CustomerDocUpload customerDocUpload)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "DUI");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerDocUpload.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSDU_DOCUMENT_ID", OracleDbType.Int32, ParameterDirection.Input, customerDocUpload.FSDU_DOCUMENT_ID);
                    dyParam.Add("P_FSDU_DOCUMENT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerDocUpload.FSDU_DOCUMENT_NAME);
                    dyParam.Add("P_FSDU_DOC_ACTUAL_PATH", OracleDbType.Varchar2, ParameterDirection.Input, customerDocUpload.FSDU_DOC_ACTUAL_PATH);
                    dyParam.Add("P_FSDU_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerDocUpload.FSDU_STATUS);
                    dyParam.Add("P_FSDU_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customerDocUpload.FSDU_CRUSER);
                    dyParam.Add("P_FSDU_CRDATE", OracleDbType.Date, ParameterDirection.Input, customerDocUpload.FSDU_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PutCustDocumUpload(CustomerDocUpload customerDocUpload)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "DUU");
                    dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerDocUpload.FSCU_CUSTOMER_CODE);
                    dyParam.Add("P_FSDU_DOCUMENT_ID", OracleDbType.Int32, ParameterDirection.Input, customerDocUpload.FSDU_DOCUMENT_ID);
                    dyParam.Add("P_FSDU_DOCUMENT_NAME", OracleDbType.Varchar2, ParameterDirection.Input, customerDocUpload.FSDU_DOCUMENT_NAME);
                    dyParam.Add("P_FSDU_DOC_ACTUAL_PATH", OracleDbType.Varchar2, ParameterDirection.Input, customerDocUpload.FSDU_DOC_ACTUAL_PATH);
                    dyParam.Add("P_FSDU_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, customerDocUpload.FSDU_STATUS);
                    dyParam.Add("P_FSDU_CRUSER", OracleDbType.Int32, ParameterDirection.Input, customerDocUpload.FSDU_CRUSER);
                    dyParam.Add("P_FSDU_CRDATE", OracleDbType.Date, ParameterDirection.Input, customerDocUpload.FSDU_CRDATE);
                    dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object GetSocialMediaProfile(int customerCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GSML");
                dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, customerCode);
                dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PostSocialMediaProfile(CustomerSociMedProf CustomerSociMedProf)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "CSML");
                dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, CustomerSociMedProf.FSCU_CUSTOMER_CODE);
                dyParam.Add("P_FSCS_SOCIALMED_TYP", OracleDbType.Varchar2, ParameterDirection.Input, CustomerSociMedProf.FSCS_SOCIALMED_TYP);
                dyParam.Add("P_FSCS_SOCIALMED_LINK", OracleDbType.Varchar2, ParameterDirection.Input, CustomerSociMedProf.FSCS_SOCIALMED_LINK);
                dyParam.Add("P_FSCS_CRUSER", OracleDbType.Int32, ParameterDirection.Input, CustomerSociMedProf.FSCS_CRUSER);
                dyParam.Add("P_FSCS_CRDATE", OracleDbType.Date, ParameterDirection.Input, CustomerSociMedProf.FSCS_CRDATE);
                dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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

        public object PutSocialMediaProfile(CustomerSociMedProf CustomerSociMedProf)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "USML");
                dyParam.Add("P_FSCU_CUSTOMER_CODE", OracleDbType.Int32, ParameterDirection.Input, CustomerSociMedProf.FSCU_CUSTOMER_CODE);
                dyParam.Add("P_FSCS_SOCIALMED_TYP", OracleDbType.Varchar2, ParameterDirection.Input, CustomerSociMedProf.FSCS_SOCIALMED_TYP);
                dyParam.Add("P_FSCS_SOCIALMED_LINK", OracleDbType.Varchar2, ParameterDirection.Input, CustomerSociMedProf.FSCS_SOCIALMED_LINK);
                dyParam.Add("P_FSCS_CRUSER", OracleDbType.Int32, ParameterDirection.Input, CustomerSociMedProf.FSCS_CRUSER);
                dyParam.Add("P_FSCS_CRDATE", OracleDbType.Date, ParameterDirection.Input, CustomerSociMedProf.FSCS_CRDATE);
                dyParam.Add("CUSTOMERCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_CUSTOMER.MAIN_PROCEDURE";

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
