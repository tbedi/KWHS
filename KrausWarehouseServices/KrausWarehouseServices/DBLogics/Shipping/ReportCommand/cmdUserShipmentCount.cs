﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
    public class cmdUserShipmentCount
    {
        ///// <summary>
        ///// for each user its total packed shipments and its dates
        ///// </summary>
        ///// <returns>List of cstUserShipmentCount</returns>
        //public List<cstUserShipmentCount> GetAllShipmentCountByUser()
        //{
        //    List<cstUserShipmentCount> _lsUserShipmentCount = new List<cstUserShipmentCount>();
        //    try
        //    {
        //        var Shipments = from shp in Service.Get.PackageAllPackge()
        //                        group shp by new { shp.UserID, Stime = EntityFunctions.TruncateTime(shp.StartTime) } into Gship
        //                        select new
        //                        {
        //                            Userid = Gship.Key.UserID,
        //                            PackingDate = Gship.Key.Stime,
        //                            ShipmentCount = Gship.Count(i => i.ShippingID != null)
        //                        };
        //        foreach (var item in Shipments)
        //        {
        //            cstUserShipmentCount Uship = new cstUserShipmentCount();
        //            Uship.UserID = item.Userid;
        //            Uship.UserName = Service.Get.UserByUserID(item.Userid)[0].UserFullName.ToString();
        //            Uship.ShipmentCount = Convert.ToInt32(item.ShipmentCount);
        //            Uship.Datepacked = Convert.ToDateTime(item.PackingDate);
        //            _lsUserShipmentCount.Add(Uship);
        //        }

        //    }
        //    catch (Exception)
        //    { }
        //    return _lsUserShipmentCount;
        //}

    }
}
