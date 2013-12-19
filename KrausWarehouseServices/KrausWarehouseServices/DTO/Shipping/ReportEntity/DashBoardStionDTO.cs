using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
    public class DashBoardStionDTO
    {
        public String StationName { get; set; }
        public int ErrorCaught { get; set; }
        public int TotalPacked { get; set; }
        public String packagePerhr { get; set; }
        public String ShipmentNumber { get; set; }
        public String PackerName { get; set; }
    }
}
