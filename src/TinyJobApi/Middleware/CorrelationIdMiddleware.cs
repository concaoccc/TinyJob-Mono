namespace TinyJobApi.Middleware
{
    public class CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
    {
        private const string CorrelationIdHeader = "X-Correlation-ID";
        public async Task InvokeAsync(HttpContext context)
        {
            var correlationId = context.Request.Headers[CorrelationIdHeader].FirstOrDefault();
            if (string.IsNullOrEmpty(correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
                context.Request.Headers.Append(CorrelationIdHeader, correlationId);
            }
            
            context.Response.Headers.Append(CorrelationIdHeader, correlationId);
            var path = context.Request.Path.ToString().Replace(Environment.NewLine, "");
            logger.LogInformation($"Request path: {path}, CorrelationId: {correlationId}");
            await next(context);
        }
    }
}