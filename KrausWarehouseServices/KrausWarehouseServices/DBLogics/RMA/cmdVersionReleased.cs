using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.RMA
{
   public class cmdVersionReleased
    {
       /// <summary>
       /// Returns the max number that is inserted in to the table of version number.
       /// </summary>
       /// <returns>String Value of latest version number</returns>
       public String GetNewVersionNumber()
       {
           Connections.Shipping.Shipping_ManagerEntities1 entShipping = new Connections.Shipping.Shipping_ManagerEntities1();
           String VersionNumber = "1.0.0.1";
           try
           {
               VersionNumber = (from ent in entShipping.VersionRelease_RGA
                                select ent).ToList().OrderBy(i => i.DateReleased).Last().VersionNumber.ToString();
           }
           catch (Exception)
           { }
           return VersionNumber;
       }
    }
}
