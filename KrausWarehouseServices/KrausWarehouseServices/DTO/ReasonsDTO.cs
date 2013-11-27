using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections;

namespace KrausWarehouseServices.DTO
{
    [DataContract]
  public  class ReasonsDTO
    {
      public ReasonsDTO(Reason _reason)
      {
        if(_reason.ReasonID!=null) this.ReasonID = _reason.ReasonID;
        if (_reason.Reason1 != null) this.Reason = _reason.Reason1;
      }
        [DataMember]
      public Guid ReasonID { get; set; }

        [DataMember]
      public string Reason { get; set; }
    }
}
