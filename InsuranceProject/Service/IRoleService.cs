using InsuranceProject.Model.Actors;
using InsuranceProject.Repository;
using System.IO;

namespace InsuranceProject.Service
{
    public interface IRoleService
    {
        
        public List<Role> GetAllRoles()
        ;

        public Role GetRoleById(int id)
        ;

        public Role AddRole(Role role)
        ;

        public Role UpdateRole(Role role)
        ;

        public bool DeleteRole(int id)
        ;
    }
}
