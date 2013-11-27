using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using KrausWarehouseServices.DTO;

namespace KrausWarehouseServices.DBLogics.RMA
{
    /// <summary>
    /// Shriram Rajaram 27 nov 2013 
    /// get and set opereation on audit table
    /// </summary>
   public  class cmdAudit
    {
        #region declaration
        //RMAsystem Database object
        RMASYSTEMEntities RMA = new RMASYSTEMEntities();

        #endregion

        /// <summary>
        /// get All data from the audit Table
        /// </summary>
        /// <returns></returns>
        public List<Audit> GetAudit()
        {
            List<Audit> _audit = new List<Audit>();
            try
            {
                _audit = (from auditdetail in RMA.Audits
                          select auditdetail).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return _audit;
        }

        /// <summary>
        /// This Fuction for get detail of audit by UserID  
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public Audit GetdatafromauditbyUserid(Guid UserID)
        {
            Audit AuditUser = new Audit();
            try
            {
                AuditUser = RMA.Audits.SingleOrDefault(aud => aud.UserID == UserID);
            }
            catch (Exception)
            {
                throw;
            }
            return AuditUser;
        }
        /// <summary>
        /// insert and update the records in audit table
        /// if data already exist then it will update or insert
        /// </summary>
        /// <param name="userlog"></param>
        /// <returns></returns>
        public Boolean UsertofAudit(Audit userlog)
        {
            Boolean _returnflag = false;
            try
            {
                Audit aud = new Audit();
                aud = RMA.Audits.SingleOrDefault(us => us.UserLogID == userlog.UserLogID);
                //insert the new record if not present
                if (aud == null)
                {
                    RMA.AddToAudits(userlog);
                }
                else //updating Existing Record
                {
                    aud = userlog;
                }
                RMA.SaveChanges();
                _returnflag = true;
            }
            catch (Exception)
            {
                throw;
            }
            return _returnflag;
        }
    }
}
