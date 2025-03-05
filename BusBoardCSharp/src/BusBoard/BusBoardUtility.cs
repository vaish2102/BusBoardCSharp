using BusBoard;
namespace BusBoard{
    class BusBoardUtility{
        public static List<ArrivalPredictions> SortList(List<ArrivalPredictions> arrivalList){
            arrivalList.Sort((a,b) =>  a.timeToStation - b.timeToStation);
            return arrivalList;
        }
         /*public static List<StopPointList> sortStopPointsList(List<StopPointList> stopPointList){}
                stopPointList.Sort((a,b) =>  a.distance - b.distance);
            return stopPointList;

        }*/

        public static double TimeInMinutes(int timeToStation){
            return Math.Floor((double)timeToStation / 60);
        }
    }
}