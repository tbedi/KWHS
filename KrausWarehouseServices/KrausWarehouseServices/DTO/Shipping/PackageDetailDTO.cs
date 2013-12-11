using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
    public class PackageDetailDTO
    {
        /// <summary>
        /// Blank Conatructor.
        /// </summary>
        public PackageDetailDTO()
        {
        }

        [DataMember]
        public Guid PackagedetailID { get; set; }

        [DataMember]
        public Guid PackingId { get; set; }

        [DataMember]
        public String SKUNumber { get; set; }

        [DataMember]
        public int SKUQuantity { get; set; }

        [DataMember]
        public String BoxNumber { get; set; }

        [DataMember]
        public String ShipmentLocation { get; set; }

        [DataMember]
        public String ItemName { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public String UnitOfMeasure { get; set; }

        [DataMember]
        public string CountryOfOrigin { get; set; }

        [DataMember]
        public Decimal MAP_Price { get; set; }

        [DataMember]
        public String TCLCOD_0 { get; set; }

        [DataMember]
        public String TarrifCode { get; set; }


        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public Guid UpdatedBy { get; set; }

        [DataMember]
        public DateTime UpdatedDateTime { get; set; }

        [DataMember]
        public DateTime CreatedDateTime { get; set; }

        [DataMember]
        public DateTime SKUScanDateTime { get; set; }
        /// <summary>
        /// Paramiterised Constructor.
        /// </summary>
        /// <param name="_packagedetail">
        /// Pass Object of PackageDetial.
        /// </param>
        
        public PackageDetailDTO(Connections.Shipping.PackageDetail _packagedetail)
        {
            if (_packagedetail.PackingDetailID != null) this.PackagedetailID = (Guid)_packagedetail.PackingDetailID;
            if (_packagedetail.PackingId != null) this.PackingId = (Guid)_packagedetail.PackingId;
            if (_packagedetail.SKUNumber != null) this.SKUNumber = (String)_packagedetail.SKUNumber;
            this.SKUQuantity = (int)_packagedetail.SKUQuantity;
            if (_packagedetail.BoxNumber != null) this.BoxNumber = (String)_packagedetail.BoxNumber;
            if (_packagedetail.ShipmentLocation != null) this.ShipmentLocation = (String)_packagedetail.ShipmentLocation;
            if (_packagedetail.ItemName != null) this.ItemName = (String)_packagedetail.ItemName;
            if (_packagedetail.ProductName != null) this.ProductName = (String)_packagedetail.ProductName;
            if (_packagedetail.UnitOfMeasure != null) this.UnitOfMeasure = (String)_packagedetail.UnitOfMeasure;
            if (_packagedetail.CountryOfOrigin != null) this.CountryOfOrigin = (String)_packagedetail.CountryOfOrigin;
            if (_packagedetail.MAP_Price != null) this.MAP_Price = (decimal)_packagedetail.MAP_Price;
            if (_packagedetail.TCLCOD_0 != null) this.TCLCOD_0 = (string)_packagedetail.TCLCOD_0;
            if (_packagedetail.TarrifCode != null) this.TarrifCode = (string)_packagedetail.TarrifCode;
            if (_packagedetail.CreatedBy != null) this.CreatedBy = (Guid)_packagedetail.CreatedBy;
            if (_packagedetail.Updatedby != null) this.UpdatedBy = (Guid)_packagedetail.Updatedby;
            if (_packagedetail.CreatedDateTime != null) this.CreatedDateTime = (DateTime)_packagedetail.CreatedDateTime;
            if (_packagedetail.UpdatedDateTime != null) this.UpdatedDateTime = (DateTime)_packagedetail.UpdatedDateTime;
            if (_packagedetail.SKUScanDateTime != null) this.SKUScanDateTime = (DateTime)_packagedetail.SKUScanDateTime;
        }







       
    }
}
