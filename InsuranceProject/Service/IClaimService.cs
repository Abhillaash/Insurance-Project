using InsuranceProject.Repository;
using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Service
{
    public interface IClaimService
    {
        

        public List<Claim> GetAllClaims()
        ;

        public Claim GetClaimById(int id)
        ;

        public Claim AddClaim(Claim claim)
        ;

        public Claim UpdateClaim(Claim claim)
        ;

        public bool DeleteClaim(int id)
        ;
    }
}
