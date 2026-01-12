namespace NetworkingDemo.API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public RequestLoggingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            System.Console.WriteLine($"Request: {context.Request.Method}, {context.Request.Path}");

            await _requestDelegate(context);

            System.Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}