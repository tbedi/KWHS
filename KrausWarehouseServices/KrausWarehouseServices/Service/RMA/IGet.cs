using KrausWarehouseServices.DTO.RMA;
using KrausWarehouseServices.DTO.Shipping;
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
        List<UserDTO> XMLUserGet(String EnumGetTypeString, String Parameters);

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
        [WebInvoke(Method = "GET", UriTemplate = "/Return?ID={ID}&value={value}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ReturnDTO> XMLReturnGet(String ID, String value);

        [OperationContract]
        List<ReturnDTO> ReturnAll();

        [OperationContract]
        ReturnDTO ReturnByReturnID(Guid ReturnID);

        [OperationContract]
        List<ReturnDTO> ReturnByReturnDetailID(Guid ReturnDetailsID);

        [OperationContract]
        ReturnDTO ReturnByRMANumber(String RMANumber);

        [OperationContract]
        List<ReturnDTO> ReturnByOrderNum(String OrderNum);

        [OperationContract]
        List<ReturnDTO> ReturnByVendoeNum(String VendorNumber);

        [OperationContract]
        List<ReturnDTO> ReturnByVendorName(String VendorName);

        [OperationContract]
        List<ReturnDTO> ReturnByShipmentNumber(String ShipmentNumber);

        [OperationContract]
        List<ReturnDTO> ReturnByPONumber(String PONumber);

        [OperationContract]
        List<ReturnDTO> ReturnByRGAROWID(String RGAROWID);

        [OperationContract]
        List<ReturnDTO> ReturnByRGADROWID(String RGADROWID);
        #endregion

        #region Return Details.

        [OperationContract]
        List<DTO.RMA.ReturnDetailsDTO> ReturnDetailAll();
        
            [OperationContract]
        List<ReturnDetailsDTO> ReturnDetailByretrnID(Guid RetunID);


        [OperationContract]
        List<ReturnDetailsDTO> ReturnDetailByRetundetailID(Guid RetundetailID);

        [OperationContract]
        List<ReturnDetailsDTO> ReturnDetailByRGADROWID(String RGADROWID);

        [OperationContract]
        List<ReturnDetailsDTO> ReturnDetailByRGAROWID(String RGAROWID);
        #endregion

        #region Reason

        [OperationContract]
        List<ReasonsDTO> ReasonsAll();

        [OperationContract]
        List<ReasonsDTO> ReasonByCategoryName(String CategoryName);

        [OperationContract]
        String ListOfReasons(Guid ReturnDetail);

        #endregion

        #region Audit

        [OperationContract]
        List<RMAAuditDTO> AuditAll();

        #endregion

        #region Sage Operations     

        [OperationContract]
        List<RMAInfoDTO> RMAInfoByShippingNumber(String ShippingNumber);

        [OperationContract]
        List<RMAInfoDTO> RMAInfoBySONumber(String SONumber);

        [OperationContract]
        List<RMAInfoDTO> RMAInfoByPONumber(String PONumber);

        [OperationContract]
        List<RMAInfoDTO> RMAInfoBySRNumber(String SRNumber);

        #endregion

        #region Role
        [OperationContract]
        List<RoleDTO> RoleAll();

        [OperationContract]
        RoleDTO RoleByRoleID(Guid RoleID);

        #endregion

        #region image return
        [OperationContract]
        List<ReturnImagesDTO> ImagePathTable(Guid ReturnDetailID);


        [OperationContract]
        List<String> ImagePathStringList(Guid ReturnDetailID);
        #endregion

        #region Version Released for RGA

        [OperationContract]
        String GetRMALatestVersionNumber();
        

        #endregion
    }
}
