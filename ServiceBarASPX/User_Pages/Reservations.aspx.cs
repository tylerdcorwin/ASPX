using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCorwin_SE256.User_Pages
{
    public partial class Reservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Home");
            }

            int res_id = Convert.ToInt32(RouteData.Values["res_id"]);

            if (!IsPostBack)
            {
                //nothing to update or send yet
            }
        }
    }
}