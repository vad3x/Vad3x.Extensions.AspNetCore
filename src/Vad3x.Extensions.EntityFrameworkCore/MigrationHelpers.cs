using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace Vad3x.Extensions.EntityFrameworkCore
{
    public static class MigrationHelpers
    {
        public static Type GetDbContextType(string dbContextName)
        {
            var types = GetAllTypes(dbContextName);
            if (types.Count() != 1)
            {
                throw new ArgumentException($"problem with finding `${dbContextName}`");
            }

            return types.First();
        }

        public static IEnumerable<Type> GetAllTypes(string name)
        {
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            return runtimeAssemblyNames
                .Select(Assembly.Load)
                .SelectMany(a => a.ExportedTypes)
                .Where(t => t.Name == name);
        }

        public static string[] PendingMigrations(IWebHost webHost, Type dbContextType)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var dbContext = services.GetService(dbContextType) as DbContext;
                var migrationsAssembly = dbContext.GetService<IMigrationsAssembly>();
                var historyRepository = dbContext.GetService<IHistoryRepository>();

                var all = migrationsAssembly.Migrations.Keys;

                IEnumerable<string> pending;
                if (historyRepository.Exists())
                {
                    var applied = historyRepository.GetAppliedMigrations().Select(r => r.MigrationId);
                    pending = all.Except(applied);
                }
                else
                {
                    pending = all.Prepend("0");
                }

                return pending.ToArray();
            }
        }

        public static void Migrate(IWebHost webHost, Type dbContextType)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var dbContext = services.GetService(dbContextType) as DbContext;

                dbContext.Database.Migrate();
            }
        }
    }
}
