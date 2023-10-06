using InsuranceProject.Model;
using InsuranceProject.Model.Actors;
using Microsoft.EntityFrameworkCore;

namespace InsuranceProject.Repository
{
    public class Entityrepository<T> : IEntityRepository<T> where T : class
    {

        private readonly DbSet<T> _table;
        private readonly ModelContext _contact;

        public Entityrepository(ModelContext contactContext)
        {
            _contact = contactContext;
            _table = _contact.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _table;
            //if (innerTables != null)
            //{
            //    query = query.Include($"{innerTables}.{innerMostTables}");
            //    //foreach (var innerTable1 in innerTables[0])
            //    //{
            //    //    query = query.Include(innerTable1);
            //    //    foreach (var innerTable2 in innerTables[1])
            //    //    {
            //    //        query = query.Then(innerTable2);
            //    //    }
            //    //}
            //}
            return query;
            
        }
        public T GetById(object id)
        {
            
            return _table.Find(id);

        }
        public void Add(T entity)
        {


            //_context.Add(user);
            //_context.SaveChanges();
            //return user;
            _table.Add(entity);
            _contact.SaveChanges();
        }
        public T Update(T entity, int id)
        {
            T existing = _table.Find(id);
            if (existing != null)
            {
                _contact.Entry(existing).State = EntityState.Detached;
                _table.Update(entity);
                _contact.SaveChanges();
                return entity;

            }
            return null;



        }

        public void Delete(T entity, int id)
        {
            T existing = _table.Find(id);
            if (existing != null)
            {
                _contact.Entry(existing).State = EntityState.Detached;
                _table.Update(entity);
                _contact.SaveChanges();

            }
        }

        public IEnumerable<T> GetAllEmployee()
        {
            IQueryable<T> query = _table;
            query = query.Include($"{"Employees"}");
            //if (innerTables != null)
            //{
            //    query = query.Include($"{innerTables}.{innerMostTables}");
            //    //foreach (var innerTable1 in innerTables[0])
            //    //{
            //    //    query = query.Include(innerTable1);
            //    //    foreach (var innerTable2 in innerTables[1])
            //    //    {
            //    //        query = query.Then(innerTable2);
            //    //    }
            //    //}
            //}
            return query;

        }
        public T GetByIdEmployee(int id1,int id2)
        {

            //return _table.Find(id);
            //IQueryable<T> query = _table;
            //query = query.Include($"{"Employees"}").Find(a =>a.Id== id);
            ////if (innerTables != null)
            ////{
            ////    query = query.Include($"{innerTables}.{innerMostTables}");
            ////    //foreach (var innerTable1 in innerTables[0])
            ////    //{
            ////    //    query = query.Include(innerTable1);
            ////    //    foreach (var innerTable2 in innerTables[1])
            ////    //    {
            ////    //        query = query.Then(innerTable2);
            ////    //    }
            ////    //}
            ////}
            //return query;
            return null;
            



        }

    }
}
