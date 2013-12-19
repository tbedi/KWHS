using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.DTO.Shipping.ReportEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
    public class cmdShippinNumStatus
    {
        /// <summary>
        /// Local entity Database object 
        /// </summary>
        Connections.Shipping.Shipping_ManagerEntities1 ent = new Connections.Shipping.Shipping_ManagerEntities1();

        /// <summary>
        /// Shipment number serch for information of packing status
        /// </summary>
        /// <param name="ShippingNumber">String Shipping Number</param>
        /// <returns>List<ShipmentNumStatusDTO> depending on location retuersn shipping number information</returns>
        public List<ShipmentNumStatusDTO> GetStaus(String ShippingNumber)
        {
            List<ShipmentNumStatusDTO> _lsStatus = new List<ShipmentNumStatusDTO>();

            try
            {
                var frmPackage = from pac in ent.Packages
                                 where pac.ShippingNum == ShippingNumber
                                 select pac;

                foreach (var item in frmPackage)
                {
                    ShipmentNumStatusDTO Statusnumber = new ShipmentNumStatusDTO();
                    String PackingStatus = "UnderPacking";
                    int PackingStatusInt = 4;
                    if (item.PackingStatus == 0)
                    {
                        PackingStatus = "Packed";
                        PackingStatusInt = 5;
                    }
                    try
                    {

                        cmdBoxPackage _box = new cmdBoxPackage();
                        cmdTracking tracking = new cmdTracking();
                        string trackingNO = "";
                        List<BoxPackageDTO> lsBoxpackage = _box.GetSelectedByPackingID(item.PackingId);

                        foreach (BoxPackageDTO Boxitem in lsBoxpackage)
                        {
                            if (tracking.IschecckTrackingNumberPresent(Boxitem.BOXNUM) == "")
                            {
                                trackingNO = "";
                                break;
                            }
                            else
                            {
                                trackingNO = tracking.IschecckTrackingNumberPresent(Boxitem.BOXNUM);
                            }
                        }
                        if (trackingNO != "" && trackingNO != null)
                        {
                            PackingStatus = "Traking";
                            PackingStatusInt = 6;
                        }
                    }
                    catch (Exception)
                    {
                    }

                    Statusnumber.PackageID = item.PackingId;
                    Statusnumber.ShippingNum = item.ShippingNum;
                    Statusnumber.ShippinStatus = PackingStatus;
                    Statusnumber.ShippingCompletedInt = PackingStatusInt;
                    Statusnumber.Location = item.ShipmentLocation;

                    int indexofls = _lsStatus.FindLastIndex(i => i.ShippingNum == ShippingNumber && i.Location == item.ShipmentLocation);
                    if (indexofls.ToString() != "-1")
                    {
                        if (_lsStatus[indexofls].ShippingCompletedInt <= PackingStatusInt)
                        {
                            _lsStatus[indexofls].ShippinStatus = PackingStatus;
                            _lsStatus[indexofls].ShippingCompletedInt = PackingStatusInt;
                        }
                    }
                    else
                    {
                        _lsStatus.Add(Statusnumber);
                    }
                }

            }
            catch (Exception)
            { }
            return _lsStatus;
        }

    }
}
