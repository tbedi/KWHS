using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
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
        RMASYSTEMEntities entRMA = new RMASYSTEMEntities();

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
        public Boolean InsertReasons(ReasonsDTO ReasonID)
        {
            Boolean status = false;
            try
            {
                entRMA.AddToReasons(ReasonID);
                entRMA.SaveChanges();
                status = true;
            }
            catch (Exception)
            { }
            return status;
        }
    }
}
