using InsuranceProject.Model.Actors;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public interface IAgentService
    {


        public List<Agent> GetAll()
        ;

        public Agent GetById(int id)
        ;

        public Agent Add(Agent agent)
        ;

        public Agent Update(Agent agent)
        ;
        public bool Delete(int id);
    }
}
