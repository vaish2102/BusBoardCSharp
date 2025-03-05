using RestSharp;

namespace BusBoard{
    public class StopPointList{
        public string id{get;set;}
    }

    public class StopPointResult{
        public StopPointList[] stopPoints{get;set;}
    }
}