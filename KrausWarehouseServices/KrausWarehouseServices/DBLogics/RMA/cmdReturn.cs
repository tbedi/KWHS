using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO;
using KrausWarehouseServices.DTO.RMA;
using System.Data.Objects;

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
        Shipping_ManagerEntities1 entRMA = new Shipping_ManagerEntities1();

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
                    ReturnDTO redto = new ReturnDTO(item);
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


        /// <summary>
        /// Pass Order Number and get All information from the Return table.
        /// </summary>
        /// <param name="OrderNum">
        /// pass parameter ordernum 
        /// </param>
        /// <returns>
        /// list return.
        /// </returns>
        public List<ReturnDTO> GetReturnTblByOrderNumber(String OrderNum)
        {
            List<ReturnDTO> _returnob = new List<ReturnDTO>();
            try
            {
                var retur = (from _return in entRMA.Returns
                             where _return.OrderNumber == OrderNum
                             select _return).ToList();

                foreach (var item in retur)
                {
                    ReturnDTO ls = new ReturnDTO(item);
                    _returnob.Add(ls);
                }
            }
            catch (Exception)
            {
            }
            return _returnob;
        }


        /// <summary>
        /// Get inforamation from return table By VenderNum.
        /// </summary>
        /// <param name="VenderNumber">
        /// pass parameter as VenderNum.
        /// </param>
        /// <returns>
        /// return List.
        /// </returns>
        public List<ReturnDTO> GetReturnTblByVenderNumber(string VenderNumber)
        {
            List<ReturnDTO> _return = new List<ReturnDTO>();
            try
            {
                var ret = (from _retun in entRMA.Returns
                           where _retun.VendorNumber == VenderNumber
                           select _retun).ToList();

                foreach (var item in ret)
                {
                    ReturnDTO ls = new ReturnDTO(item);
                    _return.Add(ls);
                }
            }
            catch (Exception)
            {
            }
            return _return;
        
        }

        /// <summary>
        /// Get inforamation from return table By VenderName.
        /// </summary>
        /// <param name="VenderName">
        /// pass parameter as VenderName.
        /// </param>
        /// <returns>
        /// return List.
        /// </returns>
        public List<ReturnDTO> GetReturnTblByVenderName(string VenderName)
        {
            List<ReturnDTO> _return = new List<ReturnDTO>();
            try
            {
                var ret = (from _retun in entRMA.Returns
                           where _retun.VendoeName == VenderName
                           select _retun).ToList();

                foreach (var item in ret)
                {
                    ReturnDTO ls = new ReturnDTO(item);
                    _return.Add(ls);
                }
            }
            catch (Exception)
            {
            }
            return _return;

        }

        /// <summary>
        /// Get inforamation from return table By ShipmentNum.
        /// </summary>
        /// <param name="ShipmentNumber">
        /// pass parameter as ShipmentNum.
        /// </param>
        /// <returns>
        /// return List.
        /// </returns>
        public List<ReturnDTO> GetReturnTblByShipmentNumber(string ShipmentNum)
        {
            List<ReturnDTO> _return = new List<ReturnDTO>();
            try
            {
                var ret = (from _retun in entRMA.Returns
                           where _retun.ShipmentNumber == ShipmentNum
                           select _retun).ToList();

                foreach (var item in ret)
                {
                    ReturnDTO ls = new ReturnDTO(item);
                    _return.Add(ls);
                }
            }
            catch (Exception)
            {
            }
            return _return;

        }

        /// <summary>
        /// Get inforamation from return table By PONumber.
        /// </summary>
        /// <param name="ShipmentNumber">
        /// pass parameter as POnumber.
        /// </param>
        /// <returns>
        /// return List.
        /// </returns>
        public List<ReturnDTO> GetReturnTblByPONumber(string PONumber)
        {
            List<ReturnDTO> _return = new List<ReturnDTO>();
            try
            {
                var ret = (from _retun in entRMA.Returns
                           where _retun.PONumber == PONumber
                           select _retun).ToList();

                foreach (var item in ret)
                {
                    ReturnDTO ls = new ReturnDTO(item);
                    _return.Add(ls);
                }
            }
            catch (Exception)
            {
            }
            return _return;
        }

        /// <summary>
        /// Get inforamation from return table By RGAROWID.
        /// </summary>
        /// <param name="RGAROWID">
        /// pass parameter as RGAROWID.
        /// </param>
        /// <returns>
        /// return List.
        /// </returns>
        public List<ReturnDTO> GetReturnTblByRGAROWID(string RGAROWID)
        {
            List<ReturnDTO> _return = new List<ReturnDTO>();
            try
            {
                var ret = (from _retun in entRMA.Returns
                           where _retun.RGAROWID == RGAROWID
                           select _retun).ToList();

                foreach (var item in ret)
                {
                    ReturnDTO ls = new ReturnDTO(item);
                    _return.Add(ls);
                }
            }
            catch (Exception)
            {
            }
            return _return;
        }


        /// <summary>
        /// Get inforamation from return table By RGADROWID.
        /// </summary>
        /// <param name="RGADROWID">
        /// pass parameter as RGADROWID.
        /// </param>
        /// <returns>
        /// return List.
        /// </returns>
        public List<ReturnDTO> GetReturnTblByRGADROWID(string RGADROWID)
        {
            List<ReturnDTO> _return = new List<ReturnDTO>();
            try
            {
                var ret = (from _retun in entRMA.Returns
                           join _returndetail in entRMA.ReturnDetails
                           on _retun.ReturnID equals _returndetail.ReturnID
                           where _returndetail.RGADROWID == RGADROWID
                           select _retun).ToList();

                foreach (var item in ret)
                {
                    ReturnDTO ls = new ReturnDTO(item);
                    _return.Add(ls);
                }
            }
            catch (Exception)
            {
            }
            return _return;
        }


        /// <summary>
        /// get Data from the return Table between date.
        /// </summary>
        /// <param name="FromDate">
        /// pass fromdate as datetime parameter. 
        /// </param>
        /// <param name="ToDate">
        /// pass todate as todate parameter.
        /// </param>
        /// <returns>
        /// Return List.
        /// </returns>
        public List<ReturnDTO> GetReturnFromDateToDate(DateTime FromDate,DateTime ToDate)
        {
            List<ReturnDTO> _return = new List<ReturnDTO>();
            try
            {
                var ret = (from _retun in entRMA.Returns
                           where EntityFunctions.TruncateTime(_retun.CreatedDate.Value) >= EntityFunctions.TruncateTime(FromDate)
                                 && EntityFunctions.TruncateTime(_retun.CreatedDate) <= EntityFunctions.TruncateTime(ToDate)
                           select _retun).ToList();

                foreach (var item in ret)
                {
                    ReturnDTO ls = new ReturnDTO(item);
                    _return.Add(ls);
                }
            }
            catch (Exception)
            {
            }
            return _return;
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
                _returnObj = entRMA.Returns.SingleOrDefault(ret => ret.RMANumber == returnDTO.RMANumber);

                //If return object is null then Save records
                if (_returnObj == null)
                {
                    _returnObj = new Return();
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
