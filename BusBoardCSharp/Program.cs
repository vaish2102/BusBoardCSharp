using BusBoard;
namespace BusBoardCSharp{
    class Program{ 
        public static async Task Main(){  
            await BusBoardOperations.GetBusStops();                   
        }
    }     
}