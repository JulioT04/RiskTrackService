using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RiskTrack.Models {
    public class OFACEntity {
        public string  Name { get; set; }
        
        public string Address { get; set; }
        
        public string Type{ get; set; }
        
        public string Programs { get; set; }
        
        public string List{ get; set; }
        
        public string Score{ get; set; }
        
    }
}