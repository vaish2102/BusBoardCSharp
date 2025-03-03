using RestSharp;
namespace BusBoard{
    class TflClient{
        public static readonly RestClient stopPointCient = new RestClient();
         private static readonly RestClient stopPointClient = new RestClient(new RestClientOptions("https://api.tfl.gov.uk/StopPoint"));
         public static async Task<List<AdditionalInformationCategory>> GetStopPointAdditionalInformation() {
            var request = new RestRequest("Meta/Categories");
            var response = await stopPointClient.GetAsync<List<AdditionalInformationCategory>>(request);
            if (response == null) {
                throw new Exception("Tfl API error");
            }
            return response;
        }

    }
}