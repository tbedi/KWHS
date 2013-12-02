﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.RMA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Get" in both code and config file together.
    public class Get : IGet
    {

        #region Declaration
        //create User Object
        DBLogics.RMA.cmdUser _user = new DBLogics.RMA.cmdUser();

        //create Return object
        DBLogics.RMA.cmdReturn _return = new DBLogics.RMA.cmdReturn();

        //create ReturnDetail object
        DBLogics.RMA.cmdReturnDetail _returnDetail = new DBLogics.RMA.cmdReturnDetail();

        //create Reason object
        DBLogics.RMA.cmdReasons _reason = new DBLogics.RMA.cmdReasons();

        //create ReasonCategory object
        DBLogics.RMA.cmdReasonCategory _reasonCat = new DBLogics.RMA.cmdReasonCategory();

        //create Role object
        DBLogics.RMA.cmdRoles _role = new DBLogics.RMA.cmdRoles();

        //create SKUNumber object
        DBLogics.RMA.cmdSKUReasons _SKUnumber = new DBLogics.RMA.cmdSKUReasons();

        //Audit commands .
        DBLogics.RMA.cmdAudit _audit = new DBLogics.RMA.cmdAudit();

        //sage Operations Object.
        DBLogics.RMA.cmdSage _sageOperations = new DBLogics.RMA.cmdSage();
        #endregion

        #region User

        public List<DTO.RMA.UserDTO> xGet(string EnumGetType, string Parameters)
        {
            //Convert to the Get Enum type.
            Globle_Classes.get Getid;
            Enum.TryParse(EnumGetType, true, out Getid);

            switch ((int)Getid)
            {
                case 0:
                    return this.UserAll();

                case 1:
                    Guid UserID;
                    Guid.TryParse(Parameters, out UserID);
                    List<DTO.RMA.UserDTO> _lsReturnDTO = new List<DTO.RMA.UserDTO>();
                    _lsReturnDTO.Add(this.UserByUserID(UserID));
                    return _lsReturnDTO;

                case 2:
                    Guid RoleID;
                    Guid.TryParse(Parameters, out RoleID);
                    return this.UserByRoleID(RoleID);

                case 3:
                    List<DTO.RMA.UserDTO> _lsReturnDTO2 = new List<DTO.RMA.UserDTO>();
                    _lsReturnDTO2.Add(this.UserByUserName(Parameters));
                    return _lsReturnDTO2;

                default:
                    List<DTO.RMA.UserDTO> userDTO = new List<DTO.RMA.UserDTO>();
                    return userDTO;
            }
        }

        public List<DTO.RMA.UserDTO> UserAll()
        {
            return _user.GetUserTbl();
        }

        public DTO.RMA.UserDTO UserByUserID(Guid UserID)
        {
            return _user.GetUserTbl1(UserID);
        }

        public List<DTO.RMA.UserDTO> UserByRoleID(Guid RoleID)
        {
            return _user.GetUserByRoleID(RoleID);
        }

        public DTO.RMA.UserDTO UserByUserName(string UserName)
        {
            return _user.GetUserTbl(UserName);
        }

        #endregion

        #region Return

        public List<DTO.RMA.ReturnDTO> ReturnAll()
        {
            return _return.GetReturnTbl();
        }

        public DTO.RMA.ReturnDTO ReturnByReturnID(Guid ReturnID)
        {
            return _return.GetReturnTblByReturnID(ReturnID);
        }

        public List<DTO.RMA.ReturnDTO> ReturnByReturnDetailID(Guid ReturnDetailsID)
        {
            return null;
        }

        public DTO.RMA.ReturnDTO ReturnByRMANumber(string RMANumber)
        {
            return _return.GetReturnTblByRMANumber(RMANumber);
        }

        #endregion

        #region Reason

        public List<DTO.RMA.ReasonsDTO> ReasonsAll()
        {
            return _reason.GetReasons();
        }

        public List<DTO.RMA.ReasonsDTO> ReasonByCategoryName(string CategoryName)
        {
            return _reason.GetReasonByCategoryName(CategoryName);
        }

        #endregion

        #region Audit
        public List<DTO.RMA.AuditDTO> AuditAll()
        {
            return _audit.GetAudit();
        }
        #endregion

        #region Sage Operations

        public List<DTO.RMA.RMAInfoDTO> RMAInfoByShippingNumber(string ShippingNumber)
        {
            return _sageOperations.GetRMAInfoByShipmentNumber(ShippingNumber);
        }

        public List<DTO.RMA.RMAInfoDTO> RMAInfoBySONumber(string SONumber)
        {
            return _sageOperations.GetRMAInfoBySONumber(SONumber);
        }

        public List<DTO.RMA.RMAInfoDTO> RMAInfoByPONumber(string PONumber)
        {
            return _sageOperations.GetRMAInfoByPONumber(PONumber);
        }

        public List<DTO.RMA.RMAInfoDTO> RMAInfoBySRNumber(string SRNumber)
        {
            return _sageOperations.GetRMAInfoBySRNumber(SRNumber);
        }

        #endregion
    
    
    }
}
