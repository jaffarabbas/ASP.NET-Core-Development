using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GenericRepositoryPatternApi.HealthCheck
{
    public class ApiHealthCheck : IHealthCheck
    {
        private readonly HttpClient _httpClient;

        public ApiHealthCheck(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var res = await _httpClient.GetAsync("https://localhost:7209/api/ProductWithUOW");
            if (res.IsSuccessStatusCode)
            {
                return await Task.FromResult(new HealthCheckResult(
                    status: HealthStatus.Healthy,
                    description: "Api is up and running"
                    ));
            }
            return await Task.FromResult(new HealthCheckResult(
                    status: HealthStatus.Unhealthy,
                    description: "Api is down"
                    ));
        }
    }
}
