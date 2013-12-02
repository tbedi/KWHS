using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.RMA;
using KrausWarehouseServices.Connections;

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
        RMASYSTEMEntities entRMA = new RMASYSTEMEntities();

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


    }
}
