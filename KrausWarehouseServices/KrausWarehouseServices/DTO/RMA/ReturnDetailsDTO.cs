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

            if (ReturnDetails.SKU_Status != null) this.SKU_Status = ReturnDetails.SKU_Status;
            if (ReturnDetails.SKU_Reason_Total_Points != null) this.SKU_Reason_Total_Points = (int)ReturnDetails.SKU_Reason_Total_Points;
            if (ReturnDetails.IsSkuScanned != null) this.IsSkuScanned = (int)ReturnDetails.IsSkuScanned;
            if (ReturnDetails.IsManuallyAdded != null) this.IsManuallyAdded = (int)ReturnDetails.IsManuallyAdded;

            if (ReturnDetails.SKU_Sequence != null) this.SKU_Sequence = (int)ReturnDetails.SKU_Sequence;
            if (ReturnDetails.SKU_Qty_Seq != null) this.SKU_Qty_Seq = (int)ReturnDetails.SKU_Qty_Seq;


            if (ReturnDetails.CreatedDate != null) this.CreatedDate = (DateTime)ReturnDetails.CreatedDate;
            if (ReturnDetails.UpadatedDate != null) this.UpadatedDate = (DateTime)ReturnDetails.UpadatedDate;
            if (ReturnDetails.RGADROWID != null) this.RGADROWID = ReturnDetails.RGADROWID;
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

        [DataMember]
        public string RGADROWID { get; set; }

        [DataMember]
        public string SKU_Status { get; set; }

        [DataMember]
        public int SKU_Reason_Total_Points { get; set; }

        [DataMember]
        public int IsSkuScanned { get; set; }

        [DataMember]
        public int IsManuallyAdded { get; set; }

        [DataMember]
        public int SKU_Sequence { get; set; }

        [DataMember]
        public int SKU_Qty_Seq { get; set; }
    }

}