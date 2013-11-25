using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KrausWarehouseServices.DTO;

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
        List<UserDTO> Get();


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
