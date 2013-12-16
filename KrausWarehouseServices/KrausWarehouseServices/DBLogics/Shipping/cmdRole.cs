using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.Connections.Shipping;

namespace KrausWarehouseServices.DBLogics.Shipping
{
    /// <summary>
    /// Get and upsert operation on Role Table. 
    /// </summary>
   public  class cmdRole
   {
       #region Get Methods of Role.
       /// <summary>
       /// Create the Entity Object.
       /// </summary>
       Shipping_ManagerEntities1 entshipping = new Shipping_ManagerEntities1();
       /// <summary>
       /// Get All Records from Role Table. 
       /// </summary>
       /// <returns></returns>
       public List<RoleDTO> GetAll()
       {
           List<RoleDTO> _lsReturn = new List<RoleDTO>();
           try
           {
               var role = (from all in entshipping.Roles
                           select all).ToList();
               foreach (var Roleitem in role)
               {
                   _lsReturn.Add(new RoleDTO(Roleitem));
               }
           }
           catch (Exception)
           {
           }

           return _lsReturn;

       }

       /// <summary>
       /// Get Role BY Role ID.
       /// </summary>
       /// <param name="_RoleID">
       /// pass RoleID as Parameter. 
       /// </param>
       /// <returns>
       /// Return list.
       /// </returns>
       public List<RoleDTO> GetRoleByRoleID(Guid _RoleID)
       {
           List<RoleDTO> _lsReturn = new List<RoleDTO>();
           try
           {
               _lsReturn.Add(new RoleDTO(entshipping.Roles.SingleOrDefault(re => re.RoleId == _RoleID)));
           }
           catch (Exception)
           {
           }
           return _lsReturn;
       }
       #endregion

       #region Upsert Roles
       /// <summary>
       /// This method is for Upsert operation on Role Table.
       /// </summary>
       /// <param name="_role"></param>
       /// <returns>
       /// return boolean value.
       /// </returns>
       public Boolean UpsertRole(List<RoleDTO> _role)
       {
           Boolean _flag = false;
           try
           {
              
               foreach (var item in _role)
               {
                   Role _roleID = new Role();
                    _roleID = entshipping.Roles.FirstOrDefault(r => r.RoleId == item.RoleID);

                   if (_roleID== null)
                   {
                       _roleID = new Role();
                       _roleID.RoleId = item.RoleID;
                       _roleID.Name = item.Name;
                       _roleID.Action = item.Action;
                       _roleID.CreatedBy = item.CreatedBy;
                       _roleID.CreatedDateTime = item.CreatedDateTime;
                       _roleID.Updatedby = item.Updatedby;
                       _roleID.UpdatedDateTime = item.UpdatedDateTime;
                       entshipping.AddToRoles(_roleID);
                   }
                   else
                   {
                       _roleID.Name = item.Name;
                       _roleID.Action = item.Action;
                       _roleID.CreatedBy = item.CreatedBy;
                       _roleID.CreatedDateTime = item.CreatedDateTime;
                       _roleID.Updatedby = item.Updatedby;
                       _roleID.UpdatedDateTime = item.UpdatedDateTime;
                   }
               }
           }
           catch (Exception)
           {
           }
           entshipping.SaveChanges();
           return _flag;
       }
       #endregion
    }
}
