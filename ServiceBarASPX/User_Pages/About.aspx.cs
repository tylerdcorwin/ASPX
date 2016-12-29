using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCorwin_SE256.User_Pages
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (Session["FullName"] != null)
                {
                    lblGreeting.Text = "Welcome " + Session["FullName"].ToString();
                }
            }
            else
            {
                lblGreeting.Text = "Welcome Stranger";
            }
        }
    }
}