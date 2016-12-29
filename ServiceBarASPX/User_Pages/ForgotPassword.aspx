<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TCorwin_SE256.User_Pages.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
 <div class="container-fluid">
        <div class="form-horizontal">
            <fieldset>
                <%--Email--%>
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Required" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Not a valid E-mail address" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="cvEmail" runat="server" ErrorMessage="E-mail's must match" ControlToValidate="txtEmail" Type="String" ControlToCompare="txtConfirmEmail"></asp:CompareValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Confirm Email--%>
                <div class="form-group">
                    <asp:Label ID="lblConfirmEmail" runat="server" Text="Confirm Email" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtConfirmEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" ErrorMessage="Required" ControlToValidate="txtConfirmEmail"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Not a valid E-mail address" ControlToValidate="txtConfirmEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="cvConfirmEmail" runat="server" ErrorMessage="E-mail's must match" ControlToValidate="txtConfirmEmail" Type="String" ControlToCompare="txtEmail"></asp:CompareValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Password--%>
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Passwords must match" ControlToValidate="txtPassword" Type="String" ControlToCompare="txtConfirmPassword"></asp:CompareValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Confirm Password--%>
                <div class="form-group">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="Passwords must match" ControlToValidate="txtConfirmPassword" Type="String" ControlToCompare="txtPassword"></asp:CompareValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Reset Password Btn--%>
                <div class="form-group">
                    <asp:LinkButton ID="lbtnResetPassword" runat="server" CssClass="btn btn-primary">Reset Password</asp:LinkButton>
                <br /><br /><br /><br /><br />
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
