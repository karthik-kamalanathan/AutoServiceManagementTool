<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="ASMT.UI.MainPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Auto Service Management Tool</title>

    <!--External Resources-->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" />

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>

    <script type="text/javascript">
        function DisableBackButton() {
            ``
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
    <!--External Resources-->

</head>
<body>
    <!--Navigation bar-->
    <nav class="navbar navbar-expand-sm bg-light navbar-light navbar-fixed-top justify-content-end">
        <div class="navbar-header">
            <h1 class="display-4 text-left">Auto Service Management Tool</h1>
        </div>
        <div>
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <button type="button" class="btn btn-link" data-toggle="modal" data-target="#SignIn">Service Provider Sign In</button>
                </li>
                <li class="nav-item">
                    <button type="button" class="btn btn-link" data-toggle="modal" data-target="#BookService">Book A Service</button>
                </li>
                <li class="nav-item">
                    <button type="button" class="btn btn-link" data-toggle="modal" data-target="#TrackStatus">Track Service Status</button>
                </li>
            </ul>
        </div>
    </nav>
    <!--Navigation bar-->

    <!--Carousel Slides-->
    <div id="demo" class="carousel slide" data-ride="carousel">
        <ul class="carousel-indicators">
            <li data-target="#demo" data-slide-to="0" class="active"></li>
            <li data-target="#demo" data-slide-to="1"></li>
            <li data-target="#demo" data-slide-to="2"></li>
            <li data-target="#demo" data-slide-to="3"></li>
        </ul>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="/Images/1.jpg" alt="BikeImage1" style="width: 100%" height="600" />
                <div class="carousel-caption">
                    <h3></h3>
                    <p></p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="/Images/2.jpg" alt="BikeImage2" style="width: 100%" height="600" />
                <div class="carousel-caption">
                    <h3></h3>
                    <p></p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="/Images/3.jpg" alt="BikeImage3" style="width: 100%" height="600" />
                <div class="carousel-caption">
                    <h3></h3>
                    <p></p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="/Images/4.jpg" alt="BikeImage4" style="width: 100%" height="600" />
                <div class="carousel-caption">
                    <h3></h3>
                    <p></p>
                </div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#demo" data-slide="prev">
            <span class="carousel-control-prev-icon"></span>
        </a>
        <a class="carousel-control-next" href="#demo" data-slide="next">
            <span class="carousel-control-next-icon"></span>
        </a>
    </div>
    <!--Carousel Slides-->

    <!-- Forms -->
    <form id="form1" runat="server">
        <div>

            <!-- Modal Service Provider Sign In -->
            <div class="modal fade" id="SignIn" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="container modal-content">
                        <div class="modal-header">
                            <h4>Service Provider Sign in</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <asp:TextBox type="text" class="form-control" ID="txtUserId" placeholder="User Id" name="custid" runat="server" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox type="password" class="form-control" ID="txtPswd" placeholder="Password" name="pswd" runat="server" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox type="text" class="form-control" ID="txtLocId" placeholder="Location Id" name="locId" runat="server" AutoCompleteType="Disabled" />
                            </div>
                            <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Sign in" OnClick="signin_Click" />
                        </div>
                        <div class="modal-footer">
                            <asp:HyperLink href="#" class="text-primary" runat="server">Forgot Password?</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Modal Service Provider Sign In -->

            <!-- Modal Book A Service -->
            <div class="modal fade" id="BookService" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="container modal-content">
                        <div class="modal-header">
                            <h4>Book A Service</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <asp:DropDownList class="form-control" ID="dropDownCity" name="serviceCity" runat="server">
                                    <asp:ListItem Value="">City</asp:ListItem>
                                    <asp:ListItem>Kumbakonam</asp:ListItem>
                                    <asp:ListItem>Thanjavur</asp:ListItem>
                                    <asp:ListItem>Trichy</asp:ListItem>
                                    <asp:ListItem>Tiruvarur</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:TextBox type="text" class="form-control" ID="txtCustName" placeholder="Name" name="custName" runat="server" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox type="text" class="form-control" ID="txtPhNum" placeholder="Phone Number" name="phNum" runat="server" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox type="text" class="form-control" ID="txtAutoNum" placeholder="Vehicle Number" name="autoNum" runat="server" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox type="text" class="form-control" ID="txtAutoModel" placeholder="Vehicle Model" name="autoModel" runat="server" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-group">
                                <asp:DropDownList class="form-control" ID="DropDownServiceType" name="serviceType" runat="server">
                                    <asp:ListItem Value="">Service Type</asp:ListItem>
                                    <asp:ListItem>1st Service</asp:ListItem>
                                    <asp:ListItem>2nd Service</asp:ListItem>
                                    <asp:ListItem>3rd Service</asp:ListItem>
                                    <asp:ListItem>4th Service</asp:ListItem>
                                    <asp:ListItem>5th Service</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:TextBox type="text" class="form-control" ID="txtInstructions" TextMode="MultiLine" placeholder="Service Instructions" name="instructions" runat="server" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-group form-check">
                                <asp:Label class="form-check-label" runat="server">
                                    <asp:CheckBox class="form-check-input" ID="chkTerms" type="checkbox" name="remember" runat="server" />
                                    I agree the 
                                    <asp:HyperLink href="#" class="text-primary" runat="server">Terms & Services</asp:HyperLink>
                                </asp:Label>
                            </div>
                            <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Book Service" OnClick="bookService_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- Modal Book A Service -->

            <!-- Modal Track Service Status -->
            <div class="modal fade" id="TrackStatus" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="container modal-content">
                        <div class="modal-header">
                            <h4>Track Service Status</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <asp:TextBox type="text" class="form-control" ID="TextBox1" placeholder="Tracking ID" name="trackingId" runat="server" AutoCompleteType="Disabled" />
                            </div>
                            <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Submit" OnClick="trackStatus_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- Modal Track Service Status -->

        </div>
    </form>

    <!-- Footer -->
    <footer class="page-footer font-small blue pt-4 mt-4">
        <div class="container-fluid text-center text-md-left">
            <div class="row">
                <div class="col-md-6 mt-md-0 mt-3">
                    <p class="footer-links">
                        <p>
                            <h4>Contact Us</h4>
                        </p>
                        <b>Address :</b>
                        <br />
                        Sastra University, Kumbakonam, 612001<br />
                        Phone: 098765 43210
                    </p>
                </div>
            </div>
        </div>
        <div class="footer-copyright text-center py-3">
            © 2022 Copyright: ASMT.Inc
        </div>
    </footer>
    <!-- Footer -->

</body>
</html>
