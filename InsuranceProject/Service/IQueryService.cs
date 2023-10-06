using InsuranceProject.Service;
using InsuranceProject.DTOs;
using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Service

{
    public interface IQueryService
    {
        List<Query> GetAllQueries();
        Query GetQueryById(int id);
        Query AddQuery(Query query);
        Query UpdateQuery(Query query);
        bool DeleteQuery(int id);
    }
}
