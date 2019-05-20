using System.ComponentModel.DataAnnotations;
using ProjZes.Common;

namespace ProjZes.Models
{
    public class CarWashPricing
    {
        public int Id { get; set; }

        [Display(Name = Constants.Washing)]
        public float Washing { get; set; }

        [Display(Name = Constants.Waxing)]
        public float Waxing { get; set; }

        [Display(Name = Constants.WashingAndWaxing)]
        public float WashingAndWaxing { get; set; }

        [Display(Name = Constants.Polishing)]
        public float Polishing { get; set; }

        [Display(Name = Constants.WashingAndWaxingAndPolishing)]
        public float WashingAndWaxingAndPolishing { get; set; }
    }
}