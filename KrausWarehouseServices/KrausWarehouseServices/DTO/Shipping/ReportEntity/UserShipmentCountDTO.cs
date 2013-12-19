using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    [DataContract]
    public class UserShipmentCountDTO
    {
        [DataMember]
        public Guid UserID { get; set; }

        [DataMember]
        public String UserName { get; set; }

        [DataMember]
        public DateTime Datepacked { get; set; }

        [DataMember]
        public int ShipmentCount { get; set; }
    }
}
