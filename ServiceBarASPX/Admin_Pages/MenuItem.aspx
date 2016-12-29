<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="MenuItem.aspx.cs" Inherits="TCorwin_SE256.Admin_Pages.MenuItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">

    <div class="container-fluid">
        <div class="form-horizontal">
            <fieldset>
                
                <%--Name--%>
                <div class="form-group">
                    <asp:Label ID="lblName" runat="server" Text="Name" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Required" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Description--%>
                <div class="form-group">
                    <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtDescription" runat="server" Width="550px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Required" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Allergens--%>
                <div class="form-group">
                    <asp:Label ID="lblAllergens" runat="server" Text="Allergens" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtAllergens" runat="server"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Price--%>
                <div class="form-group">
                    <asp:Label ID="lblPrice" runat="server" Text="Price" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Required" ControlToValidate="txtPrice"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvPrice" runat="server" ErrorMessage="Must Be Greater than 0" ControlToValidate="txtPrice" Type="Currency" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Menu--%>
                <div class="form-group">
                    <asp:Label ID="lblMenu" runat="server" Text="Menu" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:DropDownList ID="ddlMenu" runat="server" DataSourceID="sdsMenus" DataTextField="menu_name" DataValueField="menu_id"></asp:DropDownList>
                            <%--connect to DB and populate dropdown--%>
                            <asp:SqlDataSource ID = "sdsMenus" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menus_getAll" SelectCommandType="StoredProcedure" ></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="rfvMenu" runat="server" ErrorMessage="Required" ControlToValidate="ddlMenu"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Category--%>
                <div class="form-group">
                    <asp:Label ID="lblCategory" runat="server" Text="Section" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="sdsCategory" DataTextField="cat_name" DataValueField="cat_id"></asp:DropDownList>
                            <%--connect to DB and populate dropdown--%>
                            <asp:SqlDataSource ID="sdsCategory" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="menu_categories_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="rfvSection" runat="server" ErrorMessage="Required" ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Is Active--%>
                <div class="form-group">
                    <asp:Label ID="lblIsActive" runat="server" Text="Is Active" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:CheckBox ID="cbIsActive" runat="server" />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                    <%--Update Btn--%>
                <div class="form-group">
                    <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="btn btn-primary" OnClick="lbtnUpdate_Click">Update</asp:LinkButton>
                </div>
                 <%--Cancel Btn--%>
                <div class="form-group">
                    <asp:LinkButton ID="lbtnCancel" runat="server" CssClass="btn btn-danger" CausesValidation="false" OnClick="lbtnCancel_Click">Cancel</asp:LinkButton>
                    <br /><br /><br /><br /><br />
                </div>
            </fieldset>
        </div>
    </div>


</asp:Content>
