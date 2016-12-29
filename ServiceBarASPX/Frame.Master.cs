using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCorwin_SE256
{
    public partial class Frame : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<MenuItem> lmi = Menus.GetMainMenu();
                foreach (MenuItem mi in lmi)
                {
                    mnuMain.Items.Add(mi);
                }
            }

            
        }
    }
}