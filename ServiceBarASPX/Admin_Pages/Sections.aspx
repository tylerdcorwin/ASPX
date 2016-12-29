<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Sections.aspx.cs" Inherits="TCorwin_SE256.Admin_Pages.Sections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="table-responsive">
                <asp:GridView ID="gvSections" runat="server" AutoGenerateColumns="false" DataSourceID="sdsSections" CssClass="table" AllowSorting="true" AllowPaging="true" PageSize="25">
                    <Columns>
                        <asp:BoundField DataField="sect_name" HeaderText="Section Name" SortExpression="sect_name" />
                        <asp:BoundField DataField="sect_desc" HeaderText="Section Description" SortExpression="sect_desc" />
                        <asp:BoundField DataField="sect_active" HeaderText="Active" SortExpression="sect_active" />

                        <asp:HyperLinkField DataNavigateUrlFields="sect_id" DataNavigateUrlFormatString="~/Admin/Section/{0}" Text="View/Edit" />

                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" Position="TopAndBottom" />
                    <PagerStyle BackColor="#336699" HorizontalAlign="Center" />
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="sdsSections" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="sections_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            <br /><br /><br /><br /><br />
        </div>
    </div>


</asp:Content>
