using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DBLogics.Shipping
{
    public class viewGet_Shipping_Data
    {
        /// <summary>
        /// Shipping Manager Database entity Object.
        /// </summary>
        Connections.Shipping.Shipping_ManagerEntities1 entShipping = new Connections.Shipping.Shipping_ManagerEntities1();


        /// <summary>
        /// Get all records from Get_Shipping_Data view.
        /// </summary>
        /// <returns>
        /// list of DTO object.
        /// </returns>
        public List<DTO.Shipping.viewGet_Shipping_DataDTO> GetAll()
        {
            List<DTO.Shipping.viewGet_Shipping_DataDTO> _lsReturn = new List<DTO.Shipping.viewGet_Shipping_DataDTO>();
            try
            {
                var ShippingData = from _ship in entShipping.Get_Shipping_Data select _ship;

                foreach (var _xShippingitem in ShippingData)
                {
                    _lsReturn.Add(new DTO.Shipping.viewGet_Shipping_DataDTO(_xShippingitem));
                }
            }
            catch (Exception)
            { }
            return _lsReturn;
        }


        /// <summary>
        /// Get by Shipment Number.
        /// </summary>
        /// <param name="ShipmentID">
        /// String Shipment Number.
        /// </param>
        /// <returns></returns>
        public List<DTO.Shipping.viewGet_Shipping_DataDTO> GeByShipmentID(String ShipmentID)
        {
            List<DTO.Shipping.viewGet_Shipping_DataDTO> _lsReturn = new List<DTO.Shipping.viewGet_Shipping_DataDTO>();
            try
            {
                var ShippingData = (from _ship in entShipping.Get_Shipping_Data
                                    where _ship.ShipmentID == ShipmentID
                                    select _ship).ToList();

                foreach (var _xShippingitem in ShippingData)
                {
                    _lsReturn.Add(new DTO.Shipping.viewGet_Shipping_DataDTO(_xShippingitem));
                }
            }
            catch (Exception)
            { }
            return _lsReturn;
        }


        /// <summary>
        /// Get all view recoreds filtered by Location.
        /// </summary>
        /// <param name="LocationName">
        /// String Location.
        /// </param>
        /// <returns></returns>
        public List<DTO.Shipping.viewGet_Shipping_DataDTO> GeByLocation(String LocationName)
        {
            List<DTO.Shipping.viewGet_Shipping_DataDTO> _lsReturn = new List<DTO.Shipping.viewGet_Shipping_DataDTO>();
            try
            {
                var ShippingData = (from _ship in entShipping.Get_Shipping_Data
                                    where _ship.LocationCombined == LocationName
                                    select _ship).ToList();

                foreach (var _xShippingitem in ShippingData)
                {
                    _lsReturn.Add(new DTO.Shipping.viewGet_Shipping_DataDTO(_xShippingitem));
                }
            }
            catch (Exception)
            { }
            return _lsReturn;
        }


        internal List<DTO.Shipping.viewGet_Shipping_DataDTO> GeBySKUNameAndShippngNumber(string ShippingNumber, string SKUName)
        {
            List<DTO.Shipping.viewGet_Shipping_DataDTO> _lsReturn = new List<DTO.Shipping.viewGet_Shipping_DataDTO>();
            try
            {
                var ShippingData = (from _ship in entShipping.Get_Shipping_Data
                                    where _ship.SKU == SKUName && _ship.ShipmentID == ShippingNumber
                                    select _ship).ToList();

                foreach (var _xShippingitem in ShippingData)
                {
                    _lsReturn.Add(new DTO.Shipping.viewGet_Shipping_DataDTO(_xShippingitem));
                }
            }
            catch (Exception)
            { }
            return _lsReturn;
        }
    }
}
