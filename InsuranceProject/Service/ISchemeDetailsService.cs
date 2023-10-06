using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Service
{
    public interface ISchemeDetailsService
    {
        List<SchemeDetails> GetAll();
        SchemeDetails GetById(int id);
        SchemeDetails Add(SchemeDetails schemeDetails);
        SchemeDetails Update(SchemeDetails schemeDetails);
        bool Delete(int id);
    }
}
