using Microsoft.Extensions.Configuration;

namespace BusBoardCSharp{
    public class AppSettings{
        public string ApiKey{get;}
         public AppSettings(){
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
              configurationBuilder.AddJsonFile(Directory.GetCurrentDirectory()+"\\appsettings.json", false, true);
              IConfiguration config = configurationBuilder.Build();
              ApiKey = config["API_KEY"];
          }
    }
}