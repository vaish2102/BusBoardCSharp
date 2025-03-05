using RestSharp;
using BusBoardCSharp;
using Microsoft.Extensions.Configuration;
namespace BusBoard{
    class TflClient{
        private static readonly string restClientURL =  "https://api.tfl.gov.uk/StopPoint"; 
        private static readonly RestClient stopPointClient = new RestClient(new RestClientOptions(restClientURL));
        private static readonly string restClientURLForPostCode = "http://api.postcodes.io/postcodes/";
        private static readonly RestClient postCodeClient = new RestClient(new RestClientOptions(restClientURLForPostCode));
        private static readonly string ApiKey = new AppSettings().ApiKey;            
        public static async Task<List<ArrivalPredictions>> GetLiveArrivalPredictions(String stopPointId){
            var request = new RestRequest(stopPointId+"/Arrivals").AddQueryParameter("api_key",ApiKey);
            var response = await stopPointClient.GetAsync<List<ArrivalPredictions>>(request);
            if (response == null) {
                throw new Exception("Error occuring while fetching arrival predictions");
            }
            return response;
        }
        public static async Task <PostCodeDetails> GetCoordinates(){
            Console.WriteLine("Enter a post code ");
            var postCode = Console.ReadLine();
            var request = new RestRequest(postCode);
            var response = await postCodeClient.GetAsync <PostCodeDetails> (request);
             if (response == null) {
                throw new Exception("Error occuring while getting latitude and longitude");
            }
            return response; 
        }
        public static async Task<StopPointResult> GetStopPoints(double latitude,double longitude,string stopTypes){
            var parameters = new {
                lat = latitude,
                lon = longitude,
                stopTypes = stopTypes
            };
            var request = new RestRequest().AddObject(parameters);
            var response = await stopPointClient.GetAsync<StopPointResult>(request);
            if (response == null) {
                throw new Exception("Error occured while fetching stop points");
            }
            return response;
        }
    }
}