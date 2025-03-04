
namespace BusBoard{
    class BusBoardOperations{

        public async Task GetBusBoardArrivals(){
            try{
                List<ArrivalPredictions> arrivalPredictions = await TflClient.GetLiveArrivalPredictions();
                DisplayOutput displayOutput = new DisplayOutput();
                displayOutput.DisplayNextFiveBuses(SortAndFilterList(arrivalPredictions));
            }
            catch(Exception exception){
                Console.WriteLine(exception.Message);
            }
        } 

        private List<ArrivalPredictions> SortAndFilterList(List<ArrivalPredictions>arrivalPredictions){
            int displayRange = arrivalPredictions.Count > 5 ? 5:arrivalPredictions.Count;
            return BusBoardUtility.sortList(arrivalPredictions,"Arrivals").GetRange(0,displayRange);
        } 
    }
}