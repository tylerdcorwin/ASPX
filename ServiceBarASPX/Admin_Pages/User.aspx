<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="TCorwin_SE256.Admin_Pages.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">

     <div class="container-fluid">
        <div class="form-horizontal">
            <fieldset>
                <%--First Name--%>
                <div class="form-group">
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Required" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Last Name--%>
                <div class="form-group">
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Required" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Address1--%>
                <div class="form-group">
                    <asp:Label ID="lblAddress1" runat="server" Text="Address 1" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ErrorMessage="Required" ControlToValidate="txtAddress1"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Address2--%>
                <div class="form-group">
                    <asp:Label ID="lblAddress2" runat="server" Text="Address 2" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--City--%>
                <div class="form-group">
                    <asp:Label ID="lblCity" runat="server" Text="City" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Required" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--State--%>
                <div class="form-group">
                    <asp:Label ID="lblState" runat="server" Text="State" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:DropDownList ID="ddlState" runat="server" DataSourceID="sdsStates" DataTextField="State_Full_Name" DataValueField="state_id" ></asp:DropDownList>
                            <asp:SqlDataSource ID="sdsStates" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="states_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Required" ControlToValidate="ddlState"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Zip--%>
                <div class="form-group">
                    <asp:Label ID="lblZip" runat="server" Text="Zip Code" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvZip" runat="server" ErrorMessage="Required" ControlToValidate="txtZip"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revZip" runat="server" ErrorMessage="Zip must be 5 or 9 digits" ControlToValidate="txtZip" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>
                <%--Password--%>
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
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
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="Passwords must match" ControlToValidate="txtConfirmPassword" Type="String" ControlToCompare="txtPassword"></asp:CompareValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>
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
                <%--Phone--%>
                <div class="form-group">
                    <asp:Label ID="lblPhone" runat="server" Text="Phone Number" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="Required" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPhone" runat="server" ErrorMessage="Must Be a Valid Phone Number" ControlToValidate="txtPhone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}))?\d{3}\d{4}"></asp:RegularExpressionValidator>
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
                    <asp:LinkButton ID="lbtnCancel" runat="server" CssClass="btn btn-danger" OnClick="lbtnCancelClick" CausesValidation="false">Cancel</asp:LinkButton>
                    <br /><br /><br /><br /><br />
                </div>
            </fieldset>
        </div>
    </div>

</asp:Content>
