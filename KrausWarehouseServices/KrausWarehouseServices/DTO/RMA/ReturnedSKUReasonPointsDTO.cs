using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.RMA
{
    [DataContract]
   public class ReturnedSKUReasonPointsDTO
    {

        public ReturnedSKUReasonPointsDTO(ReturnedSKU_Reason_Points _returnPoints)
        {
            if (_returnPoints.ID != Guid.Empty) this.ID =(Guid) _returnPoints.ID;
            if (_returnPoints.ReturnID != Guid.Empty) this.ReturnID = _returnPoints.ReturnID;
            if (_returnPoints.ReturnDetailID != Guid.Empty) this.ReturnDetailID = _returnPoints.ReturnDetailID;
            if (_returnPoints.SKU != null) this.SKU = _returnPoints.SKU;
            if (_returnPoints.Reason != null) this.Reason = _returnPoints.Reason;
            if (_returnPoints.Reason_Value != null) this.Reason_Value = _returnPoints.Reason_Value;
            if (_returnPoints.Points != null) this.Points =(int) _returnPoints.Points;

            if (_returnPoints.SkuSequence != null) this.SkuSequence = (int)_returnPoints.SkuSequence;
        
        }

        public ReturnedSKUReasonPointsDTO()
        {
        }

        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public Guid? ReturnID { get; set; }

        [DataMember]
        public Guid? ReturnDetailID { get; set; }

        [DataMember]
        public string SKU { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public string Reason_Value { get; set; }

        [DataMember]
        public int? Points { get; set; }

        [DataMember]
        public int? SkuSequence { get; set; }
    }
}
