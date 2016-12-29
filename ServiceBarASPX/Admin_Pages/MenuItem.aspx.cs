using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TCorwin_SE256.Admin_Pages
{
    public partial class MenuItem : System.Web.UI.Page
    {
        int item_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Home");
            }

            else
            {
                if (!IsPostBack)
                {
                    item_id = Convert.ToInt32(RouteData.Values["item_id"]);

                    if (item_id > 0)
                    {

                        MenuItemCS mt = new MenuItemCS(item_id);

                        txtName.Text = mt.Item_Name;
                        txtDescription.Text = mt.Item_Desc;
                        txtAllergens.Text = mt.Item_Allergens;
                        txtPrice.Text = mt.Item_Price.ToString();
                        ddlMenu.SelectedValue = mt.Menu_Id.ToString();
                        ddlCategory.SelectedValue = mt.Cat_Id.ToString();
                        cbIsActive.Checked = mt.Item_Active;

                        lbtnUpdate.Text = "Update";
                    }
                    else
                    {
                        txtName.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                        txtAllergens.Text = String.Empty;
                        txtPrice.Text = String.Empty;
                        ddlMenu.SelectedValue = null;
                        ddlCategory.SelectedValue = null;
                        cbIsActive.Checked = false;

                        lbtnUpdate.Text = "Add";
                    }
                }

            }
        }
        protected void lbtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home");
        }
        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            MenuItemCS sr = new MenuItemCS();
            if (RouteData.Values["item_id"] != null)
            {
                sr.Item_ID = Convert.ToInt32(RouteData.Values["item_id"]);
                sr.Menu_Id = Convert.ToInt32(ddlMenu.SelectedValue);
                sr.Cat_Id = Convert.ToInt32(ddlCategory.SelectedValue);
                sr.Item_Name = txtName.Text.Trim();
                sr.Item_Desc = txtDescription.Text.Trim();
                sr.Item_Allergens = txtAllergens.Text.Trim();
                sr.Item_Price = Convert.ToDecimal(txtPrice.Text);
                sr.Item_Gluten_Free = false;
                sr.Item_Active = cbIsActive.Checked;
                MenuItemCS.UpdateMenuItems(sr);

                Response.Redirect("~/Admin/Menu-Items");
            }

            else
            {
                sr.Menu_Id = Convert.ToInt32(ddlMenu.SelectedValue);
                sr.Cat_Id = Convert.ToInt32(ddlCategory.SelectedValue);
                sr.Item_Name = txtName.Text.Trim();
                sr.Item_Desc = txtDescription.Text.Trim();
                sr.Item_Allergens = txtAllergens.Text.Trim();
                sr.Item_Price = Convert.ToDecimal(txtPrice.Text);
                sr.Item_Gluten_Free = false;
                sr.Item_Active = cbIsActive.Checked;

                MenuItemCS.InsertMenuItem(sr);

                Response.Redirect("~/Admin/Menu-Items");
            }
        }
    }
}
