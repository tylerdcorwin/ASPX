using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TCorwin_SE256 
{
    public class Menus
    {
        #region populateNavBar
        public static List<MenuItem> GetMainMenu()
        {
            List<MenuItem> lstMenu = new List<MenuItem>();
            lstMenu.Add(new MenuItem("Home", "", "", "~/Home"));
            lstMenu.Add(new MenuItem("Lunch Menu", "", "", "~/Lunch-Menu"));
            lstMenu.Add(new MenuItem("Dinner Menu", "", "", "~/Dinner-Menu"));
            lstMenu.Add(new MenuItem("Reservations", "", "", "~/Reservations"));//changed from Reservation
            lstMenu.Add(new MenuItem("Directions", "", "", "~/Directions"));
            lstMenu.Add(new MenuItem("About", "", "", "~/About"));
            lstMenu.Add(new MenuItem("Contact", "", "", "~/Contact"));

            if (HttpContext.Current.Request.IsAuthenticated)
            {
                lstMenu.Add(new MenuItem("Logout", "", "", "~/Logout"));
                lstMenu.Add(new MenuItem("Admin", "", "", "~/Admin/Reservation-Management"));
            }
            else
            {
                lstMenu.Add(new MenuItem("Sign In", "", "", "~/Sign-In"));
            }
            return lstMenu;
        }
        #endregion
        #region AdminNavBar
        public static List<MenuItem> GetAdminMenu()
        {
            List<MenuItem> adminMenu = new List<MenuItem>();
            adminMenu.Add(new MenuItem("Home", "", "", "~/Home"));
            adminMenu.Add(new MenuItem("Menu Items", "", "", "~/Admin/Menu-Items"));
            adminMenu.Add(new MenuItem("Menu Item", "", "", "~/Admin/Menu-Item"));
            adminMenu.Add(new MenuItem("Sections", "", "", "~/Admin/Sections"));
            adminMenu.Add(new MenuItem("Section", "", "", "~/Admin/Section"));
            adminMenu.Add(new MenuItem("Tables", "", "", "~/Admin/Tables"));
            adminMenu.Add(new MenuItem("Table", "", "", "~/Admin/Table"));
            adminMenu.Add(new MenuItem("Reservation Management", "", "", "~/Admin/Reservation-Management"));
            adminMenu.Add(new MenuItem("User", "", "", "~/Admin/User"));
            adminMenu.Add(new MenuItem("Users", "", "", "~/Admin/Users"));
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                adminMenu.Add(new MenuItem("Logout", "", "", "~/Logout"));
            }
            return adminMenu;
        }
        #endregion
    }
}