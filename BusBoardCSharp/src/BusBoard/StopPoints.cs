using RestSharp;

namespace BusBoard{
    public class StopPointList{
        public required string id { get; set; }
        public double distance { get; set; }
    }

    public class StopPointResult{
        public required List <StopPointList> stopPoints{get;set;}
    }
}