using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    [DataContract]
   public class ShippingInfoBPNameDTO
    {
        [DataMember]
        public Guid ShippingID { get; set; }
        [DataMember]
        public String ShippingNumner { get; set; }
        [DataMember]
        public String BusinessPartNo { get; set; }
        [DataMember]
        public String BPName { get; set; }
        [DataMember]
        public String ShippingStatus { get; set; }
    }
}
