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
        /// <summary>
        /// Blank Constructor.
        /// </summary>
        public RoleDTO()
        {
        }

        public RoleDTO(Role _role)
        {
            if (_role.RoleId != null) this.RoleID = (Guid)_role.RoleId;
            if (_role.Name != null) this.Name = (String)_role.Name;
            if (_role.Action != null) this.Action = (string)_role.Action;
        }

        [DataMember]
        public Guid RoleID { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String Action { get; set; }


    }
}
