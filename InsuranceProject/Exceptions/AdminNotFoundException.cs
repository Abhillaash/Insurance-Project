using System.Net;

namespace InsuranceProject.Exceptions
{
    public class AdminNotFoundException :Exception
    {
        public AdminNotFoundException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
            Message = message;
        }

        public int StatusCode { get; }
        public string Message { get; }
    }
}
