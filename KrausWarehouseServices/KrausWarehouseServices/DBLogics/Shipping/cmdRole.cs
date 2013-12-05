using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.Connections.Shipping;

namespace KrausWarehouseServices.DBLogics.Shipping
{
   public  class cmdRole
    {
       /// <summary>
       /// Create the Entity Object.
       /// </summary>
       Shipping_ManagerEntities1 entshipping = new Shipping_ManagerEntities1();

       public Boolean UpsertRole(List<RoleDTO> _role)
       {
           Boolean _flag = false;
           try
           {
               Role role = new Role();
               var _roleID = entshipping.Roles.SingleOrDefault(r => r.RoleId == role.RoleId);

               foreach (var item in _role)
               {
                   if (_roleID == null)
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

    }
}
