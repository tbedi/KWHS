using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using KrausWarehouseServices.DTO;
using KrausWarehouseServices.DTO.RMA;

namespace KrausWarehouseServices.DBLogics.RMA
{
    /// <summary>
    /// Shriram Rajaram 27/11/2013 Create cmdReturn for get and set
    /// the record in the Return Table
    /// </summary>
    public class cmdReturn
    {
        /// <summary>
        /// Create Object of RMASYATEMEntities
        /// </summary>
        RMASYSTEMEntities entRMA = new RMASYSTEMEntities();

        #region Get Methods
        /// <summary>
        /// Get All Records from the Return table  
        /// </summary>
        /// <returns>
        /// return List of Return Table Object.
        /// If record not Found Then Return Null.
        /// </returns>
        public List<ReturnDTO> GetReturnTbl()
        {
            List<ReturnDTO> _return = new List<ReturnDTO>();

            try
            {
                var re = (from ReturnTable in entRMA.Returns
                           select ReturnTable).ToList();

                foreach (var item in re)
                {
                    ReturnDTO redto = new ReturnDTO();
                    _return.Add(redto);
                }
            }
            catch (Exception)
            {
            }
            return _return;
        }

        /// <summary>
        /// Get all Data from Return Table By ReturnID
        /// </summary>
        /// <param name="ReturnID">
        /// Pass ReturnID And Get Data from Return Table
        /// </param>
        /// <returns>
        /// Return Returntable Object
        /// </returns>
        public ReturnDTO GetReturnTblByReturnID(Guid ReturnID)
        {
            ReturnDTO _returnObj = new ReturnDTO();
            try
            {
                var _ret = entRMA.Returns.SingleOrDefault(ret => ret.ReturnID == ReturnID);
                _returnObj = new ReturnDTO(_ret);
            }
            catch (Exception)
            {
            }
            return _returnObj;

        }

        /// <summary>
        /// Get all data From return Table By RMANumber
        /// </summary>
        /// <param name="RMANumber">
        /// Pass RMANumber and get data from Return Table.
        /// </param>
        /// <returns>
        /// Return return table Object.
        /// </returns>
        public ReturnDTO GetReturnTblByRMANumber(string RMANumber)
        {
            ReturnDTO _returnOb = new ReturnDTO();
            try
            {
              var _return = entRMA.Returns.SingleOrDefault(ret => ret.RMANumber == RMANumber);
              _returnOb = new ReturnDTO(_return);
            }
            catch (Exception)
            {
            }
            return _returnOb;
        }

        #endregion

        #region Set Method

        /// <summary>
        /// upsert operation on return table
        /// </summary>
        /// <param name="returnID"></param>
        /// <returns>
        /// boolean value return according to transaction 
        /// true when success other wise false.
        /// </returns>
        public Boolean UpsertReturnTbl(ReturnDTO returnDTO)
        {
            Boolean _status = false;

            try
            {
                Return _returnObj = new Return();
                _returnObj = entRMA.Returns.SingleOrDefault(ret => ret.ReturnID == returnDTO.ReturnID);

                //If return object is null then Save records
                if (_returnObj == null)
                {
                    _returnObj.ReturnID = returnDTO.ReturnID;
                    _returnObj.RMANumber = returnDTO.RMANumber;
                    _returnObj.ShipmentNumber = returnDTO.ShipmentNumber;
                    _returnObj.OrderNumber = returnDTO.OrderNumber;
                    _returnObj.PONumber = returnDTO.PONumber;
                    _returnObj.OrderDate = returnDTO.OrderDate;
                    _returnObj.DeliveryDate = returnDTO.DeliveryDat;
                    _returnObj.ReturnDate = returnDTO.ReturnDate;
                    _returnObj.VendorNumber = returnDTO.VendorNumber;
                    _returnObj.VendoeName = returnDTO.VendoeName;
                    _returnObj.CustomerName1 = returnDTO.CustomerName1;
                    _returnObj.CustomerName2 = returnDTO.CustomerName2;
                    _returnObj.Address1 = returnDTO.Address1;
                    _returnObj.Address2 = returnDTO.Address2;
                    _returnObj.Address3 = returnDTO.Address3;
                    _returnObj.ZipCode = returnDTO.ZipCode;
                    _returnObj.City = returnDTO.City;
                    _returnObj.State = returnDTO.State;
                    _returnObj.Country = returnDTO.Country;
                    _returnObj.ReturnReason = returnDTO.ReturnReason;
                    _returnObj.RMAStatus = returnDTO.RMAStatus;
                    _returnObj.Decision = returnDTO.Decision;
                    _returnObj.CreatedBy = returnDTO.CreatedBy;
                    _returnObj.UpdatedBy = returnDTO.UpdatedBy;
                    _returnObj.CreatedDate = returnDTO.CreatesDate;
                    _returnObj.UpdatedDate = returnDTO.UpdatedDate;
                    entRMA.AddToReturns(_returnObj);
                }
                else//update Return table
                {
                    _returnObj.RMANumber = returnDTO.RMANumber;
                    _returnObj.ShipmentNumber = returnDTO.ShipmentNumber;
                    _returnObj.OrderNumber = returnDTO.OrderNumber;
                    _returnObj.PONumber = returnDTO.PONumber;
                    _returnObj.OrderDate = returnDTO.OrderDate;
                    _returnObj.DeliveryDate = returnDTO.DeliveryDat;
                    _returnObj.ReturnDate = returnDTO.ReturnDate;
                    _returnObj.VendorNumber = returnDTO.VendorNumber;
                    _returnObj.VendoeName = returnDTO.VendoeName;
                    _returnObj.CustomerName1 = returnDTO.CustomerName1;
                    _returnObj.CustomerName2 = returnDTO.CustomerName2;
                    _returnObj.Address1 = returnDTO.Address1;
                    _returnObj.Address2 = returnDTO.Address2;
                    _returnObj.Address3 = returnDTO.Address3;
                    _returnObj.ZipCode = returnDTO.ZipCode;
                    _returnObj.City = returnDTO.City;
                    _returnObj.State = returnDTO.State;
                    _returnObj.Country = returnDTO.Country;
                    _returnObj.ReturnReason = returnDTO.ReturnReason;
                    _returnObj.RMAStatus = returnDTO.RMAStatus;
                    _returnObj.Decision = returnDTO.Decision;
                    _returnObj.CreatedBy = returnDTO.CreatedBy;
                    _returnObj.UpdatedBy = returnDTO.UpdatedBy;
                    _returnObj.CreatedDate = returnDTO.CreatesDate;
                    _returnObj.UpdatedDate = returnDTO.UpdatedDate;
                }
                entRMA.SaveChanges();
                _status = true;
            }
            catch (Exception)
            {
            }
            return _status;
        }

        #endregion

        #region delete Methods

        #endregion
    }
}
