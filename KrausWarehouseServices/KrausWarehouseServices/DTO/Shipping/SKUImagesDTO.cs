using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections.Shipping;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
   public class SKUImagesDTO
    {
        /// <summary>
        /// Create Object of ShippingEntity.
        /// </summary>
        Shipping_ManagerEntities1 entshipping = new Shipping_ManagerEntities1();

        /// <summary>
        /// Blank constructor.
        /// </summary>
        public SKUImagesDTO()
        {

        }

        public SKUImagesDTO(Connections.Shipping.SKUImage _SkuImage)
        {
            if (_SkuImage.RowID != null) this.RowID = _SkuImage.RowID;
            if (_SkuImage.SKUrl != null) this.SKUrl = _SkuImage.SKUrl;
            if (_SkuImage.SKU != null) this.SKU = _SkuImage.SKU;
           this.BarcodeFlag = _SkuImage.BarcodeFlag;
        }

        public int BarcodeFlag { get; set; }

        public string SKU { get; set; }

        public string SKUrl { get; set; }

        public Guid RowID { get; set; }
    }
}
