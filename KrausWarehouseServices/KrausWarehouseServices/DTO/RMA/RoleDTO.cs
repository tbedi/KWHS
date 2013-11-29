using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.RMA
{
    [DataContract]
   public class RoleDTO
    {
       
       public RoleDTO(Role _role)
       {
         if(_role.RoleId!=Guid.Empty) this.RoleID =(Guid) _role.RoleId;
         if(_role.Name!=null) this.Name=_role.Name;
         if(_role.Action!=null) this.Action=_role.Action;
         if(_role.CreatedDateTime!=null) this.CreatedDateTime=(DateTime)_role.CreatedDateTime;
         if(_role.UpdatedDateTime!=null) this.UpdatedDateTime=(DateTime)_role.UpdatedDateTime;
         if(_role.CreatedBy!=null) this.CreatedBy=_role.CreatedBy;
         if(_role.Updatedby!=null) this.Updatedby = _role.Updatedby;
       }
       public RoleDTO()
       { 
       }
        [DataMember]
        public Guid RoleID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Action { get; set; }

        [DataMember]
        public DateTime CreatedDateTime { get; set; }

        [DataMember]
        public DateTime UpdatedDateTime { get; set; }

        [DataMember]
        public Guid? CreatedBy { get; set; }

        [DataMember]
        public Guid? Updatedby { get; set; }
    }
}
