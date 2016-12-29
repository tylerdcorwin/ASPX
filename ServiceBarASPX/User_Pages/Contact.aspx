<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TCorwin_SE256.User_Pages.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <asp:Label ID="lblGreeting" runat="server" Text="Contact US" CssClass="h3"></asp:Label>
    
    <!-- This page holds all of the lorem ipsum on the home page-->
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                    <div class="text-muted">
                        
                        <h4 class="text-muted">Main Phone: (401) 867-5309 </h4>
                        
                        <h4 class="text-muted">Event Coordinator: (401) 867-0228 </h4>  

                        <h4><strong class="text-primary">General Manager:</strong> Ryan Wilk <br /> Ryan@ServiceBar.com</h4>
                        <h4><strong class="text-primary">Event Coordinator:</strong> Shelly Corwin <br /> Shelly@ServiceBar.com</h4>
                        <h4><strong class="text-primary">Managing Partner: </strong>Tyler Corwin <br /> Tyler@ServiceBar.com</h4>
                        

                        
                    </div>
                </div>
                <div class="col-md-4">
                    <%--Remember to use the hidden-xs style when adding pictures so that they wont overlap on the text, and will disappear at certain sizes--%>
                    <%--<div class="text-primary"><h1 style="text-align:center" class="img-responsive hidden-xs">Patriots Headquarters</h1></div>--%>
                    <img src="../images/sb2.jpg" style="float:none; width:600px; height:325px" class="img-responsive hidden-xs" />
                    <div class="text-warning">
                        <h4 class="text-warning">We're always looking for great people to join our team. Contact <b class="text-primary">Jobs@ServiceBar.com</b> to submit your resume.</h4>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="text-danger">
                        <h3><strong>Hours:</strong></h3>
                        <h5>Open from 11am - 1am 7 Days a Week</h5>
                        <h5>Open at 11am for Lunch</h5>
                        <h5>Full Menu until 10pm Sunday - Thur / until 11pm weekends</h5>
                        <h5>Late Night Menu Served until close</h5>

                        
                    </div>
                </div>
                <br /><br /><br /><br /><br />
            </div>
        </div>

</asp:Content>
