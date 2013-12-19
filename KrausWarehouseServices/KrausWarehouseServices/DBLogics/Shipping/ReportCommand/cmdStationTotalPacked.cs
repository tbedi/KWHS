using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.Shipping.ReportEntity;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
    public class cmdStationTotalPacked
    {
        Shipping_ManagerEntities1 lent = new Shipping_ManagerEntities1();

        public List<StationToatlPackedDTO> GetEachStationPacked()
        {
            List<StationToatlPackedDTO> _lsStationPacked = new List<StationToatlPackedDTO>();
            try
            {
                var vStationPacked = from station in lent.Stations
                                     join pack in lent.Packages
                                     on station.StationID equals pack.StationID
                                     group pack by station.StationID into GStationPack
                                     select new
                                     {
                                         StationID = GStationPack.Key,
                                         StaionName = GStationPack.FirstOrDefault(i => i.Station.StationName != null).Station.StationName,
                                         PackedCount = GStationPack.Count(i => i.PackingStatus == 0),
                                         PartiallyPacked = GStationPack.Count(i => i.PackingStatus == 1)
                                     };

                foreach (var item in vStationPacked)
                {
                    StationToatlPackedDTO _spacked = new StationToatlPackedDTO();
                    _spacked.StationID = item.StationID;
                    _spacked.StationName = item.StaionName;
                    _spacked.TotalPacked = item.PackedCount;
                    _spacked.PartiallyPacked = item.PartiallyPacked;
                    _lsStationPacked.Add(_spacked);
                }
            }
            catch (Exception)
            { }
            return _lsStationPacked;

        }

        public List<StationToatlPackedDTO> GetEachStationPacked(DateTime DateReport)
        {
            List<StationToatlPackedDTO> _lsStationPacked = new List<StationToatlPackedDTO>();
            try
            {
                var vStationPacked = from station in lent.Stations
                                     join pack in lent.Packages
                                     on station.StationID equals pack.StationID
                                     where EntityFunctions.TruncateTime(pack.StartTime) == EntityFunctions.TruncateTime(DateReport)
                                     group pack by station.StationID into GStationPack
                                     select new
                                     {
                                         StationID = GStationPack.Key,
                                         StaionName = GStationPack.FirstOrDefault(i => i.Station.StationName != null).Station.StationName,
                                         PackedCount = GStationPack.Count(i => i.PackingStatus == 0),
                                         PartiallyPacked = GStationPack.Count(i => i.PackingStatus == 1)
                                     };

                foreach (var item in vStationPacked)
                {
                    StationToatlPackedDTO _spacked = new StationToatlPackedDTO();
                    _spacked.StationID = item.StationID;
                    _spacked.StationName = item.StaionName;
                    _spacked.TotalPacked = item.PackedCount;
                    _spacked.PartiallyPacked = item.PartiallyPacked;
                    _lsStationPacked.Add(_spacked);
                }
            }
            catch (Exception)
            { }
            return _lsStationPacked;

        }


        public List<DashBoardStionDTO> GetStationByReport(DateTime DateReport)
        {
            List<DashBoardStionDTO> _lsStationPacked = new List<DashBoardStionDTO>();

            try
            {
                cmdUser user = new cmdUser();
                var vStationPacked = from station in lent.Stations
                                     join pack in lent.Packages
                                     on station.StationID equals pack.StationID
                                     where EntityFunctions.TruncateTime(pack.StartTime) == EntityFunctions.TruncateTime(DateReport)
                                     group pack by station.StationID into GStationPack
                                     select new
                                     {
                                         StationID = GStationPack.Key,
                                         StaionName = GStationPack.FirstOrDefault(i => i.Station.StationName != null).Station.StationName,
                                         PackedCount = GStationPack.Count(i => i.PackingStatus == 0),
                                     };
                DashBoardStionDTO dash = new DashBoardStionDTO();
            }
            catch (Exception)
            { }
            return _lsStationPacked;

        }


        public int PackedTodayByStationID(string StationName)
        {
            int _retutn = 0;
            try
            {
                Guid StationID = lent.Stations.FirstOrDefault(i => i.StationName == StationName).StationID;
                _retutn = (from station in lent.Stations
                           join pack in lent.Packages
                           on station.StationID equals pack.StationID
                           where EntityFunctions.TruncateTime(pack.StartTime) == EntityFunctions.TruncateTime(DateTime.UtcNow)
                           && station.StationID == StationID
                           group pack by station.StationID into GStationPack
                           select new
                           {
                               StationID = GStationPack.Key,
                               StaionName = GStationPack.FirstOrDefault(i => i.Station.StationName != null).Station.StationName,
                               PackedCount = GStationPack.Count(i => i.PackingStatus == 0),
                           }).FirstOrDefault(i => i.StationID == StationID).PackedCount;
            }
            catch (Exception)
            { }
            return _retutn;
        }

        public String UnderPackingID(String StationName)
        {
            String PackingID = "Not Packing";
            try
            {
                Guid StationID = lent.Stations.FirstOrDefault(i => i.StationName == StationName).StationID;
                PackingID = (from station in lent.Stations
                             join pack in lent.Packages
                             on station.StationID equals pack.StationID
                             where EntityFunctions.TruncateTime(pack.StartTime) == EntityFunctions.TruncateTime(DateTime.UtcNow)
                             && station.StationID == StationID && pack.PackingStatus == 1
                             group pack by station.StationID into GStationPack
                             select new
                             {
                                 StationID = GStationPack.Key,
                                 ShippingNum = GStationPack.FirstOrDefault(i => i.PackingStatus == 1).ShippingNum
                             }).FirstOrDefault(i => i.StationID == StationID).ShippingNum;
            }
            catch (Exception)
            { }
            return PackingID;

        }

    }
}
