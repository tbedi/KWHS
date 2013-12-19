using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
    public class GetTotalShipmentPackedToday
    {


        ///// <summary>
        ///// Current date packing details
        ///// </summary>
        ///// <returns></returns>
        //public List<cstShipmentPackedTodayAndAvgTime> GetTotalShipmentPackedTime()
        //{
        //    List<cstShipmentPackedTodayAndAvgTime> lsShipmentPacked = new List<cstShipmentPackedTodayAndAvgTime>();
        //    try
        //    {
        //        String CurrentTime = DateTime.UtcNow.ToString();

        //        var packingCount = from user in Service.Get.UserAllUser()
        //                           join packing in Service.Get.PackageAllPackge()
        //                           on user.UserID equals packing.UserID
        //                           where EntityFunctions.TruncateTime(packing.EndTime) == EntityFunctions.TruncateTime(DateTime.UtcNow)
        //                           group packing by packing.UserID into Gpacking
        //                           select new
        //                           {
        //                               userID = Gpacking.Key,
        //                               TotalPacked = Gpacking.Count(i => i.PackingStatus == 0)

        //                           };



        //        foreach (var pckitem in packingCount)
        //        {
        //            cstShipmentPackedTodayAndAvgTime _cspck = new cstShipmentPackedTodayAndAvgTime();
        //            _cspck.UserID = pckitem.userID;
        //            _cspck.Packed = Convert.ToInt32(pckitem.TotalPacked);
        //            lsShipmentPacked.Add(_cspck);
        //        }

        //    }
        //    catch (Exception)
        //    { }
        //    return lsShipmentPacked;
        //}
    }
}
