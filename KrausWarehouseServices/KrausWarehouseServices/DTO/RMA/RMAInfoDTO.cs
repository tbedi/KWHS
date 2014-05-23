using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections;

namespace KrausWarehouseServices.DTO.RMA
{
    [DataContract]
    public class RMAInfoDTO
    {
        public RMAInfoDTO(RMAInfoDTO _sage)
        {
            if (_sage.RMANumber != null) this.RMANumber = (string)_sage.RMANumber;
            if (_sage.ShipmentNumber != null) this.ShipmentNumber = (string)_sage.ShipmentNumber;
            if (_sage.OrderNumber != null) this.OrderNumber = (string)_sage.OrderNumber;
            if (_sage.PONumber != null) this.PONumber = (string)_sage.PONumber;
            if (_sage.OrderDate != null) this.OrderDate = (DateTime)_sage.OrderDate;
            if (_sage.DeliveryDate != null) this.DeliveryDate = (DateTime)_sage.DeliveryDate;
            if (_sage.ReturnDate != null) this.ReturnDate = (DateTime)_sage.ReturnDate;
            if (_sage.VendorNumber != null) this.VendorNumber = (string)_sage.VendorNumber;
            if (_sage.VendorName != null) this.VendorName = (string)_sage.VendorName;
            if (_sage.SKUNumber != null) this.SKUNumber = (string)_sage.SKUNumber;
            if (_sage.ProductName != null) this.ProductName = (string)_sage.ProductName;
            this.DeliveredQty = (int)_sage.DeliveredQty;
            this.ExpectedQty = (int)_sage.ExpectedQty;
            this.ReturnedQty = (int)_sage.ReturnedQty;
            if (_sage.CustomerName1 != null) this.CustomerName1 = (string)_sage.CustomerName1;
            if (_sage.CustomerName2 != null) this.CustomerName2 = (string)_sage.CustomerName2;
            if (_sage.Address1 != null) this.Address1 = (string)_sage.Address1;
            if (_sage.Address2 != null) this.Address2 = (string)_sage.Address2;
            if (_sage.Address3 != null) this.Address3 = (string)_sage.Address3;
            if (_sage.ZipCode != null) this.ZipCode = (string)_sage.ZipCode;
            if (_sage.City != null) this.City = (string)_sage.City;
            if (_sage.State != null) this.State = (string)_sage.State;
            if (_sage.Country != null) this.Country = (string)_sage.Country;
            if (_sage.TCLCOD_0 != null) this.TCLCOD_0 = (string)_sage.TCLCOD_0;
            this.SKU_Sequence = (int)_sage.SKU_Sequence;
            this.SKU_Qty_Seq = (int)_sage.SKU_Qty_Seq;

        }

        public RMAInfoDTO()
        { 
        
        }
        [DataMember]
        public string RMANumber { get; set; }

        [DataMember]
        public string ShipmentNumber { get; set; }

        [DataMember]
        public string OrderNumber { get; set; }

        [DataMember]
        public String PONumber { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public DateTime DeliveryDate { get; set; }

        [DataMember]
        public DateTime ReturnDate { get; set; }

        [DataMember]
        public String VendorNumber { get; set; }

        [DataMember]
        public String VendorName { get; set; }

        [DataMember]
        public String SKUNumber { get; set; }

        [DataMember]
        public String ProductName { get; set; }

        [DataMember]
        public int DeliveredQty { get; set; }

        [DataMember]
        public int ExpectedQty { get; set; }

        [DataMember]
        public int ReturnedQty { get; set; }

        [DataMember]
        public String CustomerName1 { get; set; }

        [DataMember]
        public String CustomerName2 { get; set; }

        [DataMember]
        public String Address1 { get; set; }

        [DataMember]
        public String Address2 { get; set; }

        [DataMember]
        public String Address3 { get; set; }

        [DataMember]
        public String ZipCode { get; set; }

        [DataMember]
        public String City { get; set; }

        [DataMember]
        public String State { get; set; }

        [DataMember]
        public String Country { get; set; }

        [DataMember]
        public string TCLCOD_0 { get; set; }

        [DataMember]
        public int SKU_Sequence { get; set; }

        [DataMember]
        public int SKU_Qty_Seq { get; set; }

    }
}
