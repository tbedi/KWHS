using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;

namespace KrausWarehouseServices.DTO
{
    /// <summary>
    /// DTO of user table.
    /// </summary>
    [DataContract]
    public class UserDTO 
    {
        /// <summary>
        /// Paremeterised constructor for class.
        /// </summary>
        /// <param name="_user">
        /// User Object of entity class.
        /// </param>
        public UserDTO(User _user)
        {
          if(_user.UserID!=null)  this.UserID = _user.UserID;
          if(_user.RoleId!=null)  this.RoleId = _user.RoleId;
          if(_user.UserFullName!=null)  this.UserFullName = _user.UserFullName;
          if(_user.UserName!=null)  this.UserName = _user.UserName;
          if(_user.UserAddress!=null)  this.UserAddress = _user.UserAddress;
          if(_user.UserJoiningDate!=null)  this.UserJoiningDate = (DateTime)_user.UserJoiningDate;
          if(_user.UserPassword!=null)  this.UserPassword = _user.UserPassword;
          if (_user.CreatedDateTime != null) this.CreatedDateTime = (DateTime)_user.CreatedDateTime;
          if (_user.UpdatedDateTime != null) this.UpdatedDateTime = (DateTime)_user.UpdatedDateTime;
          if (_user.CreatedBy != null) this.CreatedBy = (Guid)_user.CreatedBy;
          if (_user.Updatedby != null) this.Updatedby = (Guid)_user.Updatedby;
        }

        /// <summary>
        /// Blank constructor.
        /// </summary>
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
