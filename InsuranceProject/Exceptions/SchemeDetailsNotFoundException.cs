using System.Net;

namespace InsuranceProject.Exceptions
{
    public class SchemeDetailsNotFoundException : Exception
    {
        public SchemeDetailsNotFoundException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
            Message = message;
        }

        public int StatusCode { get; }
        public string Message { get; }
    }
}
