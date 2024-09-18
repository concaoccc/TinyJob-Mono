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
            logger.LogInformation($"Request path: {context.Request.Path}, CorrelationId: {correlationId}");
            await next(context);
        }
    }
}