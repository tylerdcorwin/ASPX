<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="Directions.aspx.cs" Inherits="TCorwin_SE256.User_Pages.Directions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <asp:Label ID="lblGreeting" runat="server" Text="Directions:" CssClass="h3"></asp:Label>
    
    <!-- This page holds all of the lorem ipsum on the home page-->
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                    <div class="text-muted">
                        <h4 class="text-muted"> <br />Service Bar is located at 440 Westminster Street in Providence, RI. 
                        Just take Exit 21 off of interstate 95 going North or South.  Go through 2 lights and
                            we're on the right. <br /> <br /> </h4><h4 class="text-warning">Complimentry valet parking</h4>
                    </div>
                </div>
                <div class="col-md-4">
                    <%--Remember to use the hidden-xs style when adding pictures so that they wont overlap on the text, and will disappear at certain sizes--%>
                    <div class="text-primary"><h1 style="text-align:center" class="img-responsive hidden-xs">Our Headquarters</h1></div>
                    <img src="../images/map.jpg" style="float:none; width:600px; height:325px" class="img-responsive hidden-xs" />
                    <div class="text-warning">
                        <br /><br /><br /><br /><br /><br /> 
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="text-danger">
                        <br /><br /><br /><br /><br />
                        <img src="../images/west.jpg" style="float:none; width:600px; height:325px" class="img-responsive hidden-xs" />
                    </div>
                </div>
                <br /><br /><br /><br /><br />
            </div>
        </div>

</asp:Content>
