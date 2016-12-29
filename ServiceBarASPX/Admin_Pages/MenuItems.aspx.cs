using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCorwin_SE256.Admin_Pages
{
    public partial class MenuItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int item_id = Convert.ToInt32(RouteData.Values["item_id"]);
            MenuItemCS test = new MenuItemCS(item_id);
            lblTest.Text = String.Concat(test.Item_ID + " has been updated").ToString();
        }
    }
}