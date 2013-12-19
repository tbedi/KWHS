using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    [DataContract]
    public class PackingTimeDTO
    {
        [DataMember]
        public Guid PackingID { get; set; }

        [DataMember]
        public String ShippingNumber { get; set; }

        [DataMember]
        public String TimeSpend { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }
}
