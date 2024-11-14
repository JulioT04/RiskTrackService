using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RiskTrack.Models {
    public class OffshoreLeaksEntity {
        //public int Id { get; set; }

        public string Entity { get; set; }

        public string Jurisdiction { get; set; }

        public string LinkedTo{ get; set; }

        public string DataFrom{ get; set; }

    }
}