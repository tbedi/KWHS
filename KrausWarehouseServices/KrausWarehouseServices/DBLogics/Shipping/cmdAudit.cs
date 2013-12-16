using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using KrausWarehouseServices.DTO.Shipping;
using System.Data.Objects;

namespace KrausWarehouseServices.DBLogics.Shipping
{
    /// <summary>
    /// Shriram Rajaram 5/12/2013.
    /// All set and get Operation on Audit Table.
    /// </summary>
   public class cmdAudit
    {
       /// <summary>
       /// Create the ShippingEntity Object.
       /// </summary>
       Connections.Shipping.Shipping_ManagerEntities1 entshipping = new Connections.Shipping.Shipping_ManagerEntities1();

       #region Upsert Method For Audit
       /// <summary>
       /// Upsert the UserLog in Audit table.
       /// </summary>
       /// <param name="_audit">
       /// AuditDTO parameter pass.
       /// </param>
       /// <returns>
       /// Return boolean Value.
       /// </returns>
       public Boolean UpsertAuditLog(List<AutditDTO> _audit)
       {
           Boolean _flag = false;
           try
           {
               foreach (var _UserLogitem in _audit)
               {
                   Connections.Shipping.Audit userlog = new Connections.Shipping.Audit();

                   userlog = entshipping.Audits.SingleOrDefault(re => re.UserLogID == _UserLogitem.UserLogID);
                   if (userlog == null)
                   {
                       userlog = new Connections.Shipping.Audit();
                       userlog.UserLogID = Guid.NewGuid();
                       userlog.UserID = _UserLogitem.UserID;
                       userlog.ActionType = _UserLogitem.ActionType;
                       userlog.ActionTime = Convert.ToDateTime(_UserLogitem.ActionTime);
                       userlog.ActionValue = _UserLogitem.ActionValue;
                       entshipping.AddToAudits(userlog);
                   }
                   else
                   {

                       userlog.UserID = _UserLogitem.UserID;
                       userlog.ActionType = _UserLogitem.ActionType;
                       userlog.ActionTime = Convert.ToDateTime(_UserLogitem.ActionTime);
                       userlog.ActionValue = _UserLogitem.ActionValue;

                   }
               }
               entshipping.SaveChanges();
               _flag = true;
           }
           catch (Exception)
           {
           }
           return _flag;
       }
       #endregion

       #region Get Methods for Audit

       /// <summary>
       /// fetch all rows from the UserLogs table and return the list
       /// </summary>
       /// <returns>list of UserLogCustom type</returns>
       public List<AutditDTO> UserLog()
       {
           List<AutditDTO> _lsReturn = new List<AutditDTO>();
           try
           {
               var UserLogsinfo = from Userl in entshipping.Audits select Userl;
               foreach (var _UserLogitem in UserLogsinfo)
               {
                   _lsReturn.Add(new AutditDTO(_UserLogitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsReturn;
       }

       /// <summary>
       /// Fetch Selected User Information From the Userlogs table
       /// </summary>
       /// <param name="UserID">Long UserID </param>
       /// <returns>List of UserLogs of type UserLogCustom</returns>
       public List<AutditDTO> UserLogByUserID(Guid UserID)
       {
           List<AutditDTO> _lsReturn = new List<AutditDTO>();
           try
           {
               var UserLoginfo = from userl in entshipping.Audits
                                 where userl.UserID == UserID
                                 select userl;
               foreach (var _UserLogitem in UserLoginfo)
               {
                   _lsReturn.Add(new AutditDTO(_UserLogitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsReturn;
       }

       /// <summary>
       /// Fetch Information From the Userlogs table by UserlogID
       /// </summary>
       /// <param name="UserlogID">Long UserID </param>
       /// <returns>List of UserLogs of type UserLogCustom</returns>
       public List<AutditDTO> UserLogByUserlogID(Guid UserlogID)
       {
           List<AutditDTO> _lsReturn = new List<AutditDTO>();
           try
           {
               var UserLoginfo = from userl in entshipping.Audits
                                 where userl.UserLogID == UserlogID
                                 select userl;
               foreach (var _UserLogitem in UserLoginfo)
               {
                   _lsReturn.Add(new AutditDTO(_UserLogitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsReturn;
       }

       #endregion
   }
}
