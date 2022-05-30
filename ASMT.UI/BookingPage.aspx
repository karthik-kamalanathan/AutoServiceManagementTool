<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingPage.aspx.cs" Inherits="ASMT.UI.BookingPage" %>

<!DOCTYPE html>
<html lang="en">
<head>

    <!-- Meta Data -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="Aishvarya">
    <!-- Meta Data -->

    <title>ASMT - Auto Service & Management Tool</title>

    <!--External Resources-->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-select.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../Scripts/jquery-3.6.0.slim.js"></script>
    <script src="../Scripts/umd/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <!--External Resources-->

    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }
    </style>

    <!-- Date Selector -->
    <script type="text/javascript">
        let startDate = document.getElementById('startDate')

        startDate.addEventListener('change', (e) => {
            let startDateVal = e.target.value
            document.getElementById('startDateSelected').innerText = startDateVal
        })
    </script>

    <!-- Booking Success Show Modal -->
    <script type="text/javascript">
        function openSuccessModal(bookingId) {
            document.getElementById("txtBookingId").value = bookingId;
            $('#bookingSuccess').modal('show');
        }
    </script>

    <script type="text/javascript">
        $('.selectpicker').selectpicker();
    </script>

    <link href="../Content/form-validation.css" rel="stylesheet" />
    <link href="../Content/modals.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <div class="container">
        <main>
            <!-- Header -->
            <div class="py-5 text-center">
                <h2>Booking Form</h2>
                <p class="lead">Submit the Below Form to Book Vehicle Service</p>
            </div>
            <!-- Header -->

            <!-- Booking Form -->
            <h4 class="mb-3">Basic Info</h4>
            <form class="needs-validation" id="bookingForm" runat="server" novalidate>
                <%--<form id="bookingForm" runat="server" novalidate>--%>
                <div class="row g-3">

                    <!-- Customer First Name -->
                    <div class="col-sm-6">
                        <label for="firstName" class="form-label">First Name</label>
                        <asp:TextBox type="text" class="form-control" ID="firstName" placeholder="" name="firstName" runat="server" AutoCompleteType="Disabled" required="required" />
                        <div class="invalid-feedback">
                            Valid first name is required.
                        </div>
                    </div>

                    <!-- Customer Last Name -->
                    <div class="col-sm-6">
                        <label for="lastName" class="form-label">Last Name</label>
                        <asp:TextBox type="text" class="form-control" ID="lastName" placeholder="" name="lastName" runat="server" AutoCompleteType="Disabled" required="required" />
                        <div class="invalid-feedback">
                            Valid last name is required.
                        </div>
                    </div>

                    <!-- Customer Phone Number -->
                    <div class="col-sm-6">
                        <label for="lastName" class="form-label">Phone Number</label>
                        <asp:TextBox type="text" class="form-control" ID="phonenum" placeholder="" name="phonenum" runat="server" AutoCompleteType="Disabled" required="required" />
                        <div class="invalid-feedback">
                            Valid phone number is required.
                        </div>
                    </div>

                    <!-- Customer Email -->
                    <div class="col-sm-6">
                        <label for="email" class="form-label">Email <span class="text-muted">(Optional)</span></label>
                        <asp:TextBox type="email" class="form-control" ID="email" placeholder="" name="email" runat="server" AutoCompleteType="Disabled" />
                        <div class="invalid-feedback">
                            Please enter a valid email address.
                        </div>
                    </div>

                    <!-- Vehicle Model -->
                    <div class="col-sm-6">
                        <label for="vehicleModel" class="form-label">Vehicle Model</label>
                        <asp:TextBox type="text" class="form-control" ID="vehicleModel" placeholder="" name="vehicleModel" runat="server" AutoCompleteType="Disabled" required="required" />
                        <div class="invalid-feedback">
                            Valid vehicle model is required.
                        </div>
                    </div>

                    <!-- Vehicle Number -->
                    <div class="col-sm-6">
                        <label for="vehicleNum" class="form-label">Vehicle Number</label>
                        <asp:TextBox type="text" class="form-control" ID="vehicleNum" placeholder="" name="vehicleNum" runat="server" AutoCompleteType="Disabled" required="required" />
                        <div class="invalid-feedback">
                            Valid vehicle number is required.
                        </div>
                    </div>

                    <!-- Location -->
                    <div class="col-sm-6">
                        <label for="location" class="form-label">Location</label>
                        <asp:DropDownList class="form-control form-select" ID="location" name="location" runat="server">
                            <asp:ListItem hidden>Choose...</asp:ListItem>
                            <asp:ListItem>Kumbakonam</asp:ListItem>
                            <asp:ListItem>Trichy</asp:ListItem>
                            <asp:ListItem>Thanjavur</asp:ListItem>
                        </asp:DropDownList>
                        <div class="invalid-feedback">
                            Please select a valid location.
                        </div>
                    </div>

                    <!-- Service Date -->
                    <div class="col-sm-6">
                        <label for="serviceDate" class="form-label">Service Date</label>
                        <asp:TextBox type="date" class="form-control" ID="serviceDate" placeholder="" name="serviceDate" runat="server" AutoCompleteType="Disabled" required="required" />
                        <span id="startDateSelected"></span>
                    </div>
                </div>

                <hr class="my-4" />

                <h4 class="mb-3">Service Details</h4>
                <div class="row g-3">

                    <!-- Service Type -->
                    <div class="col-sm-6">
                        <label for="serviceType" class="form-label">Service Type</label>
                        <asp:DropDownList class="form-control form-select" ID="serviceType" name="serviceType" runat="server">
                            <asp:ListItem hidden>Choose...</asp:ListItem>
                            <asp:ListItem>1st Service (Free)</asp:ListItem>
                            <asp:ListItem>2nd Service (Free)</asp:ListItem>
                            <asp:ListItem>3rd Service (Free)</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                        <div class="invalid-feedback">
                            Please select a valid service type.
                        </div>
                    </div>

                    <!-- Service Items Selector -->
                    <div class="col-sm-6">
                        <label for="serviceItems" class="form-label">Service Items</label>
                        <asp:DropDownList class="form-control form-select selectpicker" ID="serviceItems" name="serviceItems" runat="server" SelectionMode="Multiple" data-live-search="true">
                            <asp:ListItem>Engine Oil Change</asp:ListItem>
                            <asp:ListItem>Break Oil Change</asp:ListItem>
                            <asp:ListItem>Tight/Loose Chain</asp:ListItem>
                            <asp:ListItem>Battery Change</asp:ListItem>
                        </asp:DropDownList>
                        <div class="invalid-feedback">
                            Please select a valid service type.
                        </div>
                    </div>

                    <!-- Service Instructions Text Area -->
                    <div class="col-sm-12">
                        <label for="serviceIns" class="form-label">Service Instructions<span class="text-muted">(Optional)</span></label>
                        <asp:TextBox type="text" class="form-control" ID="serviceIns" TextMode="MultiLine" placeholder="" name="serviceIns" runat="server" AutoCompleteType="Disabled" />
                        <div class="invalid-feedback">
                            Please enter valid instructions.
                        </div>
                    </div>

                </div>
                <hr class="my-4" />

                <asp:Button type="submit" class="w-100 btn btn-primary btn-lg" runat="server" Text="Book Service" OnClick="bookClick" CausesValidation="False" />
                <asp:Button class="w-100 btn btn-outline-secondary btn-lg my-4" runat="server" Text="Go Back" OnClick="goBackClick" />

            </form>
            <!-- Booking Form -->

        </main>

        <!-- Footer -->
        <footer class="my-5 pt-5 text-muted text-center text-small">
            <p class="mb-1">&copy; 2021 sastra.edu</p>
        </footer>
        <!-- Footer -->

    </div>

    <!-- Booking Success Modal -->
    <div class="modal fade" id="bookingSuccess" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="container modal-content">
                <div class="modal-header">
                    <h4>Service Booked Successfully</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:Label class="form-check-label" runat="server">
                            <h5>Tracking Id</h5>
                            <input id="txtBookingId" class="form-control" type="text" value="Disabled readonly input" aria-label="Disabled input example" disabled readonly />
                            <br />
                            Please, Use this id to track serive status. thank you.
                        </asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Booking Success Modal -->

    <script src="../Scripts/jquery-3.6.0.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../Scripts/form-validation.js"></script>
    <script src="../Scripts/bootstrap-select.min.js"></script>
</body>
</html>
