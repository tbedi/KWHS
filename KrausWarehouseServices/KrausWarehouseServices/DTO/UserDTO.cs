using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;

namespace KrausWarehouseServices.DTO
{
    [DataContract]
    public class UserDTO
    {
        public UserDTO(User _user)
        {
            this.UserID = _user.UserID;
            this.RoleId = _user.RoleId;
            this.UserFullName = _user.UserFullName;
            this.UserName = _user.UserName;
            this.UserAddress = _user.UserAddress;
            this.UserJoiningDate = (DateTime)_user.UserJoiningDate;
            this.UserPassword = _user.UserPassword;
            this.CreatedDateTime = (DateTime)_user.CreatedDateTime;
            this.UpdatedDateTime = (DateTime)_user.UpdatedDateTime;
            this.CreatedBy = (Guid)_user.CreatedBy;
            this.Updatedby = (Guid)_user.Updatedby;
        }

        public UserDTO() { }

        [DataMember]
        public Guid UserID { get; set; }

        [DataMember]
        public Guid RoleId { get; set; }

        [DataMember]
        public String UserFullName { get; set; }

        [DataMember]
        public String UserName { get; set; }

        [DataMember]
        public String UserAddress { get; set; }

        [DataMember]
        public DateTime UserJoiningDate { get; set; }

        [DataMember]
        public String UserPassword { get; set; }

        [DataMember]
        public DateTime CreatedDateTime { get; set; }

        [DataMember]
        public DateTime UpdatedDateTime { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public Guid Updatedby { get; set; }
    }
}
