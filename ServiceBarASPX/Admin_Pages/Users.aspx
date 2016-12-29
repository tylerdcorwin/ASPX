<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="TCorwin_SE256.Admin_Pages.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="table-responsive">
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" DataSourceID="sdsUsers" CssClass="table" AllowSorting="true" AllowPaging="true" PageSize="25">
                    <Columns>
                        <asp:BoundField DataField="user_first" HeaderText="First Name" SortExpression="user_first" />
                        <asp:BoundField DataField="user_last" HeaderText="Last Nme" SortExpression="user_last" />
                        <asp:BoundField DataField="user_add1" HeaderText="Address 1" SortExpression="user_add1" />
                        <asp:BoundField DataField="user_add2" HeaderText="Address 2" SortExpression="user_add2" />
                        <asp:BoundField DataField="user_city" HeaderText="City" SortExpression="user_city" />
                        <asp:BoundField DataField="state_id" HeaderText="State" SortExpression="state_id" />
                        <asp:BoundField DataField="user_zip" HeaderText="Zip" SortExpression="user_zip" />
                        <asp:BoundField DataField="user_phone" HeaderText="Phone" SortExpression="user_phone" />
                        <asp:BoundField DataField="user_active" HeaderText="Active" SortExpression="user_active" />

                        <asp:HyperLinkField DataNavigateUrlFields="user_id" DataNavigateUrlFormatString="~/Admin/User/{0}" Text="View/Edit" />

                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" Position="TopAndBottom" />
                    <PagerStyle BackColor="#336699" HorizontalAlign="Center" />
                </asp:GridView>
                <br /><br /><br /><br /><br />
            </div>
            <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="users_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>
    </div>

</asp:Content>
