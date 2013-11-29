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

        public List<DTO.RMA.UserDTO> xGet(string ID, string Parameters)
        {
            switch (ID.ToUpper())
            {
                case "USERID":
                    Guid UserID;
                    Guid.TryParse(Parameters, out UserID);
                    List<DTO.RMA.UserDTO> _lsReturnDTO = new List<DTO.RMA.UserDTO>();
                    _lsReturnDTO.Add(this.GetByUserID(UserID));
                    return _lsReturnDTO;

                case "ROLEID":
                    Guid RoleID;
                    Guid.TryParse(Parameters, out RoleID);
                    return this.GetByRoleID(RoleID);

                case "LOGINNAME":
                    List<DTO.RMA.UserDTO> _lsReturnDTO2 = new List<DTO.RMA.UserDTO>();
                    _lsReturnDTO2.Add(this.GetByUserName(Parameters));
                    return _lsReturnDTO2;

                case "GETALL":
                    return this.Get();

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
