﻿using KrausWarehouseServices.DTO.RMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KrausWarehouseServices.Service.RMA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGet" in both code and config file together.
    [ServiceContract]
    public interface IGet
    {

        #region User 

        /// <summary>
        /// XML return user information.
        /// </summary>
        /// <param name="EnumGetTypeString">
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
        [WebInvoke(UriTemplate = "/User?ID={EnumGetTypeString}&value={Parameters}", Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        List<UserDTO> xGet(String EnumGetTypeString, String Parameters);

        /// <summary>
        /// SOA function return all user table.
        /// </summary>
        /// <returns>
        /// list of UserDTO table information.
        /// </returns>
        [OperationContract]
        List<UserDTO> UserAll();


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
        UserDTO UserByUserID(Guid UserID);


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
        List<UserDTO> UserByRoleID(Guid RoleID);

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
        UserDTO UserByUserName(String UserName);



        #endregion

        #region Return

        [OperationContract]
        List<ReturnDTO> ReturnAll();

        [OperationContract]
        ReturnDTO ReturnByReturnID(Guid ReturnID);

        [OperationContract]
        List<ReturnDTO> ReturnByReturnDetailID(Guid ReturnDetailsID);

        [OperationContract]
        ReturnDTO ReturnByRMANumber(String RMANumber);

        #endregion

        #region Return Details.


        #endregion

        #region Reason

        [OperationContract]
        List<ReasonsDTO> ReasonsAll();

        [OperationContract]
        List<ReasonsDTO> ReasonByCategoryName(String CategoryName);

        #endregion
    }
}