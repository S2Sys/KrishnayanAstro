using KrishnyanAstro.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace KrishnyanAstro.Shared
{
  

    public static class DIWrapper
    {
        public static IServiceCollection AddAdoNetHelper(
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName = "DefaultConnection",
            DbProviderFactory dbProviderFactory = null)
        {
            // Register DbProviderFactory if not provided
            if (dbProviderFactory == null)
            {
                services.AddSingleton<DbProviderFactory>(SqlClientFactory.Instance);
            }
            else
            {
                services.AddSingleton(dbProviderFactory);
            }

            // Register AdoNetHelper
            services.AddScoped<AdoNetHelper>(sp =>
            {
                var connectionString = configuration.GetConnectionString(connectionStringName);
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException($"Connection string '{connectionStringName}' not found.");
                }

                var factory = sp.GetRequiredService<DbProviderFactory>();
                return new AdoNetHelper(connectionString, factory);
            });

            return services;
        }
    }
}
