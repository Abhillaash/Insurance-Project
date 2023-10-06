using System.Net;

namespace InsuranceProject.Exceptions
{
    public class InsurancePolicyNotFoundException :Exception
    {
        public InsurancePolicyNotFoundException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
            Message = message;
        }

        public int StatusCode { get; }
        public string Message { get; }
    }
}
