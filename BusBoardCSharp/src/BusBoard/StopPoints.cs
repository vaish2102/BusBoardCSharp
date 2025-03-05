using RestSharp;
namespace BusBoard{
    public class StopPoints{
        public required string id { get; set; }
        public required double distance { get; set; }
        public required string commonName{get;set;}
    }
    public class StopPointResult{
        public required List <StopPoints> stopPoints{get;set;}
    }
}