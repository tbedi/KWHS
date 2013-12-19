using KrausWarehouseServices.DTO.Shipping.ReportEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using System.Data.Objects;

namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
    public class GetTotalShipmentPackedToday
    {
        Shipping_ManagerEntities1 entShipping = new Shipping_ManagerEntities1();

        /// <summary>
        /// Current date packing details
        /// </summary>
        /// <returns></returns>
        public List<ShipmentPackedTodayAndAvgTimeDTO> GetTotalShipmentPackedTime()
        {
            List<ShipmentPackedTodayAndAvgTimeDTO> lsShipmentPacked = new List<ShipmentPackedTodayAndAvgTimeDTO>();
            try
            {
                String CurrentTime = DateTime.UtcNow.ToString();

                var packingCount = from user in entShipping.Users //Service.Get.UserAllUser()
                                   join packing in entShipping.Packages //Service.Get.PackageAllPackge()
                                   on user.UserID equals packing.UserId
                                   where EntityFunctions.TruncateTime(packing.EndTime) == EntityFunctions.TruncateTime(DateTime.UtcNow)
                                   group packing by packing.UserId into Gpacking
                                   select new
                                   {
                                       userID = Gpacking.Key,
                                       TotalPacked = Gpacking.Count(i => i.PackingStatus == 0)

                                   };



                foreach (var pckitem in packingCount)
                {
                    ShipmentPackedTodayAndAvgTimeDTO _cspck = new ShipmentPackedTodayAndAvgTimeDTO();
                    _cspck.UserID = pckitem.userID;
                    _cspck.Packed = Convert.ToInt32(pckitem.TotalPacked);
                    lsShipmentPacked.Add(_cspck);
                }

            }
            catch (Exception)
            { }
            return lsShipmentPacked;
        }
    }
}
