using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KrausWarehouseServices.DBLogics;
using KrausWarehouseServices.DBLogics.RMA;

namespace KrausWarehouseServices.Service.RMA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Delete" in both code and config file together.
    public class Delete : IDelete
    {

        #region Declarations.
        /// <summary>
        /// Return Deails Table Object.
        /// </summary>
        cmdReturnDetail _cReturnDetails = new cmdReturnDetail();

        cmdReasonCategory _cReasonCategory = new cmdReasonCategory();

        cmdSKUReasons _cSKUReasons = new cmdSKUReasons();
        #endregion

        public bool ReturnDetailsallForeignKeyTables(Guid ReturnDetailID)
        {
           return _cReturnDetails.DeleteAllForeignKeyTables(ReturnDetailID);
        }


        public bool ReasonCategoryByReasonID(Guid ReasonID)
        {
            return _cReasonCategory.DeleteByReasonID(ReasonID);
        }

        #region SKUReasons

        public Boolean SKUReasonsByReturnDetailsID(Guid ReturnDetailID)
        {
            return _cSKUReasons.DeleteByReturnDetailsID(ReturnDetailID);
        }

        #endregion

    }
}
