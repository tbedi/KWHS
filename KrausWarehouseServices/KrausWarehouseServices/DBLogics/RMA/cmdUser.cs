using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.RMA;
using KrausWarehouseServices.DTO.Shipping;

namespace KrausWarehouseServices.DBLogics.RMA
{
     /// <summary>
    /// Avinash : 25Nov2013 : KWS
    /// UserDTO Get Set functions and other user related functions.
    /// that is performed on RMASYSTEM database.
    /// </summary>
    public class cmdUser
    {

        /// <summary>
        /// RMASYSTEM database object.
        /// </summary>
        Shipping_ManagerEntities1 entRMADB = new Shipping_ManagerEntities1();

        #region Get Operation for UserDTO Table.

        /// <summary>
        /// This will give you all users information. 
        /// Withaout any arguments or parameters.
        /// </summary>
        /// <returns>
        /// list of user class information.
        /// </returns>
        public List<UserDTO> GetUserTbl()
        {
            //Return list object.
            List<UserDTO> _lsUserReturn = new List<UserDTO>();
            try
            {
                //Select all users from Database.
                var UserList = from ent in entRMADB.Users
                               select ent;

                //Add each user information to the return list.
                foreach (var Useritem in UserList)
                {
                    UserDTO user = new UserDTO(Useritem);
                   // user = (UserDTO)Useritem;
                    _lsUserReturn.Add(user);
                }
            }
            catch (Exception)
            { }

            return _lsUserReturn;
        }

        /// <summary>
        /// Get user information by his Guid.
        /// </summary>
        /// <param name="Userid">
        /// Guid UserID. 
        /// </param>
        /// <returns>
        /// UserDTO class with user informatipn its null if information not found about user.
        /// </returns>
        public UserDTO GetUserTbl1(Guid Userid)
        {
            UserDTO _lsUserReturn = new UserDTO();
            try
            {
                _lsUserReturn = new UserDTO(entRMADB.Users.FirstOrDefault(i => i.UserID == Userid));

            }
            catch (Exception)
            { }
            return _lsUserReturn;
        }

        /// <summary>
        /// UserDTO information get form user table
        /// whith parameter String UserName which is login username
        /// not name of the user.
        /// </summary>
        /// <param name="LoginUserName">
        /// String Login user Name not UserDTO name.
        /// </param>
        /// <returns>
        /// UserDTO class object its null if user information not found.
        /// </returns>
        public UserDTO GetUserTbl(String LoginUserName)
        {
            UserDTO _return = new UserDTO();
            try
            {
               var _lsUserReturn1 = entRMADB.Users.FirstOrDefault(user => user.UserName == LoginUserName);
               _return = new UserDTO(_lsUserReturn1);
            }
            catch (Exception)
            { }
            return _return;
        }

        /// <summary>
        /// this gives user information filterd by RoleID
        /// </summary>
        /// <param name="RoleID">
        /// Guild Role ID.
        /// </param>
        /// <returns>
        /// List of user information .
        /// </returns>
        public List<UserDTO> GetUserByRoleID(Guid RoleID)
        {
            List<UserDTO> _lsReturn = new List<UserDTO>();
            try
            {
                var userInfo = from user in entRMADB.Users
                               where user.RoleId == RoleID
                               select user;

                foreach (var useritem in userInfo)
                {
                    UserDTO _user = new UserDTO(useritem);
                    
                    //Add to return list.
                    _lsReturn.Add(_user);
                }
            }
            catch (Exception)
            { }
            return _lsReturn;
        }

        /// <summary>
        /// Gives user information from user master table
        /// UserDTO Name (Login Name )and its password.
        /// </summary>
        /// <param name="UserName">
        /// String UserName (Ligin Name Not Name)
        /// </param>
        /// <param name="Password">
        /// String Password .
        /// </param>
        /// <returns>
        /// UserDTO class object with information yield null.
        /// </returns>
        public UserDTO GetUserByUserNamePassword(String UserName, String Password)
        {
            UserDTO _userReturn = new UserDTO();
            try
            {
              var  _userReturn1 = entRMADB.Users.FirstOrDefault(user => user.UserName == UserName && user.UserPassword == Password);
              _userReturn = new UserDTO(_userReturn1);
            }
            catch (Exception)
            { }
            return _userReturn;
        }

        /// <summary>
        /// save only
        /// </summary>
        /// <param name="_User"></param>
        /// <returns></returns>
        public Boolean  UpsertUser(UserDTO _User)
        {
            Boolean _status = false;
            try
            {
                User user = new User();
                user = entRMADB.Users.SingleOrDefault(us => us.UserID == _User.UserID);
                //insert the new record if not present
                if (user == null)
                {
                    user = new User();
                    user.UserID = _User.UserID;
                    user.RoleId = _User.RoleID;
                    user.UserFullName = _User.UserFullName;
                    user.UserAddress = _User.UserAddress;
                    user.UserName = _User.UserName;
                    user.UserPassword = _User.UserPassword;
                    user.UserJoiningDate = _User.UserJoiningDate;
                    user.CreatedBy = _User.CreatedBy;
                    user.Updatedby = null;
                    user.CreatedDateTime = DateTime.Now;
                    user.UpdatedDateTime = null;
                    entRMADB.AddToUsers(user);
                }
                else //updating Existing Record
                {
                    user.RoleId = _User.RoleID;
                    user.UserFullName = _User.UserFullName;
                    user.UserAddress = _User.UserAddress;
                    user.UserName = _User.UserName;
                    user.UserPassword = _User.UserPassword;
                    user.UserJoiningDate = _User.UserJoiningDate;
                    user.CreatedBy = _User.CreatedBy;
                    user.Updatedby = null;
                    user.CreatedDateTime = DateTime.Now;
                    user.UpdatedDateTime = null;
                }
                entRMADB.SaveChanges();
                _status = true;
            }
            catch (Exception)
            {
            }
            return _status;
        }
        #endregion
    }
}
