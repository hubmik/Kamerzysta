namespace Domain.Entities
{
    public class CameraEntity
    {
        public int Number { get; set; }
        public string FullName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set;}

        public CameraEntity()
        {
            if (Latitude < -90 || Latitude > 90)
                throw new ArgumentOutOfRangeException($"Latitude is out of valid range.");
            if (Longitude < -180 || Longitude > 180)
                throw new ArgumentOutOfRangeException($"Longitude is out of valid range.");
        }
    }
}
