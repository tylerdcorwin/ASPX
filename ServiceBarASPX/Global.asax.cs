using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace TCorwin_SE256
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            AdminRegisterRoutes(RouteTable.Routes);
        }



        public static void RegisterRoutes(RouteCollection routes)
        {
            #region userNavBar
            //ignore WebResource.axd file
            routes.Ignore("{resource}.axd/{*pathInfo}");
            //map static pages
            routes.MapPageRoute("home", "Home", "~/User_Pages/Default.aspx");
            routes.MapPageRoute("lunch", "Lunch-Menu", "~/User_Pages/LunchMenu.aspx");
            routes.MapPageRoute("dinner", "Dinner-Menu", "~/User_Pages/DinnerMenu.aspx");
            //routes.MapPageRoute("reservations", "Reservations", "~/User_Pages/Reservations.aspx");
            routes.MapPageRoute("reservations", "Reservations", "~/User_Pages/Reservation.aspx");
            //redirect to new reservations for guests/users

            //changed             viewReservations
            routes.MapPageRoute("ReservationsID", "Reservation/{res_id}", "~/User_Pages/Reservation.aspx", false, new RouteValueDictionary { { "res_id", "-1" } });
            //here
            routes.MapPageRoute("directions", "Directions", "~/User_Pages/Directions.aspx");
            routes.MapPageRoute("about", "About", "~/User_Pages/About.aspx");
            routes.MapPageRoute("contact", "Contact", "~/User_Pages/Contact.aspx");
            routes.MapPageRoute("signIn", "Sign-In", "~/User_Pages/Login.aspx");
            routes.MapPageRoute("admin", "Admin", "~/Admin_Pages/ResMgmt.aspx");
            routes.MapPageRoute("logout", "Logout", "~/User_Pages/Logout.aspx");
        }
        #endregion
        #region adminNavBar
        public static void AdminRegisterRoutes(RouteCollection route)
        {
            //ignore WebResource.adx file
            route.Ignore("{resource}.axd/{*pathInfo}");
            //map static pages for Admin

            route.MapPageRoute("menuItems", "Admin/Menu-Items", "~/Admin_Pages/MenuItems.aspx");

            //This needs to match EXACTLY 
            route.MapPageRoute("menu_Items", "Admin/Menu-Item/{item_id}", "~/Admin_Pages/MenuItem.aspx", false, new RouteValueDictionary { { "item_id", "-1" } });
            route.MapPageRoute("admin_ResMgmt", "Admin/Reservation/{res_id}", "~/User_Pages/Reservation.aspx", false, new RouteValueDictionary { { "res_id", "-1" } });
            route.MapPageRoute("admin_Sections", "Admin/Section/{sect_id}", "~/Admin_Pages/Section.aspx", false, new RouteValueDictionary { { "sect_id", "-1" } });
            route.MapPageRoute("admin_Tables", "Admin/Table/{tbl_id}", "~/Admin_Pages/Table.aspx", false, new RouteValueDictionary { { "tbl_id", "-1" } });
            route.MapPageRoute("admin_Users", "Admin/User/{user_id}", "~/Admin_Pages/User.aspx", false, new RouteValueDictionary { { "user_id", "-1" } });
            //running into issue here for the navbar...set break and test

            route.MapPageRoute("menuItem", "Admin/Menu-Item", "~/Admin_Pages/MenuItem.aspx");
            route.MapPageRoute("sections", "Admin/Sections", "~/Admin_Pages/Sections.aspx");
            route.MapPageRoute("section", "Admin/Section", "~/Admin_Pages/Section.aspx");
            route.MapPageRoute("tables", "Admin/Tables", "~/Admin_Pages/Tables.aspx");
            route.MapPageRoute("table", "Admin/Table", "~/Admin_Pages/Table.aspx"); //maybe
            route.MapPageRoute("resMgmt", "Admin/Reservation-Management", "~/Admin_Pages/ResMgmt.aspx");
            route.MapPageRoute("user", "Admin/User", "~/Admin_Pages/User.aspx");
            route.MapPageRoute("users", "Admin/Users", "~/Admin_Pages/Users.aspx");
            //  route.MapPageRoute("logout", "Logout", "~/User_Pages/Logout.aspx");

            
        }
        #endregion
    }


}