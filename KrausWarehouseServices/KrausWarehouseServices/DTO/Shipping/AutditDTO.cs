using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
   public  class AutditDTO
    {

        [DataMember]
        public Guid UserLogID { get; set; }

        [DataMember]
        public Guid UserID { get; set; }

        [DataMember]
        public String ActionType { get; set; }

        [DataMember]
        public DateTime ActionTime { get; set; }

        [DataMember]
        public string ActionValue { get; set; }

        /// <summary>
        /// Blank Cunstructor.
        /// </summary>
        public AutditDTO()
        {

        }

        /// <summary>
        /// Paramiterised Constructor
        /// </summary>
        /// <param name="_audit">
        /// pass The Audit table object
        /// </param>
        public AutditDTO(Connections.Shipping.Audit _audit)
        {
            if (_audit.UserLogID != null) this.UserLogID = (Guid)_audit.UserLogID;
            if (_audit.UserID != null) this.UserID = (Guid)_audit.UserID;
            if (_audit.ActionType != null) this.ActionType = (String)_audit.ActionType;
            if (_audit.ActionTime != Convert.ToDateTime("01/01/0001")) this.ActionTime = (DateTime)_audit.ActionTime;
            if (_audit.ActionValue != null) this.ActionValue = (string)_audit.ActionValue;
        }


    }
}
