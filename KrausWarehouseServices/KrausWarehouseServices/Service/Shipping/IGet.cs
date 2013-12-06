using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.Shipping
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGet" in both code and config file together.
    [ServiceContract]
    public interface IGet
    {
        #region Get_Shipping_Data

        [OperationContract]
        List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataAll();

        [OperationContract]
        List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataByShippingNumber(String ShippingNumber);

        [OperationContract]
        List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataByLocation(String Location); 

        #endregion
    }
}
