using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.Connections.Shipping;

namespace KrausWarehouseServices.DBLogics.Shipping
{
   public  class cmdUserStation
    {
       /// <summary>
       /// Create object of Shipping Entity Model.
       /// </summary>
       Shipping_ManagerEntities1 entShipping = new Shipping_ManagerEntities1();

       #region Get Methods for UserStation Table.

       /// <summary>
       /// Get all Users;
       /// </summary>
       /// <returns>
       /// Retrun List;
       /// </returns>
       public List<UserStationDTO> GetAll()
       {
       List<UserStationDTO> __lsuserstaion=new List<UserStationDTO>();
       try
       {
           var user = (from userstation in entShipping.UserStations
                       select userstation).ToList();

           foreach (var useritem in user)
           {
               __lsuserstaion.Add(new UserStationDTO(useritem));
           }

       }
       catch (Exception)
       {
       }
       return __lsuserstaion;
       }

       /// <summary>
       /// Get all records from User Station Table By UserStationID.
       /// </summary>
       /// <param name="_UserStationID">
       /// pass userstationid  as parameter. 
       /// </param>
       /// <returns>
       /// Return List.
       /// </returns>
       public List<UserStationDTO> GetByUserStationID(Guid _UserStationID)
       {
           List<UserStationDTO> _lsuserstation = new List<UserStationDTO>();
           try
           {
               var userstation = (from user in entShipping.UserStations
                                  where user.UserStationID == _UserStationID
                                  select user).ToList();

               foreach (var useritem in userstation)
               {
                   _lsuserstation.Add(new UserStationDTO(useritem));
               }
           }
           catch (Exception)
           {
           }
           return _lsuserstation;
       }

       /// <summary>
       /// Get all records from User Station Table By UserID.
       /// </summary>
       /// <param name="_UserID">
       /// pass userid  as parameter. 
       /// </param>
       /// <returns>
       /// Return List.
       /// </returns>
       public List<UserStationDTO> GetByUserID(Guid _UserID)
       {
           List<UserStationDTO> _lsuserstation = new List<UserStationDTO>();
           try
           {
               var userstation = (from user in entShipping.UserStations
                                  where user.UserID == _UserID
                                  select user).ToList();

               foreach (var useritem in userstation)
               {
                   _lsuserstation.Add(new UserStationDTO(useritem));
               }
           }
           catch (Exception)
           {
           }
           return _lsuserstation;
       }

       /// <summary>
       /// Get all records from User Station Table By StationID.
       /// </summary>
       /// <param name="_StationID">
       /// pass StationID  as parameter. 
       /// </param>
       /// <returns>
       /// Return List.
       /// </returns>
       public List<UserStationDTO> GetByStationID(Guid _StationID)
       {
           List<UserStationDTO> _lsuserstation = new List<UserStationDTO>();
           try
           {
               var userstation = (from user in entShipping.UserStations
                                  where user.StationID == _StationID
                                  select user).ToList();

               foreach (var useritem in userstation)
               {
                   _lsuserstation.Add(new UserStationDTO(useritem));
               }
           }
           catch (Exception)
           {
           }
           return _lsuserstation;
       }

       #endregion

        #region Upsert Method for UserStaion
       public Boolean UpsertUserStation(List<UserStationDTO> _userstaion)
       {
           Boolean _flag = false;
           try
           {
               foreach (var useritem in _userstaion)
               {
                   UserStation userstation = new UserStation();
                   userstation = entShipping.UserStations.SingleOrDefault(re => re.UserStationID == useritem.UserStationID);
                   if (userstation == null)
                   {
                       userstation.UserStationID = useritem.UserStationID;
                       userstation.UserID = useritem.UserID;
                       userstation.StationID = useritem.StationID;
                       userstation.UpdatedDateTime = useritem.UpdatedDateTime;
                       userstation.Updatedby = useritem.Updatedby;
                       userstation.CreatedBy = userstation.CreatedBy;
                       userstation.CreatedDateTime = useritem.CreatedDateTime;
                       userstation.LoginDateTime = useritem.LoginDateTime;
                       entShipping.AddToUserStations(userstation);
                   }
                   else
                   {
                       userstation.UserID = useritem.UserID;
                       userstation.StationID = useritem.StationID;
                       userstation.UpdatedDateTime = useritem.UpdatedDateTime;
                       userstation.Updatedby = useritem.Updatedby;
                       userstation.CreatedBy = userstation.CreatedBy;
                       userstation.CreatedDateTime = useritem.CreatedDateTime;
                       userstation.LoginDateTime = useritem.LoginDateTime;
                   }
               }
           }
           catch (Exception)
           {
           }
           entShipping.SaveChanges();
           return _flag;
       }

        #endregion

    }
}
