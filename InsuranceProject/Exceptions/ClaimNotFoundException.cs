using System.Net;

namespace InsuranceProject.Exceptions
{
    public class ClaimNotFoundException :Exception
    {
        public ClaimNotFoundException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
            Message = message;
        }

        public int StatusCode { get; }
        public string Message { get; }
    }
}
