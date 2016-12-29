using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace TCorwin_SE256.User_Pages
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //kill session
            Session["FullName"] = null;
            //kill ticket
            FormsAuthentication.SignOut();
            // Redirect browser back to home page
            Response.Redirect("~/home");
        }
    }
}