using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace TCorwin_SE256.User_Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            AppUser u = new AppUser();
            //validation check for null or empty txtboxes for username && password
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                 u = new AppUser(txtUserName.Text.Trim());
                string hash = AppUser.CreatePasswordHash(u.Salt, txtPassword.Text.Trim());
                if (hash == u.HashedPassword)
                {
                    u.ValidLogin = true;
                }
                else
                    lblResult.Text = "Login Failed, please enter a valid email address and password";
            }
            if (u.ValidLogin == true)
            {
                lblResult.Text = "Login Success";

                //creation of authenication ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1, u.UserId.ToString(), DateTime.Now, DateTime.Now.AddMinutes(480), false, "Admin");

                string ticketEncrypt = FormsAuthentication.Encrypt(ticket);
                //creating a cookie to communicate with the response object
                HttpCookie c = new HttpCookie(
                    FormsAuthentication.FormsCookieName, ticketEncrypt);
                //add cookie to response
                Response.Cookies.Add(c);

                //check the ticket
                Session["FullName"] = string.Concat(
                        u.LastName,
                       ", ", u.FistName);

                // Redirect browser back to home page
                Response.Redirect("~/home");
            }
            //
            else
            {
                lblResult.CssClass = "col-lg-2 text-danger";
                lblResult.Text = "Incorrect username or password please try again";
            }

        }
    }
}