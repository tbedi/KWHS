using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping
{
   public class cmdSageOperations
    {

       Connections.x3v6Entities ent = new Connections.x3v6Entities();

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
                var Name = ent.ExecuteStoreQuery<string>(@"SELECT [BPCNAM_0] FROM [PRODUCTION].[BPCUSTOMER] WHERE [BPCNUM_0]='" + BPNUM_0 + "';");
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
