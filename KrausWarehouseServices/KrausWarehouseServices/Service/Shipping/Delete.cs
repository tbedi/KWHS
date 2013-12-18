using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KrausWarehouseServices.DBLogics.Shipping;

namespace KrausWarehouseServices.Service.Shipping
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Delete" in both code and config file together.
    public class Delete : IDelete
    {

        #region Declarations

        /// <summary>
        /// Package Table commands
        /// </summary>
        cmdPackage _cPackage = new cmdPackage();

        /// <summary>
        /// Shipping Table object.
        /// </summary>
        cmdShipping _cShipping = new cmdShipping();


        #endregion

        public bool PackageByShipmentNum(string ShipmentNum)
        {
            return _cPackage.DeleteByShipmentNum(ShipmentNum);
        }

        public bool ShippingByPackingID(Guid PackingID)
        {
            return _cShipping.DeleteShipment(PackingID);
        }
    }
}
