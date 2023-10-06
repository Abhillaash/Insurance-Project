using InsuranceProject.Model.Actors;
using InsuranceProject.Repository;
using InsuranceProject.Exceptions;

namespace InsuranceProject.Service
{
    public class UserService : IUserService
    {
        private readonly IEntityRepository<User> _repository;

        public UserService(IEntityRepository<User> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<User> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }

        public User Add(User user)
        {
            _repository.Add(user);
            return user;
        }

        public User Update(User user)
        {
            if (_repository.Update(user, user.UserId) != null)
            {
                return _repository.Update(user, user.UserId);
            }
            throw new Exception("No such user found");
        }

        public bool Delete(int id)
        {
            var deleteUser = _repository.GetById(id);
            if (deleteUser != null)
            {
                deleteUser.Status = false;
                _repository.Delete(deleteUser, deleteUser.UserId);
                return true;
            }
            throw new UserNotFoundException("No such User");
        }
    }
}
