using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace InsuranceProject.Repository
{
    public interface IEntityRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T GetById(object id);

        public void Add(T entity);

        public T Update(T entity, int id);


        public void Delete(T entity, int id);
        public IEnumerable<T> GetAllEmployee();


    }
}
