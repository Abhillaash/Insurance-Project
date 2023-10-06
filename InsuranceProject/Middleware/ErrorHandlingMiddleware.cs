using InsuranceProject.Exceptions;
using System.Net;
using System.Text.Json;
using InsuranceProject.Model;

namespace InsuranceProject.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AdminNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (EmployeeNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (AgentNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (CustomerNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (RoleNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (InsurancePolicyNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (InsuranceSchemeNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (InsurancePlanNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (SchemeDetailsNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (DocumentNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (ClaimNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (PaymentNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (QueryNotFoundException ex)
            {
                await HandleException(context, ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleException(context, (int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        private static Task HandleException(HttpContext context, int code, string message)
        {
            //var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new ErrorDetails()
            {
                StatusCode = code,
                Message = message,
            });
            context.Response.StatusCode = code;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
