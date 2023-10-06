using InsuranceProject.Repository;
using InsuranceProject.Exceptions;
using InsuranceProject.Service;
using InsuranceProject.DTOs;
using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Service
{
    public class QueryService : IQueryService
    {
        private readonly IEntityRepository<Query> _repository;

        public QueryService(IEntityRepository<Query> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<Query> GetAllQueries()
        {
            return _repository.GetAll().ToList();
        }

        public Query GetQueryById(int id)
        {
            return _repository.GetById(id);
        }

        public Query AddQuery(Query query)
        {
            _repository.Add(query);
            return query;
        }

        public Query UpdateQuery(Query query)
        {
            if (_repository.Update(query, query.QueryId) != null)
            {
                return _repository.Update(query, query.QueryId);
            }
            throw new Exception("No such query found");
        }

        public bool DeleteQuery(int id)
        {
            var deleteQuery = _repository.GetById(id);
            if (deleteQuery != null)
            {
                deleteQuery.Status = false;
                _repository.Delete(deleteQuery, deleteQuery.QueryId);
                return true;
            }
            throw new QueryNotFoundException("No such query");
        }
    }
}
