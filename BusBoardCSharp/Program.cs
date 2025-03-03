using BusBoard;
namespace BusBoardCSharp{
    class Program{
        public static async Task Main(){
            var additionalInformationCategories = await TflClient.GetStopPointAdditionalInformation();
            foreach(var categoryInformation in additionalInformationCategories ){
                Console.WriteLine($"Category: {categoryInformation.category}");
                Console.WriteLine($"Available keys: {string.Join(", ", categoryInformation.availableKeys)}");

            }
        }


    }

     
}

