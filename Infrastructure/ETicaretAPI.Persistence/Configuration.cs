using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Persistence
{
    static class Configuration
    {
        public static string ConnectionString { get
            {
                ConfigurationManager configManager = new ConfigurationManager();
                configManager.SetBasePath(
                   Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
                configManager.AddJsonFile("appsettings.json");
                return configManager.GetConnectionString("PostgreSQL");
            } }

    }
}
