<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="budpay.aspx.cs" Inherits="HotelWebApi_v2.verifications.budpay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Payment Veification System | Ibom Waterfall Resort & Suites</title>
    <meta content="width=device-width, initial-scale=1.0, shrink-to-fit=no"
          name="viewport" />
    <link rel="icon"
          href="../assets/img/kaiadmin/logo-icon.jpg" type="image/x-icon" />

        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"
              rel="stylesheet" />
        <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/css/bootstrap-datepicker.css"
              rel="stylesheet" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.js">
        </script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js">
        </script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/js/bootstrap-datepicker.js">
        </script>

    <!-- Fonts and icons -->
    <script src="../assets/js/plugin/webfont/webfont.min.js"></script>
    <script>
      WebFont.load({
        google: { families: ["Public Sans:300,400,500,600,700"] },
        custom: {
          families: [
            "Font Awesome 5 Solid",
            "Font Awesome 5 Regular",
            "Font Awesome 5 Brands",
            "simple-line-icons",
          ],
          urls: ["assets/css/fonts.min.css"],
        },
        active: function () {
          sessionStorage.fonts = true;
        },
      });

        sessionStorage.getItem("Reservation");
    </script>

    <!-- CSS Files -->
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/plugins.min.css" />
    <link rel="stylesheet" href="../assets/css/kaiadmin.min.css" />

    <!-- CSS Just for demo purpose, don't include it in your project -->
    <!--<link rel="stylesheet" href="assets/css/demo.css" />-->
    <script src="../assets/js/jquery-3.7.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="container">
            <div class="main-header">
                <div class="main-header-logo">
                    <!-- Logo Header -->
                    <div class="logo-header" data-background-color="dark">
                        <a href="index.html" class="logo">
                            <img src="../assets/img/kaiadmin/logo-icon.png"
                                 alt="navbar brand"
                                 class="navbar-brand"
                                 height="20" />
                        </a>
                        <div class="nav-toggle">
                            <button class="btn btn-toggle toggle-sidebar">
                                <i class="gg-menu-right"></i>
                            </button>
                            <button class="btn btn-toggle sidenav-toggler">
                                <i class="gg-menu-left"></i>
                            </button>
                        </div>
                        <button class="topbar-toggler more">
                            <i class="gg-more-vertical-alt"></i>
                        </button>
                    </div>
                    <!-- End Logo Header -->
                </div>
                    <!-- Navbar Header -->
                    <nav class="navbar navbar-header navbar-header-transparent navbar-expand-lg border-bottom">
                        <div class="container">
                            <!--<nav class="navbar navbar-header-left navbar-expand-lg navbar-form nav-search p-0 d-none d-lg-flex">
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <button type="submit" class="btn btn-search pe-1">
                                            <i class="fa fa-search search-icon"></i>
                                        </button>
                                    </div>
                                    <input type="text"
                                           placeholder="Search ..."
                                           class="form-control" />
                                </div>
                            </nav>-->

                            <ul class="navbar-nav topbar-nav ms-md-auto align-items-center">

                                <li class="nav-item topbar-user dropdown hidden-caret">
                                    <a class="dropdown-toggle profile-pic"
                                       data-bs-toggle="dropdown"
                                       href="#"
                                       aria-expanded="false">
                                        <div class="avatar-sm">
                                            <img src="../assets/img/kaiadmin/logo-icon.png"
                                                 alt="..."
                                                 class="avatar-img rounded-circle" />
                                        </div>
                                        <span class="profile-username">
                                            <span class="op-7"></span>
                                            <span class="fw-bold">Wish you pleasurable stay with us!</span>
                                        </span>
                                    </a>
                                    <%--<ul class="dropdown-menu dropdown-user animated fadeIn">
                                        <div class="dropdown-user-scroll scrollbar-outer">
                                            <li>
                                                <div class="user-box">
                                                    <div class="avatar-lg">
                                                        <img src="assets/img/profile.jpg"
                                                             alt="image profile"
                                                             class="avatar-img rounded" />
                                                    </div>
                                                    <div class="u-text">
                                                        <h4>Ibom Waterfall</h4>
                                                        <p class="text-muted">hello@example.com</p>
                                                        <a href="profile.html"
                                                           class="btn btn-xs btn-secondary btn-sm">View Profile</a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="dropdown-divider"></div>
                                                <a class="dropdown-item" href="#">My Profile</a>
                                                <a class="dropdown-item" href="#">My Balance</a>
                                                <a class="dropdown-item" href="#">Inbox</a>
                                                <div class="dropdown-divider"></div>
                                                <a class="dropdown-item" href="#">Account Setting</a>
                                                <div class="dropdown-divider"></div>
                                                <a class="dropdown-item" href="#">Logout</a>
                                            </li>
                                        </div>
                                    </ul>--%>
                                </li>
                            </ul>
                        </div>
                    </nav>
                    <!-- End Navbar -->
            </div>

        <div class="row" style="padding-top:100px;">
            <div class="col-md-3"></div>
            <div class="col-md-6 col-stats">
                <div class="card mt-5">
                        <div class="card-head m-3">
                            <div class="form-inline d-flex flex-row align-items-start justify-content-start">
                        <p class="text-success h6 text-md text-left">Reservation was successful</p>
                                <%--<p class="font-weight-bold text-right ml-auto">Ref. No.</p>--%>
                                <p id="pRefNo" runat="server" class="font-weight-bold text-right ml-auto">Ref. No.: ref-8746537439-e</p>
                            </div>
                        </div>
                    <div class="card-body text-center m-3">

                        <div class="numbers">
                            <div class="form-inline mb-2">
                                <label class="ml-2 font-weight-bold">Full Name:</label>
                                <label class="ml-2">Olamide Ojo M.</label>
                            </div>
                            <div class="form-inline mb-2">
                                <label class="ml-2 font-weight-bold">Phone:</label>
                                <label class="ml-2">07032499237</label>
                            </div>
                            <div class="form-inline mb-2">
                                <label class="ml-2 font-weight-bold">Email:</label>
                                <label class="ml-2">info@9appsoft.com</label>
                            </div>
                            <div class="form-inline mb-2">
                                <label class="ml-2 font-weight-bold">Check out</label>
                                <label class="ml-2">22/11/2024</label>
                            </div>
                            <div class="form-inline mb-2">
                                <label class="ml-2 font-weight-bold">Check out</label>
                                <label class="ml-2">22/11/2024</label>
                            </div>
                            <div class="form-inline mb-2">
                                <label class="ml-2 font-weight-bold">Booking Date:</label>
                                <label class="ml-2">K-874t53743</label>
                            </div>
                        </div>
                        <%--<div class="progress progress-sm mt-2 mb-3">
                            <div class="progress-bar bg-warning w-75"
                                role="progressbar"
                                aria-valuenow="75"
                                aria-valuemin="0"
                                aria-valuemax="100">
                            </div>
                        </div>--%>
                    </div>
                    <div class="card-footer form-inline">
                            <h5 class="card-title ml-2 text-left">&#8358;0.00</h5>
                        <a href="https://ibomwaterfallsuites.com/" class="btn btn-info btn-sm text-right ml-auto">Return to home </a>
                    </div>
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>
        </div>

    </form>

    
    <!--   Core JS Files   -->
    <script src="../assets/js/core/jquery-3.7.1.min.js"></script>
    <script src="../assets/js/core/popper.min.js"></script>
    <script src="../assets/js/core/bootstrap.min.js"></script>

    <!-- jQuery Scrollbar -->
    <script src="../assets/js/plugin/jquery-scrollbar/jquery.scrollbar.min.js"></script>

    <!-- Chart JS -->
    <script src="../assets/js/plugin/chart.js/chart.min.js"></script>

    <!-- jQuery Sparkline -->
    <script src="../assets/js/plugin/jquery.sparkline/jquery.sparkline.min.js"></script>

    <!-- Chart Circle -->
    <script src="../assets/js/plugin/chart-circle/circles.min.js"></script>

    <!-- Datatables -->
    <script src="../assets/js/plugin/datatables/datatables.min.js"></script>

    <!-- Bootstrap Notify -->
    <script src="../assets/js/plugin/bootstrap-notify/bootstrap-notify.min.js"></script>

    <!-- jQuery Vector Maps -->
    <script src="../assets/js/plugin/jsvectormap/jsvectormap.min.js"></script>
    <script src="../assets/js/plugin/jsvectormap/world.js"></script>

    <!-- Sweet Alert -->
    <script src="../assets/js/plugin/sweetalert/sweetalert.min.js"></script>

    <!-- Kaiadmin JS -->
    <script src="../assets/js/kaiadmin.min.js"></script>

    <!-- Kaiadmin DEMO methods, don't include it in your project! -->
    <!--<script src="assets/js/setting-demo.js"></script>-->
    <!--<script src="assets/js/demo.js"></script>-->
    <script>
      $("#lineChart").sparkline([102, 109, 120, 99, 110, 105, 115], {
        type: "line",
        height: "70",
        width: "100%",
        lineWidth: "2",
        lineColor: "#177dff",
        fillColor: "rgba(23, 125, 255, 0.14)",
      });

      $("#lineChart2").sparkline([99, 125, 122, 105, 110, 124, 115], {
        type: "line",
        height: "70",
        width: "100%",
        lineWidth: "2",
        lineColor: "#f3545d",
        fillColor: "rgba(243, 84, 93, .14)",
      });

      $("#lineChart3").sparkline([105, 103, 123, 100, 95, 105, 115], {
        type: "line",
        height: "70",
        width: "100%",
        lineWidth: "2",
        lineColor: "#ffa534",
        fillColor: "rgba(255, 165, 52, .14)",
      });
    </script>
    <!--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.13.2/jquery-ui.min.js"></script>
    <script>
    $(function(){
        $("#date").datepicker();
        $("#format").on("change", function(){
            $("#fromDate").datepicker("option", "dateFormat", $(this).val());
        });
    });
    </script>-->
</body>
</html>
