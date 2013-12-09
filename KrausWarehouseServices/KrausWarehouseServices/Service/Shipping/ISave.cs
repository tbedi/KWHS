using KrausWarehouseServices.DTO.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.Shipping
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISave" in both code and config file together.
    [ServiceContract]
    public interface ISave
    {
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

        #endregion
    }
}
