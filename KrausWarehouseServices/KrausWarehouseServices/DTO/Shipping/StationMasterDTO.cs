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
    public class StationMasterDTO
    {
        /// <summary>
        /// Blank Constructor.
        /// </summary>
        public StationMasterDTO()
        {
        }

        /// <summary>
        /// Paramiterised Conctructor. 
        /// </summary>
        /// <param name="_station">
        /// Pass Station Object.
        /// </param>
        public StationMasterDTO(Connections.Shipping.Station _station)
        {
            if (_station.StationID != null) this.StationID = (Guid)_station.StationID;
            if (_station.StationName != null) this.StationName = (String)_station.StationName;
            if (_station.RequestedUserID != null) this.RequestedUserID = (Guid)_station.RequestedUserID;
            this.StationAlive = _station.StationAlive;
            if (_station.DeviceNumber != null) this.DeviceNumber = (String)_station.DeviceNumber;
            if (_station.StationLocation != null) this.StaionLocation = (String)_station.StationLocation;
            if (_station.RegistrationDate != Convert.ToDateTime("01/01/0001")) this.RegistrationDate = (DateTime)_station.RegistrationDate;
        }

        [DataMember]
        public Guid StationID { get; set; }

        [DataMember]
        public string StationName { get; set; }

        [DataMember]
        public Guid RequestedUserID { get; set; }

        [DataMember]
        public int StationAlive { get; set; }

        [DataMember]
        public string DeviceNumber { get; set; }

        [DataMember]
        public String StaionLocation { get; set; }

        [DataMember]
        public DateTime RegistrationDate { get; set; }
    }
}
