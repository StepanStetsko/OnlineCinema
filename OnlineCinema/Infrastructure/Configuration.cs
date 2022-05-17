using BLL.Services;

namespace OnlineCinema.Infrastructure
{
    public class Configuration
    {
        public static void ConfigurationService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UserService>();
            serviceCollection.AddTransient<SeasonService>();
        }
    }
}
