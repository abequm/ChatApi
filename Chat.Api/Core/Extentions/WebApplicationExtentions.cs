using Chat.Api.Core.ExceptionsRequests;
using Chat.Api.Core.Middleware;

namespace Chat.Api.Core.Extentions
{
    public static class WebApplicationExtentions
    {
        public static WebApplication UseExceptions(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
        public static IMvcBuilder ConfigureValidation(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (errorContext) =>
                {
                    var errors = errorContext.ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray();
                    throw new InvalidModelException(errors);
                };
            });
            return builder;
        }
    }
}
