using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
    class cmdBPNameShippingNum
    {
        ///// <summary>
        ///// Add Delivery provide name to the from sage and add it to the list of information of shipment.
        ///// </summary>
        ///// <returns>List<cstShippingInfoBPName> information</returns>
        //public List<cstShippingInfoBPName> GetBpinfoOFShippingNum()
        //{
        //    //list with Delivery provider name. to be returened.
        //    List<cstShippingInfoBPName> _lsretuen = new List<cstShippingInfoBPName>();
        //    try
        //    {
        //        var ship = Service.Get.ShippingAllShipping();
        //        foreach (var item in ship)
        //        {
        //            cstShippingInfoBPName Bpnamecall = new cstShippingInfoBPName();
        //            Bpnamecall.BPName = getBPNameFromBPNUM(item.DeliveryProvider);
        //            Bpnamecall.ShippingID = item.ShippingID;
        //            Bpnamecall.ShippingNumner = item.ShippingNum;
        //            Bpnamecall.BusinessPartNo = item.DeliveryProvider;
        //            Bpnamecall.ShippingStatus = item.ShipmentStatus;
        //            _lsretuen.Add(Bpnamecall);
        //        }
        //    }
        //    catch (Exception)
        //    { }
        //    return _lsretuen;
        //}


        ///// <summary>
        ///// get the Name from number
        ///// </summary>
        ///// <param name="BPNUM_0">string Delivery provider number</param>
        ///// <returns>Srtring Delivery Provider name</returns>
        //public string getBPNameFromBPNUM(string BPNUM_0)
        //{
        //    string BpName = "";
        //    try
        //    {
        //        var Name = Service.Get.getBPNameFromBPNUM(BPNUM_0);
        //        foreach (var item in Name)
        //        {
        //            BpName = item.ToString();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return BpName;
        //}
    }
}
