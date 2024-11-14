using System.ComponentModel.DataAnnotations;

namespace RiskTrack.Util
{
    public enum DatabaseEnum
    {
        [Display(Name = "WORLD BANK")]
        WorldBank,

        [Display(Name = "OFAC")]
        Ofac,

        [Display(Name = "OFFSHORE LEAKS")]
        OffshoreLeaks
    }
}
