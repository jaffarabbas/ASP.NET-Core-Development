namespace GlobalErrorHandling.Confriguations
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Custom Error Handler Middleware
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <returns></returns>
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<GlobalExceptionsHandlingMiddleware>();
    }
}
