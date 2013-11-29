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
        public Boolean SetReturnTbl(ReturnDTO returnID)
        {
            Boolean _status = false;

            try
            {
                ReturnDTO _returnbj = new ReturnDTO();
                var _re = entRMA.Returns.SingleOrDefault(ret => ret.ReturnID == returnID.ReturnID);
                _returnbj = new ReturnDTO(_re);
                //If return object is null then Save records
                if (_returnbj == null)
                {
                    entRMA.AddToReturns(_returnbj);
                }
                else//update Return table
                {
                    _returnbj = returnID;
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
