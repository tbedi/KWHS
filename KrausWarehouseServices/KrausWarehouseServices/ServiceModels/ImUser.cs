using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KrausWarehouseServices.DTO;
using System.ServiceModel.Web;

namespace KrausWarehouseServices.ServiceModels
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ImUser" in both code and config file together.
    [ServiceContract]
    public interface ImUser
    {
        /// <summary>
        /// Get all user Table information with all rows.
        /// Withaout any filter.
        /// </summary>
        /// <returns>
        /// List of user table object. else list count is zero.
        /// </returns>
        [OperationContract]
        [WebGet(UriTemplate = "/Get", ResponseFormat = WebMessageFormat.Xml)]
        List<UserDTO> Get();

        /// <summary>
        /// Get all user information for perticular user ID.
        /// </summary>
        /// <param name="UserID">
        /// Guid UserID
        /// </param>
        /// <returns>
        /// User table object with user information else null.
        /// </returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/Get1?UserID={UserID}", ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        List<UserDTO> GetByUserID(Guid UserID);


        [OperationContract]
        [WebInvoke(UriTemplate = "/Get2?name={name}", ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        string GetName(String name);
        /// <summary>
        /// Get all Logging  name information from user table.
        /// </summary>
        /// <param name="LogingUserName">
        /// String name used for loggin.
        /// </param>
        /// <returns>
        /// user table object. else null object.
        /// </returns>
        [OperationContract]
        UserDTO GetByLoginName(String LogingUserName);

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
        [OperationContract]
        List<UserDTO> GetByRoleID(Guid RoleID);
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
        [OperationContract]
        Boolean Save(List<UserDTO> lsUsers);


        /// <summary>
        /// Delete perticulr record by user id.
        /// </summary>
        /// <param name="UserID">
        /// Guid UserID
        /// </param>
        /// <returns>
        /// Boolean value indicating transaction success or failur.
        /// </returns>
        [OperationContract]
        Boolean Delete(Guid UserID);

    }
}
