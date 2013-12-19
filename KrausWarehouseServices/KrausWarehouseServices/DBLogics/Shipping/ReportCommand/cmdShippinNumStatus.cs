using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
    public class cmdShippinNumStatus
    {
        ///// <summary>
        ///// Shipment number serch for information of packing status
        ///// </summary>
        ///// <param name="ShippingNumber">String Shipping Number</param>
        ///// <returns>List<cstShipmentNumStatus> depending on location retuersn shipping number information</returns>
        //public List<cstShipmentNumStatus> GetStaus(String ShippingNumber)
        //{
        //    List<cstShipmentNumStatus> _lsStatus = new List<cstShipmentNumStatus>();

        //    try
        //    {
        //        var frmPackage = Service.Get.PackageByShippingNum(ShippingNumber);

        //        foreach (var item in frmPackage)
        //        {
        //            cstShipmentNumStatus Statusnumber = new cstShipmentNumStatus();
        //            String PackingStatus = "UnderPacking";
        //            int PackingStatusInt = 4;
        //            if (item.PackingStatus == 0)
        //            {
        //                PackingStatus = "Packed";
        //                PackingStatusInt = 5;
        //            }
        //            try
        //            {

        //                cmdBox _box = new cmdBox();
        //                cmdTracking tracking = new cmdTracking();
        //                string trackingNO = "";
        //                List<cstBoxPackage> lsBoxpackage = _box.GetSelectedByPackingID(item.PackingId);

        //                foreach (cstBoxPackage Boxitem in lsBoxpackage)
        //                {
        //                    if (tracking.IschecckTrackingNumberPresent(Boxitem.BOXNUM) == "")
        //                    {
        //                        trackingNO = "";
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        trackingNO = tracking.IschecckTrackingNumberPresent(Boxitem.BOXNUM);
        //                    }
        //                }
        //                if (trackingNO != "" && trackingNO != null)
        //                {
        //                    PackingStatus = "Traking";
        //                    PackingStatusInt = 6;
        //                }
        //            }
        //            catch (Exception)
        //            {
        //            }

        //            Statusnumber.PackageID = item.PackingId;
        //            Statusnumber.ShippingNum = item.ShippingNum;
        //            Statusnumber.ShippinStatus = PackingStatus;
        //            Statusnumber.ShippingCompletedInt = PackingStatusInt;
        //            Statusnumber.Location = item.ShipmentLocation;

        //            int indexofls = _lsStatus.FindLastIndex(i => i.ShippingNum == ShippingNumber && i.Location == item.ShipmentLocation);
        //            if (indexofls.ToString() != "-1")
        //            {
        //                if (_lsStatus[indexofls].ShippingCompletedInt <= PackingStatusInt)
        //                {
        //                    _lsStatus[indexofls].ShippinStatus = PackingStatus;
        //                    _lsStatus[indexofls].ShippingCompletedInt = PackingStatusInt;
        //                }
        //            }
        //            else
        //            {
        //                _lsStatus.Add(Statusnumber);
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    { }
        //    return _lsStatus;
        //}

    }
}
