using Microsoft.Extensions.Configuration;

namespace BusBoardCSharp{
    class AppSettings{

        public string Api_Key;
        public AppSettings(string api_key){
            Api_Key = api_key;
        }
       //string Api_Key = "";
       public string GetAPIKey(){
           IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
           configurationBuilder.AddJsonFile(Directory.GetCurrentDirectory()+"\\appsettings.json", false, true);
           IConfiguration config = configurationBuilder.Build();
           Api_Key = config["API_KEY"] ;
           return Api_Key;
       }
    }
}