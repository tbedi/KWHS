using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.RMA;

namespace KrausWarehouseServices.DBLogics.RMA
{
    public class cmdReturnedSKUPoints
    {
        Shipping_ManagerEntities1 entRMA = new Shipping_ManagerEntities1();

        public Boolean UpsertReturnedSKUPoints(ReturnedSKUReasonPointsDTO ReturnedSKUPoints)
        {
            Boolean _flag = false;
            try
            {
                ReturnedSKU_Reason_Points _ReturnedSKUPoints = new ReturnedSKU_Reason_Points();
                _ReturnedSKUPoints = entRMA.ReturnedSKU_Reason_Points.SingleOrDefault(ret => ret.ID == ReturnedSKUPoints.ID);

                //if redto is null then insert
                if (_ReturnedSKUPoints == null)
                {
                    _ReturnedSKUPoints = new ReturnedSKU_Reason_Points();
                    _ReturnedSKUPoints.ID = ReturnedSKUPoints.ID;
                    _ReturnedSKUPoints.ReturnDetailID = ReturnedSKUPoints.ReturnDetailID;
                    _ReturnedSKUPoints.ReturnID = ReturnedSKUPoints.ReturnID;
                    _ReturnedSKUPoints.SKU = ReturnedSKUPoints.SKU;
                    _ReturnedSKUPoints.Reason = ReturnedSKUPoints.Reason;
                    _ReturnedSKUPoints.Reason_Value = ReturnedSKUPoints.Reason_Value;
                    _ReturnedSKUPoints.Points = ReturnedSKUPoints.Points;
                    _ReturnedSKUPoints.SkuSequence = ReturnedSKUPoints.SkuSequence;

                    entRMA.AddToReturnedSKU_Reason_Points(_ReturnedSKUPoints);
                }
                else//otherwise update.
                {
                    _ReturnedSKUPoints.ReturnDetailID = ReturnedSKUPoints.ReturnDetailID;
                    _ReturnedSKUPoints.ReturnID = ReturnedSKUPoints.ReturnID;
                    _ReturnedSKUPoints.SKU = ReturnedSKUPoints.SKU;
                    _ReturnedSKUPoints.Reason = ReturnedSKUPoints.Reason;
                    _ReturnedSKUPoints.Reason_Value = ReturnedSKUPoints.Reason_Value;
                    _ReturnedSKUPoints.Points = ReturnedSKUPoints.Points;
                    _ReturnedSKUPoints.SkuSequence = ReturnedSKUPoints.SkuSequence;
                }
                entRMA.SaveChanges();
                _flag = true;

            }
            catch (Exception)
            { }
            return _flag;
        }

    }
}
