using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
    public class cmdStationTotalPacked
    {

        //public List<cstStationToatlPacked> GetEachStationPacked()
        //{
        //    List<cstStationToatlPacked> _lsStationPacked = new List<cstStationToatlPacked>();
        //    try
        //    {
        //        var vStationPacked = from station in Service.Get.StationMasterAllStation()
        //                             join pack in Service.Get.PackageAllPackge()
        //                             on station.StationID equals pack.StationID
        //                             group pack by station.StationID into GStationPack
        //                             select new
        //                             {
        //                                 StationID = GStationPack.Key,
        //                                 StaionName = Service.Get.StationMasterByStationID(GStationPack.FirstOrDefault(i => i.StationID != null).StationID)[0].StationName,
        //                                 PackedCount = GStationPack.Count(i => i.PackingStatus == 0),
        //                                 PartiallyPacked = GStationPack.Count(i => i.PackingStatus == 1)
        //                             };

        //        foreach (var item in vStationPacked)
        //        {
        //            cstStationToatlPacked _spacked = new cstStationToatlPacked();
        //            _spacked.StationID = item.StationID;
        //            _spacked.StationName = item.StaionName;
        //            _spacked.TotalPacked = item.PackedCount;
        //            _spacked.PartiallyPacked = item.PartiallyPacked;
        //            _lsStationPacked.Add(_spacked);
        //        }
        //    }
        //    catch (Exception)
        //    { }
        //    return _lsStationPacked;

        //}

        //public List<cstStationToatlPacked> GetEachStationPacked(DateTime DateReport)
        //{
        //    List<cstStationToatlPacked> _lsStationPacked = new List<cstStationToatlPacked>();
        //    try
        //    {
        //        var vStationPacked = from station in Service.Get.StationMasterAllStation()
        //                             join pack in Service.Get.PackageAllPackge()
        //                             on station.StationID equals pack.StationID
        //                             where EntityFunctions.TruncateTime(pack.StartTime) == EntityFunctions.TruncateTime(DateReport)
        //                             group pack by station.StationID into GStationPack
        //                             select new
        //                             {
        //                                 StationID = GStationPack.Key,
        //                                 StaionName = Service.Get.StationMasterByStationID(GStationPack.FirstOrDefault(i => i.StationID != null).StationID)[0].StationName,
        //                                 PackedCount = GStationPack.Count(i => i.PackingStatus == 0),
        //                                 PartiallyPacked = GStationPack.Count(i => i.PackingStatus == 1)
        //                             };

        //        foreach (var item in vStationPacked)
        //        {
        //            cstStationToatlPacked _spacked = new cstStationToatlPacked();
        //            _spacked.StationID = item.StationID;
        //            _spacked.StationName = item.StaionName;
        //            _spacked.TotalPacked = item.PackedCount;
        //            _spacked.PartiallyPacked = item.PartiallyPacked;
        //            _lsStationPacked.Add(_spacked);
        //        }
        //    }
        //    catch (Exception)
        //    { }
        //    return _lsStationPacked;

        //}

        //public List<cstDashBoardStion> GetStationByReport(DateTime DateReport)
        //{
        //    List<cstDashBoardStion> _lsStationPacked = new List<cstDashBoardStion>();

        //    try
        //    {
        //        cmdUser user = new cmdUser();
        //        var vStationPacked = from station in Service.Get.StationMasterAllStation()
        //                             join pack in Service.Get.PackageAllPackge()
        //                             on station.StationID equals pack.StationID
        //                             where EntityFunctions.TruncateTime(pack.StartTime) == EntityFunctions.TruncateTime(DateReport)
        //                             group pack by station.StationID into GStationPack
        //                             select new
        //                             {
        //                                 StationID = GStationPack.Key,
        //                                 StaionName = Service.Get.StationMasterByStationID(GStationPack.FirstOrDefault(i => i.StationID != null).StationID)[0].StationName,
        //                                 PackedCount = GStationPack.Count(i => i.PackingStatus == 0),
        //                             };
        //        cstDashBoardStion dash = new cstDashBoardStion();
        //    }
        //    catch (Exception)
        //    { }
        //    return _lsStationPacked;

        //}

        //public int PackedTodayByStationID(string StationName)
        //{
        //    int _retutn = 0;
        //    try
        //    {
        //        Guid StationID = Service.Get.StationMasterByStationName(StationName)[0].StationID;
        //        _retutn = (from station in Service.Get.StationMasterAllStation()
        //                   join pack in Service.Get.PackageAllPackge()
        //                   on station.StationID equals pack.StationID
        //                   where EntityFunctions.TruncateTime(pack.StartTime) == EntityFunctions.TruncateTime(DateTime.UtcNow)
        //                   && station.StationID == StationID
        //                   group pack by station.StationID into GStationPack
        //                   select new
        //                   {
        //                       StationID = GStationPack.Key,
        //                       StaionName = Service.Get.StationMasterByStationID(GStationPack.FirstOrDefault(i => i.StationID != null).StationID)[0].StationName,
        //                       PackedCount = GStationPack.Count(i => i.PackingStatus == 0),
        //                   }).FirstOrDefault(i => i.StationID == StationID).PackedCount;
        //    }
        //    catch (Exception)
        //    { }
        //    return _retutn;
        //}

        //public String UnderPackingID(String StationName)
        //{
        //    String PackingID = "Not Packing";
        //    try
        //    {
        //        Guid StationID = Service.Get.StationMasterByStationName(StationName)[0].StationID;
        //        PackingID = (from station in Service.Get.StationMasterAllStation()
        //                     join pack in Service.Get.PackageAllPackge()
        //                     on station.StationID equals pack.StationID
        //                     where EntityFunctions.TruncateTime(pack.StartTime) == EntityFunctions.TruncateTime(DateTime.UtcNow)
        //                     && station.StationID == StationID && pack.PackingStatus == 1
        //                     group pack by station.StationID into GStationPack
        //                     select new
        //                     {
        //                         StationID = GStationPack.Key,
        //                         ShippingNum = GStationPack.FirstOrDefault(i => i.PackingStatus == 1).ShippingNum
        //                     }).FirstOrDefault(i => i.StationID == StationID).ShippingNum;
        //    }
        //    catch (Exception)
        //    { }
        //    return PackingID;

        //}

    }
}
