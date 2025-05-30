using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;

namespace Object.Storage.Infra.Storage.Minio
{
    public static class MinioConfig
    {
        public static IServiceCollection AddMinioStorage(this IServiceCollection services, IConfiguration configuration)
        {
            var minioOptions = configuration.GetSection("Minio").Get<MinioOptions>();
            if (minioOptions == null)
            {
                ArgumentNullException argumentNullException = new(nameof(minioOptions), "Minio options are not configured in the appsettings.");
                throw argumentNullException;
            }
            services.AddMinio(configureClient => configureClient
                .WithEndpoint(minioOptions.Endpoint)                
                .WithCredentials(minioOptions.AcessKey, minioOptions.SecretKey)
                .WithSSL(false)
                .Build());

            services.AddScoped<IStorageProvider, MinioStorageProvider>();
            return services;
        }
    }
}
