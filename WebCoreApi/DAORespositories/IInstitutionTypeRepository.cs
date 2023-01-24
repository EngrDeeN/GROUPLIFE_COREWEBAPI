using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IInstitutionTypeRepository
    {
        public object GetInstitutionTypeList();
        public object GetInstitutionTypeDetails(int InstitutionTypeId);
        public object PostInstitutionType(InstitutionType institutionType);
        public object PutInstitutionType(InstitutionType institutionType);
        public object DeleteInstitutionType(int InstitutionTypeId);
    }
}
