<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="DinnerMenu.aspx.cs" Inherits="TCorwin_SE256.User_Pages.DinnerMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <h2>Dinner Menu</h2>
    <fieldset>

        <%--Apps--%>
        <legend>Appetizers & Salads</legend>
        <asp:GridView ID="gvApps" runat="server" DataSourceID="sdsDinnerApps"
            GridLines="Both" ShowHeader="false" AutoGenerateColumns="false" CssClass="menu" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="item_name" ReadOnly="true" SortExpression="item_name" ItemStyle-Width="350px" />
                <asp:BoundField DataField="item_desc" ReadOnly="true" SortExpression="item_desc" ItemStyle-Width="950px" />
                <asp:BoundField DataField="item_price" ReadOnly="true" SortExpression="item_price" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsDinnerApps" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menu_items_getByMenu" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="4" Name="menu_id" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>
    <br />
    <%--Entrees--%>
    <br />
    <fieldset>
        <legend>Entrees</legend>
        <asp:GridView ID="gvSandwiches" runat="server" DataSourceID="sdsLunchSandwiches"
            GridLines="Both" ShowHeader="false" AutoGenerateColumns="false" CssClass="menu" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="item_name" ReadOnly="true" SortExpression="item_name" ItemStyle-Width="350px" />
                <asp:BoundField DataField="item_desc" ReadOnly="true" SortExpression="item_desc" ItemStyle-Width="950px" />
                <asp:BoundField DataField="item_price" ReadOnly="true" SortExpression="item_price" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsLunchSandwiches" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menu_items_getByCat" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="4" Name="cat_id" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>
    <br />
    <%--Late Night--%>
    <br />
    <fieldset>
        <legend>Late Night</legend>
        <asp:GridView ID="gvLateNight" runat="server" DataSourceID="sdsLateNight"
            GridLines="Both" ShowHeader="false" AutoGenerateColumns="false" CssClass="menu" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="item_name" ReadOnly="true" SortExpression="item_name" ItemStyle-Width="350px" />
                <asp:BoundField DataField="item_desc" ReadOnly="true" SortExpression="item_desc" ItemStyle-Width="950px" />
                <asp:BoundField DataField="item_price" ReadOnly="true" SortExpression="item_price" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsLateNight" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menu_items_getByMenu" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="7" Name="menu_id" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>
    <br />
    <%--Alcholic Bevs--%>
    <br />
    <fieldset>
        <legend>Alcholic Beverages</legend>
        <asp:GridView ID="gvABev" runat="server" DataSourceID="sdsABev"
            GridLines="Both" ShowHeader="false" AutoGenerateColumns="false" CssClass="menu" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="item_name" ReadOnly="true" SortExpression="item_name" ItemStyle-Width="350px" />
                <asp:BoundField DataField="item_desc" ReadOnly="true" SortExpression="item_desc" ItemStyle-Width="950px" />
                <asp:BoundField DataField="item_price" ReadOnly="true" SortExpression="item_price" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsABev" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menu_items_getByMenu" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="10" Name="menu_id" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>
    <br />
    <br /><br /><br /><br /><br />



</asp:Content>
