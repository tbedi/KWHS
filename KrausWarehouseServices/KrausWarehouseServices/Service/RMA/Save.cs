using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.RMA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Save" in both code and config file together.
    public class Save : ISave
    {
        #region Declaration
        //create User Object
        DBLogics.RMA.cmdUser _user = new DBLogics.RMA.cmdUser();

        //create Return object
        DBLogics.RMA.cmdReturn _returnobj = new DBLogics.RMA.cmdReturn();

        //create ReturnDetail object
        DBLogics.RMA.cmdReturnDetail _returnDetailobj = new DBLogics.RMA.cmdReturnDetail();

        //create Reason object
        DBLogics.RMA.cmdReasons _reason = new DBLogics.RMA.cmdReasons();

        //create ReasonCategory object
        DBLogics.RMA.cmdReasonCategory _reasonCat = new DBLogics.RMA.cmdReasonCategory();

        //create Role object
        DBLogics.RMA.cmdRoles _role = new DBLogics.RMA.cmdRoles();

        //create SKUNumber object
        DBLogics.RMA.cmdSKUReasons _SKUnumber = new DBLogics.RMA.cmdSKUReasons();

        //create ReturnImage object
        DBLogics.RMA.cmdReturnImages _returnImg = new DBLogics.RMA.cmdReturnImages();

        DBLogics.RMA.cmdAudit _audit = new DBLogics.RMA.cmdAudit();

        #endregion

        public bool ReasonCategory(DTO.RMA.ReasonCategoryDTO reasonCat)
        {
            return _reasonCat.UpsertReasonCategory(reasonCat);
        }

        public bool Reasons(DTO.RMA.ReasonsDTO reasons)
        {
            return _reason.UpsertReasons(reasons);
        }

        public bool Return(DTO.RMA.ReturnDTO _return)
        {
            return _returnobj.UpsertReturnTbl(_return);
        }

        public bool ReturnDetails(DTO.RMA.ReturnDetailsDTO returndetail)
        {
            return _returnDetailobj.UpsertReturnDetail(returndetail);
        }

        public bool ReturnImages(DTO.RMA.ReturnImagesDTO returnimages)
        {
            return _returnImg.UpsertRerurnImages(returnimages);
        }

        public bool SKUReasons(DTO.RMA.SKUReasonsDTO SKU)
        {
            return _SKUnumber.UpsertSKUReasons(SKU);
        }

        public bool User(DTO.RMA.UserDTO user)
        {
            return _user.UpsertUser(user);
        }

        public bool UpsertAudit(DTO.RMA.AuditDTO audit)
        {
            return _audit.UpsertAudit(audit);
        }
    }
}
