using ProjetWebApi.Data.DatabaseContext;
using ProjetWebApi.Repositories;

namespace ProjetWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Enregistre UserRepository comme service
            services.AddSingleton<UserRepository>();

            // Enregistre DataContext et autres services nécessaires
            services.AddScoped<DataContext>();
        }
    }
}
