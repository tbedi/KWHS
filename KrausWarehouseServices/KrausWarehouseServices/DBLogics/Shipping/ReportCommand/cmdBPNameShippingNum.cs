using KrausWarehouseServices.DTO.Shipping.ReportEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping.ReportCommand
{
   public class cmdBPNameShippingNum
    {

        //Local Database model Object
       Connections.x3v6Entities sent = new Connections.x3v6Entities();
        //Sage Database Model object
       Connections.Shipping.Shipping_ManagerEntities1 lent = new Connections.Shipping.Shipping_ManagerEntities1();

        /// <summary>
        /// Add Delivery provide name to the from sage and add it to the list of information of shipment.
        /// </summary>
        /// <returns>List<ShippingInfoBPNameDTO> information</returns>
        public List<ShippingInfoBPNameDTO> GetBpinfoOFShippingNum()
        {
            //list with Delivery provider name. to be returened.
            List<ShippingInfoBPNameDTO> _lsretuen = new List<ShippingInfoBPNameDTO>();
            try
            {
                var ship = lent.Shippings;
                foreach (var item in ship)
                {
                    ShippingInfoBPNameDTO Bpnamecall = new ShippingInfoBPNameDTO();
                    Bpnamecall.BPName = getBPNameFromBPNUM(item.DeliveryProvider);
                    Bpnamecall.ShippingID = item.ShippingID;
                    Bpnamecall.ShippingNumner = item.ShippingNum;
                    Bpnamecall.BusinessPartNo = item.DeliveryProvider;
                    Bpnamecall.ShippingStatus = item.ShipmentStatus;
                    _lsretuen.Add(Bpnamecall);
                }
            }
            catch (Exception)
            { }
            return _lsretuen;
        }


        /// <summary>
        /// get the Name from number
        /// </summary>
        /// <param name="BPNUM_0">string Delivery provider number</param>
        /// <returns>Srtring Delivery Provider name</returns>
        public string getBPNameFromBPNUM(string BPNUM_0)
        {
            string BpName = "";
            try
            {
                var Name = sent.ExecuteStoreQuery<string>(@"SELECT [BPCNAM_0] FROM [PRODUCTION].[BPCUSTOMER] WHERE [BPCNUM_0]='" + BPNUM_0 + "';");
                foreach (var item in Name)
                {
                    BpName = item.ToString();
                }
            }
            catch (Exception)
            {
            }
            return BpName;
        }
    }
}
