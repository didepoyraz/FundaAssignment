using Polly;
using Polly.Extensions.Http;
using System.Net;

namespace FundaWeb.Policies
{
    public class RetryPolicy
    {
        public static IAsyncPolicy<HttpResponseMessage> GetFundaRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(response => response.StatusCode == HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync( 6, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                    onRetry: (outcome, timespan, attempt, context) =>
                    {
                       Console.WriteLine($"Retry {attempt} after {timespan.TotalSeconds}s due to {outcome.Exception?.Message ?? outcome.Result.StatusCode.ToString()}");
                    }
                );
        }
    }
}