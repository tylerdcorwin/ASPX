<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="MenuItems.aspx.cs" Inherits="TCorwin_SE256.Admin_Pages.MenuItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    
<div class ="row">
            <div class ="col-md-12">
                <div class="table-responsive">
                <asp:GridView ID="gvMenuItems" runat="server" AutoGenerateColumns="false" DataSourceID="sdsMenuItems" CssClass="table" AllowSorting="true" AllowPaging="true" PageSize="25">
                    <Columns>
                        <asp:BoundField DataField="item_name" HeaderText="Name" SortExpression="item_name" />
                        <asp:BoundField DataField="item_desc" HeaderText="Description" SortExpression="item_desc" />
                        <asp:BoundField DataField="item_allergens" HeaderText="Allergens" SortExpression="item_allergens" />
                        <asp:BoundField DataField="item_price" HeaderText="Price" SortExpression="item_price" />
                        <asp:BoundField DataField="item_gluten_free" HeaderText="Gluten Free" SortExpression="item_gluten_free" />
                        <asp:BoundField DataField="item_active" HeaderText="Active" SortExpression="item_active" />

                        <asp:HyperLinkField DataNavigateUrlFields="item_id" DataNavigateUrlFormatString="~/Admin/Menu-Item/{0}" Text="View/Edit"/>

                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" Position="TopAndBottom" />
                    <PagerStyle BackColor="#336699" HorizontalAlign="Center" />
                </asp:GridView>

                    <asp:Label ID="lblTest" runat="server" ></asp:Label>
                    </div>
                <asp:SqlDataSource ID="sdsMenuItems" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menu_items_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </div>


</asp:Content>
