<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="TCorwin_SE256.User_Pages.Reservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="container-fluid">
        <div class="form-horizontal">
            <fieldset>
                <h2>Make a Reservation</h2>
                <div id="guestInsert" runat="server">
                    <%--start guest insert--%>
                    <%--First Name--%>
                    <div class="form-group">
                        <asp:Label ID="lblFName" runat="server" Text="First Name" CssClass="col-lg-2"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtFName" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFName" runat="server" ErrorMessage="First Name is Required" ControlToValidate="txtFName"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-5"></div>
                    </div>

                    <%--Last Name--%>
                    <div class="form-group">
                        <asp:Label ID="lblLName" runat="server" Text="Last Name" CssClass="col-lg-2"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtLName" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLName" runat="server" ErrorMessage="Last Name is Required" ControlToValidate="txtFName"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-5"></div>
                    </div>

                    <%--Email--%>
                    <div class="form-group">
                        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="col-lg-2"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Email is Required" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter A Valid Email" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-5"></div>
                    </div>

                    <%--Phone--%>
                    <div class="form-group">
                        <asp:Label ID="lblPhone" runat="server" Text="Phone Number" CssClass="col-lg-2"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Phone"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="Phone is Required" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-5"></div>
                    </div>

                </div> <%-- close guest insert--%>

                <div class="form-group">
                    <div class="col-lg-offset-5 col-lg-2">
                        <asp:HiddenField ID="hfGuestId" runat="server" />
                        <asp:HiddenField ID="hfTblId" runat="server" />
                    </div>
                </div>

                <%--PUT HIDDEN FIELDS HERE--%>
                
                <%--Employee--%>
                <div class="form-group">
                    <div class="col-lg-offset-5 col-lg-2">
                        <asp:Label ID="lblUserID" runat="server" Text="Employee:"></asp:Label>
                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control" DataSourceID="sdsEmployee" DataTextField="employee" DataValueField="user_id"></asp:DropDownList>
                        <asp:SqlDataSource ID="sdsEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CorwinConnectionString %>" SelectCommand="users_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    </div>
                </div>

                <%--Date--%>
                <div class="form-group">
                    <asp:Label ID="lblDate" runat="server" Text="Choose a Date" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="Date is Required" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>

                <%--Time--%>
                <div class="form-group">
                    <asp:Label ID="lblTime" runat="server" Text="Time" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtTime" runat="server" TextMode="Time"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTime" runat="server" ErrorMessage="Time is Required" ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>

                <%--Guest Count--%>
                <div class="form-group">
                    <asp:Label ID="lblGuestCnt" runat="server" Text="Guest Count" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:DropDownList ID="ddlGuestCnt" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvGuestCnt" runat="server" ErrorMessage="Required" ControlToValidate="ddlGuestCnt"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-lg-5"></div>
                </div>

                <%--Special Requests--%>
                <div class="form-group">
                    <asp:Label ID="lblSpRequests" runat="server" Text="Special Requests" CssClass="col-lg-2"></asp:Label>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtSpReq" runat="server" CssClass="form-control" placeholder="Special Requests"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSpReq" runat="server" ErrorMessage="Required" ControlToValidate="txtSpReq"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-5"></div>
                </div>



                <%--Update Btn--%>
                <div class="form-group">
                    <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="btn btn-primary" OnClick="lbtnUpdate_Click">Add</asp:LinkButton>
                </div>
                <%--Cancel Btn--%>
                <div class="form-group">
                    <asp:LinkButton ID="lbtnCancel" runat="server" CssClass="btn btn-danger" OnClick="lbtnCancel_Click" CausesValidation="false">Cancel</asp:LinkButton>
                </div>
                <%--result--%>
                <div class="form-group">
                    <div class="col-lg-offset-5 col-lg-2">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </div>
                    <br /><br /><br /><br /><br />
                </div>
            </fieldset>
        </div>
    </div>




</asp:Content>
