using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.RMA;
using KrausWarehouseServices.Connections.Shipping;

namespace KrausWarehouseServices.DBLogics.RMA
{
    /// <summary>
    /// Set Reason Category
    /// </summary>
    public class cmdReasonCategory
    {
        /// <summary>
        /// Create  tne Entity Object.
        /// </summary>
        Shipping_ManagerEntities1 entRMA = new Shipping_ManagerEntities1();

        /// <summary>
        /// Set opartion on Reason Category Table. 
        /// </summary>
        /// <returns></returns>
        public Boolean UpsertReasonCategory(ReasonCategoryDTO reas)
        {
            Boolean _flag = false;
            try
            {
                ReasonCategory ResonCat = new ReasonCategory();
                ResonCat = entRMA.ReasonCategories.FirstOrDefault(i => i.ReasonCatID == reas.ReasonCatID);
                if (ResonCat == null)
                {
                    ResonCat = new ReasonCategory();
                    ResonCat.ReasonCatID = reas.ReasonCatID;
                    ResonCat.ReasonID = reas.ReasonID;
                    ResonCat.CategoryName = reas.CategoryName;
                    entRMA.AddToReasonCategories(ResonCat);
                }
                else
                {
                    ResonCat.ReasonID = reas.ReasonID;
                    ResonCat.CategoryName = reas.CategoryName;
                }
                entRMA.SaveChanges();

             //   entRMA.AddToReasonCategories(reas);
                entRMA.SaveChanges();
                _flag = true;
            }
            catch (Exception)
            {
            }
            return _flag;
        }

        #region Get
        public List<ReasonCategoryDTO> All()
        {
            List<ReasonCategoryDTO> _lsReturn = new List<ReasonCategoryDTO>();
            try
            {
                var reasonC = (from ls in entRMA.ReasonCategories select ls).ToList();
                foreach (var item in reasonC)
                {
                    _lsReturn.Add(new ReasonCategoryDTO(item));
                }
            }
            catch (Exception)
            {}
            return _lsReturn;
        }

        public List<ReasonCategoryDTO> ByReasonID(Guid ReasonID)
        {
            List<ReasonCategoryDTO> _lsReturn = new List<ReasonCategoryDTO>();
            try
            {
                var reasonC = (from ls in entRMA.ReasonCategories
                               where ls.ReasonID == ReasonID
                               select ls).ToList();
                foreach (var item in reasonC)
                {
                    _lsReturn.Add(new ReasonCategoryDTO(item));
                }
            }
            catch (Exception)
            { }
            return _lsReturn;
        }
        #endregion

        #region Delete 

        public Boolean DeleteByReasonID(Guid ReasonID)
        {
            Boolean _flag = false;
            try
            {
                var reasonC = (from ls in entRMA.ReasonCategories
                               where ls.ReasonID == ReasonID
                               select ls).ToList();
                foreach (var item in reasonC)
                {
                    ReasonCategory reasnCat = (ReasonCategory)item;
                    entRMA.DeleteObject(reasnCat);
                }
                entRMA.SaveChanges();
            }
            catch (Exception)
            {}
            return _flag;
        }

        #endregion
    }
}
