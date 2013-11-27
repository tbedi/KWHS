using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using System.Runtime.Serialization;


namespace KrausWarehouseServices.DTO.RMA
{
    [DataContract]
    public class ReturnDTO
    {

        public ReturnDTO(Return _return)
        {
            if (_return.ReturnID != null) this.ReturnID = _return.ReturnID;
            if (_return.RMANumber != null) this.RMANumber = _return.RMANumber;
            if (_return.ShipmentNumber != null) this.ShipmentNumber = _return.ShipmentNumber;
            if (_return.OrderNumber != null) this.OrderNumber = _return.OrderNumber;
            if (_return.PONumber != null) this.PONumber = _return.PONumber;
            if (_return.OrderDate != null) this.OrderDate = (DateTime)_return.OrderDate;
            if (_return.DeliveryDate != null) this.DeliveryDat = (DateTime)_return.DeliveryDate;
            if (_return.ReturnDate != null) this.ReturnDate = (DateTime)_return.ReturnDate;
            if (_return.ReturnDate != null) this.VendorNumber = _return.VendorNumber;
            if (_return.VendoeName != null) this.VendoeName = _return.VendoeName;
            if (_return.CustomerName1 != null) this.CustomerName1 = _return.CustomerName1;
            if (_return.CustomerName2 != null) this.CustomerName2 = _return.CustomerName2;
            if (_return.Address1 != null) this.Address1 = _return.Address1;
            if (_return.Address2 != null) this.Address2 = _return.Address2;
            if (_return.Address3 != null) this.Address3 = _return.Address3;
            if (_return.ZipCode != null) this.ZipCode = _return.ZipCode;
            if (_return.City != null) this.City = _return.City;
            if (_return.State != null) this.State = _return.State;
            if (_return.Country != null) this.Country = _return.Country;
            if (_return.ReturnReason != null) this.ReturnReason = _return.ReturnReason;
            if (_return.RMAStatus != null) this.RMAStatus = _return.RMAStatus;
            if (_return.Decision != null) this.Decision = _return.Decision;
            if (_return.CreatedBy != null) this.CreatedBy = _return.CreatedBy;
            if (_return.UpdatedBy != null) this.UpdatedBy = _return.UpdatedBy;
            if (_return.CreatedDate != null) this.CreatesDate = (DateTime)_return.CreatedDate;
            if (_return.UpdatedDate != null) this.UpdatedDate = (DateTime)_return.UpdatedDate;
        }
        public ReturnDTO()
        { }

        [DataMember]
        public Guid ReturnID { get; set; }

        [DataMember]
        public string RMANumber { get; set; }

        [DataMember]
        public string ShipmentNumber { get; set; }

        [DataMember]
        public string OrderNumber { get; set; }

        [DataMember]
        public string PONumber { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public DateTime DeliveryDat { get; set; }

        [DataMember]
        public DateTime ReturnDate { get; set; }

        [DataMember]
        public string VendorNumber { get; set; }

        [DataMember]
        public string VendoeName { get; set; }

        [DataMember]
        public string CustomerName1 { get; set; }

        [DataMember]
        public string CustomerName2 { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public string Address3 { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string ReturnReason { get; set; }

        [DataMember]
        public byte? RMAStatus { get; set; }

        [DataMember]
        public byte? Decision { get; set; }

        [DataMember]
        public Guid? CreatedBy { get; set; }

        [DataMember]
        public Guid? UpdatedBy { get; set; }

        [DataMember]
        public DateTime CreatesDate { get; set; }

        [DataMember]
        public DateTime UpdatedDate { get; set; }
    }
}
