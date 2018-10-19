using System;
using System.Linq;

using Microsoft.AspNetCore.Hosting;

namespace Vad3x.Extensions.EntityFrameworkCore
{
    public static class MigratorWebHostExtensions
    {
        public static string Migrator(this IWebHost webHost, string[] args)
        {
            if (args.Contains("--pending-migrations"))
            {
                var dbContextName = args.First(x => !x.StartsWith("--"));

                var pending = MigrationHelpers.PendingMigrations(webHost, MigrationHelpers.GetDbContextType(dbContextName));

                if (pending.Any())
                {
                    if (args.Contains("--first-last"))
                    {
                        var first = pending.First();
                        var last = pending.Last();

                        pending = new[] { first, last };
                    }

                    if (args.Contains("--first"))
                    {
                        pending = new[] { pending.First() };
                    }
                }

                return string.Join(" ", pending);
            }
            else if (args.Contains("--migrate"))
            {
                var dbContextName = args.First(x => !x.StartsWith("--"));

                MigrationHelpers.Migrate(webHost, MigrationHelpers.GetDbContextType(dbContextName));

                return string.Empty;
            }

            return null;
        }
    }
}
