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
    public class InstitutionRepository : IInstitutionRepository

    {
        IConfiguration configuration;
        public InstitutionRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetInstitutionDetails(int InstitutionCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G2");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, InstitutionCode);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object PostInstitution(Institution institution)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "I");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, institution.FSSI_INSTITUTE_ID);
                    dyParam.Add("P_FSIT_INSTITYP_ID", OracleDbType.Int32, ParameterDirection.Input, institution.FSIT_INSTITYP_ID);
                    dyParam.Add("P_FSSI_CATEGORY_CODE", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_CATEGORY_CODE);
                    dyParam.Add("P_FSSI_OCCUP_INDSTRY_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_OCCUP_INDSTRY_TYPE);
                    dyParam.Add("P_FSSI_COMP_SECTOR_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_COMP_SECTOR_TYPE);    
                    dyParam.Add("P_FSSI_SHORT_CODE", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_SHORT_CODE);
                    dyParam.Add("P_FSSI_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_DESCRIPTION);
                    dyParam.Add("P_FSSI_SHORT_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_SHORT_DESCRIPTION);
                    dyParam.Add("P_FSSI_WEB_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_WEB_ADDRESS);
                    dyParam.Add("P_FSSI_REGISTRATION_NO", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_REGISTRATION_NO);
                    dyParam.Add("P_FSSI_REGISTRATION_DATE", OracleDbType.Date, ParameterDirection.Input, institution.FSSI_REGISTRATION_DATE);
                    dyParam.Add("P_FSSI_NTN_NO", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_NTN_NO);
                    dyParam.Add("P_FSSI_STRN_NO", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_STRN_NO);
                    dyParam.Add("P_FSSI_EFFECT_FROM_DATE", OracleDbType.Date, ParameterDirection.Input, institution.FSSI_EFFECT_FROM_DATE);
                    dyParam.Add("P_FSSI_EFFECT_TO_DATE", OracleDbType.Date, ParameterDirection.Input, institution.FSSI_EFFECT_TO_DATE);
                    dyParam.Add("P_FSSI_BANK_ROLE", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_BANK_ROLE);
                    dyParam.Add("P_FSSI_BANK_COMMSN", OracleDbType.Int32, ParameterDirection.Input, institution.FSSI_BANK_COMMSN);
                    dyParam.Add("P_FSSI_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_STATUS);
                    dyParam.Add("P_FSSI_CRUSER", OracleDbType.Int32, ParameterDirection.Input, institution.FSSI_CRUSER);
                    dyParam.Add("P_FSSI_CRDATE", OracleDbType.Date, ParameterDirection.Input, institution.FSSI_CRDATE);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object PutInstitution(Institution institution)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "U");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, institution.FSSI_INSTITUTE_ID);
                    dyParam.Add("P_FSIT_INSTITYP_ID", OracleDbType.Int32, ParameterDirection.Input, institution.FSIT_INSTITYP_ID);
                    dyParam.Add("P_FSSI_CATEGORY_CODE", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_CATEGORY_CODE);
                    dyParam.Add("P_FSSI_OCCUP_INDSTRY_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_OCCUP_INDSTRY_TYPE);
                    dyParam.Add("P_FSSI_COMP_SECTOR_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_COMP_SECTOR_TYPE);
                    dyParam.Add("P_FSSI_SHORT_CODE", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_SHORT_CODE);
                    dyParam.Add("P_FSSI_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_DESCRIPTION);
                    dyParam.Add("P_FSSI_SHORT_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_SHORT_DESCRIPTION);
                    dyParam.Add("P_FSSI_WEB_ADDRESS", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_WEB_ADDRESS);
                    dyParam.Add("P_FSSI_REGISTRATION_NO", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_REGISTRATION_NO);
                    dyParam.Add("P_FSSI_REGISTRATION_DATE", OracleDbType.Date, ParameterDirection.Input, institution.FSSI_REGISTRATION_DATE);
                    dyParam.Add("P_FSSI_NTN_NO", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_NTN_NO);
                    dyParam.Add("P_FSSI_STRN_NO", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_STRN_NO);
                    dyParam.Add("P_FSSI_EFFECT_FROM_DATE", OracleDbType.Date, ParameterDirection.Input, institution.FSSI_EFFECT_FROM_DATE);
                    dyParam.Add("P_FSSI_EFFECT_TO_DATE", OracleDbType.Date, ParameterDirection.Input, institution.FSSI_EFFECT_TO_DATE);
                    dyParam.Add("P_FSSI_BANK_ROLE", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_BANK_ROLE);
                    dyParam.Add("P_FSSI_BANK_COMMSN", OracleDbType.Int32, ParameterDirection.Input, institution.FSSI_BANK_COMMSN);
                    dyParam.Add("P_FSSI_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, institution.FSSI_STATUS);
                    dyParam.Add("P_FSSI_CRUSER", OracleDbType.Int32, ParameterDirection.Input, institution.FSSI_CRUSER);
                    dyParam.Add("P_FSSI_CRDATE", OracleDbType.Date, ParameterDirection.Input, institution.FSSI_CRDATE);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object DeleteInstitution(int InstitutionCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "D");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, InstitutionCode);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object SearchInstitution(string InstRegNo, string FSSI_DESCRIPTION)
        {
            object result = null;
            if (FSSI_DESCRIPTION.Equals("---Select---")|| FSSI_DESCRIPTION.Equals("null"))
            {
                FSSI_DESCRIPTION = null;
            }
          
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "S");
                    dyParam.Add("P_FSSI_REGISTRATION_NO", OracleDbType.Varchar2, ParameterDirection.Input, InstRegNo);
                    dyParam.Add("P_FSSI_DESCRIPTION", OracleDbType.Varchar2, ParameterDirection.Input, FSSI_DESCRIPTION);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object GetInstitutionList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "G1");
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object GetInstitutionTypeList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GIT1");
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object GetInstitAddressDetails(int InstitutionCode, string addressType)
        {
            object result = null;
            try
            {

                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GIA1");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, InstitutionCode);
                    dyParam.Add("P_FSIA_ADDRESS_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, addressType);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object PostInstitAddress(InstituteAddress institutionAddr)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "IAI");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSSI_INSTITUTE_ID);
                    dyParam.Add("P_FSIA_ADDRESS_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_ADDRESS_TYPE);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSCT_CITY_ID);
                    dyParam.Add("P_FSPS_POSTAL_ID", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSPS_POSTAL_ID);
                    dyParam.Add("P_FSIA_ADDRESS1", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_ADDRESS1);
                    dyParam.Add("P_FSIA_ADDRESS2", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_ADDRESS2);
                    dyParam.Add("P_FSIA_ADDRESS3", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_ADDRESS3);
                    dyParam.Add("P_FSIA_ADDR_ISCORSP", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_ADDR_ISCORSP);
                    dyParam.Add("P_FSIA_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_STATUS);
                    dyParam.Add("P_FSIA_CRUSER", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSIA_CRUSER);
                    dyParam.Add("P_FSIA_CRDATE", OracleDbType.Date, ParameterDirection.Input, institutionAddr.FSIA_CRDATE);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object PutInstitAddress(InstituteAddress institutionAddr)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "IAU");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSSI_INSTITUTE_ID);
                    dyParam.Add("P_FSIA_ADDRESS_TYPE", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_ADDRESS_TYPE);
                    dyParam.Add("P_FSSC_COUNTRY_ID", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSSC_COUNTRY_ID);
                    dyParam.Add("P_FSSP_PROVINCE_ID", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSSP_PROVINCE_ID);
                    dyParam.Add("P_FSCT_CITY_ID", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSCT_CITY_ID);
                    dyParam.Add("P_FSPS_POSTAL_ID", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSPS_POSTAL_ID);
                    dyParam.Add("P_FSIA_ADDRESS1", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_ADDRESS1);
                    dyParam.Add("P_FSIA_ADDRESS2", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_ADDRESS2);
                    dyParam.Add("P_FSIA_ADDRESS3", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_ADDRESS3);
                    dyParam.Add("P_FSIA_ADDR_ISCORSP", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_ADDR_ISCORSP);
                    dyParam.Add("P_FSIA_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, institutionAddr.FSIA_STATUS);
                    dyParam.Add("P_FSIA_CRUSER", OracleDbType.Int32, ParameterDirection.Input, institutionAddr.FSIA_CRUSER);
                    dyParam.Add("P_FSIA_CRDATE", OracleDbType.Date, ParameterDirection.Input, institutionAddr.FSIA_CRDATE);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object GetInstitContactDetails(int InstitutionCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GIC1");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, InstitutionCode);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object PostInstitContacts(InstitutionContacts institutionContacts)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "ICI");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, institutionContacts.FSSI_INSTITUTE_ID);
                    dyParam.Add("P_FSIC_CONTACT_PERSON", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_CONTACT_PERSON);
                    dyParam.Add("P_FSIC_CONT_DESIGNAT", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_CONT_DESIGNAT);
                    dyParam.Add("P_FSIC_EMAIL1", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_EMAIL1);
                    dyParam.Add("P_FSIC_EMAIL2", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_EMAIL2);
                    dyParam.Add("P_FSIC_CONT_CNIC", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_CONT_CNIC);
                    dyParam.Add("P_FSIC_CONTACT_NO1", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_CONTACT_NO1);
                    dyParam.Add("P_FSIC_CONTACT_NO2", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_CONTACT_NO2);
                    //dyParam.Add("P_FSIM_MOBILE_NO1", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIM_MOBILE_NO1);
                    //dyParam.Add("P_FSIM_MOBILE_NO2", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIM_MOBILE_NO2);    
                    dyParam.Add("P_FSIC_FAX_NO", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_FAX_NO);                
                    dyParam.Add("P_FSIC_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_STATUS);
                    dyParam.Add("P_FSIC_CRUSER", OracleDbType.Int32, ParameterDirection.Input, institutionContacts.FSIC_CRUSER);
                    dyParam.Add("P_FSIC_CRDATE", OracleDbType.Date, ParameterDirection.Input, institutionContacts.FSIC_CRDATE);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object PutInstitContacts(InstitutionContacts institutionContacts)
        {
            object result = null;
            try
            {
            var dyParam = new OracleDynamicParameters();
                dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "ICU");
                dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, institutionContacts.FSSI_INSTITUTE_ID);
                dyParam.Add("P_FSIC_CONTACT_PERSON", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_CONTACT_PERSON);
                dyParam.Add("P_FSIC_CONT_DESIGNAT", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_CONT_DESIGNAT);
                dyParam.Add("P_FSIC_EMAIL1", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_EMAIL1);
                dyParam.Add("P_FSIC_EMAIL2", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_EMAIL2);
                dyParam.Add("P_FSIC_CONT_CNIC", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_CONT_CNIC);
                dyParam.Add("P_FSIC_CONTACT_NO1", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_CONTACT_NO1);
                dyParam.Add("P_FSIC_CONTACT_NO2", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_CONTACT_NO2);
                //dyParam.Add("P_FSIM_MOBILE_NO1", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIM_MOBILE_NO1);
                //dyParam.Add("P_FSIM_MOBILE_NO2", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIM_MOBILE_NO2);    
                dyParam.Add("P_FSIC_FAX_NO", OracleDbType.Varchar2, ParameterDirection.Input, institutionContacts.FSIC_FAX_NO);
                dyParam.Add("P_FSIC_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, "Y");
                dyParam.Add("P_FSIC_CRUSER", OracleDbType.Int32, ParameterDirection.Input, institutionContacts.FSIC_CRUSER);
                dyParam.Add("P_FSIC_CRDATE", OracleDbType.Date, ParameterDirection.Input, institutionContacts.FSIC_CRDATE);
                dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object GetInstitMobileDetails(int InstitutionCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GIM1");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, InstitutionCode);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object PostInstitMobileDtls(InstitutionMobContacts institutionMobContacts)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "IMI");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, institutionMobContacts.FSSI_INSTITUTE_ID);
                    dyParam.Add("P_FSIM_MOBILE_NO1", OracleDbType.Varchar2, ParameterDirection.Input, institutionMobContacts.FSIM_MOBILE_NO1);
                    dyParam.Add("P_FSIM_MOBILE_NO2", OracleDbType.Varchar2, ParameterDirection.Input, institutionMobContacts.FSIM_MOBILE_NO2);
                    dyParam.Add("P_FSIM_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, institutionMobContacts.FSIM_STATUS);
                    dyParam.Add("P_FSIM_CRUSER", OracleDbType.Int32, ParameterDirection.Input, institutionMobContacts.FSIM_CRUSER);
                    dyParam.Add("P_FSIM_CRDATE", OracleDbType.Date, ParameterDirection.Input, institutionMobContacts.FSIM_CRDATE);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object PutInstitMobileDtls(InstitutionMobContacts institutionMobContacts)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "IMU");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, institutionMobContacts.FSSI_INSTITUTE_ID);
                    dyParam.Add("P_FSIM_MOBILE_NO1", OracleDbType.Varchar2, ParameterDirection.Input, institutionMobContacts.FSIM_MOBILE_NO1);
                    dyParam.Add("P_FSIM_MOBILE_NO2", OracleDbType.Varchar2, ParameterDirection.Input, institutionMobContacts.FSIM_MOBILE_NO2);
                    dyParam.Add("P_FSIM_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, institutionMobContacts.FSIM_STATUS);
                    dyParam.Add("P_FSIM_CRUSER", OracleDbType.Int32, ParameterDirection.Input, institutionMobContacts.FSIM_CRUSER);
                    dyParam.Add("P_FSIM_CRDATE", OracleDbType.Date, ParameterDirection.Input, institutionMobContacts.FSIM_CRDATE);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object GetInstitOwnerInfo(int InstitutionCode)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "GIO1");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, InstitutionCode);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object PostInstitOwnerInfo(InstitutionOwnerInfo institutionOwnerInfo)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                //institutionOwnerInfo.FSIO_OCNIC_EXPRDATE = "12-01-2022 00:00:00";
                //institutionOwnerInfo.FSIO_OCNIC_ISSUDATE = "12-01-2016 00:00:00";

                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "IOI");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, institutionOwnerInfo.FSSI_INSTITUTE_ID);
                    dyParam.Add("P_FSIO_OWNER_NAME", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_NAME);
                    dyParam.Add("P_FSIO_OWNER_DESIGN", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_DESIGN);
                    dyParam.Add("P_FSIO_OWNER_TELNO", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_TELNO);
                    dyParam.Add("P_FSIO_OWNER_MOBNO", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_MOBNO);
                    dyParam.Add("P_FSIO_OWNER_EMAIL", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_EMAIL);
                    dyParam.Add("P_FSIO_SHARE_PERCENT", OracleDbType.Int32, ParameterDirection.Input, institutionOwnerInfo.FSIO_SHARE_PERCENT);
                    dyParam.Add("P_FSIO_OWNER_CNIC", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_CNIC);
                    dyParam.Add("P_FSIO_OCNIC_ISSUDATE", OracleDbType.Date, ParameterDirection.Input, institutionOwnerInfo.FSIO_OCNIC_ISSUDATE);
                    dyParam.Add("P_FSIO_OCNIC_EXPRDATE", OracleDbType.Date, ParameterDirection.Input, institutionOwnerInfo.FSIO_OCNIC_EXPRDATE);
                  //  dyParam.Add("P_FSIO_SHARE_PERCENT", OracleDbType.Decimal, ParameterDirection.Input, institutionOwnerInfo.FSIO_SHARE_PERCENT);
                    dyParam.Add("P_FSIO_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_STATUS);
                    dyParam.Add("P_FSIO_CRUSER", OracleDbType.Int32, ParameterDirection.Input, institutionOwnerInfo.FSIO_CRUSER);
                    dyParam.Add("P_FSIO_CRDATE", OracleDbType.Date, ParameterDirection.Input, institutionOwnerInfo.FSIO_CRDATE);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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

        public object PutInstitOwnerInfo(InstitutionOwnerInfo institutionOwnerInfo)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                    dyParam.Add("P_FUNCTYPE", OracleDbType.Varchar2, ParameterDirection.Input, "IOU");
                    dyParam.Add("P_FSSI_INSTITUTE_ID", OracleDbType.Int32, ParameterDirection.Input, institutionOwnerInfo.FSSI_INSTITUTE_ID);
                    dyParam.Add("P_FSIO_OWNER_NAME", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_NAME);
                    dyParam.Add("P_FSIO_OWNER_DESIGN", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_DESIGN);
                    dyParam.Add("P_FSIO_OWNER_TELNO", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_TELNO);
                    dyParam.Add("P_FSIO_OWNER_MOBNO", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_MOBNO);
                    dyParam.Add("P_FSIO_OWNER_EMAIL", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_EMAIL);
                    dyParam.Add("P_FSIO_SHARE_PERCENT", OracleDbType.Int32, ParameterDirection.Input, institutionOwnerInfo.FSIO_SHARE_PERCENT);
                    dyParam.Add("P_FSIO_OWNER_CNIC", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_OWNER_CNIC);
                    dyParam.Add("P_FSIO_OCNIC_ISSUDATE", OracleDbType.Date, ParameterDirection.Input, institutionOwnerInfo.FSIO_OCNIC_ISSUDATE);
                    dyParam.Add("P_FSIO_OCNIC_EXPRDATE", OracleDbType.Date, ParameterDirection.Input, institutionOwnerInfo.FSIO_OCNIC_EXPRDATE);
                    //  dyParam.Add("P_FSIO_SHARE_PERCENT", OracleDbType.Decimal, ParameterDirection.Input, institutionOwnerInfo.FSIO_SHARE_PERCENT);
                    dyParam.Add("P_FSIO_STATUS", OracleDbType.Varchar2, ParameterDirection.Input, institutionOwnerInfo.FSIO_STATUS);
                    dyParam.Add("P_FSIO_CRUSER", OracleDbType.Int32, ParameterDirection.Input, institutionOwnerInfo.FSIO_CRUSER);
                    dyParam.Add("P_FSIO_CRDATE", OracleDbType.Date, ParameterDirection.Input, institutionOwnerInfo.FSIO_CRDATE);
                    dyParam.Add("INSTITUTIONCURSOR", OracleDbType.RefCursor, ParameterDirection.Output, null);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "ACT_SET_ENT_INSTITUTION.MAIN_PROCEDURE";

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
