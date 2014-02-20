using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.RMA;

namespace KrausWarehouseServices.DBLogics.RMA
{
    /// <summary>
    /// get and set the operation on reason table
    /// </summary>
    public  class cmdReasons
    {
        /// <summary>
        /// Create Object Of RMASyatem entity.
        /// </summary>
        Shipping_ManagerEntities1 entRMA = new Shipping_ManagerEntities1();

        /// <summary>
        /// get all reasons from the reason table.
        /// </summary>
        /// <returns></returns>
        public List<ReasonsDTO> GetReasons()
        {
            List<ReasonsDTO> _reasonlist = new List<ReasonsDTO>();
            try
            {
                var reasons = (from reason in entRMA.Reasons
                               select reason).ToList();
                foreach (var item in reasons)
                {
                    ReasonsDTO Reason = new ReasonsDTO(item);
                    _reasonlist.Add(Reason);
                }
            }
            catch (Exception)
            {
            }
            return _reasonlist;
        }
        public List<ReasonsDTO> ListOfReasonsByReasonDetaailID(Guid ReturnDetailID)
        {
            List<ReasonsDTO> List = new List<ReasonsDTO>();
            try
            {
                var lsreason = (from sku in entRMA.SKUReasons
                                join reson in entRMA.Reasons
                                    on sku.ReasonID equals reson.ReasonID
                                where sku.ReturnDetailID == ReturnDetailID
                                select reson).ToList();

                if (lsreason.Count > 0)
                {
                    foreach (var item in lsreason)
                    {
                        List.Add(new ReasonsDTO(item));
                    }
                }
            }
            catch (Exception)
            {
            }
            return List;
        }
        /// <summary>
        /// get category wise reasons from reason Table
        /// </summary>
        /// <param name="CategoryName">
        /// get reason from reason table by categoryName.  
        /// </param>
        /// <returns></returns>
        public List<ReasonsDTO> GetReasonByCategoryName(string CategoryName)
        {
            List<ReasonsDTO> _reasoncatname = new List<ReasonsDTO>();
            try
            {
                string _categorynm = CategoryName.ToUpper();

                var cateReason = (from catname in entRMA.ReasonCategories
                                  join resons in entRMA.Reasons
                                  on catname.ReasonID equals resons.ReasonID
                                  where catname.CategoryName == _categorynm
                                  select resons).ToList();
                foreach (var item in cateReason)
                {
                    ReasonsDTO catre = new ReasonsDTO(item);
                    _reasoncatname.Add(catre);
                }
            }
            catch (Exception)
            {
            }
            return _reasoncatname;
        
        }

        /// <summary>
        /// this function is for Insert the reasons in to the Reason Table and Update 
        /// the Records of Reason Table.....
        /// </summary>
        /// <param name="reasonID">
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public Boolean UpsertReasons(ReasonsDTO DTOReason)
        {
            Boolean status = false;
            try
            {
                Reason _Reasons = new Reason();
                _Reasons = entRMA.Reasons.FirstOrDefault(i => i.ReasonID == DTOReason.ReasonID);
                if (_Reasons ==null)
                {
                    _Reasons = new Reason();
                    _Reasons.ReasonID = DTOReason.ReasonID;
                    _Reasons.Reason1 = DTOReason.Reason;
                    _Reasons.ReasonPoints = DTOReason.ReasonPoints;
                    entRMA.AddToReasons(_Reasons);
                }
                else
                {
                    _Reasons.Reason1 = DTOReason.Reason;
                    _Reasons.ReasonPoints = DTOReason.ReasonPoints;
                }
                entRMA.SaveChanges();
                status = true;
            }
            catch (Exception)
            { }
            return status;
        }


        #region Delete

        public Boolean DeleteByResonID(Guid ReasonID)
        {
            Boolean _return = false;
            try
            {
                Reason reasn = entRMA.Reasons.SingleOrDefault(i => i.ReasonID == ReasonID);
                entRMA.DeleteObject(reasn);
                entRMA.SaveChanges();
                _return = true;
            }
            catch (Exception)
            {}
            return _return;
        }
        
        #endregion
    }
}
