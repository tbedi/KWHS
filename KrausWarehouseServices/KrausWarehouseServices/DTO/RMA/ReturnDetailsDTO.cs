using KrausWarehouseServices.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.RMA
{
    [DataContract]
   public class ReturnDetailsDTO
    {
        public ReturnDetailsDTO(ReturnDetail ReturnDetails)
        {
            if (ReturnDetails.ReturnDetailID != Guid.Empty) this.ReturnDetailID = ReturnDetails.ReturnDetailID;
            if (ReturnDetails.ReturnID != Guid.Empty) this.ReturnID = ReturnDetails.ReturnID;
            if (ReturnDetails.SKUNumber != null) this.SKUNumber = ReturnDetails.SKUNumber;
            if (ReturnDetails.ProductName != null) this.ProductName = ReturnDetails.ProductName;
            if (ReturnDetails.TCLCOD_0 != null) this.TCLCOD_0 = ReturnDetails.TCLCOD_0;
            if (ReturnDetails.DeliveredQty != null) this.DeliveredQty = (int)ReturnDetails.DeliveredQty;
            if (ReturnDetails.ExpectedQty != null) this.ExpectedQty = (int)ReturnDetails.ExpectedQty;
            if (ReturnDetails.ReturnQty != null) this.ReturnQty = (int)ReturnDetails.ReturnQty;
            if (ReturnDetails.ProductStatus != null) this.ProductStatus = (int)ReturnDetails.ProductStatus;
            if (ReturnDetails.CreatedBy != Guid.Empty) this.CreatedBy = (Guid)ReturnDetails.CreatedBy;
            if (ReturnDetails.UpdatedBy != Guid.Empty) this.UpdatedBy = (Guid)ReturnDetails.UpdatedBy;
            if (ReturnDetails.CreatedDate != null) this.CreatedDate = (DateTime)ReturnDetails.CreatedDate;
            if (ReturnDetails.UpadatedDate != null) this.UpadatedDate = (DateTime)ReturnDetails.UpadatedDate;
        }

        public ReturnDetailsDTO()
        {

        }

        [DataMember]
        public Guid ReturnDetailID { get; set; }

        [DataMember]
        public Guid ReturnID { get; set; }

        [DataMember]
        public String SKUNumber { get; set; }

        [DataMember]
        public String ProductName { get; set; }

        [DataMember]
        public String TCLCOD_0 { get; set; }

        [DataMember]
        public int DeliveredQty { get; set; }

        [DataMember]
        public int ExpectedQty { get; set; }

        [DataMember]
        public int ReturnQty { get; set; }

        [DataMember]
        public int ProductStatus { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public Guid UpdatedBy { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public DateTime UpadatedDate { get; set; }
    }

}