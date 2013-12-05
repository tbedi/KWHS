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
       public String UserAddress { get; set; }
       
       [DataMember]
       public DateTime JoiningDate { get; set; }
       
       [DataMember]
       public String Password { get; set; }
        
       [DataMember]
       public String UserFullName { get; set; }
       
       [DataMember]
       public String RoleName { get; set; }
       
       [DataMember]
       public Guid Role { get; set; }

       public UserDTO()
       {
           //Blank Constructor.
       }

       public UserDTO(Connections.Shipping.User user)
       {
           if (user.UserID != null) this.UserID = user.UserID;
           if (user.UserName != null) this.UserName = user.UserName;
           if (user.UserAddress != null) this.UserAddress = user.UserAddress;
           if (user.UserJoiningDate != null) this.JoiningDate = (DateTime)user.UserJoiningDate;
       }
    }
}
