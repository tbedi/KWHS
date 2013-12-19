using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
  public  class StationToatlPackedDTO
    {
        public Guid StationID { get; set; }
        public String StationName { get; set; }
        public int TotalPacked { get; set; }
        public int PartiallyPacked { get; set; }
    }
}
