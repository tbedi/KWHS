using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.Connections.Shipping;

namespace KrausWarehouseServices.DBLogics.Shipping
{
    public class cmdErrorLog
    {
        /// <summary>
        /// Create the ShippingEntity Object.
        /// </summary>
        Connections.Shipping.Shipping_ManagerEntities1 entshipping = new Connections.Shipping.Shipping_ManagerEntities1();

        #region Get Methods for ErroeLog

        /// <summary>
        /// Get all Records from the errorlog methods.
        /// </summary>
        /// <returns>
        /// Return errorLog List
        /// </returns>
        public List<ErrorLogDTO> AllErrorLog()
        {
            List<ErrorLogDTO> _lserrorlog = new List<ErrorLogDTO>();
            try
            {
                var error = (from er in entshipping.ErrorLogs
                             select er).ToList();

                foreach (var erroritem in error)
                {
                    _lserrorlog.Add(new ErrorLogDTO(erroritem));
                }
            }
            catch (Exception)
            {
            }
            return _lserrorlog;
        }

        #endregion

        #region Upsert Method

        /// <summary>
        /// Upsert Method for ErrorLog Table.
        /// </summary>
        /// <param name="_errorlog">
        /// Pass errorlogDTO list Object to the Function.
        /// </param>
        /// <returns>
        /// Return Boolean Value.
        /// </returns>
        public Boolean UpsertErrorLog(List<ErrorLogDTO> _errorlog)
        {
            Boolean _flag = false;
            try
            {
                foreach (var errorlogitem in _errorlog)
                {
                    ErrorLog error = new ErrorLog();
                        error = entshipping.ErrorLogs.SingleOrDefault(er => er.ErrorLogID == errorlogitem.ErrorlogID);
                    if (errorlogitem == null)
                    {
                      error = new ErrorLog();
                      error.ErrorLogID = errorlogitem.ErrorlogID;
                      error.ErrorDesc = errorlogitem.ErrorDesc;
                      error.ErrorLocation = errorlogitem.ErrorLocation;
                      error.ErrorTime = errorlogitem.ErrorTime;
                      error.UserID = errorlogitem.UserID;
                      entshipping.AddToErrorLogs(error);
                    }
                    else
                    {
                        error.ErrorDesc = errorlogitem.ErrorDesc;
                        error.ErrorLocation = errorlogitem.ErrorLocation;
                        error.ErrorTime = errorlogitem.ErrorTime;
                        error.UserID = errorlogitem.UserID;
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
    }
}
