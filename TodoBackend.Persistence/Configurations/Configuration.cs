using Microsoft.Extensions.Configuration;

namespace TodoBackend.Persistence.Configurations;

static public class Configuration
{
    static public string ConfigurationString
    {
        get
        {
            //complete
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TodoBackend.Api"));
            configurationManager.AddJsonFile("appsettings.json");
            
            return configurationManager.GetConnectionString("DefaultConnection");
        }
    }
}