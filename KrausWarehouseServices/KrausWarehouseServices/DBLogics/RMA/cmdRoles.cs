using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO;
using KrausWarehouseServices.DTO.Shipping;


namespace KrausWarehouseServices.DBLogics.RMA
{
    /// <summary>
    /// Shriram Rajaram Nov 27 2013
    /// Get and set operation on the role table
    /// </summary>
   public  class cmdRoles
    {
       //Create object of RMASYSTENentities Entity
       Shipping_ManagerEntities1 entRMA = new Shipping_ManagerEntities1();

       /// <summary>
       /// Get all information from the RoleDTO Table.
       /// </summary>
       /// <returns>
       /// Return the List of RoleDTO Table Object.
       /// </returns>
       public List<RoleDTO> GetRoles()
       {
           List<RoleDTO> _roleList = new List<RoleDTO>();
           try
           {
               var Roles= (from GetRoleTbl in entRMA.Roles
                            select GetRoleTbl).ToList();
               foreach (var Ritem in Roles)
               {
                   RoleDTO rol = new RoleDTO(Ritem);
                   _roleList.Add(rol);
               }
           }
           catch (Exception)
           {
           }
           return _roleList;
       }

       /// <summary>
       /// Gives the role Information by roleID
       /// </summary>
       /// <param name="RoleID">
       /// string roleID
       /// </param>
       /// <returns>
       /// return the role object.
       /// </returns>
       public RoleDTO GetRoleTblByRoleID(Guid RoleID)
       {
           RoleDTO _role = new RoleDTO();
           try
           {
               _role = new RoleDTO(entRMA.Roles.FirstOrDefault(ret => ret.RoleId == RoleID));
           }
           catch (Exception)
           {
           }
           return _role;
       
       }


    }
}
