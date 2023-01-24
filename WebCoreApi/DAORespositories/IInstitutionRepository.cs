using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IInstitutionRepository
    {
        public object GetInstitutionList();
        public object GetInstitutionDetails(int InstitutionCode);
        public object PostInstitution(Institution institution);
        public object PutInstitution(Institution institution);
        public object DeleteInstitution(int InstitutionCode);
        public object SearchInstitution(string InstRegNo, string FSSI_DESCRIPTION);
        public object GetInstitutionTypeList();
        public object GetInstitAddressDetails(int InstitutionCode, string addressType);
        public object PostInstitAddress(InstituteAddress institutionAddr);
        public object PutInstitAddress(InstituteAddress institutionAddr);
        public object GetInstitContactDetails(int InstitutionCode);
        public object PostInstitContacts(InstitutionContacts institutionContacts);
        public object PutInstitContacts(InstitutionContacts institutionContacts);
        public object GetInstitMobileDetails(int InstitutionCode);
        public object PostInstitMobileDtls(InstitutionMobContacts institutionMobContacts);
        public object PutInstitMobileDtls(InstitutionMobContacts institutionMobContacts);
        public object GetInstitOwnerInfo(int InstitutionCode);
        public object PostInstitOwnerInfo(InstitutionOwnerInfo institutionOwnerInfo);
        public object PutInstitOwnerInfo(InstitutionOwnerInfo institutionOwnerInfo);

    }
}
