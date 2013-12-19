using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    class UserShipmentCountDTO
    {

        public Guid UserID { get; set; }
        public String UserName { get; set; }
        public DateTime Datepacked { get; set; }
        public int ShipmentCount { get; set; }
    }
}
