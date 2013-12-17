using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping
{
  public class cmdUPCtoSKUandVs
    {
      Connections.Shipping.Shipping_ManagerEntities1 entShipping = new Connections.Shipping.Shipping_ManagerEntities1();
     
        /// <summary>
        /// Convert UPC Code to the SKu name.
        /// </summary>
        /// <param name="UPCCode">11 or 12 Digit UPC Code.</param>
        /// <returns>String of Sku Name in error blank string.</returns>
        public  String UPCCodeToSKU(String UPCCode)
        {
            String _return = "";
            try
            {
                _return = entShipping.Get_Shipping_Data.FirstOrDefault(i => i.UPCCode == UPCCode).SKU.ToString();
                    //Sage.ITMMASTERs.SingleOrDefault(i => i.EANCOD_0 == UPCCode).ITMDES1_0.ToString();

            }
            catch (Exception)
            {
            }
            return _return;
        }

        /// <summary>
        /// SKU Name to its UPC Code.
        /// </summary>
        /// <param name="SKUName">String SKU Name.</param>
        /// <returns>String UPC 13 Digit code in error "000000000000" code</returns>
        public  String SKUNameToUPC(String SKUName)
        {
            string UPCACode = "000000000000";

            try
            {
                // var vUPCACode = Sage.ExecuteStoreQuery<String>(@"SELECT TOP 1 [ITMMASTER].[EANCOD_0] AS UPCCode FROM [PRODUCTION].[ITMMASTER] WHERE [ITMMASTER].[ITMDES1_0] ='" + SKUName + "';").ToList();
                var vUPCACode = entShipping.Get_Shipping_Data.FirstOrDefault(i => i.SKU == SKUName).UPCCode.ToString();
                //Sage.ITMMASTERs.SingleOrDefault(i => i.ITMDES1_0 == SKUName).EANCOD_0.ToList();
                if (vUPCACode != null)
                {
                    UPCACode = vUPCACode;
                }
            }
            catch (Exception)
            { }
            return UPCACode;
        }
    }
}
