using KrausWarehouseServices.DTO.RMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KrausWarehouseServices.Service.RMA
{
    /// <summary>
    /// User model that calls all user funcations.
    /// SOA and XML functions.
    /// note: 'x' prefixed function only belongs to the XML transfer.
    /// </summary>
    [ServiceContract]
    public interface IUser
    {
        /// <summary>
        /// XML return user information.
        /// </summary>
        /// <param name="ID">
        /// Function call ID
        /// ID examples: USERID/ROLEID/LOGINNAME/GETALL.
        /// </param>
        /// <param name="Parameters">
        /// parametes to respective ID passed. in string.
        /// </param>
        /// <returns>
        /// list of UserDTO table information.
        /// </returns>
        [OperationContract]
        [WebInvoke(UriTemplate="/Get?ID={ID}&value={Parameters}", Method="GET",ResponseFormat=WebMessageFormat.Xml,BodyStyle= WebMessageBodyStyle.Bare)] 
        List<UserDTO> xGet(String ID, String Parameters);

        /// <summary>
        /// SOA function return all user table.
        /// </summary>
        /// <returns>
        /// list of UserDTO table information.
        /// </returns>
        [OperationContract]
        List<UserDTO> Get();


        /// <summary>
        /// Filter information by UserID.
        /// </summary>
        /// <param name="UserID">
        /// Guid UserID
        /// </param>
        /// <returns>
        /// UserDTO Information.
        /// </returns>
        [OperationContract]
        UserDTO GetByUserID(Guid UserID);


        /// <summary>
        /// Filter user information by RoleID
        /// </summary>
        /// <param name="RoleID">
        /// Guid RoelID.
        /// </param>
        /// <returns>
        /// List of userDTO information matched to the Role.
        /// </returns>
        [OperationContract]
        List<UserDTO> GetByRoleID(Guid RoleID);

        /// <summary>
        /// Search user information matched to the User Name and password.
        /// </summary>
        /// <param name="UserName">
        /// String User Name.(Login User namae.)
        /// </param>
        /// <param name="Password">
        /// String password.
        /// </param>
        /// <returns>
        /// UserDTO with information.
        /// </returns>
        [OperationContract]
        UserDTO GetByUserName(String UserName);


        /// <summary>
        /// Upsert operation for the User Table.
        /// </summary>
        /// <param name="UserInformation">
        /// userDTO object with information.
        /// </param>
        /// <returns>
        /// Guid wich is inserted or updated.
        /// </returns>
        [OperationContract]
        Guid Save(UserDTO UserInformation);


        /// <summary>
        /// Delete the record from user table by UserID.
        /// </summary>
        /// <param name="UserID">
        /// Guid UserID.
        /// </param>
        /// <returns>
        /// Boolean value with information.
        /// </returns>
        [OperationContract]
        Boolean Delete(Guid UserID);

    }
}
