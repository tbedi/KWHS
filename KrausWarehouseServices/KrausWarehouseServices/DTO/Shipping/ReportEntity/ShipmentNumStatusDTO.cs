using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    [DataContract]
    public class ShipmentNumStatusDTO
    {
        [DataMember]
        public Guid PackageID { get; set; }
        [DataMember]
        public String ShippingNum { get; set; }
        [DataMember]
        public String Location { get; set; }
        [DataMember]
        public string ShippinStatus { get; set; }
        [DataMember]
        public int ShippingCompletedInt { get; set; }
    }
}
