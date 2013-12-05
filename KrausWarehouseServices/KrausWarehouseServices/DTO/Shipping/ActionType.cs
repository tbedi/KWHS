using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrausWarehouseServices.DTO.Shipping
{
   public enum ActionType
    {
        Login = 1,
        Login_PageStart,
        Login_Fail_00,
        Login_Invalid_User_00,
        Login_Success,
        Logout,
        ApplicationExit,
        Manager_Override,
        Manager_Override_Request,
        ShipmentID_Scan,
        Invalid_ShipmentScan__00,
        ShipmentID_UnderPacking_Scan_00,
        ShipmentID_AlreadyPacked_Scan_00,
        MultiLocation_ShipmentIDScan,
        Shipment_PackedCompleted,
        Shipment_ForceExit__00,
        Shipment_RowScan,
        WrongProductScan_00,
        ExtraProductScan__00,
        CorrecProductScan,
        SessionTimeOut,
        SessionReLogin,
        MainWindowLoaded,
        MainWindowClosed,
        MainWindow_Button_Home,
        MainWindow_Button_logout,
        HomeScreenLoaded,
        Home_Button_Shipment,
        Home_Button_UserManagement,
        Home_Button_Setting,
        Home_Button_Logout,
        Home_Button_Reports,
        Home_Button_Exit,
        HomeScreenClosed,
        ShipmentScreenLoaded,
        ShipmentScreenClosed,
        Setting_LocationChanged,
        Setting_LanguageChanged,
        Setting_LocalSettingUpdated,
        UserManagement_ScreenLoaded,
        UserManagement_NewUserClicked,
        UserManagement_NewRoleClicked,
        UserManagement_HomeClicked,
        Re_Print_PackingSlip
    }
}
