using DLL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Infrastructure
{
    public static class Configuration
    {
        public static void ConfigurationService(IServiceCollection serviceCollection, string connectionString, IdentityBuilder builder)
        {
            serviceCollection.AddDbContext<MainContext>(option => option.UseSqlServer(connectionString, b => b.MigrationsAssembly("OnlineCinema")));

            builder.AddEntityFrameworkStores<MainContext>();
          
        }
    }
}
