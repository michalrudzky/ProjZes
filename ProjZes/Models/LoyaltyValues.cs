using System.ComponentModel.DataAnnotations;
using ProjZes.Common;

namespace ProjZes.Models
{
    public class LoyaltyValues
    {
        public int Id { get; set; }

        [Display(Name = Constants.Fuel)]
        public int Fuel { get; set; }

        [Display(Name = Constants.Lpg)]
        public int Lpg { get; set; }

        [Display(Name = Constants.Washing)]
        public int Washing { get; set; }

        [Display(Name = Constants.WashingAndWaxing)]
        public int WashingPlusWaxing { get; set; }
    }
}