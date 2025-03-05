namespace BusBoard{
    class BusBoardOperations{
        public static async Task GetBusBoardArrivals(string stopPointId,string busStopName){
            List<ArrivalPredictions> arrivalPredictions = await TflClient.GetLiveArrivalPredictions(stopPointId);
            DisplayOutput.DisplayNextFiveBuses(SortAndFilterArrivalList(arrivalPredictions),busStopName);
        } 
        private static List<ArrivalPredictions> SortAndFilterArrivalList(List<ArrivalPredictions>arrivalPredictions){
            int displayRange = arrivalPredictions.Count > 5 ? 5:arrivalPredictions.Count;
            return BusBoardUtility.SortList(arrivalPredictions).GetRange(0,displayRange);
        }   
        private static List<StopPoints> SortAndFilterBusStopList(List<StopPoints> stopPoints){
            int displayRange = stopPoints.Count > 2 ? 2:stopPoints.Count;
            return BusBoardUtility.SortStopPointsList(stopPoints).GetRange(0,displayRange);
        } 
       public static async Task GetBusStops(){
            PostCodeDetails postCodeDetails = await GetCoordinatesForAPostCode();
            double latitude = postCodeDetails.result.latitude;
            double longitude = postCodeDetails.result.longitude;
            string stopTypes = "NaptanPublicBusCoachTram";
            StopPointResult stopPointResult = await GetStopPointsWithin(latitude,longitude,stopTypes);
            List<StopPoints> sortedStopPointList = SortAndFilterBusStopList(stopPointResult.stopPoints);
           foreach(var stopPoint in sortedStopPointList){
                await GetBusBoardArrivals(stopPoint.id,stopPoint.commonName);
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