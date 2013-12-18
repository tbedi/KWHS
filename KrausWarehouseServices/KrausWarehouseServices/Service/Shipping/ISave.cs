using KrausWarehouseServices.DTO.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KrausWarehouseServices.Service.Shipping
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISave" in both code and config file together.
    [ServiceContract]
    public interface ISave
    {
        #region Audit
        /// <summary>
        /// Upsert Method Declaration of audit.
        /// </summary>
        /// <param name="_audit">
        /// pass audit object as parameter.
        /// </param>
        /// <returns>
        /// return Boolean Value.
        /// </returns>
        [OperationContract]
        Boolean Audit(List<AutditDTO> _audit);

        #endregion

        #region BoxPackage
        /// <summary>
        /// Upsert Method Declaration of boxpackage.
        /// </summary>
        /// <param name="_boxpackage">
        /// pass boxpackage object as parameter.
        /// </param>
        /// <returns>
        /// return Boolean Value.
        /// </returns>
        [OperationContract]
        Boolean BoxPackage(List<BoxPackageDTO> _boxpackage);

        #endregion


        #region Package
        /// <summary>
        /// Upsert Method Declaration of Package.
        /// </summary>
        /// <param name="_package">
        /// pass package object as parameter.
        /// </param>
        /// <returns>
        /// return Boolean Value.
        /// </returns>
        [OperationContract]
        Boolean Package(List<PackageDTO> _package);

        #endregion

        #region PckageDetail

        /// <summary>
        /// Upsert declaration of Packagedetail. 
        /// </summary>
        /// <param name="_packagedetail">
        /// pass Packagedetail object as Parameter.
        /// </param>
        /// <returns>
        /// Return Boolean Value.
        /// </returns>
        [OperationContract]
        Boolean PackageDetail(List<PackageDetailDTO> _packagedetail);
        #endregion

        #region MyRegion

        /// <summary>
        /// Upsert declaration Of Role
        /// </summary>
        /// <param name="_role">
        /// Pass RoleDTO object as parameter.
        /// </param>
        /// <returns></returns>
        [OperationContract]
        Boolean Role(List<RoleDTO> _role);
        #endregion

        #region Shipping

        /// <summary>
        /// Upsert for Shipping
        /// </summary>
        /// <param name="_shipping">
        /// pass shipping Object as parameter.
        /// </param>
        /// <returns>
        /// return boolean value.
        /// </returns>
        [OperationContract]
        Boolean Shipping(List<ShippingDTO> _shipping);

        #endregion

        #region StationMaster

        /// <summary>
        /// Upsert declaration of StationMaster 
        /// </summary>
        /// <param name="_stationmaster">
        /// pass Station master object parameter.
        /// </param>
        /// <returns>
        /// return Boolean Value.
        /// </returns>
        [OperationContract]
        Boolean StationMaster(List<StationMasterDTO> _stationmaster);
        #endregion

        #region User

        /// <summary>
        /// Upsert declaration of User. 
        /// </summary>
        /// <param name="_user">
        /// pass user object as parameter.
        /// </param>
        /// <returns>
        /// return boolean value.
        /// </returns>
        [OperationContract]
        Boolean User(List<UserDTO> _user);
   

        /// <summary>
        /// Update UserBy UserID. 
        /// </summary>
        /// <param name="lsuser">
        /// pass userDTO object as parameter.
        /// </param>
        /// /// <param name="userID">
        /// pass userID object as parameter.
        /// </param>
        /// <returns>
        /// return boolean value.
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate="/Any", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Boolean UpdateByUser(List<UserDTO> _user,Guid UserID);

        #endregion



        #region UserStation

        /// <summary>
        /// Upsert declaration Of userStation.
        /// </summary>
        /// <param name="_userstation">
        /// Pass UserStation Object As parameter.
        /// </param>
        /// <returns>
        /// Return Boolean Value.
        /// </returns>
        [OperationContract]
        Boolean UserStation(List<UserStationDTO> _userstation);

        /// <summary>
        /// Upsert declaration Of ErrorLog.
        /// </summary>
        /// <param name="_errorlog">
        /// Pass ErrorLog Object As parameter.
        /// </param>
        /// <returns>
        /// Return Boolean Value.
        /// </returns>
        [OperationContract]
        Boolean ErrorLog(List<ErrorLogDTO> _errorlog);

        #endregion

        #region User

        /// <summary>
        /// Update tracking By ReadyToExpert.
        /// </summary>
        /// <param name="ReadyToExpert">
        /// pass boolean value.
        /// </param>
        /// <returns>
        /// return boolean value.
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/TrackingUpdateByReadytoExpert?ID={TrackingNo}&value={BoxNumber}&bool={ReadyToExpert}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        Boolean TrackingUpdateByReadytoExpert(String TrackingNo, String BoxNumber, Boolean ReadyToExpert);
        #endregion



    }
}
