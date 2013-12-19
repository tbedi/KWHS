using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
   public class PackingTimeDTO
    {
        public Guid PackingID { get; set; }
        public String ShippingNumber { get; set; }
        public String TimeSpend { get; set; }
        public int Quantity { get; set; }
    }
}
