using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.DTO.RMA;

namespace KrausWarehouseServices.Service.RMA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISave" in both code and config file together.
    [ServiceContract]
    public interface ISave
    {
        #region  ReasonCategory

        /// <summary>
        /// Save the Reason Category in reason Category Table
        /// </summary>
        /// <param name="reasonCat">
        /// Create object of reason CategoryDTO. 
        /// </param>
        /// <returns>
        /// Retrun Boolean Value is transaction is success
        /// </returns>
        [OperationContract]
        Boolean ReasonCategory(ReasonCategoryDTO reasonCat);

        #endregion

        #region  ReasonsTable

        /// <summary>
        /// Save And Update the Reasons in Reasons Table
        /// </summary>
        /// <param name="reasons">
        /// pass Object of ReasonsDTO
        /// </param>
        /// <returns>
        /// Return boolean Value.
        /// </returns>
        [OperationContract]
        Boolean Reasons(ReasonsDTO reasons);

        #endregion

        #region Return

        /// <summary>
        /// Save and update operation in Return Table.
        /// </summary>
        /// <param name="_return">
        /// pass the returnDTO object.
        /// </param>
        /// <returns>
        /// Return boolean value.
        /// </returns>
        [OperationContract]
        Boolean Return(ReturnDTO _return);

        #endregion

        #region ReturnDetail 

        /// <summary>
        /// save and update operation on Return detail table
        /// </summary>
        /// <param name="returndetail">
        /// pass object of returndetailDTO 
        /// </param>
        /// <returns>
        /// return boolean value.
        /// </returns>
        [OperationContract]
        Boolean ReturnDetails(ReturnDetailsDTO returndetail);
        
        #endregion

        #region ReturnImages

        /// <summary>
        /// save and update operation on ReturnImageDTO.
        /// </summary>
        /// <param name="returnimages">
        /// pass obect of returnImageDTO.
        /// </param>
        /// <returns>
        /// return Boolean Value.
        /// </returns>
        [OperationContract]
        Boolean ReturnImages(ReturnImagesDTO returnimages);

        #endregion

        #region SKUReasons

        /// <summary>
        /// save and update operation on SKUreasonDTO.
        /// </summary>
        /// <param name="returnimages">
        /// pass obect of SKUreasonDTO.
        /// </param>
        /// <returns>
        /// return Boolean Value.
        /// </returns>
        [OperationContract]
        Boolean SKUReasons(SKUReasonsDTO SKU);

        #endregion
   
        #region Users
        /// <summary>
        /// save and update operation on userDTO.
        /// </summary>
        /// <param name="user">
        /// pass obect of userDTO.
        /// </param>
        /// <returns>
        /// return Boolean Value.
        /// </returns>
        [OperationContract]
        Boolean User(UserDTO user);
        #endregion

        #region Audit
        [OperationContract]
        Boolean UpsertAudit(RMAAuditDTO audit);


     
        #endregion

    }
}
