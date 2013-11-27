using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO;
using KrausWarehouseServices.Connections;

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
        RMASYSTEMEntities entRMA = new RMASYSTEMEntities();

        /// <summary>
        /// get all reasons from the reason table.
        /// </summary>
        /// <returns></returns>
        public List<Reason> GetReasons()
        {
            List<Reason> _reasonlist = new List<Reason>();
            try
            {
                _reasonlist = (from reason in entRMA.Reasons
                               select reason).ToList();
            }
            catch (Exception)
            {
            }
            return _reasonlist;
        }

        /// <summary>
        /// get category wise reasons from reason Table
        /// </summary>
        /// <param name="CategoryName">
        /// get reason from reason table by categoryName.  
        /// </param>
        /// <returns></returns>
        public List<Reason> GetReasonByCategoryName(string CategoryName)
        {
            List<Reason> _reasoncatname = new List<Reason>();
            try
            {
                string _categorynm = CategoryName.ToUpper();

                _reasoncatname = (from catname in entRMA.ReasonCategories
                                  join resons in entRMA.Reasons
                                  on catname.ReasonID equals resons.ReasonID
                                  where catname.CategoryName == _categorynm
                                  select resons).ToList();
                                  
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
        public Boolean InsertReasons(Reason reasonID)
        {
            Boolean status = false;
            try
            {
                entRMA.AddToReasons(reasonID);
                entRMA.SaveChanges();
                status = true;
            }
            catch (Exception)
            { }
            return status;
        }
    }
}
