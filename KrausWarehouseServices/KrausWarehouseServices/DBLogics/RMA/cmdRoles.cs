using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using KrausWarehouseServices.DTO;


namespace KrausWarehouseServices.DBLogics.RMA
{
    /// <summary>
    /// Shriram Rajaram Nov 27 2013
    /// Get and set operation on the role table
    /// </summary>
   public  class cmdRoles
    {
       //Create object of RMASYSTENentities Entity
       RMASYSTEMEntities entRMA = new RMASYSTEMEntities();

       /// <summary>
       /// Get all information from the Role Table.
       /// </summary>
       /// <returns>
       /// Return the List of Role Table Object.
       /// </returns>
       public List<Role> GetRoles()
       {
           List<Role> _RoleList = new List<Role>();
           try
           {
               _RoleList = (from GetRoleTbl in entRMA.Roles
                            select GetRoleTbl).ToList();
           }
           catch (Exception)
           {
           }
           return _RoleList;
       }

       /// <summary>
       /// Gives the role Information by roleID
       /// </summary>
       /// <param name="roleID">
       /// string roleID
       /// </param>
       /// <returns>
       /// return the role object.
       /// </returns>
       public Role GetRoleTblByRoleID(Guid roleID)
       {
           Role _role = new Role();
           try
           {
               _role = entRMA.Roles.FirstOrDefault(ret => ret.RoleId == roleID);
           }
           catch (Exception)
           {
           }
           return _role;
       
       }


    }
}
