using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KrausWarehouseServices.DTO.RMA;

namespace KrausWarehouseServices.ServiceModels
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "mUser" in both code and config file together.
    public class mUser :ImUser
    {
        protected DBLogics.RMA.cmdUser _user = new DBLogics.RMA.cmdUser();
       
        /// <summary>
        /// Get all user Table information with all rows.
        /// Withaout any filter.
        /// </summary>
        /// <returns>
        /// List of user table object. else list count is zero.
        /// </returns>
        public List<UserDTO> Get()
        {
            return _user.GetUserTbl();
        }

        /// <summary>
        /// Get all user information for perticular user ID.
        /// </summary>
        /// <param name="UserID">
        /// Guid UserID
        /// </param>
        /// <returns>
        /// User table object with user information else null.
        /// </returns>
        public List <UserDTO> GetByUserID(Guid UserID)
        {
            return _user.GetUserTbl1(UserID);
        }

        /// <summary>
        /// Get all Logging  name information from user table.
        /// </summary>
        /// <param name="LogingUserName">
        /// String name used for loggin.
        /// </param>
        /// <returns>
        /// user table object. else null object.
        /// </returns>
        public UserDTO GetByLoginName(string LogingUserName)
        {
            return _user.GetUserTbl(LogingUserName);  
        }

        /// <summary>
        /// Get user table information filtered by RoleID
        /// </summary>
        /// <param name="RoleID">
        /// Guid RoleID .
        /// </param>
        /// <param name="IsThisRoleID">
        /// Boolean value to confirm entered ID is RoleID
        /// </param>
        /// <returns>
        /// list of user table information by same RoleID. else Rowcount is 0.
        /// </returns>
        public List<UserDTO> GetByRoleID(Guid RoleID)
        {
            return _user.GetUserByRoleID(RoleID);
        }

        /// <summary>
        /// This is upset operation if any id present in database that record is updated 
        /// otherwise its inserted.
        /// </summary>
        /// <param name="lsUsers">
        /// List of user table object with infortion.
        /// </param>
        /// <returns>
        /// Boolean value indicating recored either inserted or updated(true) else false.
        /// </returns>
        public bool Save(List<UserDTO> lsUsers)
        {
            return true;
        }

        /// <summary>
        /// Delete perticulr record by user id.
        /// </summary>
        /// <param name="UserID">
        /// Guid UserID
        /// </param>
        /// <returns>
        /// Boolean value indicating transaction success or failur.
        /// </returns>
        public bool Delete(Guid UserID)
        {
            return true;
        }



        public string GetName(string name)
        {
            return "Name= " + name;
        }
    }
}
