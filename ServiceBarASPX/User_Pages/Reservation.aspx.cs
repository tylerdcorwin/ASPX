using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace TCorwin_SE256.User_Pages
{
    public partial class Reservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
     
            if (!IsPostBack)
            {
                //clear old values -> populate ddlGuestCnt
                ddlGuestCnt.Items.Clear();
                for (int i = 0; i <= 15; i++)
                {
                    ddlGuestCnt.Items.Add(new ListItem(i.ToString()));
                }
                //check url for res_id
                int res_Id = Convert.ToInt32(RouteData.Values["res_id"]);

                if (res_Id > 0)
                {
                    guestInsert.Visible = false;
                    //new reservation
                    ReservationsCS mt = new ReservationsCS(res_Id);

                    hfGuestId.Value = mt.Guest_Id.ToString();
                    hfTblId.Value = mt.Table_Id.ToString();
                    ddlEmployee.SelectedValue = mt.User_Id.ToString();
                    txtDate.Text = mt.Res_Date;
                    txtTime.Text = mt.Res_Time;
                    ddlGuestCnt.SelectedValue = mt.Res_Guest_Cnt.ToString();
                    txtSpReq.Text = mt.Res_Sp_Req;

                    lbtnUpdate.Text = "Update";
                }
                else //if no res id go to add
                {
                    //update reservation
                    GuestCS gt = new GuestCS();

                    txtFName.Text = gt.Guest_First;
                    txtLName.Text = gt.Guest_Last;
                    txtEmail.Text = gt.Guest_Email;
                    txtPhone.Text = gt.Guest_Phone;

                    ReservationsCS rd = new ReservationsCS(res_Id);

                    ddlEmployee.SelectedValue = null;
                    txtDate.Text = String.Empty;
                    txtTime.Text = String.Empty;
                    ddlGuestCnt.SelectedValue = String.Empty;
                    txtSpReq.Text = String.Empty;

                    lbtnUpdate.Text = "Add";
                }
            }

        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            ReservationsCS sr = new ReservationsCS();
            if (RouteData.Values["res_id"] != null)
            //Write res -> DB
            {
                bool result = false;
                sr.Res_Id = Convert.ToInt32(RouteData.Values["res_id"]);
                //sr.Guest_Id = Convert.ToInt32(RouteData.Values["guest_id"]);
                sr.Guest_Id = Convert.ToInt32(hfGuestId.Value); //error thrown
                sr.Table_Id = Convert.ToInt32(hfTblId.Value);
                //sr.Table_Id = Convert.ToInt32(RouteData.Values["tbl_id"]);
                sr.User_Id = Convert.ToInt32(ddlEmployee.SelectedValue);
                sr.Res_Date = txtDate.Text.ToString();
                sr.Res_Time = txtTime.Text.ToString();
                sr.Res_Guest_Cnt = Convert.ToInt32(ddlGuestCnt.SelectedValue);
                sr.Res_Sp_Req = txtSpReq.Text.Trim();
                
                result = ReservationsCS.UpdateReservation(sr);
                if (result)
                {
                    Response.Redirect("~/Admin/Reservation-Management");
                }

                //Response.Redirect("~/ResMgmt");
            }

            else
            {
                int new_id = 0;

                GuestCS ng = new GuestCS();
                //for guests default pwd is 'password'
                ng.Guest_Pwd = UsersCS.CreatePasswordHash(ng.Guest_Salt, "password");
                ng.Guest_First = txtFName.Text.Trim();
                ng.Guest_Last = txtLName.Text.Trim();
                ng.Guest_Email = txtEmail.Text.Trim();
                ng.Guest_Phone = txtPhone.Text.Trim();

                GuestCS og = new GuestCS(txtEmail.Text);

                if (og.Guest_ID > 0)
                {
                    sr.Guest_Id = og.Guest_ID;
                }
                else
                {
                    sr.Guest_Id = GuestCS.InsertGuest(ng);
                }

                sr.Table_Id = ReservationsCS.GetAvailableTable(txtDate.Text, txtTime.Text, Convert.ToInt32(ddlGuestCnt.SelectedValue));
                sr.User_Id = Convert.ToInt32(ddlEmployee.SelectedValue.ToString());
                sr.Res_Date = txtDate.Text.Trim();
                sr.Res_Time = txtTime.Text.Trim();
                sr.Res_Guest_Cnt = Convert.ToInt32(ddlGuestCnt.SelectedValue);
                sr.Res_Sp_Req = txtSpReq.Text.Trim();

                new_id = ReservationsCS.InsertReservation(sr);

                lblResult.Text = String.Concat("Guest's Email: " + ng.Guest_Email + " Reservation ID: " + new_id);
                //Response.Redirect("~/Reservations");

            }
        }

        protected void lbtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home");
        }
    }
}