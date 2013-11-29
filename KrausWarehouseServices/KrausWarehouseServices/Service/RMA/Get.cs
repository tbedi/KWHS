using System;
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
        DBLogics.RMA.cmdUser _user = new DBLogics.RMA.cmdUser();
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
    }
}
