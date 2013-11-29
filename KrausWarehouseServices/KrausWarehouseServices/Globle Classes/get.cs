using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.Globle_Classes
{
    public enum get
    {
        #region User Service.
        
        All = 0,
        UserID,
        RoleID,
        UserName,

        #endregion

        #region Return Service

        ReturnID =4,
        ReturnDetailID,


        #endregion
    }
}
