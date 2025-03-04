using Microsoft.Extensions.Configuration;

namespace BusBoardCSharp{
    class EnvironmentVariableSetUp{
       string api_key = "";
       public string GetAPIKey(){
           IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
           configurationBuilder.AddJsonFile(Directory.GetCurrentDirectory()+"\\appsettings.json", false, true);
           IConfiguration config = configurationBuilder.Build();
           api_key = config["API_KEY"] ;
           return api_key;
       }
    }
}