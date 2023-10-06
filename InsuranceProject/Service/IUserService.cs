using InsuranceProject.Model.Actors;

namespace InsuranceProject.Service
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        User Add(User user);
        User Update(User user);
        bool Delete(int id);
    }
}
