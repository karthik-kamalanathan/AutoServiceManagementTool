<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="ASMT.UI.ErrorPage" %>

<!DOCTYPE html>
<html lang="en">
<head>

    <!-- Meta Data -->
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="">
    <meta name="author" content="Aishvarya">
    <!-- Meta Data -->

    <title>Error</title>

    <!-- Internal Resources -->
    <link type="text/css" rel="stylesheet" href="../Content/Error/style.css" />
    <script type="text/javascript" async="" src="../Content/Error/analytics.js.download" nonce="c7346b97-7260-4d19-bd36-3d901d2bad85"></script>
    <script defer="" referrerpolicy="origin" src="../Content/Error/s.js.download"></script>
    <!-- Internal Resources -->

    <!-- JavaScript Code to Show Error -->
    <script nonce="c7346b97-7260-4d19-bd36-3d901d2bad85">
        (function (w, d) {
            !(function (a, e, t, r) {
                (a.zarazData = a.zarazData || {}),
                    (a.zarazData.executed = []),
                    (a.zaraz = { deferred: [] }),
                    (a.zaraz.q = []),
                    (a.zaraz._f = function (e) {
                        return function () {
                            var t = Array.prototype.slice.call(arguments);
                            a.zaraz.q.push({ m: e, a: t });
                        };
                    });
                for (const e of ["track", "set", "ecommerce", "debug"])
                    a.zaraz[e] = a.zaraz._f(e);
                a.addEventListener("DOMContentLoaded", () => {
                    var t = e.getElementsByTagName(r)[0],
                        z = e.createElement(r),
                        n = e.getElementsByTagName("title")[0];
                    for (
                        n && (a.zarazData.t = e.getElementsByTagName("title")[0].text),
                        a.zarazData.w = a.screen.width,
                        a.zarazData.h = a.screen.height,
                        a.zarazData.j = a.innerHeight,
                        a.zarazData.e = a.innerWidth,
                        a.zarazData.l = a.location.href,
                        a.zarazData.r = e.referrer,
                        a.zarazData.k = a.screen.colorDepth,
                        a.zarazData.n = e.characterSet,
                        a.zarazData.o = new Date().getTimezoneOffset(),
                        a.zarazData.q = [];
                        a.zaraz.q.length;

                    ) {
                        const e = a.zaraz.q.shift();
                        a.zarazData.q.push(e);
                    }
                    (z.defer = !0),
                        (z.referrerPolicy = "origin"),
                        (z.src =
                            "/cdn-cgi/zaraz/s.js?z=" +
                            btoa(encodeURIComponent(JSON.stringify(a.zarazData)))),
                        t.parentNode.insertBefore(z, t);
                });
            })(w, d, 0, "script");
        })(window, document);
    </script>
    <!-- JavaScript Code to Show Error -->

    <!-- JavaScript Code to Disable Back Button -->
    <%--<script type="text/javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>--%>
    <!-- JavaScript Code to Disable Back Button -->

    <!-- CSS Styles For Texts in Error Page -->
    <style type="text/css">
        @font-face {
            font-weight: 400;
            font-style: normal;
            font-family: "Circular-Loom";
            src: url("../Content/Error/CircularXXWeb-Book-cd7d2bcec649b1243839a15d5eb8f0a3.woff2") format("woff2");
        }

        @font-face {
            font-weight: 500;
            font-style: normal;
            font-family: "Circular-Loom";
            src: url("../Content/Error/CircularXXWeb-Medium-d74eac43c78bd5852478998ce63dceb3.woff2") format("woff2");
        }

        @font-face {
            font-weight: 700;
            font-style: normal;
            font-family: "Circular-Loom";
            src: url("../Content/Error/CircularXXWeb-Bold-83b8ceaf77f49c7cffa44107561909e4.woff2") format("woff2");
        }

        @font-face {
            font-weight: 900;
            font-style: normal;
            font-family: "Circular-Loom";
            src: url("../Content/Error/CircularXXWeb-Black-bf067ecb8aa777ceb6df7d72226febca.woff2") format("woff2");
        }
    </style>
    <!-- CSS Styles For Texts in Error Page -->

</head>
<body>

    <!-- Error Display -->
    <div id="notfound">
        <div class="notfound">
            <div class="notfound-404">
                <h3>Oops! Internal Server Error</h3>
                <h1><span>5</span><span>0</span><span>0</span></h1>
            </div>
            <h2>we are sorry, we couldn't load the page you requested</h2>
        </div>
    </div>
    <!-- Error Display -->

    <script async="" src="./404 HTML Template by Colorlib_files/js"></script>

    <!-- JavaScript Code to Display Error -->
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() {
            dataLayer.push(arguments);
        }
        gtag("js", new Date());

        gtag("config", "UA-23581568-13");
    </script>
    <!-- JavaScript Code to Display Error -->

    <!-- Internal Resources -->
    <script
        defer=""
        src="../Content/Error/v652eace1692a40cfa3763df669d7439c1639079717194"
        integrity="sha512-Gi7xpJR8tSkrpF7aordPZQlW2DLtzUlZcumS8dMQjwDHEnw9I7ZLyiOj/6tZStRBGtGgN6ceN6cMH8z7etPGlw=="
        data-cf-beacon='{"rayId":"708ffe43884c06b0","token":"cd0b4b3a733644fc843ef0b185f98241","version":"2021.12.0","si":100}'
        crossorigin="anonymous">
    </script>
    <!-- Internal Resources -->

</body>
</html>