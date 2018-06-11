using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace DDD.Web.WebInfrastructure
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is DbUpdateConcurrencyException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.Conflict);
            }
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return Task.Run(() => OnException(actionExecutedContext), cancellationToken);
        }
    }
}