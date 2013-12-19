using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    [DataContract]
    public class UserCurrentStationAndDeviceIDDTO
    {
        [DataMember]
        public Guid UserID { get; set; }

        [DataMember]
        public String UserName { get; set; }

        [DataMember]
        public String StationName { get; set; }

        [DataMember]
        public String DeviceID { get; set; }

        [DataMember]
        public String Datetime { get; set; }
    }
}
