﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.Shipping.ReportEntity
{
     public class ShipmentPackedTodayAndAvgTimeDTO
    {
        public Guid UserID { get; set; }
        public int Packed { get; set; }
    }
}
