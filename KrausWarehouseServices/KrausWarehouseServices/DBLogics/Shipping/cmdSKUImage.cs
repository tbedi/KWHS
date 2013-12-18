using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.Connections.Shipping;


namespace KrausWarehouseServices.DBLogics.Shipping
{
   public class cmdSKUImage
   {
       /// <summary>
       /// Create Entity Object.
       /// </summary>
       Shipping_ManagerEntities1 entshipping = new Shipping_ManagerEntities1();

       #region GetMethods For SKUImages

       /// <summary>
       /// Get SKUUrl by SKUname.
       /// </summary>
       /// <param name="SKUName"></param>
       /// <returns></returns>
       public string GetSKUurlByName(string SKUName)
       {
           string _flag = "";
           try
           {
               var sku = entshipping.SKUImages.SingleOrDefault(re => re.SKU == SKUName).SKUrl;
               _flag = sku;
           }
           catch (Exception)
           {
           }
           return _flag;
       }


       /// <summary>
       /// check that product show barcode or not
       /// </summary>
       /// <param name="SKUName">
       /// String SKU name to be check
       /// </param>
       /// <returns>
       /// Boolean value to show barcode or not
       /// </returns>
       public Boolean getBarcodeShowFlag(string SKUName)
       {
           Boolean _return = true;
           try
           {
               int Showvalue = entshipping.SKUImages.FirstOrDefault(i => i.SKU == SKUName).BarcodeFlag;
               if (Showvalue == 0) _return = false;
           }
           catch (Exception)
           { }
           return _return;
       }
       
       #endregion
   }
}
