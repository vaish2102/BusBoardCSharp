using BusBoard;
namespace BusBoard{
    class BusBoardUtility{
        public static List<ArrivalPredictions> SortList(List<ArrivalPredictions> arrivalList,string sortParam){
            if(sortParam == "Arrivals"){
                arrivalList.Sort((a,b) =>  a.timeToStation - b.timeToStation);
            }
            else{
                return null;
            }
            return arrivalList;

        }

        public static double TimeInMinutes(int timeToStation){
            return Math.Floor((double)timeToStation / 60);
        }
    }
}