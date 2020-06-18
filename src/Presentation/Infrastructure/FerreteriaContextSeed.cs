using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Presentation.Infrastructure
{
    public class FerreteriaContextSeed
    {
        public async Task SeedAsync(FerreteriaContext context, IWebHostEnvironment env, ILogger<FerreteriaContextSeed> logger)
        {
            var policy = CreatePolicy(logger, nameof(FerreteriaContextSeed));

            await policy.ExecuteAsync(async () =>
            {

                var contentRootPath = env.ContentRootPath;


                using (context)
                {

                    context.Database.EnsureCreated();

                    context.Database.Migrate();

                }
            });
        }

        private AsyncRetryPolicy CreatePolicy(ILogger<FerreteriaContextSeed> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }
    }
}
