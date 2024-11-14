using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RiskTrack.Models {
    public class WorldBankEntity {
        //[Key]
        //[Required]
       // public int Id { get; set; }
        [Required]
        public string  FirmName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string FromDate{ get; set; }
        [Required]
        public string ToDate { get; set; }
        [Required]
        public string Grounds{ get; set; }
    }
}