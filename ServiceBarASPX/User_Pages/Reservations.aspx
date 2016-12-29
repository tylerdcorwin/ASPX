<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="TCorwin_SE256.User_Pages.Reservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">



    <div class="row">
        <div class="col-md-12">
            <div class="table-responsive">
                <asp:GridView ID="gvResMgmt" runat="server" AutoGenerateColumns="false" DataSourceID="sdsResMgmt" CssClass="table" AllowSorting="true" AllowPaging="true" PageSize="25">
                    <Columns>
                        <asp:BoundField DataField="guest_name" HeaderText="Guest Name" SortExpression="guest_name" />
                        <asp:BoundField DataField="res_spec_req" HeaderText="Special Requests" SortExpression="res_spec_req" />
                        <asp:BoundField DataField="res_date" HeaderText="Date" SortExpression="res_date" />
                        <asp:BoundField DataField="res_time" HeaderText="Time" SortExpression="res_time" />
                        <asp:BoundField DataField="tbl_name" HeaderText="Table" SortExpression="tbl_name" />
                        <asp:BoundField DataField="res_guest_cnt" HeaderText="# of Guests" SortExpression="res_guest_cnt" />
                        <asp:BoundField DataField="employee" HeaderText="Employee" SortExpression="employee" />

                        <asp:HyperLinkField DataNavigateUrlFields="res_id" DataNavigateUrlFormatString="~/Reservation/{0}" Text="View/Edit" />

                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" Position="TopAndBottom" />
                    <PagerStyle BackColor="#336699" HorizontalAlign="Center" />
                </asp:GridView>
                <br /><br /><br /><br /><br />
            </div>
            <asp:SqlDataSource ID="sdsResMgmt" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="reservations_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>
    </div>






</asp:Content>
