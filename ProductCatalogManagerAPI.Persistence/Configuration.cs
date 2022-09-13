using Microsoft.Extensions.Configuration;

namespace ProductCatalogManagerAPI.Persistence
{
    /// <summary>
    /// static class that operates appsettings.json configurations
    /// </summary>
    internal static class Configuration
    {
        /// <summary>
        /// ConnectionString property that gates appsettings.json values
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("SqlConnection");
            }
        }
    }
}