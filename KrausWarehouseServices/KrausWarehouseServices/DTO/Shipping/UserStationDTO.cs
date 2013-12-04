using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
    public class UserStationDTO 
    {
        [DataMember]
        public Guid UserStationID { get; set; }
        
        [DataMember]
        public Guid StationID { get; set; }

        [DataMember]
        public Guid UserID { get; set; }

        [DataMember]
        public DateTime LoginDateTime { get; set; }

        public UserStationDTO()
        {
            //Black Constructor;
        }

        public UserStationDTO(Shipping.UserStationDTO userStation)
        {
            if (userStation.UserStationID != null) this.UserStationID = userStation.UserStationID;
            if (userStation.StationID != null) this.StationID = userStation.StationID;
            if (userStation.UserID != null) this.UserID = userStation.UserID;
            if (userStation.LoginDateTime != Convert.ToDateTime("01/01/0001")) this.LoginDateTime = userStation.LoginDateTime;
        }
    }
}
