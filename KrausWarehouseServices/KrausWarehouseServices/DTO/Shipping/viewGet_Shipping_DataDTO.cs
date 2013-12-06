using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
    public class viewGet_Shipping_DataDTO
    {
        [DataMember]
        public int Row_Number { get; set; }

        [DataMember]
        public String ShipmentID { get; set; }
       
        [DataMember]
        public String SKU { get; set; }
        
        [DataMember]
        public String ItemName { get; set; }
        
        [DataMember]
        public String ProductName { get; set; }
        
        [DataMember]
        public int Quantity { get; set; }
        
        [DataMember]
        public Decimal ItemWeight { get; set; }
        
        [DataMember]
        public String UnitOfMeasure { get; set; }
        
        [DataMember]
        public Byte LineType { get; set; }
        
        [DataMember]
        public String UPCCode { get; set; }
        
        [DataMember]
        public String CountryOfOrigin { get; set; }
        
        [DataMember]
        public Decimal MAP_Price { get; set; }
        
        [DataMember]
        public String TCLCOD_0 { get; set; }
        
        [DataMember]
        public String TarrifCode { get; set; }
        
        [DataMember]
        public Byte ValidationFLG { get; set; }
        
        [DataMember]
        public String AllocationLocation { get; set; }
        
        [DataMember]
        public String ShippingLocation { get; set; }
        
        [DataMember]
        public String LocationCombined { get; set; }

        public viewGet_Shipping_DataDTO()
        {

        }

        public viewGet_Shipping_DataDTO(Connections.Shipping.Get_Shipping_Data GetShippingData)
        {
            if (GetShippingData.Row_Number != null) this.Row_Number = (int)GetShippingData.Row_Number;
            if (GetShippingData.ShipmentID != null) this.ShipmentID = GetShippingData.ShipmentID;
            if (GetShippingData.SKU != null) this.SKU = GetShippingData.SKU;
            if (GetShippingData.ItemName != null) this.ItemName = GetShippingData.ItemName;
            if (GetShippingData.ProductName != null) this.ProductName = GetShippingData.ProductName;
            if (GetShippingData.Quantity != null) this.Quantity = (int)GetShippingData.Quantity;
            this.ItemWeight = GetShippingData.ItemWeight;
            if (GetShippingData.UnitOfMeasure != null) this.UnitOfMeasure = GetShippingData.UnitOfMeasure;
            if (GetShippingData.LineType != null) this.LineType = (Byte)GetShippingData.LineType;
            if (GetShippingData.UPCCode != null) this.UPCCode = GetShippingData.UPCCode;
            if (GetShippingData.CountryOfOrigin != null) this.CountryOfOrigin = GetShippingData.CountryOfOrigin;
            if (GetShippingData.MAP_Price != null) this.MAP_Price = (Decimal)GetShippingData.MAP_Price;
            if (GetShippingData.TCLCOD_0 != null) this.TCLCOD_0 = GetShippingData.TCLCOD_0;
            if (GetShippingData.TarrifCode != null) this.TarrifCode = GetShippingData.TarrifCode;
            this.ValidationFLG = GetShippingData.ValidationFLG;
            if (GetShippingData.AllocationLocation != null) this.AllocationLocation = GetShippingData.AllocationLocation;
            if (GetShippingData.ShippingLocation != null) this.ShippingLocation = GetShippingData.ShippingLocation;
            if (GetShippingData.LocationCombined != null) this.LocationCombined = GetShippingData.LocationCombined;
        }
       
    }
}
