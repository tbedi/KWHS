using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections.Shipping;

namespace KrausWarehouseServices.DTO.RMA
{
   public class RMAAuditDTO
    {
       public RMAAuditDTO(RMAAudit _audit)
       {
          if (_audit.UserLogID != Guid.Empty) this.UserLogID = (Guid)_audit.UserLogID;
          if(_audit.UserID!=Guid.Empty) this.UserID=(Guid)_audit.UserID;
          if(_audit.ActionType!=null) this.ActionType=_audit.ActionType;
          if(_audit.ActionTime!=null) this.ActionTime=_audit.ActionTime;
          if(_audit.ActionValue!=null) this.ActionValue=_audit.ActionValue;
       }

       public RMAAuditDTO()
       {
 
       }

       [DataMember]
       public Guid UserLogID { get; set; }

       [DataMember]
       public Guid UserID { get; set; }

       [DataMember]
       public string ActionType { get; set; }

       [DataMember]
       public DateTime? ActionTime { get; set; }

       [DataMember]
       public string ActionValue { get; set; }
    }
}
