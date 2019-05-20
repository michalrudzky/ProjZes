using System.ComponentModel.DataAnnotations;
using ProjZes.Common;

namespace ProjZes.Models
{
    public class FuelPricing
    {
        public int Id { get; set; }

        [Display(Name = Constants.Pb95)]
        public float Pb95 { get; set; }

        [Display(Name = Constants.Pb98)]
        public float Pb98 { get; set; }

        public float Diesel { get; set; }

        [Display(Name = Constants.Lpg)]
        public float Lpg { get; set; }
    }
}