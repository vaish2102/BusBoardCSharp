
namespace BusBoard{
    class DisplayOutput{
        private static void FormatOutput(){
            Console.WriteLine(" ===================================================List of Buses At the Bus Stop=============================================");   
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("| {0,-10} | {1,-45} | {2, -35} |{3, -25} |", "Bus number", "Destination","Route", "Arrival Time (in minutes)");
        }

        public static void DisplayNextFiveBuses(List<ArrivalPredictions>arrivalPredictions){
            FormatOutput();
            foreach(var predictionList in arrivalPredictions){
                Console.WriteLine("| {0,-10} | {1,-45} | {2, -35} | {3, -25}|", 
                        predictionList.lineId,
                        predictionList.towards,
                        predictionList.destinationName,
                        BusBoardUtility.TimeInMinutes(predictionList.timeToStation)
                );
            }        
            Console.ResetColor();
        }
    }
}
