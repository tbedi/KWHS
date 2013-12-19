using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    [DataContract]
    public class StationToatlPackedDTO
    {
        [DataMember]
        public Guid StationID { get; set; }
        [DataMember]
        public String StationName { get; set; }
        [DataMember]
        public int TotalPacked { get; set; }
        [DataMember]
        public int PartiallyPacked { get; set; }
    }
}
