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

        [DataMember]
        public DateTime CreatedDateTime { get; set; }
       
        [DataMember]
        public DateTime UpdatedDateTime { get; set; }
        
        [DataMember]
        public Guid CreatedBy { get; set; }
        
        [DataMember]
        public Guid Updatedby { get; set; }

        public UserStationDTO()
        {
            //Black Constructor;
        }

        public UserStationDTO(Connections.Shipping.UserStation userStation)
        {
            if (userStation.UserStationID != null) this.UserStationID = userStation.UserStationID;
            if (userStation.StationID != null) this.StationID = userStation.StationID;
            if (userStation.UserID != null) this.UserID = userStation.UserID;
            if (userStation.LoginDateTime != null) this.LoginDateTime = userStation.LoginDateTime;
            if (userStation.CreatedDateTime != null) this.CreatedDateTime = (DateTime)userStation.CreatedDateTime;
            if (userStation.UpdatedDateTime !=null) this.UpdatedDateTime = (DateTime)userStation.UpdatedDateTime;
            if (userStation.Updatedby != null) this.Updatedby = (Guid)userStation.Updatedby;
            if (userStation.CreatedBy != null) this.CreatedBy = (Guid)userStation.CreatedBy;
        }

        public UserStationDTO GetShallowCopy()
        {
            return (UserStationDTO)this.MemberwiseClone();
        }
    }
}
