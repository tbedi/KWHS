using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    [DataContract]
     public class ShipmentPackedTodayAndAvgTimeDTO
    {
        [DataMember]
        public Guid UserID { get; set; }
        [DataMember]
        public int Packed { get; set; }
    }
}
