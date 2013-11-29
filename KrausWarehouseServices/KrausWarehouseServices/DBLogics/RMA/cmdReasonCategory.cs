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
        public Boolean SetReasonCategory(ReasonCategoryDTO reas)
        {
            Boolean _flag = false;
            try
            {
                entRMA.AddToReasonCategories(reas);
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
