using RestSharp;
using BusBoardCSharp;

namespace BusBoard{
    class TflClient{
        static string restClientURL =  "https://api.tfl.gov.uk/StopPoint"; 
         private static readonly RestClient stopPointClient = new RestClient(new RestClientOptions(restClientURL));
         static string app_key = new EnvironmentVariableSetUp().GetAPIKey();
        
        public static async Task<List<ArrivalPredictions>> GetLiveArrivalPredictions(){
            Console.WriteLine("Enter the bus stop code:");//490008660N
            var busStopId = Console.ReadLine();
            Console.WriteLine("api_key is "+app_key);
            var request = new RestRequest(busStopId+"/Arrivals").AddQueryParameter("api_key",app_key);
            var response = await stopPointClient.GetAsync<List<ArrivalPredictions>>(request);
            if (response == null) {
                throw new Exception("Error occuring during Tfl API call");
            }
            return response;

        }

    }
}