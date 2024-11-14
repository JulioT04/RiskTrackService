namespace RiskTrack.DTOs{
    public class ProviderReadDTO {
        public int Id { get; set; }
        public string TradeName{ get; set; }
        public string TID{ get; set; }
        public string PhoneNumber{ get; set; }
        public string Email{ get; set; }
        public string Website{ get; set; }
        public string Address{ get; set; }
        public string Country{ get; set; }
        public decimal AnualRevenue{ get; set; }
        public DateTime LastEditedDate{ get; set; }
    }
}