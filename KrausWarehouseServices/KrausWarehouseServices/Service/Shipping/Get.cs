using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.Shipping
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Get" in both code and config file together.
    public class Get : IGet
    {

        #region Declarations.

        /// <summary>
        /// view Get_Shipping_Data new Object.
        /// </summary>
        DBLogics.Shipping.cmdGetShippingData _GetShippingData = new DBLogics.Shipping.cmdGetShippingData();
        
        #endregion

        #region View Get_Shipping_Data

        public List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataAll()
        {
            return _GetShippingData.GetAll();
        }

        public List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataByShippingNumber(string ShippingNumber)
        {
            return _GetShippingData.GeByShipmentID(ShippingNumber);
        }

        public List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataByLocation(string Location)
        {
            return _GetShippingData.GeByLocation(Location);
        } 

        #endregion
    }
}
