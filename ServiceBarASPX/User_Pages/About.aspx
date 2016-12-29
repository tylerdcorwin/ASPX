<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TCorwin_SE256.User_Pages.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    
    <asp:Label ID="lblGreeting" runat="server" Text="Welcome Stranger" CssClass="h2"></asp:Label>
    
    <!-- This page holds all of the lorem ipsum on the home page-->
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                    <div class="text-muted"> <h4>To Service Bar, where all you need is a good drink.</h4>
                        
                        <strong> CONCEPT: </strong>Born from bartending's roots, Service Bar is a uniquely stylish sports bar which offers high-quality traditional pub fare 
                        in addition to a range of awe-inspiring cocktails. With all of our dishes and mixers made from scratch, we strive to provide our customers with only 
                        the freshest of ingredients and proudly support many of our local farms in the process. We have worked hard to create a warm and 
                        welcoming atmosphere where guests feel comfortable and at home. We're dedicated to the celebration of great food, great beer, great 
                        entertainment and great service—we look forward to seeing you soon!
                        <img src="../images/cocktails.jpg" style="float:right ; padding:45px 45px 5px 5px;" class="img-responsive hidden-xs" />
                        
                    </div>
                </div>
                <div class="col-md-4">
                    <%--Remember to use the hidden-xs style when adding pictures so that they wont overlap on the text, and will disappear at certain sizes--%>
                    <div class="text-warning"><h3 style="text-align:center" class="img-responsive hidden-xs, text-warning">HUGE GIVEAWAYS DURING ALL PATRIOTS GAMES!!! </h3></div>
                    <img src="../images/Pats.jpg" style="float:none; width:600px; height:325px" class="img-responsive hidden-xs" />
                    <div class="text-warning"> <h4 class="text-warning">Come in for every Patriots game this season, we've got 1/2 priced wings, great burger specials
                        and FREE SHOTS every time the PATS SCORE! </h4>

                    </div>
                </div>
                <div class="col-md-4">
                    <img src="../images/sb.jpg" style="float:none; width:600px; height:325px" class="img-responsive hidden-xs" />
                    <div class="text-danger"><h5 class="text-primary">With over 75 TV's playing every sports network that you can dream of and full game sound every sunday during 
                        football season.  Come Join us for Gametime!
                                             </h5>
                    </div>
                    <br /><br /><br /><br /><br />
                </div>
            </div>
            <br /><br /><br /><br /><br /><br /><br />
        </div>

</asp:Content>
