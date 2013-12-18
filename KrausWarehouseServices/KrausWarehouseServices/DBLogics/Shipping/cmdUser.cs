using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.Globle_Classes;


namespace KrausWarehouseServices.DBLogics.Shipping
{
   public  class cmdUser
    {

       /// <summary>
       /// Create Object of EntityModel.
       /// </summary>
       Shipping_ManagerEntities1 entShipping = new Shipping_ManagerEntities1();

        #region Get User MEthods.

       /// <summary>
       /// Get all Data from the User table.
       /// </summary>
       /// <returns>
       /// Return List of Users;
       /// </returns>
       public List<UserDTO> GetAll()
       {
           List<UserDTO> _lsUSer = new List<UserDTO>();
           try
           {
               var user = (from _user in entShipping.Users
                           select _user).ToList();

               foreach (var useritem in user)
               {
                   _lsUSer.Add(new UserDTO(useritem));
               }
           }
           catch (Exception)
           {
           }
           return _lsUSer;
       
       }

       /// <summary>
       /// Get all Users by UserID.
       /// </summary>
       /// <param name="_UserID">
       /// pass UserID as Parameter.
       /// </param>
       /// <returns>
       /// Return List.
       /// </returns>
       public List<UserDTO> GetByUserID(Guid _UserID)
       {
           List<UserDTO> _lsUser = new List<UserDTO>();
           try
           {
               var _user = (from user in entShipping.Users
                            where user.UserID == _UserID
                            select user).ToList();

               foreach (var useritem in _user)
               {
                   _lsUser.Add(new UserDTO(useritem));
               }
           }
           catch (Exception)
           {
           }
           return _lsUser;
       }

       /// <summary>
       /// Get all Users by UserName.
       /// </summary>
       /// <param name="_UserName">
       /// pass UserName as Parameter.
       /// </param>
       /// <returns>
       /// Return List.
       /// </returns>
       public List<UserDTO> GetByUserName(String _UserName)
       {
           List<UserDTO> _lsUser = new List<UserDTO>();
           try
           {
               var _user = (from user in entShipping.Users
                            where user.UserName == _UserName
                            select user).ToList();

               foreach (var useritem in _user)
               {
                   _lsUser.Add(new UserDTO(useritem));
               }
           }
           catch (Exception)
           {
           }
           return _lsUser;
       }

       /// <summary>
       /// Get all Users by RoleID.
       /// </summary>
       /// <param name="_RoleID">
       /// pass RoleID as Parameter.
       /// </param>
       /// <returns>
       /// Return List.
       /// </returns>
       public List<UserDTO> GetByRoleID(Guid _RoleID)
       {
           List<UserDTO> _lsUser = new List<UserDTO>();
           try
           {
               var _user = (from user in entShipping.Users
                            where user.RoleId == _RoleID
                            select user).ToList();

               foreach (var useritem in _user)
               {
                   _lsUser.Add(new UserDTO(useritem));
               }
           }
           catch (Exception)
           {
           }
           return _lsUser;
       }



       /// <summary>
       /// Get all Users by RoleName.
       /// </summary>
       /// <param name="_RoleName">
       /// pass RoleName as Parameter.
       /// </param>
       /// <returns>
       /// Return List.
       /// </returns>
       public List<UserDTO> GetByRoleName(String _RoleName)
       {
           List<UserDTO> _lsUser = new List<UserDTO>();
           try
           {
               var Usersel = from _user in entShipping.Users
                           join _role in entShipping.Roles
                          on _user.RoleId equals _role.RoleId
                           where _role.Name == _RoleName
                           select _user;

               foreach (var useritem in Usersel)
               {
                   _lsUser.Add(new UserDTO(useritem));
               }
           }
           catch (Exception)
           {
           }
           return _lsUser;
       }
        #endregion

        #region UpsertUser

       /// <summary>
       /// Insert And Update the User Table in One function that is Upsert.
       /// </summary>
       /// <param name="_user">
       /// Pass UserDTO object To the Function; 
       /// </param>
       /// <returns>
       /// Return Boolean value.
       /// </returns>
       public Boolean UsertUser(List<UserDTO> _user)
       {
           Boolean _flag = false;
           try
           {
               foreach (var useritem in _user)
               {
                   User user = new User(); 
                       user = entShipping.Users.SingleOrDefault(us => us.UserID == useritem.UserID);
                   if (user == null)
                   {
                       user = new User();
                       user.UserID = useritem.UserID;
                       user.UserName = useritem.UserName;
                       user.UserFullName = useritem.UserFullName;
                       user.UserAddress = useritem.UserAddress;
                       user.UserJoiningDate =Convert.ToDateTime(useritem.UserJoiningDate);
                       user.UserPassword = useritem.UserPassword;
                       user.RoleId = useritem.RoleID;
                       user.CreatedDateTime =useritem.CreatedDateTime;
                       user.UpdatedDateTime =useritem.UpdatedDateTime;
                       user.CreatedBy = useritem.CreatedBy;
                       user.Updatedby = useritem.Updatedby;
                       entShipping.AddToUsers(user);

                   }
                   else
                   {
                       user.UserName = useritem.UserName;
                       user.UserFullName = useritem.UserFullName;
                       user.UserAddress = useritem.UserAddress;
                       user.UserJoiningDate = Convert.ToDateTime(useritem.UserJoiningDate);
                       user.UserPassword = useritem.UserPassword;
                       user.RoleId = useritem.RoleID;
                       user.CreatedDateTime = useritem.CreatedDateTime;
                       user.UpdatedDateTime = useritem.UpdatedDateTime;
                       user.CreatedBy = useritem.CreatedBy;
                       user.Updatedby = useritem.Updatedby;
                   }
               }
               entShipping.SaveChanges();
               _flag = true;
           }
              
           catch (Exception)
           {
           }
           return _flag;
       }


       /// <summary>
       /// update usermaster by User Id
       /// </summary>
       /// <param name="lsuser"></param>
       /// <param name="UserID"></param>
       /// <returns></returns>
       public Boolean UserMasterByUserID(List<UserDTO> lsuser, Guid UserID)
       {
            Boolean _flag = false;
           try
           {
               User _user = entShipping.Users.SingleOrDefault(i => i.UserID == UserID);

               foreach (var useritem in lsuser)
               {
                   _user.UserName = useritem.UserName;
                   _user.UserAddress = useritem.UserAddress;
                   _user.UserPassword = useritem.UserPassword;
                   _user.UserJoiningDate = useritem.UserJoiningDate;
                   _user.UserFullName = useritem.UserFullName;
                   _user.RoleId = useritem.RoleID;
                   _user.UpdatedDateTime = DateTime.UtcNow;
                   _user.Updatedby = useritem.UserID;
                   if (useritem.RoleID == Guid.Empty)
                   {
                       _user.RoleId = entShipping.Users.SingleOrDefault(i => i.UserID == UserID).RoleId;
                   }
               }
               entShipping.SaveChanges();
               _flag = true;
           }
           catch (Exception)
           {
           }
           return _flag;
       
       }

        #endregion

    }
}
