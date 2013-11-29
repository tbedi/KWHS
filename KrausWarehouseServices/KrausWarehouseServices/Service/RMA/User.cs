using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.RMA
{
    /// <summary>
    /// User service model.
    /// </summary>
    public class User : IUser
    {
        DBLogics.RMA.cmdUser _user = new DBLogics.RMA.cmdUser();

        /// <summary>
        /// XML return user information.
        /// </summary>
        /// <param name="EnumGetType">
        /// Function call ID
        /// ID examples: USERID/ROLEID/LOGINNAME/GETALL.
        /// </param>
        /// <param name="Parameters">
        /// parametes to respective ID passed. in string.
        /// </param>
        /// <returns>
        /// list of UserDTO table information.
        /// </returns>
        public List<DTO.RMA.UserDTO> xGet(string EnumGetType, string Parameters)
        {
            //Convert to the Get Enum type.
            Globle_Classes.get Getid;
            Enum.TryParse(EnumGetType, true, out Getid);

            switch ((int) Getid)
            { 
                case 0:
                    return this.Get();

                case 1:
                    Guid UserID;
                    Guid.TryParse(Parameters, out UserID);
                    List<DTO.RMA.UserDTO> _lsReturnDTO = new List<DTO.RMA.UserDTO>();
                    _lsReturnDTO.Add(this.GetByUserID(UserID));
                    return _lsReturnDTO;

                case 2:
                    Guid RoleID;
                    Guid.TryParse(Parameters, out RoleID);
                    return this.GetByRoleID(RoleID);

                case 3:
                    List<DTO.RMA.UserDTO> _lsReturnDTO2 = new List<DTO.RMA.UserDTO>();
                    _lsReturnDTO2.Add(this.GetByUserName(Parameters));
                    return _lsReturnDTO2;

                default:
                    List<DTO.RMA.UserDTO> userDTO = new List<DTO.RMA.UserDTO>();
                    return userDTO;
            }
        }

        public List<DTO.RMA.UserDTO> Get()
        {
            return _user.GetUserTbl();
        }

        public DTO.RMA.UserDTO GetByUserID(Guid UserID)
        {
            return _user.GetUserTbl1(UserID);
        }

        public List<DTO.RMA.UserDTO> GetByRoleID(Guid RoleID)
        {
            return _user.GetUserByRoleID(RoleID);
        }

        public DTO.RMA.UserDTO GetByUserName(string UserName)
        {
            return _user.GetUserTbl(UserName);
        }

        public Guid Save(DTO.RMA.UserDTO UserInformation)
        {
            return Guid.Empty;
        }

        public bool Delete(Guid UserID)
        {
            return false;
        }
    }
}
