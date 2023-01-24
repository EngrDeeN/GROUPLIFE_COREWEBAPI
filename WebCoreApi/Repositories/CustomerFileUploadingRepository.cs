using System;
using WebCoreApi.Oracle;
using WebCoreApi.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using WebCoreApi.DAORespositories;

namespace WebCoreApi.Repositories
{
    public class CustomerFileUploadingRepository : ICustomerFileUploadingRepository
    {
        private int sys_userid = 1;


        IConfiguration configuration;
        public CustomerFileUploadingRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object PostUploadCustomerFile(CustomerFileUploading CustomerFileUploading)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                    dyParam.Add("P_FGBU_CUST_TITLE", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_TITLE);
                    dyParam.Add("P_FGBU_CUST_NAME", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_NAME);
                    dyParam.Add("P_FGBU_CUST_CNIC", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_CNIC);
                    dyParam.Add("P_FGBU_CUST_PASSPORT", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_PASSPORT);
                    dyParam.Add("P_FGBU_EMP_ID", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_EMP_ID);
                    dyParam.Add("P_FGBU_EMP_NAME", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_EMP_NAME);
                    dyParam.Add("P_FGBU_EMP_DESIGN", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_EMP_DESIGN);
                    dyParam.Add("P_FGBU_EMP_AGE", OracleDbType.Int32, ParameterDirection.Input, CustomerFileUploading.FGBU_EMP_AGE);
                    dyParam.Add("P_FGBU_EMP_RELATION", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_EMP_RELATION);
                    dyParam.Add("P_FGBU_CUST_DOB", OracleDbType.Date, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_DOB);
                    dyParam.Add("P_FGBU_CUST_GENDER", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_GENDER);
                    dyParam.Add("P_FGBU_CUST_OCCUPATION", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_OCCUPATION);
                    dyParam.Add("P_FGBU_CUST_CATEGORY", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_CATEGORY);
                    dyParam.Add("P_FGBU_EMP_SALARY", OracleDbType.Int32, ParameterDirection.Input, CustomerFileUploading.FGBU_EMP_SALARY);
                    dyParam.Add("P_FGBU_POL_COVGE_TERM", OracleDbType.Int32, ParameterDirection.Input, CustomerFileUploading.FGBU_POL_COVGE_TERM);
                    dyParam.Add("P_FGBU_POL_COVGE_STDATE", OracleDbType.Date, ParameterDirection.Input, CustomerFileUploading.FGBU_POL_COVGE_STDATE);
                    dyParam.Add("P_FGBU_POL_COVGE_EDDATE", OracleDbType.Date, ParameterDirection.Input, CustomerFileUploading.FGBU_POL_COVGE_EDDATE);
                    dyParam.Add("P_FGBU_POL_COVGE_SUMASSURD", OracleDbType.Int32, ParameterDirection.Input, CustomerFileUploading.FGBU_POL_COVGE_SUMASSURD);
                    dyParam.Add("P_FGBU_INSTIT_HEADOFFICE", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_INSTIT_HEADOFFICE);
                    dyParam.Add("P_FGBU_INSTIT_BRANCH", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_INSTIT_BRANCH);
                    dyParam.Add("P_FGBU_CUST_MOBILENO", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_MOBILENO);
                    dyParam.Add("P_FGBU_CUST_EMAIL", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_EMAIL);
                    dyParam.Add("P_FGBU_CUST_FAMILYID", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_FAMILYID);
                    dyParam.Add("P_FGBU_CUST_MARITALSTATUS", OracleDbType.Varchar2, ParameterDirection.Input, CustomerFileUploading.FGBU_CUST_MARITALSTATUS);
                    dyParam.Add("P_FGBU_CRUSER", OracleDbType.Int32, ParameterDirection.Input, sys_userid);
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, CustomerFileUploading.FSSI_INSTITUTE_ID);
                    dyParam.Add("P_FGQH_QUOTATHDR_ID", OracleDbType.Int32, ParameterDirection.Input, CustomerFileUploading.FGQH_QUOTATHDR_ID);
                    dyParam.Add("BULKUPLOADCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_GL_UPLOADINGS.MAIN_PROCEDURE";
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
        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("GlobalConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}
