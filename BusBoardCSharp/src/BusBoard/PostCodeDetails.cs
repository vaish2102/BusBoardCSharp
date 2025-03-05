namespace BusBoard{
    class PostCodeCoordinates{
        public required string postcode { get; set; }
        public required double longitude { get; set; }
        public required double latitude { get; set; }       
    }
    class PostCodeDetails {
        public required PostCodeCoordinates result { get; set; }
    }
}