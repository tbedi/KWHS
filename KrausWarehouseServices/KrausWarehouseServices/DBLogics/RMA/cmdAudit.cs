using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using KrausWarehouseServices.DTO.RMA;

namespace KrausWarehouseServices.DBLogics.RMA
{
    /// <summary>
    /// shriram rajaram 29/11/2013 
    /// create get,set operation on Audit table
    /// </summary>
   public  class cmdAudit
    {
       /// <summary>
       /// Create Entity Object RMAEntity.
       /// </summary>
       RMASYSTEMEntities entRMA = new RMASYSTEMEntities();

       /// <summary>
       /// Get records From the Audit table.
       /// </summary>
       /// <returns>
       /// Return the List of Audit.
       /// </returns>
       public List<AuditDTO> GetAudit()
       {
           List<AuditDTO> _auditlist = new List<AuditDTO>();
           try
           {
               var aud = (from t in entRMA.Audits
                          select t).ToList();
               foreach (var item in aud)
               {
                   AuditDTO au = new AuditDTO(item);
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
       public AuditDTO GetbyUserid(Guid UserID)
       {
           AuditDTO auduserid = new AuditDTO();
           try
           {
               var audit = entRMA.Audits.SingleOrDefault(au => au.UserID == UserID);
               auduserid = new AuditDTO(audit);
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
       public Boolean UpsertAudit(AuditDTO userlog)
       {
           Boolean _returnflag = false;
           try
           {
               Audit aud = new Audit();
               aud = entRMA.Audits.SingleOrDefault(us => us.UserLogID == userlog.UserLogID);
               //insert the new record if not present
               if (aud == null)
               {
                   aud = new Audit();
                   aud.UserLogID = userlog.UserLogID;
                   aud.UserID = userlog.UserID;
                   aud.ActionType = userlog.ActionType;
                   aud.ActionTime = userlog.ActionTime;
                   aud.ActionValue = userlog.ActionValue;
                   entRMA.AddToAudits(aud);
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
