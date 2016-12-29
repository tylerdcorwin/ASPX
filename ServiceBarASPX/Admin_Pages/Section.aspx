<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Section.aspx.cs" Inherits="TCorwin_SE256.Admin_Pages.Section" %>
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
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Required" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
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
                    <asp:LinkButton ID="lbtnCancel" runat="server" CssClass="btn btn-danger" OnClick="lbtnCancelClick" CausesValidation="false">Cancel</asp:LinkButton>
                    <br /><br /><br /><br /><br />
                </div>
            </fieldset>
        </div>
    </div>

</asp:Content>
