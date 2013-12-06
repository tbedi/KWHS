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

        [DataMember]
        public Guid Updatedby { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public DateTime? CreatedDateTime { get; set; }

        [DataMember]
        public DateTime? UpdatedDateTime { get; set; }

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
            if (_station.CreatedBy != null) this.CreatedBy = (Guid)_station.CreatedBy;
            if (_station.Updatedby != null) this.Updatedby = (Guid)_station.Updatedby;
            if (_station.CreatedDateTime != Convert.ToDateTime("01/01/0001")) this.CreatedDateTime = _station.CreatedDateTime;
            if (_station.UpdatedDateTime != Convert.ToDateTime("01/01/0001")) this.UpdatedDateTime = _station.UpdatedDateTime;
        }
    }
}
