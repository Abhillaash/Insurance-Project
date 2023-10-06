using InsuranceProject.Model.Actors;
using InsuranceProject.Repository;
using InsuranceProject.Exceptions;
using System.IO;

namespace InsuranceProject.Service
{
    public class RoleService : IRoleService
    {
        private readonly IEntityRepository<Role> _repository;

        public RoleService(IEntityRepository<Role> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<Role> GetAllRoles()
        {
            return _repository.GetAll().ToList();
        }

        public Role GetRoleById(int id)
        {
            return _repository.GetById(id);
        }

        public Role AddRole(Role role)
        {
            _repository.Add(role);
            return role;
        }

        public Role UpdateRole(Role role)
        {
            if (_repository.Update(role, role.RoleId) != null)
            {
                return _repository.Update(role, role.RoleId);
            }
            throw new Exception("No such role found");
        }

        public bool DeleteRole(int id)
        {
            var deleteRole = _repository.GetById(id);
            if (deleteRole != null)
            {
                deleteRole.Status = false;
                _repository.Delete(deleteRole, deleteRole.RoleId);
                return true;
            }
            throw new RoleNotFoundException("No such role");
        }
    }
}
