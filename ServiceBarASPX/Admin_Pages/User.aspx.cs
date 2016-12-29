using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace TCorwin_SE256.Admin_Pages
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Home");
            }

            int user_id = Convert.ToInt32(RouteData.Values["user_id"]);

            if (!IsPostBack)
            {
                if (user_id > 0)
                {
                    lbtnUpdate.Text = "Update";
                    UsersCS mt = new UsersCS(user_id);

                    txtEmail.Text = mt.User_Email;
                    txtFirstName.Text = mt.User_First;
                    txtLastName.Text = mt.User_Last;
                    txtAddress1.Text = mt.User_Add1;
                    txtAddress2.Text = mt.User_Add2;
                    txtCity.Text = mt.User_City;
                    ddlState.SelectedValue = mt.State_ID.ToString();
                    txtZip.Text = mt.User_Zip;
                    txtPassword.Text = mt.User_Pwd;
                    txtPhone.Text = mt.User_Phone;
                    cbIsActive.Checked = mt.User_Active;
                }
                else
                {
                    lbtnUpdate.Text = "Add";
                    //blank Values
                    txtEmail.Text = String.Empty;
                    txtFirstName.Text = String.Empty;
                    txtLastName.Text = String.Empty;
                    txtAddress1.Text = String.Empty;
                    txtAddress2.Text = String.Empty;
                    txtCity.Text = String.Empty;
                    ddlState.SelectedValue = null;
                    txtZip.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                    txtPhone.Text = String.Empty;
                    cbIsActive.Checked = false;
                }
            }

        }
        protected void lbtnCancelClick(object sender, EventArgs e)
        {
            Response.Redirect("/Home");
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            string var = lbtnUpdate.Text;
            if (var == "Update")
            {
                UsersCS sr = new UsersCS();

                if (RouteData.Values["user_id"] != null)
                {
                    sr.User_ID = Convert.ToInt32(RouteData.Values["user_id"]);
                    sr.User_Email = txtEmail.Text.Trim();
                    sr.User_First = txtFirstName.Text.Trim();
                    sr.User_Last = txtLastName.Text.Trim();
                    sr.User_Add1 = txtAddress1.Text.Trim();
                    sr.User_Add2 = txtAddress2.Text.Trim();
                    sr.User_City = txtCity.Text.Trim();
                    sr.State_ID = ddlState.SelectedValue;
                    sr.User_Zip = txtZip.Text.Trim();
                    sr.User_Salt = txtPassword.Text.Trim();
                    sr.User_Pwd = txtConfirmPassword.Text.Trim();
                    sr.User_Phone = txtPhone.Text.Trim();
                    sr.User_Active = cbIsActive.Checked;

                    UsersCS.UpdateUser(sr);

                    Response.Redirect("~/Admin/Users");

                }
            }
            else
            {
                UsersCS sr = new UsersCS();
                //sr.User_ID = Convert.ToInt32(RouteData.Values["sect_id"]);
                sr.User_Email = txtEmail.Text.Trim();
                sr.User_First = txtFirstName.Text.Trim();
                sr.User_Last = txtLastName.Text.Trim();
                sr.User_Add1 = txtAddress1.Text.Trim();
                sr.User_Add2 = txtAddress2.Text.Trim();
                sr.User_City = txtCity.Text.Trim();
                sr.State_ID = ddlState.SelectedValue;
                sr.User_Zip = txtZip.Text.Trim();
                sr.User_Salt = txtPassword.Text.Trim();
                sr.User_Pwd = txtPassword.Text.Trim();
                sr.User_Phone = txtPhone.Text.Trim();
                sr.User_Active = cbIsActive.Checked;

                UsersCS.InsertUser(sr);
                Response.Redirect("~/Admin/Users");
            }
        }
    }
}