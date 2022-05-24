<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillingPage.aspx.cs" Inherits="ASMT.UI.BillingPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="Aishvarya" />
    <meta name="generator" content="Hugo 0.88.1" />

    <title>ASMT - Auto Service & Management Tool</title>

    <!--External Resources-->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

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

    <link href="../Content/form-validation.css" rel="stylesheet" />

</head>
<body class="bg-light">
    <div class="container">

        <main>
            <div class="py-5 text-center">
                <h2>Checkout Form</h2>
                <p class="lead">Submit the Below Form & Payments Details to Checkout</p>
            </div>


            <div class="row g-5">

                <!-- Orders Panel -->
                <div class="col-md-5 col-lg-4 order-md-last">
                    <h4 class="d-flex justify-content-between align-items-center mb-3">
                        <span class="text-primary">Your cart</span>
                        <span class="badge bg-primary rounded-pill">3</span>
                    </h4>
                    <ul class="list-group mb-3">
                        <li class="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 class="my-0">Product name</h6>
                                <small class="text-muted">Brief description</small>
                            </div>
                            <span class="text-muted">₹12</span>
                        </li>
                        <li class="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 class="my-0">Second product</h6>
                                <small class="text-muted">Brief description</small>
                            </div>
                            <span class="text-muted">₹8</span>
                        </li>
                        <li class="list-group-item d-flex justify-content-between lh-sm">
                            <div>
                                <h6 class="my-0">Third item</h6>
                                <small class="text-muted">Brief description</small>
                            </div>
                            <span class="text-muted">₹5</span>
                        </li>
                        <li class="list-group-item d-flex justify-content-between">
                            <span>Total (USD)</span>
                            <strong>₹20</strong>
                        </li>
                    </ul>
                </div>
                <!-- Orders Panel -->

                <!-- Billing Form -->
                <div class="col-md-7 col-lg-8">
                    <h4 class="mb-3">Billing address</h4>
                    <form class="needs-validation" id="billingForm" runat="server" novalidate>
                        <div class="row g-3">
                            <div class="col-sm-6">
                                <label for="firstName" class="form-label">First name</label>
                                <asp:TextBox type="text" class="form-control" ID="firstName" placeholder="" name="firstName" runat="server" AutoCompleteType="Disabled" required="required" />
                                <div class="invalid-feedback">
                                    Valid first name is required.
                                </div>
                            </div>

                            <div class="col-sm-6">
                                <label for="lastName" class="form-label">Last name</label>
                                <asp:TextBox type="text" class="form-control" ID="lastName" placeholder="" name="lastName" runat="server" AutoCompleteType="Disabled" required="required" />
                                <div class="invalid-feedback">
                                    Valid last name is required.
                                </div>
                            </div>

                            <div class="col-12">
                                <label for="email" class="form-label">Email <span class="text-muted">(Optional)</span></label>
                                <asp:TextBox type="email" class="form-control" ID="email" placeholder="" name="email" runat="server" AutoCompleteType="Disabled" />
                                <div class="invalid-feedback">
                                    Please enter a valid email address for shipping updates.
                                </div>
                            </div>

                            <div class="col-12">
                                <label for="address" class="form-label">Address</label>
                                <asp:TextBox type="text" class="form-control" ID="address" placeholder="1234 Main St" name="address" runat="server" AutoCompleteType="Disabled" required="required" />
                                <div class="invalid-feedback">
                                    Please enter your shipping address.
                                </div>
                            </div>

                            <div class="col-12">
                                <label for="address2" class="form-label">Address 2 <span class="text-muted">(Optional)</span></label>
                                <asp:TextBox type="text" class="form-control" ID="address2" placeholder="Apartment or Place" name="address2" runat="server" AutoCompleteType="Disabled" />
                            </div>

                            <div class="col-md-5">
                                <label for="country" class="form-label">Country</label>
                                <asp:DropDownList class="form-control form-select" ID="country" name="countryName" runat="server">
                                    <asp:ListItem hidden>Choose...</asp:ListItem>
                                    <asp:ListItem>India</asp:ListItem>
                                </asp:DropDownList>
                                <div class="invalid-feedback">
                                    Please select a valid country.
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label for="state" class="form-label">State</label>
                                <asp:DropDownList class="form-control form-select" ID="state" name="stateName" runat="server">
                                    <asp:ListItem hidden>Choose...</asp:ListItem>
                                    <asp:ListItem>Tamilnadu</asp:ListItem>
                                    <asp:ListItem>Karnataka</asp:ListItem>
                                    <asp:ListItem>Kearla</asp:ListItem>
                                    <asp:ListItem>Telungana</asp:ListItem>
                                    <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                    <asp:ListItem>Pudhucherry</asp:ListItem>
                                </asp:DropDownList>
                                <div class="invalid-feedback">
                                    Please provide a valid state.
                                </div>
                            </div>

                            <div class="col-md-3">
                                <label for="zip" class="form-label">Pin code</label>
                                <asp:TextBox type="text" class="form-control" ID="zip" placeholder="" name="zip" runat="server" AutoCompleteType="Disabled" required="required" />
                                <div class="invalid-feedback">
                                    Pin code required.
                                </div>
                            </div>
                        </div>

                        <hr class="my-4">

                        <div class="form-group form-check">
                            <%--<input type="checkbox" class="form-check-input" id="same-address">--%>
                            <asp:CheckBox class="form-check-input" ID="sameaddress" type="checkbox" name="sameaddress" runat="server" />
                            <label class="form-check-label" for="sameaddress">Shipping address is the same as my billing address</label>
                        </div>

                        <div class="form-group form-check">
                            <%--<input type="checkbox" class="form-check-input" id="save-info">--%>
                            <asp:CheckBox class="form-check-input" ID="saveinfo" type="checkbox" name="saveinfo" runat="server" />
                            <label class="form-check-label" for="saveinfo">Save this information for next time</label>
                        </div>

                        <hr class="my-4">

                        <h4 class="mb-3">Payment</h4>

                        <div class="my-3">
                            <div class="form-check">
                                <input id="credit" name="paymentMethod" type="radio" class="form-check-input" checked required>
                                <label class="form-check-label" for="credit">Credit card</label>
                            </div>
                            <div class="form-check">
                                <input id="debit" name="paymentMethod" type="radio" class="form-check-input" required>
                                <label class="form-check-label" for="debit">Debit card</label>
                            </div>
                        </div>

                        <div class="row gy-3">
                            <div class="col-md-6">
                                <label for="ccname" class="form-label">Name on card</label>
                                <asp:TextBox type="text" class="form-control" ID="ccname" placeholder="" name="ccname" runat="server" AutoCompleteType="Disabled" required="required" />
                                <small class="text-muted">Full name as displayed on card</small>
                                <div class="invalid-feedback">
                                    Name on card is required
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label for="ccnumber" class="form-label">Card number</label>
                                <asp:TextBox type="text" class="form-control" ID="ccnumber" placeholder="" name="ccnumber" runat="server" AutoCompleteType="Disabled" required="required" />
                                <div class="invalid-feedback">
                                    Credit card number is required
                                </div>
                            </div>

                            <div class="col-md-3">
                                <label for="ccexpiration" class="form-label">Expiration</label>
                                <asp:TextBox type="text" class="form-control" ID="ccexpiration" placeholder="" name="ccexpiration" runat="server" AutoCompleteType="Disabled" required="required" />
                                <div class="invalid-feedback">
                                    Expiration date required
                                </div>
                            </div>

                            <div class="col-md-3">
                                <label for="cccvv" class="form-label">CVV</label>
                                <asp:TextBox type="text" class="form-control" ID="cccvv" placeholder="" name="cccvv" runat="server" AutoCompleteType="Disabled" required="required" />
                                <div class="invalid-feedback">
                                    Security code required
                                </div>
                            </div>
                        </div>

                        <hr class="my-4">

                        <asp:Button type="submit" class="w-100 btn btn-primary btn-lg" runat="server" Text="Continue to Checkout" OnClick="checkoutClick" />

                        <asp:Button type="submit" class="w-100 btn btn-outline-secondary btn-lg my-4" Text="Go Back" runat="server" OnClick="goBackClick" />
                    </form>
                </div>
            </div>

        </main>

        <footer class="my-5 pt-5 text-muted text-center text-small">
            <p class="mb-1">&copy; 2021 sastra.edu</p>
        </footer>

    </div>

    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../Scripts/form-validation.js"></script>

</body>
</html>
