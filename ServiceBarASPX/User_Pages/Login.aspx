<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TCorwin_SE256.User_Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="container-fluid">
        <div class="form-horizontal">
            <fieldset>
                <%--username--%>
                <div class="form-group">
                    <asp:Label ID="lblUserName" runat="server" Text="Email Address" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Required" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--password--%>
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        <br />
                        <asp:HyperLink ID="hlnkForgotPassword" runat="server" NavigateUrl="~/User_Pages/ForgotPassword.aspx">Forgot Password</asp:HyperLink>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--result message--%>
                <div class="form-group">
                    <asp:Label ID="lblResult" runat="server" Text="" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5"></div>
                    <div class="col-lg-5"></div>
                </div>
                <%--login btn--%>
                <div class="form-group">
                    <asp:LinkButton ID="lbtnLogin" runat="server" CssClass="btn btn-primary" OnClick="lbtnLogin_Click">Login</asp:LinkButton>
                    <br /><br /><br /><br /><br />
                </div>
            </fieldset>
        </div>
    </div>

</asp:Content>
