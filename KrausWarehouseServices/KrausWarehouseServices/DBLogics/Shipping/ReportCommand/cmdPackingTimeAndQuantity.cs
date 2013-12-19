using KrausWarehouseServices.DTO.Shipping.ReportEntity;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
    public class cmdPackingTimeAndQuantity
    {

        Connections.Shipping.Shipping_ManagerEntities1 x3v6 = new Connections.Shipping.Shipping_ManagerEntities1();


        cmdPackage cmd = new cmdPackage();

        /// <summary>
        /// Calculate all shipments toatal Quantity and Time Required to pack the saprate shipment
        /// </summary>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantity()
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            try
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       join Packingdtl in x3v6.PackageDetails
                                       on packing.PackingId equals Packingdtl.PackingId
                                       select new
                                       {
                                           ShipmentID = Packingdtl.PackingId,
                                           TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                       };
                var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                      group packingDetail by packingDetail.PackingId into Gpd
                                      select new
                                      {
                                          ShipmentID = Gpd.Key,
                                          Quantity = Gpd.Sum(p => p.SKUQuantity)
                                      };
                var packingJoin = from Pq in PackingQuantity
                                  join Pt in packingTimeAndID
                                  on Pq.ShipmentID equals Pt.ShipmentID
                                  select new
                                  {
                                      ShipmentID = Pq.ShipmentID,
                                      TimeRquare = Pt.TimeSpend,
                                      Quantity = Pq.Quantity
                                  };
                var packingG = from pj in packingJoin
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.PackingID = listItem.Key;
                    _Packing.ShippingNumber = cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }
        /// <summary>
        /// Shipment With its Time And SKu Quantity up to current Date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantity(Guid UserID)
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            try
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       join Packingdtl in x3v6.PackageDetails
                                       on packing.PackingId equals Packingdtl.PackingId
                                       where packing.UserId == UserID
                                       select new
                                       {
                                           ShipmentID = Packingdtl.PackingId,
                                           TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                       };
                var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                      group packingDetail by packingDetail.PackingId into Gpd
                                      select new
                                      {
                                          ShipmentID = Gpd.Key,
                                          Quantity = Gpd.Sum(p => p.SKUQuantity)
                                      };
                var packingJoin = from Pq in PackingQuantity
                                  join Pt in packingTimeAndID
                                  on Pq.ShipmentID equals Pt.ShipmentID
                                  select new
                                  {
                                      ShipmentID = Pq.ShipmentID,
                                      TimeRquare = Pt.TimeSpend,
                                      Quantity = Pq.Quantity
                                  };
                var packingG = from pj in packingJoin
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.PackingID = listItem.Key;
                    _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <param name="date"> DateTime For Filter</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantity(DateTime Fromdate, DateTime Todate)
        {


            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            try
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       join Packingdtl in x3v6.PackageDetails
                                       on packing.PackingId equals Packingdtl.PackingId
                                       where EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                        EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date
                                       select new
                                       {
                                           ShipmentID = Packingdtl.PackingId,
                                           TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                       };
                var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                      group packingDetail by packingDetail.PackingId into Gpd
                                      select new
                                      {
                                          ShipmentID = Gpd.Key,
                                          Quantity = Gpd.Sum(p => p.SKUQuantity)
                                      };
                var packingJoin = from Pq in PackingQuantity
                                  join Pt in packingTimeAndID
                                  on Pq.ShipmentID equals Pt.ShipmentID
                                  select new
                                  {
                                      ShipmentID = Pq.ShipmentID,
                                      TimeRquare = Pt.TimeSpend,
                                      Quantity = Pq.Quantity
                                  };
                var packingG = from pj in packingJoin
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.PackingID = listItem.Key;
                    _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantity(Guid UserID, DateTime Fromdate, DateTime Todate)
        {

            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            try
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       join Packingdtl in x3v6.PackageDetails
                                       on packing.PackingId equals Packingdtl.PackingId
                                       where EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                        EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date &&
                                        packing.UserId == UserID
                                       select new
                                       {
                                           ShipmentID = Packingdtl.PackingId,
                                           TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                       };
                var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                      group packingDetail by packingDetail.PackingId into Gpd
                                      select new
                                      {
                                          ShipmentID = Gpd.Key,
                                          Quantity = Gpd.Sum(p => p.SKUQuantity)
                                      };
                var packingJoin = from Pq in PackingQuantity
                                  join Pt in packingTimeAndID
                                  on Pq.ShipmentID equals Pt.ShipmentID
                                  select new
                                  {
                                      ShipmentID = Pq.ShipmentID,
                                      TimeRquare = Pt.TimeSpend,
                                      Quantity = Pq.Quantity
                                  };
                var packingG = from pj in packingJoin
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.PackingID = listItem.Key;
                    _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }


        public List<PackingTimeDTO> GetPackingTimeAndQantity(int PackingStatus, Boolean PackingStaus)
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            if (PackingStatus == 0)
            {
                try
                {
                    var packingTimeAndID = from packing in x3v6.Packages
                                           join Packingdtl in x3v6.PackageDetails
                                           on packing.PackingId equals Packingdtl.PackingId
                                           where packing.PackingStatus == PackingStatus
                                           select new
                                           {
                                               ShipmentID = Packingdtl.PackingId,
                                               TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                           };
                    var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                          group packingDetail by packingDetail.PackingId into Gpd
                                          select new
                                          {
                                              ShipmentID = Gpd.Key,
                                              Quantity = Gpd.Sum(p => p.SKUQuantity)
                                          };
                    var packingJoin = from Pq in PackingQuantity
                                      join Pt in packingTimeAndID
                                      on Pq.ShipmentID equals Pt.ShipmentID
                                      select new
                                      {
                                          ShipmentID = Pq.ShipmentID,
                                          TimeRquare = Pt.TimeSpend,
                                          Quantity = Pq.Quantity
                                      };
                    var packingG = from pj in packingJoin
                                   group pj by pj.ShipmentID into GPj
                                   select GPj;

                    foreach (var listItem in packingG)
                    {
                        PackingTimeDTO _Packing = new PackingTimeDTO();
                        _Packing.PackingID = listItem.Key;
                        _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                        _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }
                catch (Exception)
                { }
            }
            else
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       where packing.PackingStatus == PackingStatus
                                       select new
                                       {
                                           ShipmentID = packing.PackingId,
                                           TimeRquare = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime),
                                           Quantity = 00
                                       };
                var packingG = from pj in packingTimeAndID
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.ShippingNumber = cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            return _lsreturnPacingTime;
        }
        /// <summary>
        /// Shipment With its Time And SKu Quantity up to current Date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantity(Guid UserID, int PackingStatus)
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            if (PackingStatus == 0)
            {
                try
                {
                    var packingTimeAndID = from packing in x3v6.Packages
                                           join Packingdtl in x3v6.PackageDetails
                                           on packing.PackingId equals Packingdtl.PackingId
                                           where packing.PackingStatus == PackingStatus && packing.UserId == UserID
                                           select new
                                           {
                                               ShipmentID = Packingdtl.PackingId,
                                               TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                           };
                    var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                          group packingDetail by packingDetail.PackingId into Gpd
                                          select new
                                          {
                                              ShipmentID = Gpd.Key,
                                              Quantity = Gpd.Sum(p => p.SKUQuantity)
                                          };
                    var packingJoin = from Pq in PackingQuantity
                                      join Pt in packingTimeAndID
                                      on Pq.ShipmentID equals Pt.ShipmentID
                                      select new
                                      {
                                          ShipmentID = Pq.ShipmentID,
                                          TimeRquare = Pt.TimeSpend,
                                          Quantity = Pq.Quantity
                                      };
                    var packingG = from pj in packingJoin
                                   group pj by pj.ShipmentID into GPj
                                   select GPj;

                    foreach (var listItem in packingG)
                    {
                        PackingTimeDTO _Packing = new PackingTimeDTO();
                        _Packing.PackingID = listItem.Key;
                        _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                        _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }
                catch (Exception)
                { }
            }
            else
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       where packing.UserId == UserID &&
                                          packing.PackingStatus == PackingStatus

                                       select new
                                       {
                                           ShipmentID = packing.PackingId,
                                           TimeRquare = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime),
                                           Quantity = 00
                                       };
                var packingG = from pj in packingTimeAndID
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.ShippingNumber = cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <param name="date"> DateTime For Filter</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantity(DateTime Fromdate, DateTime Todate, int PackingStatus)
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            if (PackingStatus == 0)
            {
                try
                {
                    var packingTimeAndID = from packing in x3v6.Packages
                                           join Packingdtl in x3v6.PackageDetails
                                           on packing.PackingId equals Packingdtl.PackingId
                                           where EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                           EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date &&
                                           packing.PackingStatus == PackingStatus
                                           select new
                                           {
                                               ShipmentID = Packingdtl.PackingId,
                                               TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                           };
                    var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                          group packingDetail by packingDetail.PackingId into Gpd
                                          select new
                                          {
                                              ShipmentID = Gpd.Key,
                                              Quantity = Gpd.Sum(p => p.SKUQuantity)
                                          };
                    var packingJoin = from Pq in PackingQuantity
                                      join Pt in packingTimeAndID
                                      on Pq.ShipmentID equals Pt.ShipmentID
                                      select new
                                      {
                                          ShipmentID = Pq.ShipmentID,
                                          TimeRquare = Pt.TimeSpend,
                                          Quantity = Pq.Quantity
                                      };
                    var packingG = from pj in packingJoin
                                   group pj by pj.ShipmentID into GPj
                                   select GPj;

                    foreach (var listItem in packingG)
                    {
                        PackingTimeDTO _Packing = new PackingTimeDTO();
                        _Packing.PackingID = listItem.Key;
                        _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                        _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }
                catch (Exception)
                { }
            }
            else
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       where EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                            EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date &&
                                            packing.PackingStatus == PackingStatus
                                       select new
                                       {
                                           ShipmentID = packing.PackingId,
                                           TimeRquare = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime),
                                           Quantity = 00
                                       };
                var packingG = from pj in packingTimeAndID
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.ShippingNumber = cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantity(Guid UserID, DateTime Fromdate, DateTime Todate, int PackingStatus)
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            if (PackingStatus == 0)
            {
                try
                {
                    var packingTimeAndID = from packing in x3v6.Packages
                                           join Packingdtl in x3v6.PackageDetails
                                           on packing.PackingId equals Packingdtl.PackingId
                                           where packing.UserId == UserID &&
                                         EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                          EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date &&
                                          packing.PackingStatus == PackingStatus
                                           select new
                                           {
                                               ShipmentID = Packingdtl.PackingId,
                                               TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                           };
                    var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                          group packingDetail by packingDetail.PackingId into Gpd
                                          select new
                                          {
                                              ShipmentID = Gpd.Key,
                                              Quantity = Gpd.Sum(p => p.SKUQuantity)
                                          };
                    var packingJoin = from Pq in PackingQuantity
                                      join Pt in packingTimeAndID
                                      on Pq.ShipmentID equals Pt.ShipmentID
                                      select new
                                      {
                                          ShipmentID = Pq.ShipmentID,
                                          TimeRquare = Pt.TimeSpend,
                                          Quantity = Pq.Quantity
                                      };
                    var packingG = from pj in packingJoin
                                   group pj by pj.ShipmentID into GPj
                                   select GPj;

                    foreach (var listItem in packingG)
                    {
                        PackingTimeDTO _Packing = new PackingTimeDTO();
                        _Packing.PackingID = listItem.Key;
                        _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                        _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }
                catch (Exception)
                { }
            }
            else
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       where packing.UserId == UserID &&
                                           EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                            EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date &&
                                            packing.PackingStatus == PackingStatus
                                       select new
                                       {
                                           ShipmentID = packing.PackingId,
                                           TimeRquare = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime),
                                           Quantity = 00
                                       };
                var packingG = from pj in packingTimeAndID
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.ShippingNumber = cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            return _lsreturnPacingTime;
        }


        #region Station Wise new added

        /// <summary>
        /// Calculate all shipments toatal Quantity and Time Required to pack the saprate shipment
        /// </summary>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantityByStation(Guid StationID)
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            try
            {
                DateTime dt = DateTime.UtcNow;
                var packingTimeAndID = from packing in x3v6.Packages
                                       join Packingdtl in x3v6.PackageDetails
                                       on packing.PackingId equals Packingdtl.PackingId
                                       where packing.StationID == StationID && EntityFunctions.TruncateTime(packing.EndTime) == EntityFunctions.TruncateTime(dt)
                                       select new
                                       {
                                           ShipmentID = Packingdtl.PackingId,
                                           TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                       };
                var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                      group packingDetail by packingDetail.PackingId into Gpd
                                      select new
                                      {
                                          ShipmentID = Gpd.Key,
                                          Quantity = Gpd.Sum(p => p.SKUQuantity)
                                      };
                var packingJoin = from Pq in PackingQuantity
                                  join Pt in packingTimeAndID
                                  on Pq.ShipmentID equals Pt.ShipmentID
                                  select new
                                  {
                                      ShipmentID = Pq.ShipmentID,
                                      TimeRquare = Pt.TimeSpend,
                                      Quantity = Pq.Quantity
                                  };
                var packingG = from pj in packingJoin
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.PackingID = listItem.Key;
                    _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }
        /// <summary>
        /// Shipment With its Time And SKu Quantity up to current Date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantityByStation(Guid UserID, Guid StationID)
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            try
            {
                DateTime dt = DateTime.UtcNow;
                var packingTimeAndID = from packing in x3v6.Packages
                                       join Packingdtl in x3v6.PackageDetails
                                       on packing.PackingId equals Packingdtl.PackingId
                                       where packing.UserId == UserID
                                       where packing.StationID == StationID && EntityFunctions.TruncateTime(packing.EndTime) == EntityFunctions.TruncateTime(dt)
                                       select new
                                       {
                                           ShipmentID = Packingdtl.PackingId,
                                           TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                       };
                var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                      group packingDetail by packingDetail.PackingId into Gpd
                                      select new
                                      {
                                          ShipmentID = Gpd.Key,
                                          Quantity = Gpd.Sum(p => p.SKUQuantity)
                                      };
                var packingJoin = from Pq in PackingQuantity
                                  join Pt in packingTimeAndID
                                  on Pq.ShipmentID equals Pt.ShipmentID
                                  select new
                                  {
                                      ShipmentID = Pq.ShipmentID,
                                      TimeRquare = Pt.TimeSpend,
                                      Quantity = Pq.Quantity
                                  };
                var packingG = from pj in packingJoin
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.PackingID = listItem.Key;
                    _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <param name="date"> DateTime For Filter</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantityByStation(DateTime Fromdate, DateTime Todate, Guid StationID)
        {


            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            try
            {
                DateTime dt = DateTime.UtcNow;
                var packingTimeAndID = from packing in x3v6.Packages
                                       join Packingdtl in x3v6.PackageDetails
                                       on packing.PackingId equals Packingdtl.PackingId
                                       where EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                        EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date && packing.StationID == StationID
                                       select new
                                       {
                                           ShipmentID = Packingdtl.PackingId,
                                           TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                       };
                var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                      group packingDetail by packingDetail.PackingId into Gpd
                                      select new
                                      {
                                          ShipmentID = Gpd.Key,
                                          Quantity = Gpd.Sum(p => p.SKUQuantity)
                                      };
                var packingJoin = from Pq in PackingQuantity
                                  join Pt in packingTimeAndID
                                  on Pq.ShipmentID equals Pt.ShipmentID
                                  select new
                                  {
                                      ShipmentID = Pq.ShipmentID,
                                      TimeRquare = Pt.TimeSpend,
                                      Quantity = Pq.Quantity
                                  };
                var packingG = from pj in packingJoin
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.PackingID = listItem.Key;
                    _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantityByStation(Guid UserID, DateTime Fromdate, DateTime Todate, Guid StationID)
        {

            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            try
            {
                DateTime dt = DateTime.UtcNow;
                var packingTimeAndID = from packing in x3v6.Packages
                                       join Packingdtl in x3v6.PackageDetails
                                       on packing.PackingId equals Packingdtl.PackingId
                                       where EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                        EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date &&
                                        packing.UserId == UserID &&
                                         packing.StationID == StationID

                                       select new
                                       {
                                           ShipmentID = Packingdtl.PackingId,
                                           TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                       };
                var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                      group packingDetail by packingDetail.PackingId into Gpd
                                      select new
                                      {
                                          ShipmentID = Gpd.Key,
                                          Quantity = Gpd.Sum(p => p.SKUQuantity)
                                      };
                var packingJoin = from Pq in PackingQuantity
                                  join Pt in packingTimeAndID
                                  on Pq.ShipmentID equals Pt.ShipmentID
                                  select new
                                  {
                                      ShipmentID = Pq.ShipmentID,
                                      TimeRquare = Pt.TimeSpend,
                                      Quantity = Pq.Quantity
                                  };
                var packingG = from pj in packingJoin
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.PackingID = listItem.Key;
                    _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }


        public List<PackingTimeDTO> GetPackingTimeAndQantityByStation(int PackingStatus, Boolean PackingStaus, Guid StationID)
        {
            DateTime dt = DateTime.UtcNow;
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            if (PackingStatus == 0)
            {
                try
                {

                    var packingTimeAndID = from packing in x3v6.Packages
                                           join Packingdtl in x3v6.PackageDetails
                                           on packing.PackingId equals Packingdtl.PackingId
                                           where packing.PackingStatus == PackingStatus
                                           && packing.StationID == StationID && EntityFunctions.TruncateTime(packing.EndTime) == EntityFunctions.TruncateTime(dt)
                                           select new
                                           {
                                               ShipmentID = Packingdtl.PackingId,
                                               TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                           };
                    var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                          group packingDetail by packingDetail.PackingId into Gpd
                                          select new
                                          {
                                              ShipmentID = Gpd.Key,
                                              Quantity = Gpd.Sum(p => p.SKUQuantity)
                                          };
                    var packingJoin = from Pq in PackingQuantity
                                      join Pt in packingTimeAndID
                                      on Pq.ShipmentID equals Pt.ShipmentID
                                      select new
                                      {
                                          ShipmentID = Pq.ShipmentID,
                                          TimeRquare = Pt.TimeSpend,
                                          Quantity = Pq.Quantity
                                      };
                    var packingG = from pj in packingJoin
                                   group pj by pj.ShipmentID into GPj
                                   select GPj;

                    foreach (var listItem in packingG)
                    {
                        PackingTimeDTO _Packing = new PackingTimeDTO();
                        _Packing.PackingID = listItem.Key;
                        _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                        _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }
                catch (Exception)
                { }
            }
            else
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       where packing.PackingStatus == PackingStatus &&
                                       packing.StationID == StationID && EntityFunctions.TruncateTime(packing.EndTime) == EntityFunctions.TruncateTime(dt)
                                       select new
                                       {
                                           ShipmentID = packing.PackingId,
                                           TimeRquare = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime),
                                           Quantity = 00
                                       };
                var packingG = from pj in packingTimeAndID
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.ShippingNumber = cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            return _lsreturnPacingTime;
        }
        /// <summary>
        /// Shipment With its Time And SKu Quantity up to current Date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantityByStation(Guid UserID, int PackingStatus, Guid StationID)
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            if (PackingStatus == 0)
            {
                try
                {
                    DateTime dt = DateTime.UtcNow;
                    var packingTimeAndID = from packing in x3v6.Packages
                                           join Packingdtl in x3v6.PackageDetails
                                           on packing.PackingId equals Packingdtl.PackingId
                                           where packing.PackingStatus == PackingStatus && packing.UserId == UserID
                                           where packing.StationID == StationID && EntityFunctions.TruncateTime(packing.EndTime) == EntityFunctions.TruncateTime(dt)
                                           select new
                                           {
                                               ShipmentID = Packingdtl.PackingId,
                                               TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                           };
                    var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                          group packingDetail by packingDetail.PackingId into Gpd
                                          select new
                                          {
                                              ShipmentID = Gpd.Key,
                                              Quantity = Gpd.Sum(p => p.SKUQuantity)
                                          };
                    var packingJoin = from Pq in PackingQuantity
                                      join Pt in packingTimeAndID
                                      on Pq.ShipmentID equals Pt.ShipmentID
                                      select new
                                      {
                                          ShipmentID = Pq.ShipmentID,
                                          TimeRquare = Pt.TimeSpend,
                                          Quantity = Pq.Quantity
                                      };
                    var packingG = from pj in packingJoin
                                   group pj by pj.ShipmentID into GPj
                                   select GPj;

                    foreach (var listItem in packingG)
                    {
                        PackingTimeDTO _Packing = new PackingTimeDTO();
                        _Packing.PackingID = listItem.Key;
                        _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                        _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }
                catch (Exception)
                { }
            }
            else
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       where packing.UserId == UserID &&
                                          packing.PackingStatus == PackingStatus
                                       select new
                                       {
                                           ShipmentID = packing.PackingId,
                                           TimeRquare = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime),
                                           Quantity = 00
                                       };
                var packingG = from pj in packingTimeAndID
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.ShippingNumber = cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <param name="date"> DateTime For Filter</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantityByStation(DateTime Fromdate, DateTime Todate, int PackingStatus, Guid StationID)
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            if (PackingStatus == 0)
            {
                try
                {
                    DateTime dt = DateTime.UtcNow;
                    var packingTimeAndID = from packing in x3v6.Packages
                                           join Packingdtl in x3v6.PackageDetails
                                           on packing.PackingId equals Packingdtl.PackingId
                                           where EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                           EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date &&
                                           packing.PackingStatus == PackingStatus
                                           && packing.StationID == StationID
                                           select new
                                           {
                                               ShipmentID = Packingdtl.PackingId,
                                               TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                           };
                    var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                          group packingDetail by packingDetail.PackingId into Gpd
                                          select new
                                          {
                                              ShipmentID = Gpd.Key,
                                              Quantity = Gpd.Sum(p => p.SKUQuantity)
                                          };
                    var packingJoin = from Pq in PackingQuantity
                                      join Pt in packingTimeAndID
                                      on Pq.ShipmentID equals Pt.ShipmentID
                                      select new
                                      {
                                          ShipmentID = Pq.ShipmentID,
                                          TimeRquare = Pt.TimeSpend,
                                          Quantity = Pq.Quantity
                                      };
                    var packingG = from pj in packingJoin
                                   group pj by pj.ShipmentID into GPj
                                   select GPj;

                    foreach (var listItem in packingG)
                    {
                        PackingTimeDTO _Packing = new PackingTimeDTO();
                        _Packing.PackingID = listItem.Key;
                        _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                        _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }
                catch (Exception)
                { }
            }
            else
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       where EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                            EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date &&
                                            packing.PackingStatus == PackingStatus
                                       select new
                                       {
                                           ShipmentID = packing.PackingId,
                                           TimeRquare = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime),
                                           Quantity = 00
                                       };
                var packingG = from pj in packingTimeAndID
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.ShippingNumber = cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<PackingTimeDTO></returns>
        public List<PackingTimeDTO> GetPackingTimeAndQantityByStation(Guid UserID, DateTime Fromdate, DateTime Todate, int PackingStatus, Guid StationID)
        {
            List<PackingTimeDTO> _lsreturnPacingTime = new List<PackingTimeDTO>();
            if (PackingStatus == 0)
            {
                try
                {
                    DateTime dt = DateTime.UtcNow;
                    var packingTimeAndID = from packing in x3v6.Packages
                                           join Packingdtl in x3v6.PackageDetails
                                           on packing.PackingId equals Packingdtl.PackingId
                                           where packing.UserId == UserID &&
                                         EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                          EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date &&
                                          packing.PackingStatus == PackingStatus
                                          && packing.StationID == StationID
                                           select new
                                           {
                                               ShipmentID = Packingdtl.PackingId,
                                               TimeSpend = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime)
                                           };
                    var PackingQuantity = from packingDetail in x3v6.PackageDetails
                                          group packingDetail by packingDetail.PackingId into Gpd
                                          select new
                                          {
                                              ShipmentID = Gpd.Key,
                                              Quantity = Gpd.Sum(p => p.SKUQuantity)
                                          };
                    var packingJoin = from Pq in PackingQuantity
                                      join Pt in packingTimeAndID
                                      on Pq.ShipmentID equals Pt.ShipmentID
                                      select new
                                      {
                                          ShipmentID = Pq.ShipmentID,
                                          TimeRquare = Pt.TimeSpend,
                                          Quantity = Pq.Quantity
                                      };
                    var packingG = from pj in packingJoin
                                   group pj by pj.ShipmentID into GPj
                                   select GPj;

                    foreach (var listItem in packingG)
                    {
                        PackingTimeDTO _Packing = new PackingTimeDTO();
                        _Packing.PackingID = listItem.Key;
                        _Packing.ShippingNumber =cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                        _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }
                catch (Exception)
                { }
            }
            else
            {
                var packingTimeAndID = from packing in x3v6.Packages
                                       where packing.UserId == UserID &&
                                           EntityFunctions.TruncateTime(packing.EndTime.Value) >= Fromdate.Date &&
                                            EntityFunctions.TruncateTime(packing.EndTime.Value) <= Todate.Date &&
                                            packing.PackingStatus == PackingStatus
                                       select new
                                       {
                                           ShipmentID = packing.PackingId,
                                           TimeRquare = SqlFunctions.DateDiff("s", packing.StartTime, packing.EndTime),
                                           Quantity = 00
                                       };
                var packingG = from pj in packingTimeAndID
                               group pj by pj.ShipmentID into GPj
                               select GPj;

                foreach (var listItem in packingG)
                {
                    PackingTimeDTO _Packing = new PackingTimeDTO();
                    _Packing.ShippingNumber = cmd.GetByPackageID(listItem.Key)[0].ShippingNum;
                    _Packing.Quantity = Convert.ToInt32(listItem.FirstOrDefault().Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.FirstOrDefault().TimeRquare.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            return _lsreturnPacingTime;
        }
        #endregion

    }
}
