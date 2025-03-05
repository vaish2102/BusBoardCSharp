using BusBoard;

namespace BusBoardCSharp{
    class Program{ 
        public static async Task Main(){  
           // BusBoardOperations busBoardOperations = new BusBoardOperations();
            await BusBoardOperations.GetBusStops();                   
        }
    }     
}