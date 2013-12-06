using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
    public class RoleDTO
    {


        [DataMember]
        public Guid RoleID { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String Action { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public Guid Updatedby { get; set; }

        [DataMember]
        public DateTime? CreatedDateTime { get; set; }

        [DataMember]
        public DateTime? UpdatedDateTime { get; set; }
       
        /// <summary>
        /// Blank Constructor.
        /// </summary>
        public RoleDTO()
        {
        }

        public RoleDTO(Connections.Shipping.Role _role)
        {
            if (_role.RoleId != null) this.RoleID = (Guid)_role.RoleId;
            if (_role.Name != null) this.Name = (String)_role.Name;
            if (_role.Action != null) this.Action = (string)_role.Action;
            if (_role.CreatedBy != null) this.CreatedBy = (Guid)_role.CreatedBy;
            if (_role.Updatedby != null) this.Updatedby = (Guid)_role.Updatedby;
            if (_role.CreatedDateTime != Convert.ToDateTime("01/01/0001")) this.CreatedDateTime = _role.CreatedDateTime;
            if (_role.UpdatedDateTime != Convert.ToDateTime("01/01/0001")) this.UpdatedDateTime = _role.UpdatedDateTime;
        }
    }
}
