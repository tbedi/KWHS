using KrausWarehouseServices.Connections.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.RMA
{
    [DataContract]
   public class SKUReasonsDTO
    {
        public SKUReasonsDTO(SKUReason SKUReasons)
        {
            if (SKUReasons.SKUReasonID != Guid.Empty) this.SKUReasonID = SKUReasons.SKUReasonID;
            if (SKUReasons.ReasonID != Guid.Empty) this.ReasonID = (Guid)SKUReasons.ReasonID;
            if (SKUReasons.ReturnDetailID != Guid.Empty) this.ReturnDetailID = (Guid)SKUReasons.ReturnDetailID;
        }

        public SKUReasonsDTO()
        {

        }

        [DataMember]
        public Guid SKUReasonID { get; set; }
        
        [DataMember]
        public Guid ReasonID { get; set; }
        
        [DataMember]
        public Guid ReturnDetailID { get; set; }

    }
}
