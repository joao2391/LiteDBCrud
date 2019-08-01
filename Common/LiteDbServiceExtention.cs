using Exemplo_LiteDB.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Exemplo_LiteDB.Common
{
    public static class LiteDbServiceExtention
    {
        public static void AddLiteDb(this IServiceCollection services, string databasePath)
        {
            services.AddTransient<LiteDbContext, LiteDbContext>();

            services.Configure<MyConfig>(options => options.PathToDB = databasePath);
        }
    }
}
