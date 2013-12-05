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

       /// <summary>
       /// Save the UserLog in Audit table.
       /// </summary>
       /// <param name="_audit">
       /// AuditDTO parameter pass.
       /// </param>
       /// <returns>
       /// Return boolean Value.
       /// </returns>
       public Boolean SaveUserLog(List<AutditDTO> _audit)
       {
            Boolean _flag=false;
            try 
	        {	        
		        if(_audit.Count>0)
                {
                foreach (var _UserLogitem in _audit)
                    {
                        Connections.Shipping.Audit _Userlog = new Connections.Shipping.Audit();
                        _Userlog.UserLogID = Guid.NewGuid();
                        _Userlog.UserID = _UserLogitem.UserID;
                        _Userlog.ActionType = _UserLogitem.ActionType;
                        _Userlog.ActionTime = Convert.ToDateTime(_UserLogitem.ActionTime);
                        _Userlog.ActionValue = _UserLogitem.ActionValue;
                        entshipping.AddToAudits(_Userlog);
                    }
                    entshipping.SaveChanges();
                    _flag = true;
                }
	        }
	        catch (Exception)
	        {
	        }
           return _flag;
       }


       /// <summary>
       /// Update the UserLogs information
       /// </summary>
       /// <param name="lsUserLog">Updated User Information list </param>
        /// <param name="UserID">User Id (Long)</param>
       /// <returns>Boolean Value</returns>
        public Boolean UpdateUserLog(List<AutditDTO> lsUserLog, Guid UserID)
        {
            Boolean _return = false;
            try
            {
                if (lsUserLog.Count > 0)
                {
                    foreach (var _UserLogitem in lsUserLog)
                    {
                        Audit _Userlog = new Audit();
                        _Userlog.UserLogID = _UserLogitem.UserLogID;
                        _Userlog.UserID = _UserLogitem.UserID;
                        _Userlog.ActionType = _UserLogitem.ActionType;
                        _Userlog.ActionTime = Convert.ToDateTime(_UserLogitem.ActionTime);
                        _Userlog.ActionValue = _UserLogitem.ActionValue;
                    }
                    entshipping.SaveChanges();
                    _return = true;
                }
            }
            catch (Exception )
            {
            }
            return _return;
        }

        /// <summary>
       /// fetch all rows from the UserLogs table and return the list
       /// </summary>
       /// <returns>list of UserLogCustom type</returns>
        public List<AutditDTO> GetUserLog()
        {
            List<AutditDTO> _lsReturn = new List<AutditDTO>();
            try
            {
                var UserLogsinfo = from Userl in entshipping.Audits select Userl;
                foreach (var _UserLogitem in UserLogsinfo)
                {
                    AutditDTO _UserCustom = new AutditDTO();
                    _UserCustom.UserLogID = _UserLogitem.UserLogID;
                    _UserCustom.UserID = _UserLogitem.UserID;
                    _UserCustom.ActionType = _UserLogitem.ActionType;
                    _UserCustom.ActionTime = Convert.ToDateTime(_UserLogitem.ActionTime);
                    _UserCustom.ActionValue = _UserLogitem.ActionValue;
                    _lsReturn.Add(_UserCustom);                    
                }
            }
            catch (Exception )
            {
            }
            return _lsReturn;
        }

        /// <summary>
        /// Fetch Selected User Information From the Userlogs table
        /// </summary>
        /// <param name="UserID">Long UserID </param>
        /// <param name="CurrentDate">Date time paramenter</param>
        /// <returns>List of UserLogs of type UserLogCustom</returns>
        public List<AutditDTO> GetUserLog(Guid UserID,DateTime CurrentDate)
        {
            List<AutditDTO> _lsReturn = new List<AutditDTO>();
            try
            {
                DateTime Cdate = CurrentDate.Date;
                var UserLoginfo = from userl in entshipping.Audits
                                  where userl.UserID == UserID
                                  &&  EntityFunctions.TruncateTime(userl.ActionTime) == Cdate
                                  select userl;
                foreach (var _UserLogitem in UserLoginfo)
                {
                    AutditDTO _UserCustom = new AutditDTO();
                    _UserCustom.UserLogID = _UserLogitem.UserLogID;
                    _UserCustom.UserID = _UserLogitem.UserID;
                    _UserCustom.ActionType = _UserLogitem.ActionType;
                    _UserCustom.ActionTime = Convert.ToDateTime(_UserLogitem.ActionTime);
                    _UserCustom.ActionValue = _UserLogitem.ActionValue;
                    _lsReturn.Add(_UserCustom);
                }
            }
            catch (Exception )
            {
            }
            return _lsReturn;
        }

       /// <summary>
       /// Last User login datetime.
       /// </summary>
       /// <param name="UserID">Long UserID</param>
       /// <returns>DateTime </returns>
        public DateTime UserLastLogin(Guid UserID)
        {
            DateTime _returnDateTime = DateTime.UtcNow;
            try
            {
                String datee = ActionType.Login.ToString();
                var DatetimeLast = from _Last in entshipping.Audits
                                   where _Last.UserID == UserID &&
                                   _Last.ActionType == datee
                                   group _Last by _Last.UserID into _NewLast
                                   select new
                                   {
                                       Lastdate = _NewLast.Max(i => i.ActionTime)
                                   };
            _returnDateTime =Convert.ToDateTime( DatetimeLast.FirstOrDefault().Lastdate.ToString());
            }
            catch (Exception )
            {
            }

            return _returnDateTime;
        }

   }
}
