
using System.ComponentModel.DataAnnotations;

namespace BusBoard{
    class BusBoardOperations{

        public static async Task GetBusBoardArrivals(string stopPointId){
            List<ArrivalPredictions> arrivalPredictions = await TflClient.GetLiveArrivalPredictions(stopPointId);
            DisplayOutput.DisplayNextFiveBuses(SortAndFilterArrivalList(arrivalPredictions));
        } 

        private static List<ArrivalPredictions> SortAndFilterArrivalList(List<ArrivalPredictions>arrivalPredictions){
            int displayRange = arrivalPredictions.Count > 5 ? 5:arrivalPredictions.Count;
            return BusBoardUtility.SortList(arrivalPredictions).GetRange(0,displayRange);
        } 

        /* private static List<StopPointList> SortAndFilterBusStopList(StopPointList[] stopPointList){
            Console.WriteLine("Count is *************"+stopPointList.Count());
            Console.WriteLine("Length is *************"+stopPointList.Length);
            int displayRange = stopPointList.Length > 2 ? 2:stopPointList.Length;
            return BusBoardUtility.SortStopPointsList(stopPointList).GetRange(0,displayRange);
        } */

       public static async Task GetBusStops(){
            PostCodeDetails postCodeDetails = await GetCoordinatesForAPostCode();
            double latitude = postCodeDetails.result.latitude;
            double longitude = postCodeDetails.result.longitude;
            string stopTypes = "NaptanPublicBusCoachTram";
             //List<StopPoints> stopPoints = await TflClient.GetStopPoints(latitude,longitude,stopTypes);
            StopPointResult stopPointResult = await GetStopPointsWithin(latitude,longitude,stopTypes);
            //SortAndFilterBusStopList(stopPointResult.stopPoints);
           foreach(var stopPoint in stopPointResult.stopPoints){
                await GetBusBoardArrivals(stopPoint.id);
            }
       }
        public static async Task <PostCodeDetails> GetCoordinatesForAPostCode(){
            PostCodeDetails postCodeDetails = await TflClient.GetCoordinates();
            return postCodeDetails;
        }

        public static async Task<StopPointResult> GetStopPointsWithin(double latitude,double longitude,string stopTypes){
           StopPointResult stopPointResult = await TflClient.GetStopPoints(latitude,longitude,stopTypes);
          return stopPointResult;
        }
    }
}