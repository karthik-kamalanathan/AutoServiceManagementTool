<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrackingPage.aspx.cs" Inherits="ASMT.UI.TrackingPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASMT - Auto Service & Management Tool</title>

    <!--External Resources-->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/heroes.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/umd/popper.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../Scripts/jquery-3.6.0.slim.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

</head>
<body>
    <main>
        <form runat="server">
            <div class="container-fluid py-4 bg-light">
                <div class="p-5 pb-1 mb-1 rounded-3">
                    <div class="container-fluid py-3">
                        <div class="py-1 text-center">
                            <h2>Tracking Service Status</h2>
                            <p class="lead">Track vehicle service status, progress & updates using booking id. Also you can pay & checkout online here, if service is complete</p>
                            <br />
                            <div class="d-md-flex justify-content-sm-center mb-3">
                                <asp:TextBox type="text" class="form-control form-control-lg" ID="trackingId" placeholder="Tracking Id" runat="server"></asp:TextBox>
                            </div>
                            <div class="d-md-flex justify-content-sm-center mb-2">
                                <asp:Button class="btn btn-primary btn-lg" type="submit" Text="Track Service" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="px-5 rounded-3">
                <div class="container-fluid py-2">
                    <div class="py-1 text-left">
                        <h2>Tracking Details</h2>
                        <p class="lead">Please find your service status details below.</p>
                        <br />
                        <div class="progress">
                            <div class="progress-bar" role="progressbar" style="width: 25%;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">25%</div>
                        </div>
                        <div class="d-flex">
                            <div class="flex-column flex-fill p-5 m-3">
                                <p class="lead">Left</p>
                            </div>
                            <div class="flex-column flex-fill p-5 m-3">
                                <p class="lead">Right</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </main>
</body>
</html>
