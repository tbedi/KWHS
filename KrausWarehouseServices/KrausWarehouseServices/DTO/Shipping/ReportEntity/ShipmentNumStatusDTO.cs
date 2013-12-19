using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    public  class ShipmentNumStatusDTO
    {
        public Guid PackageID { get; set; }
        public String ShippingNum { get; set; }
        public String Location { get; set; }
        public string ShippinStatus { get; set; }
        public int ShippingCompletedInt { get; set; }
    }
}
