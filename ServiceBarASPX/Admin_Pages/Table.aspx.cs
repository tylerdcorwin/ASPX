using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TCorwin_SE256.Admin_Pages
{
    public partial class Table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Home");
            }

            int table_id = Convert.ToInt32(RouteData.Values["tbl_id"]);

            if (!IsPostBack)
            {
                if (table_id > 0)
                {
                    lbtnUpdate.Text = "Update";
                    TableCS mt = new TableCS(table_id);

                    txtName.Text = mt.Table_Name;
                    txtDescription.Text = mt.Table_Desc;
                    ddlSection.SelectedValue = mt.Sect_ID.ToString();
                    txtSeatCount.Text = mt.Table_SeatCnt.ToString();
                    cbIsActive.Checked = mt.Table_Active;
                }
                else
                {
                    lbtnUpdate.Text = "Add";
                    TableCS mt = new TableCS(table_id);

                    txtName.Text = String.Empty;
                    txtDescription.Text = String.Empty;
                    ddlSection.SelectedValue = null;
                    txtSeatCount.Text = String.Empty;
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
                TableCS sr = new TableCS();

                if (RouteData.Values["tbl_id"] != null)
                {
                    sr.Table_ID = Convert.ToInt32(RouteData.Values["tbl_id"]);
                    sr.Sect_ID = Convert.ToInt32(ddlSection.SelectedValue);
                    sr.Table_Name = txtName.Text.Trim();
                    sr.Table_Desc = txtDescription.Text.Trim();
                    sr.Table_SeatCnt = Convert.ToInt32(txtSeatCount.Text);
                    sr.Table_Active = cbIsActive.Checked;

                    TableCS.UpdateTable(sr);
                    Response.Redirect("~/Admin/Tables");
                }
            }
            else
            {
                TableCS sr = new TableCS();
                sr.Table_ID = Convert.ToInt32(RouteData.Values["tbl_id"]);
                sr.Sect_ID = Convert.ToInt32(ddlSection.SelectedValue);
                sr.Table_Name = txtName.Text.Trim();
                sr.Table_Desc = txtDescription.Text.Trim();
                sr.Table_SeatCnt = Convert.ToInt32(txtSeatCount.Text);
                sr.Table_Active = cbIsActive.Checked;

                TableCS.InsertTable(sr);
                Response.Redirect("~/Admin/Tables");
            }
        }
    }
}