using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.RMA;

namespace KrausWarehouseServices.DBLogics.RMA
{
    /// <summary>
    /// shriram rajaram 29/11/2013 
    /// create get,set operation on RMAAudit table
    /// </summary>
   public  class cmdRMAAudit
    {
       /// <summary>
       /// Create Entity Object RMAEntity.
       /// </summary>
       Shipping_ManagerEntities1 entRMA = new Shipping_ManagerEntities1();

       /// <summary>
       /// Get records From the RMAAudit table.
       /// </summary>
       /// <returns>
       /// Return the List of RMAAudit.
       /// </returns>
       public List<RMAAuditDTO> GetAudit()
       {
           List<RMAAuditDTO> _auditlist = new List<RMAAuditDTO>();
           try
           {
               var aud = (from t in entRMA.RMAAudits
                          select t).ToList();
               foreach (var item in aud)
               {
                   RMAAuditDTO au = new RMAAuditDTO(item);
                   _auditlist.Add(au);
               }
           }
           catch (Exception)
           {
           }
           return _auditlist;
       }

       /// <summary>
       /// Get Records from the audit table by UserID 
       /// </summary>
       /// <param name="UserID">
       /// pass UserID As Parameter.
       /// </param>
       /// <returns>
       /// return the audit list.
       /// </returns>
       public RMAAuditDTO GetbyUserid(Guid UserID)
       {
           RMAAuditDTO auduserid = new RMAAuditDTO();
           try
           {
               var audit = entRMA.RMAAudits.SingleOrDefault(au => au.UserID == UserID);
               auduserid = new RMAAuditDTO(audit);
           }
           catch (Exception)
           {
           }
           return auduserid;
       }

       /// <summary>
       /// insert and update the records in audit table
       /// if data already exist then it will update.
       /// </summary>
       /// <param name="userlog">
       /// pass the userlog as parameter.
       /// </param>
       /// <returns>
       /// Return boolean Value when Transaction is Success.
       /// </returns>
       public Boolean UpsertAudit(RMAAuditDTO userlog)
       {
           Boolean _returnflag = false;
           try
           {
               RMAAudit aud = new RMAAudit();
               aud = entRMA.RMAAudits.SingleOrDefault(us => us.UserLogID == userlog.UserLogID);
               //insert the new record if not present
               if (aud == null)
               {
                   aud = new RMAAudit();
                   aud.UserLogID = userlog.UserLogID;
                   aud.UserID = userlog.UserID;
                   aud.ActionType = userlog.ActionType;
                   aud.ActionTime = userlog.ActionTime;
                   aud.ActionValue = userlog.ActionValue;
                   entRMA.AddToRMAAudits(aud);
               }
               else //updating Existing Record
               {
                   aud.UserID = userlog.UserID;
                   aud.ActionType = userlog.ActionType;
                   aud.ActionTime = userlog.ActionTime;
                   aud.ActionValue = userlog.ActionValue;
               }
               entRMA.SaveChanges();
               _returnflag = true;
           }
           catch (Exception)
           {

           }
           return _returnflag;
       }
    }
}
