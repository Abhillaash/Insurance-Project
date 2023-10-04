using InsuranceProject.Model;
using Microsoft.EntityFrameworkCore;

namespace InsuranceProject.Repository
{
    public class EntityRepository
    {

        private readonly DbSet<T> _table;
        private readonly ModelContext _contact;

        public Entityrepository(ContactContext contactContext)
        {
            _contact = contactContext;
            _table = _contact.Set<T>();
        }
        public IEnumerable<T> GetAll(string innerTables, string innerMostTables)
        {
            IQueryable<T> query = _table;
            if (innerTables != null)
            {
                query = query.Include($"{innerTables}.{innerMostTables}");
                //foreach (var innerTable1 in innerTables[0])
                //{
                //    query = query.Include(innerTable1);
                //    foreach (var innerTable2 in innerTables[1])
                //    {
                //        query = query.Then(innerTable2);
                //    }
                //}
            }
            return query;
            //var users = _context.Users.Where(user => user.IsActive == true).Include(user => user.Contacts)
            //    /*ThenInclude(contact => contact.ContactDetails)*/.ToList();

            //return users;
        }
        public T GetById(object id)
        {
            // Assuming 'T' represents the User entity
            //var query =_table;

            //query=query.Include(user => user.Contacts)
            //    .FirstOrDefault(user => user.IsActive && user.UserId == id);
            //return query;
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
    }
}
