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
    <link href="../Content/modals.css" rel="stylesheet" />

    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../Scripts/jquery-3.6.0.slim.js"></script>
    <script src="../Scripts/umd/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <!--External Resources-->

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
        jQuery.noConflict();
        function openSuccessModal() {
            $('#bookingSuccess').modal('show');
        }
    </script>
    <script>
        $('#myModal').on('shown.bs.modal', function () {
            $('#myInput').trigger('focus')
        })
    </script>
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
            <form id="bookingForm" runat="server" novalidate>
                <div class="row g-3">

                    <!-- Customer First Name -->
                    <div class="col-sm-6">
                        <label for="firstName" class="form-label">First Name</label>
                        <asp:TextBox type="text" class="form-control" ID="firstName" placeholder="" name="firstName" runat="server" AutoCompleteType="Disabled" required="required" />
                    </div>

                    <!-- Customer Last Name -->
                    <div class="col-sm-6">
                        <label for="lastName" class="form-label">Last Name</label>
                        <asp:TextBox type="text" class="form-control" ID="lastName" placeholder="" name="lastName" runat="server" AutoCompleteType="Disabled" required="required" />
                    </div>

                    <!-- Customer Phone Number -->
                    <div class="col-sm-6">
                        <label for="lastName" class="form-label">Phone Number</label>
                        <asp:TextBox type="text" class="form-control" ID="phonenum" placeholder="" name="phonenum" runat="server" AutoCompleteType="Disabled" required="required" />
                    </div>

                    <!-- Customer Email -->
                    <div class="col-sm-6">
                        <label for="email" class="form-label">Email <span class="text-muted">(Optional)</span></label>
                        <asp:TextBox type="email" class="form-control" ID="email" placeholder="" name="email" runat="server" AutoCompleteType="Disabled" />
                    </div>

                    <!-- Vehicle Model -->
                    <div class="col-sm-6">
                        <label for="vehicleModel" class="form-label">Vehicle Model</label>
                        <asp:TextBox type="text" class="form-control" ID="vehicleModel" placeholder="" name="vehicleModel" runat="server" AutoCompleteType="Disabled" required="required" />
                    </div>

                    <!-- Vehicle Number -->
                    <div class="col-sm-6">
                        <label for="vehicleNum" class="form-label">Vehicle Number</label>
                        <asp:TextBox type="text" class="form-control" ID="vehicleNum" placeholder="" name="vehicleNum" runat="server" AutoCompleteType="Disabled" required="required" />
                    </div>

                    <!-- Location -->
                    <div class="col-sm-6">
                        <label for="location" class="form-label">Location</label>
                        <asp:DropDownList class="form-control form-select" ID="location" name="location" runat="server" required="required">
                            <asp:ListItem hidden>Choose...</asp:ListItem>
                            <asp:ListItem>Kumbakonam</asp:ListItem>
                            <asp:ListItem>Trichy</asp:ListItem>
                            <asp:ListItem>Thanjavur</asp:ListItem>
                        </asp:DropDownList>
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
                        <asp:DropDownList class="form-control form-select" ID="serviceType" name="serviceType" runat="server" required="required">
                            <asp:ListItem hidden>Choose...</asp:ListItem>
                            <asp:ListItem>1st Service (Free)</asp:ListItem>
                            <asp:ListItem>2nd Service (Free)</asp:ListItem>
                            <asp:ListItem>3rd Service (Free)</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Service Items Selector -->
                    <div class="col-sm-6">
                        <%--<label for="serviceItems" class="form-label">Service Items</label>--%>
                        <div class="dropdown">
                            <a class="w-100 btn btn-light dropdown-toggle btn-outline-secondary" href="#" role="button" id="tasksMenuLink" data-bs-toggle="dropdown" aria-expanded="false">Service Items</a>
                            <ul class="dropdown-menu" aria-labelledby="tasksMenuLink">
                                <li class="dropdown-item">
                                    <asp:CheckBox ID="engineOil" class="form-check-input me-1" runat="server" value="" aria-label="..." />
                                    Engine Oil Change
                                </li>
                                <li class="dropdown-item">
                                    <asp:CheckBox ID="breakOil" class="form-check-input me-1" runat="server" value="" aria-label="..." />
                                    Break Oil Change
                                </li>
                                <li class="dropdown-item">
                                    <asp:CheckBox ID="suspension" class="form-check-input me-1" runat="server" value="" aria-label="..." />
                                    Adjust Suspension
                                </li>
                                <li class="dropdown-item">
                                    <asp:CheckBox ID="tyreChange" class="form-check-input me-1" runat="server" value="" aria-label="..." />
                                    Change Tyre
                                </li>
                                <li class="dropdown-item">
                                    <asp:CheckBox ID="chainTight" class="form-check-input me-1" runat="server" value="" aria-label="..." />
                                    Chain Tightening
                                </li>
                            </ul>
                        </div>
                    </div>

                    <!-- Service Instructions Text Area -->
                    <div class="col-sm-12">
                        <label for="serviceIns" class="form-label">Service Instructions<span class="text-muted">(Optional)</span></label>
                        <asp:TextBox type="text" class="form-control" ID="serviceIns" TextMode="MultiLine" placeholder="" name="serviceIns" runat="server" AutoCompleteType="Disabled" />
                    </div>

                </div>
                <hr class="my-4" />

                <asp:Button type="submit" class="w-100 btn btn-primary btn-lg" runat="server" Text="Book Service" OnClick="bookClick" />
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
    <div class="modal fade" tabindex="-1" role="dialog" id="bookingSuccess" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content shadow">
                <div class="modal-header p-5 pb-4 border-bottom-0">
                    <h4>Service Booked Successfully</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onclick="location.href='IndexPage.aspx'"></button>
                </div>
                <div class="modal-body p-5 pt-0">
                    <h5>Tracking Id</h5>
                    <input id="txtBookingId" class="form-control" type="text" value="Disabled readonly input" aria-label="Disabled input example" disabled readonly />
                    <br />
                    <p class="lead">Please, Use this id to track serive status. thank you.</p>
                </div>
            </div>
        </div>
    </div>
    <!-- Booking Success Modal -->
</body>
</html>
