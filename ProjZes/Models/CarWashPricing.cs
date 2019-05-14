namespace ProjZes.Models
{
    public class CarWashPricing
    {
        public int Id { get; set; }
        public float Washing { get; set; }
        public float Waxing { get; set; }
        public float WashingAndWaxing { get; set; }
        public float Polishing { get; set; }
        public float WashingAndWaxingAndPolishing { get; set; }
    }
}