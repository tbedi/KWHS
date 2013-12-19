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
    public class cmdUserShipmentCount
    {
        Shipping_ManagerEntities1 entshipping = new Shipping_ManagerEntities1();

        /// <summary>
        /// for each user its total packed shipments and its dates
        /// </summary>
        /// <returns>List of cstUserShipmentCount</returns>
        public List<UserShipmentCountDTO> GetAllShipmentCountByUser()
        {
            List<UserShipmentCountDTO> _lsUserShipmentCount = new List<UserShipmentCountDTO>();
            try
            {
                var Shipments = from shp in entshipping.Packages //Service.Get.PackageAllPackge()
                                group shp by new { shp.UserId, Stime = EntityFunctions.TruncateTime(shp.StartTime) } into Gship
                                select new
                                {
                                    Userid = Gship.Key.UserId,
                                    PackingDate = Gship.Key.Stime,
                                    ShipmentCount = Gship.Count(i => i.ShippingID != null)
                                };
                foreach (var item in Shipments)
                {
                    UserShipmentCountDTO Uship = new UserShipmentCountDTO();
                    Uship.UserID = item.Userid;
                    Uship.UserName = entshipping.Users.FirstOrDefault(re => re.UserID == item.Userid).UserFullName.ToString();//Service.Get.UserByUserID(item.Userid)[0].UserFullName.ToString();
                    Uship.ShipmentCount = Convert.ToInt32(item.ShipmentCount);
                    Uship.Datepacked = Convert.ToDateTime(item.PackingDate);
                    _lsUserShipmentCount.Add(Uship);
                }

            }
            catch (Exception)
            { }
            return _lsUserShipmentCount;
        }

    }
}
