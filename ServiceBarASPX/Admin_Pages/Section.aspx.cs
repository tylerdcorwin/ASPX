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
    public partial class Section : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Home");
            }


            int sect_id = Convert.ToInt32(RouteData.Values["sect_id"]);

            if (!IsPostBack)
            {
                if (sect_id > 0)
                {
                    lbtnUpdate.Text = "Update";
                    SectionCS mt = new SectionCS(sect_id);

                    txtName.Text = mt.Sect_Name;
                    txtDescription.Text = mt.Sect_Desc;
                    cbIsActive.Checked = mt.Sect_Active;
                }
                else
                {
                    lbtnUpdate.Text = "Add";
                    txtName.Text = String.Empty;
                    txtDescription.Text = String.Empty;
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
                SectionCS sr = new SectionCS();
                
                if (RouteData.Values["sect_id"] != null)
                {
                    sr.Sect_ID = Convert.ToInt32(RouteData.Values["sect_id"]);
                    sr.Sect_Name = txtName.Text.Trim();
                    sr.Sect_Desc = txtDescription.Text.Trim();
                    sr.Sect_Active = cbIsActive.Checked;

                    SectionCS.UpdateSectionItems(sr);
                    Response.Redirect("~/Admin/Sections");

                }
            }
            else
            {
                SectionCS sr = new SectionCS();
                sr.Sect_ID = Convert.ToInt32(RouteData.Values["sect_id"]);
                sr.Sect_Name = txtName.Text.Trim();
                sr.Sect_Desc = txtDescription.Text.Trim();
                sr.Sect_Active = cbIsActive.Checked;

                SectionCS.InsertSectionItem(sr);
                Response.Redirect("~/Admin/Sections");
            }
        }

        protected void lbtnUpdate_Click1(object sender, EventArgs e)
        {

        }
    }
}