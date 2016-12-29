<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Tables.aspx.cs" Inherits="TCorwin_SE256.Admin_Pages.Tables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="table-responsive">
                <asp:GridView ID="gvTables" runat="server" AutoGenerateColumns="false" DataSourceID="sdsTables" CssClass="table" AllowSorting="true" AllowPaging="true" PageSize="25">
                    <Columns>
                        <asp:BoundField DataField="tbl_name" HeaderText="Table Name" SortExpression="tbl_name" />
                        <asp:BoundField DataField="tbl_desc" HeaderText="Description" SortExpression="tbl_desc" />
                        <asp:BoundField DataField="sect_name" HeaderText="Section" SortExpression="sect_name" />
                        <asp:BoundField DataField="tbl_seat_cnt" HeaderText="Seat Count" SortExpression="tbl_seat_cnt" />
                        <asp:BoundField DataField="tbl_active" HeaderText="Active" SortExpression="tbl_active" />

                        <asp:HyperLinkField DataNavigateUrlFields="tbl_id" DataNavigateUrlFormatString="~/Admin/Table/{0}" Text="View/Edit" />

                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" Position="TopAndBottom" />
                    <PagerStyle BackColor="#336699" HorizontalAlign="Center" />
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="sdsTables" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="tables_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            <br /><br /><br /><br /><br />
        </div>
    </div>



</asp:Content>
