using Microsoft.Extensions.Configuration;

namespace BusBoardCSharp{
    class AppSettings{

        /*public AppSettings(){

        }*/
       string Api_Key = "";
       public string GetAPIKey(){
           IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
           configurationBuilder.AddJsonFile(Directory.GetCurrentDirectory()+"\\appsettings.json", false, true);
           IConfiguration config = configurationBuilder.Build();
           Api_Key = config["API_KEY"] ;
           return Api_Key;
       }
    }
}