using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.RMA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDelete" in both code and config file together.
    [ServiceContract]
    public interface IDelete
    {
        #region ReturnDetails

        [OperationContract]
        bool ReturnDetailsallForeignKeyTables(Guid ReturnDetailID); 

        #endregion

        #region Reason
        [OperationContract]
        Boolean ReasonCategoryByReasonID(Guid ReasonID);
        #endregion
    }
}
