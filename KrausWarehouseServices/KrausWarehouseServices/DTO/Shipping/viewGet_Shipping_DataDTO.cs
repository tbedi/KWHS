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
        public String Row_Number { get; set; }

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

       
    }
}
