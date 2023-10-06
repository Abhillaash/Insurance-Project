using InsuranceProject.Model.Actors;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public class AgentService : IAgentService
    {
        private readonly IEntityRepository<Agent> _repository;

        public AgentService(IEntityRepository<Agent> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<Agent> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Agent GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Agent Add(Agent agent)
        {
            _repository.Add(agent);
            return agent;
        }

        public Agent Update(Agent agent)
        {
            if (_repository.Update(agent, agent.AgentId) != null)
            {
                return _repository.Update(agent, agent.AgentId);
            }
            throw new AgentNotFoundException("No such agent found");
        }
        public bool Delete(int id)
        {
            var deleteAgent = _repository.GetById(id);
            if (deleteAgent != null)
            {
                deleteAgent.Status = false;
                _repository.Delete(deleteAgent, deleteAgent.AgentId);
                return true;
            }
            throw new AgentNotFoundException("No such agent");
        }


    }
}
