<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="TCorwin_SE256.Admin_Pages.test1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%--Define a panel to control the rendering of form elements--%>
<asp:Panel ID="Panel1" runat="server" Width="95%" >
           
<%--Define your grid properties  Datakeynames = Your Primary key from the dataset--%>
<%--emptydatatext = What displays when the grid data source is empty
        allowsorting="true" AllowPaging="true" PageSize ="3"    --%>
   <br />
    This is a GridView Control
    <br />  <br />            
<asp:GridView ID="gvRoles" runat="server" 
AutoGenerateColumns="False"  Width="95%" PageSize="5" 
DataSourceID="sdsRoles" AllowPaging="true" AllowSorting="true"
emptydatatext="No records match the criteria provided.">
    <%--declare your column collection--%>
    <Columns>
    <%--Define your grid columns--%>
                    
        <%--This item's visible property = "false".  this is to include the UserID for 
        code-behind access
        and not show this column to users, a common practice--%>
        <asp:BoundField HeaderText="ID" 
            HeaderStyle-HorizontalAlign="Left" 
            DataField="RoleID"
            SortExpression="RoleID" 
            >
            <ItemStyle HorizontalAlign="left"></ItemStyle>
            <HeaderStyle HorizontalAlign="Center" />
        </asp:BoundField>
            <%--DataNavigateUrlFields fields allows you assign a 
                column in the data set as 
                a parameter for a page redirect call
                which is defined in the DataNavigateUrlFormatString
                 property.  the {0} is the value of 
                DataNavigateUrlFields.  
                --%>     
        <asp:HyperLinkField 
        DataTextField="RoleName" 
        DataNavigateUrlFields="RoleID" 
        DataNavigateUrlFormatString="~/Roles/Role/{0}" 
        HeaderText="Role Name" 
        SortExpression="RoleName" />
            
        
         <asp:BoundField HeaderText="Active?" 
            DataField="RoleIsActive"
            SortExpression="RoleIsActive">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField> 
        </Columns>
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" 
            PageButtonCount="1"  />
        <PagerStyle HorizontalAlign="Center" />
    </asp:GridView>
       
<asp:SqlDataSource ID="sdsRoles" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SE256 %>" 
    SelectCommand="spGetRoles" SelectCommandType="StoredProcedure" 
        >
    </asp:SqlDataSource>

</asp:Panel>

</asp:Content>


