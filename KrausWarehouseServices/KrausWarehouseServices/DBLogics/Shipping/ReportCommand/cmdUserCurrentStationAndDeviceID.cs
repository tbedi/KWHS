using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.Shipping.ReportEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
    public class cmdUserCurrentStationAndDeviceID
    {

        Shipping_ManagerEntities1 entshipping = new Shipping_ManagerEntities1();

        /// <summary>
        /// All Users last Login Station
        /// </summary>
        /// <returns></returns>
        public List<UserCurrentStationAndDeviceIDDTO> LastLoginStationAllUsers()
        {
            List<UserCurrentStationAndDeviceIDDTO> lsUstation = new List<UserCurrentStationAndDeviceIDDTO>();
            try
            {
                var UserName = from user in entshipping.Users//Service.Get.UserAllUser()
                               join Us in entshipping.UserStations//Service.Get.UserStationAllUser()
                               on user.UserID equals Us.UserID
                               group Us by user.UserID into Gusers
                               select new
                               {
                                   User = Gusers.Key,
                                   StationTime = Gusers.Max(i => i.LoginDateTime),
                                   StaionID = Gusers.FirstOrDefault(i => i.UserID == Gusers.Key && i.LoginDateTime == Gusers.Max(j => j.LoginDateTime)).StationID
                               };
                var StaionName = from Station in UserName
                                 join Station2 in entshipping.Stations //Service.Get.StationMasterAllStation()
                               on Station.StaionID equals Station2.StationID
                                 join User in entshipping.Users //Service.Get.UserAllUser()
                                 on Station.User equals User.UserID
                                 select new
                                 {
                                     UserID = User.UserID,
                                     UserName = User.UserFullName,
                                     Station.StationTime,
                                     Station2.StationName,
                                     Station2.DeviceNumber,
                                 };

                foreach (var Useritem in StaionName)
                {
                    UserCurrentStationAndDeviceIDDTO UserStation = new UserCurrentStationAndDeviceIDDTO();
                    UserStation.UserID = Useritem.UserID;
                    UserStation.UserName = Useritem.UserName;
                    UserStation.StationName = Useritem.StationName;
                    UserStation.Datetime = Useritem.StationTime.ToString("MMM dd, yyyy hh:mm tt");
                    UserStation.DeviceID = Useritem.DeviceNumber;
                    lsUstation.Add(UserStation);
                }
            }
            catch (Exception)
            { }
            return lsUstation;
        }

    }
}
