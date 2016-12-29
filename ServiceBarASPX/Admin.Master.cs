using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCorwin_SE256
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region nav

            if (!IsPostBack)
            {
                //populate the admin nav bar with the list generated in the menu class
                List<MenuItem> lmi = Menus.GetAdminMenu();
                foreach (MenuItem mi in lmi)
                {
                    mnuMain.Items.Add(mi);
                }
            }
            #endregion
        }
    }
}