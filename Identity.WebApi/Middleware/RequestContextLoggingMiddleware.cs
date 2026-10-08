using Nur.Store2026.Observability.Tracing;
using Serilog.Context;

namespace Identity.WebApi.Middleware;

public class RequestContextLoggingMiddleware(RequestDelegate next)
{
    public Task Invoke(HttpContext context, ITracingProvider correlationIdProvider)
    {
        using (LogContext.PushProperty("CorrelationId", correlationIdProvider.GetCorrelationId()))
        {
            return next.Invoke(context);
        }
    }
}
