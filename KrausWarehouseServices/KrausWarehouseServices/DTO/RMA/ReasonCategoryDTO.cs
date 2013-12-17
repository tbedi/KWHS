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
   public  class ReasonCategoryDTO
    {
        public ReasonCategoryDTO(ReasonCategory _reason)
        {
            if (_reason.ReasonCatID != Guid.Empty) this.ReasonCatID =(Guid) _reason.ReasonCatID;
            if (_reason.ReasonID != Guid.Empty) this.ReasonID = (Guid)_reason.ReasonID;
            if(_reason.CategoryName!=null) this.CategoryName=(string)_reason.CategoryName;
        }

        [DataMember]
        public Guid ReasonCatID { get; set; }

        [DataMember]
        public Guid ReasonID { get; set; }

        [DataMember]
        public string CategoryName { get; set; }
    }
}
