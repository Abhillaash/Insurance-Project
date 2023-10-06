using InsuranceProject.Repository;
using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Service
{
    public class ClaimService: IClaimService
    {
        private readonly IEntityRepository<Claim> _repository;

        public ClaimService(IEntityRepository<Claim> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<Claim> GetAllClaims()
        {
            return _repository.GetAll().ToList();
        }

        public Claim GetClaimById(int id)
        {
            return _repository.GetById(id);
        }

        public Claim AddClaim(Claim claim)
        {
            _repository.Add(claim);
            return claim;
        }

        public Claim UpdateClaim(Claim claim)
        {
            if (_repository.Update(claim, claim.ClaimId) != null)
            {
                return _repository.Update(claim, claim.ClaimId);
            }
            throw new ClaimNotFoundException("No such claim found");
        }

        public bool DeleteClaim(int id)
        {
            var deleteClaim = _repository.GetById(id);
            if (deleteClaim != null)
            {
                deleteClaim.Status = false;
                _repository.Delete(deleteClaim, deleteClaim.ClaimId);
                return true;
            }
            throw new ClaimNotFoundException("No such claim");
        }
    }
}
