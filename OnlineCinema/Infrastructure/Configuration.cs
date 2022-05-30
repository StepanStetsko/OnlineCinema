using BLL.Services;
using Microsoft.AspNetCore.Identity;

namespace OnlineCinema.Infrastructure
{
    public class Configuration
    {
        public static void ConfigurationService(IdentityBuilder serviceCollection)
        {
            serviceCollection.Services.AddTransient<UserService>();
            serviceCollection.Services.AddTransient<SeasonService>();
            serviceCollection.Services.AddTransient<GenreService>();
            serviceCollection.Services.AddTransient<MovieService>();
            serviceCollection.Services.AddTransient<PersonService>();
        }
    }
}
