using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.Shipping
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDelete" in both code and config file together.
    [ServiceContract]
    public interface IDelete
    {
        #region package
        [OperationContract]
        Boolean PackageByShipmentNum(String ShipmentNum);
        #endregion

        #region Shipping
        [OperationContract]
        Boolean ShippingByPackingID(Guid PackingID);
        #endregion
    }
}
