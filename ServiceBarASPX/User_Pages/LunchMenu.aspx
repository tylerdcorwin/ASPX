<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="LunchMenu.aspx.cs" Inherits="TCorwin_SE256.User_Pages.LunchMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h2>Lunch Menu</h2>
    <fieldset>

        <%--Apps--%>
        <legend>Appetizers & Salads</legend>
        <asp:GridView ID="gvApps" runat="server" DataSourceID="sdsLunchApps"
            GridLines="Both" ShowHeader="false" AutoGenerateColumns="false" CssClass="menu" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="item_name" ReadOnly="true" SortExpression="item_name" ItemStyle-Width="350px" />
                <asp:BoundField DataField="item_desc" ReadOnly="true" SortExpression="item_desc" ItemStyle-Width="950px" />
                <asp:BoundField DataField="item_price" ReadOnly="true" SortExpression="item_price" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsLunchApps" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menu_items_getByMenu" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="4" Name="menu_id" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>
    <br />
    <%--Sandwiches--%>
    <br />
    <fieldset>
        <legend>Sandwiches</legend>
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
                <asp:Parameter DefaultValue="2" Name="cat_id" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>
    <br />
    <%--Happy Hour--%>
    <br />
    <fieldset>
        <legend>Happy Hour</legend>
        <asp:GridView ID="gvHappyHr" runat="server" DataSourceID="sdsHappyHr"
            GridLines="Both" ShowHeader="false" AutoGenerateColumns="false" CssClass="menu" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="item_name" ReadOnly="true" SortExpression="item_name" ItemStyle-Width="350px" />
                <asp:BoundField DataField="item_desc" ReadOnly="true" SortExpression="item_desc" ItemStyle-Width="950px" />
                <asp:BoundField DataField="item_price" ReadOnly="true" SortExpression="item_price" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsHappyHr" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menu_items_getByMenu" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="6" Name="menu_id" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>
    <br />
    <%--Kids--%>
    <br />
    <fieldset>
        <legend>Kids</legend>
        <asp:GridView ID="gvKids" runat="server" DataSourceID="sdsKids"
            GridLines="Both" ShowHeader="false" AutoGenerateColumns="false" CssClass="menu" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="item_name" ReadOnly="true" SortExpression="item_name" ItemStyle-Width="350px" />
                <asp:BoundField DataField="item_desc" ReadOnly="true" SortExpression="item_desc" ItemStyle-Width="950px" />
                <asp:BoundField DataField="item_price" ReadOnly="true" SortExpression="item_price" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsKids" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menu_items_getByMenu" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="3" Name="menu_id" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>
    <br />
     <%--Non-Alcholic Bevs--%>
    <br />
    <fieldset>
        <legend>Non-Alcholic Beverages</legend>
        <asp:GridView ID="gvNaBev" runat="server" DataSourceID="sdsNaBev"
            GridLines="Both" ShowHeader="false" AutoGenerateColumns="false" CssClass="menu" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="item_name" ReadOnly="true" SortExpression="item_name" ItemStyle-Width="350px" />
                <asp:BoundField DataField="item_desc" ReadOnly="true" SortExpression="item_desc" ItemStyle-Width="950px" />
                <asp:BoundField DataField="item_price" ReadOnly="true" SortExpression="item_price" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsNaBev" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menu_items_getByMenu" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="9" Name="menu_id" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </fieldset>
    <br />
    <br /><br /><br /><br /><br />


</asp:Content>
