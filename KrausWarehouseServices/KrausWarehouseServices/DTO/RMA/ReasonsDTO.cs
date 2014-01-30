using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections.Shipping;
namespace KrausWarehouseServices.DTO.RMA
{
    [DataContract]
    public class ReasonsDTO
    {
        public ReasonsDTO(Reason _reason)
        {
            if (_reason.ReasonID != null) this.ReasonID = _reason.ReasonID;
            if (_reason.Reason1 != null) this.Reason = _reason.Reason1;
            if (_reason.ReasonPoints != null) this.ReasonPoints = (int)_reason.ReasonPoints;
        }
        [DataMember]
        public Guid ReasonID { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public int ReasonPoints { get; set; }
    }
}
