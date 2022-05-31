<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DealerPage.aspx.cs" Inherits="ASMT.UI.DealerPage" %>

<!DOCTYPE html>
<html lang="en">
<head>

    <!-- Meta Data -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="">
    <meta name="author" content="Aishvarya">
    <!-- Meta Data -->

    <title>ASMT - Auto Service & Management Tool</title>

    <!--External Resources-->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/sidebars.css" rel="stylesheet" />
    <link href="../Content/modals.css" rel="stylesheet" />

    <%--<script src="../Scripts/umd/popper.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>--%>
    <script src="../Scripts/jquery-3.6.0.slim.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <script type="text/javascript">
        function openSuccessModal() {
            $('#bookingSuccess').modal('show');
        }
    </script>
    <script>
        $('#myModal').on('shown.bs.modal', function () {
            $('#myInput').trigger('focus')
        })
    </script>

    <script type="text/javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
</head>
<body>
    <form runat="server">

        <!-- SVGs -->
        <svg xmlns="http://www.w3.org/2000/svg" style="display: none;">
            <symbol id="home" viewbox="0 0 16 16">
                <path d="M8.354 1.146a.5.5 0 0 0-.708 0l-6 6A.5.5 0 0 0 1.5 7.5v7a.5.5 0 0 0 .5.5h4.5a.5.5 0 0 0 .5-.5v-4h2v4a.5.5 0 0 0 .5.5H14a.5.5 0 0 0 .5-.5v-7a.5.5 0 0 0-.146-.354L13 5.793V2.5a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1.293L8.354 1.146zM2.5 14V7.707l5.5-5.5 5.5 5.5V14H10v-4a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5v4H2.5z" />
            </symbol>
            <symbol id="speedometer2" viewbox="0 0 16 16">
                <path d="M8 4a.5.5 0 0 1 .5.5V6a.5.5 0 0 1-1 0V4.5A.5.5 0 0 1 8 4zM3.732 5.732a.5.5 0 0 1 .707 0l.915.914a.5.5 0 1 1-.708.708l-.914-.915a.5.5 0 0 1 0-.707zM2 10a.5.5 0 0 1 .5-.5h1.586a.5.5 0 0 1 0 1H2.5A.5.5 0 0 1 2 10zm9.5 0a.5.5 0 0 1 .5-.5h1.5a.5.5 0 0 1 0 1H12a.5.5 0 0 1-.5-.5zm.754-4.246a.389.389 0 0 0-.527-.02L7.547 9.31a.91.91 0 1 0 1.302 1.258l3.434-4.297a.389.389 0 0 0-.029-.518z" />
                <path fill-rule="evenodd" d="M0 10a8 8 0 1 1 15.547 2.661c-.442 1.253-1.845 1.602-2.932 1.25C11.309 13.488 9.475 13 8 13c-1.474 0-3.31.488-4.615.911-1.087.352-2.49.003-2.932-1.25A7.988 7.988 0 0 1 0 10zm8-7a7 7 0 0 0-6.603 9.329c.203.575.923.876 1.68.63C4.397 12.533 6.358 12 8 12s3.604.532 4.923.96c.757.245 1.477-.056 1.68-.631A7 7 0 0 0 8 3z" />
            </symbol>
            <symbol id="table" viewbox="0 0 16 16">
                <path d="M0 2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V2zm15 2h-4v3h4V4zm0 4h-4v3h4V8zm0 4h-4v3h3a1 1 0 0 0 1-1v-2zm-5 3v-3H6v3h4zm-5 0v-3H1v2a1 1 0 0 0 1 1h3zm-4-4h4V8H1v3zm0-4h4V4H1v3zm5-3v3h4V4H6zm4 4H6v3h4V8z" />
            </symbol>
            <symbol id="box" viewbox="0 0 16 16">
                <path d="M8.186 1.113a.5.5 0 0 0-.372 0L1.846 3.5l2.404.961L10.404 2l-2.218-.887zm3.564 1.426L5.596 5 8 5.961 14.154 3.5l-2.404-.961zm3.25 1.7-6.5 2.6v7.922l6.5-2.6V4.24zM7.5 14.762V6.838L1 4.239v7.923l6.5 2.6zM7.443.184a1.5 1.5 0 0 1 1.114 0l7.129 2.852A.5.5 0 0 1 16 3.5v8.662a1 1 0 0 1-.629.928l-7.185 2.874a.5.5 0 0 1-.372 0L.63 13.09a1 1 0 0 1-.63-.928V3.5a.5.5 0 0 1 .314-.464L7.443.184z" />
            </symbol>
            <symbol id="people-circle" viewbox="0 0 16 16">
                <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z" />
                <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z" />
            </symbol>
            <symbol id="cash" viewbox="0 0 16 16">
                <path fill-rule="evenodd" d="M11 15a4 4 0 1 0 0-8 4 4 0 0 0 0 8zm5-4a5 5 0 1 1-10 0 5 5 0 0 1 10 0z" />
                <path d="M9.438 11.944c.047.596.518 1.06 1.363 1.116v.44h.375v-.443c.875-.061 1.386-.529 1.386-1.207 0-.618-.39-.936-1.09-1.1l-.296-.07v-1.2c.376.043.614.248.671.532h.658c-.047-.575-.54-1.024-1.329-1.073V8.5h-.375v.45c-.747.073-1.255.522-1.255 1.158 0 .562.378.92 1.007 1.066l.248.061v1.272c-.384-.058-.639-.27-.696-.563h-.668zm1.36-1.354c-.369-.085-.569-.26-.569-.522 0-.294.216-.514.572-.578v1.1h-.003zm.432.746c.449.104.655.272.655.569 0 .339-.257.571-.709.614v-1.195l.054.012z" />
                <path d="M1 0a1 1 0 0 0-1 1v8a1 1 0 0 0 1 1h4.083c.058-.344.145-.678.258-1H3a2 2 0 0 0-2-2V3a2 2 0 0 0 2-2h10a2 2 0 0 0 2 2v3.528c.38.34.717.728 1 1.154V1a1 1 0 0 0-1-1H1z" />
                <path d="M9.998 5.083 10 5a2 2 0 1 0-3.132 1.65 5.982 5.982 0 0 1 3.13-1.567z" />
            </symbol>
        </svg>
        <!-- SVGs -->

        <!-- Side Bar -->
        <main class="d-flex flex-nowrap">

            <div class="d-flex flex-column flex-shrink-0 p-3 bg-light min-vh-100" style="width: 280px;">
                <a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none">
                    <svg class="bi me-2" width="40" height="32">
                        <use xlink:href="#bootstrap" />
                    </svg>
                    <span class="fs-4">ASMT</span>
                </a>
                <hr />
                <ul class="nav nav-pills flex-column mb-auto">
                    <li class="nav-item">
                        <a href="#" class="nav-link link-dark" aria-current="page">
                            <svg class="bi me-2" width="16" height="16">
                                <use xlink:href="#home" />
                            </svg>
                            Home
                        </a>
                    </li>
                    <li>
                        <a href="#" class="nav-link link-dark">
                            <svg class="bi me-2" width="16" height="16">
                                <use xlink:href="#speedometer2" />
                            </svg>
                            Dashboard
                        </a>
                    </li>
                    <li>
                        <a href="#" class="nav-link active">
                            <svg class="bi me-2" width="16" height="16">
                                <use xlink:href="#table" />
                            </svg>
                            Service Orders
                        </a>
                    </li>
                    <li>
                        <a href="#" class="nav-link link-dark">
                            <svg class="bi me-2" width="16" height="16">
                                <use xlink:href="#box" />
                            </svg>
                            Inventory
                        </a>
                    </li>
                    <li>
                        <a href="#" class="nav-link link-dark">
                            <svg class="bi me-2" width="16" height="16">
                                <use xlink:href="#people-circle" />
                            </svg>
                            Customers
                        </a>
                    </li>
                    <li>
                        <a href="#" class="nav-link link-dark">
                            <svg class="bi me-2" width="16" height="16">
                                <use xlink:href="#cash" />
                            </svg>
                            Accounts
                        </a>
                    </li>
                </ul>
                <hr />
                <div class="dropdown">
                    <a href="#" class="d-flex align-items-center link-dark text-decoration-none dropdown-toggle" id="dropdownUser2" data-bs-toggle="dropdown" aria-expanded="false">
                        <img src="https://github.com/mdo.png" alt="" width="32" height="32" class="rounded-circle me-2" />
                        <strong>Administrator</strong>
                    </a>
                    <ul class="dropdown-menu text-small shadow" aria-labelledby="dropdownUser2">
                        <li><a class="dropdown-item" href="#">Settings</a></li>
                        <li><a class="dropdown-item" href="#">Profile</a></li>
                        <li>
                            <hr class="dropdown-divider" />
                        </li>
                        <li><a class="dropdown-item" href="IndexPage.aspx">Sign out</a></li>
                    </ul>
                </div>
            </div>
            <!-- Side Bar -->

            <div class="vr"></div>

            <!-- List Group -->
            <div class="d-flex flex-column flex-fill">

                <div class="d-flex align-items-center flex-shrink-0 p-3 link-dark text-decoration-none border-bottom">
                    <span class="fs-5 fw-semibold">Service Orders</span>
                </div>
                <div class="list-group list-group-flush border-bottom scrollarea">
                    <asp:Panel ID="contentArea" runat="server">
                    </asp:Panel>
                </div>
            </div>

        </main>

        <!-- FullScreen Service Details Modal -->
        <div class="modal fade" id="serviceDetailsModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-fullscreen">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title mx-3" id="exampleModalLabel">Service Details</h2>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>

                    <div class="modal-body">
                        <div class="container">

                            <h1 runat="server" id="modalHeader"></h1>
                            <p runat="server" class="lead" id="modalDescription">Basic grid layouts to get you familiar with building within the Bootstrap grid system.</p>
                            <br />

                            <div class="row g-3">
                                <div class="col-sm-6">
                                    <%--<h3>Name: 
                                    <small class="text-muted">Karthik Kamalanathan</small>
                                    </h3>--%>
                                    <h4>Tasks</h4>
                                </div>

                                <div class="col-sm-6">
                                    <h4>Status</h4>
                                </div>
                                <asp:Panel runat="server" ID="modalTasks">
                                </asp:Panel>
                                <div class="col-sm-6">
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-check form-switch form-control-lg">
                                        <input class="form-check-input" type="checkbox">
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-check form-switch form-control-lg">
                                        <input class="form-check-input" type="checkbox">
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-check form-switch form-control-lg">
                                        <input class="form-check-input" type="checkbox">
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-lg btn-secondary" data-bs-dismiss="modal">Close</button>
                        <asp:Button type="submit" class="mb-2 btn btn-lg btn-primary" runat="server" Text="Save Changes" OnClick="saveChanges" />
                    </div>

                </div>
            </div>
        </div>
        <!-- FullScreen Service Details Modal -->
    </form>
</body>
</html>
