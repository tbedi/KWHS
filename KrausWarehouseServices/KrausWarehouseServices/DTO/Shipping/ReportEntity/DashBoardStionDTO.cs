using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    [DataContract]
    public class DashBoardStionDTO
    {
        [DataMember]
        public String StationName { get; set; }

        [DataMember]
        public int ErrorCaught { get; set; }

        [DataMember]
        public int TotalPacked { get; set; }

        [DataMember]
        public String packagePerhr { get; set; }

        [DataMember]
        public String ShipmentNumber { get; set; }
        
        [DataMember]
        public String PackerName { get; set; }
    }
}
