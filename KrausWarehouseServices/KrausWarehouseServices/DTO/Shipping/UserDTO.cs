using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace KrausWarehouseServices.DTO.Shipping
{
   [DataContract]
   public class UserDTO
    {
       [DataMember]
        public Guid UserID { get; set; }
        
       [DataMember]
       public string UserName { get; set; }
      
       [DataMember]
       public String UserFullName { get; set; }
     
       [DataMember]
       public String UserAddress { get; set; }
       
       [DataMember]
       public DateTime UserJoiningDate { get; set; }
       
       [DataMember]
       public String UserPassword { get; set; }
       
       [DataMember]
       public Guid RoleID { get; set; }

       [DataMember]
       public DateTime CreatedDateTime { get; set; }

       [DataMember]
       public DateTime UpdatedDateTime { get; set; }

       [DataMember]
       public Guid CreatedBy { get; set; }

       [DataMember]
       public Guid Updatedby { get; set; }

       public UserDTO()
       {
           //Blank Constructor.
       }

       public UserDTO(Connections.Shipping.User user)
       {
           if (user.UserID != null) this.UserID = user.UserID;
           if (user.UserName != null) this.UserName = user.UserName;
           if (user.UserAddress != null) this.UserAddress = user.UserAddress;
           if (user.UserJoiningDate != Convert.ToDateTime("01/01/0001")) this.UserJoiningDate = (DateTime)user.UserJoiningDate;
           if (user.UserPassword != null) this.UserPassword = (String)user.UserPassword;
           if (user.UserFullName != null) this.UserFullName = (String)user.UserFullName;
           if (user.Role != null) this.RoleID = (Guid)user.RoleId;
           if (user.CreatedDateTime !=null) this.CreatedDateTime = (DateTime)user.CreatedDateTime;
           if (user.UpdatedDateTime!=null) this.UpdatedDateTime = (DateTime)user.UpdatedDateTime;
           if (user.Updatedby != null ) this.Updatedby = (Guid)user.Updatedby;
           if (user.CreatedBy != null) this.CreatedBy = (Guid)user.CreatedBy;
       }
    }
}
