<?php
if (isset($_SESSION['bank_authentication']))
{
    if ($_SESSION['bank_authentication'] == 1)
        header ("location: /intranet/bank/account");
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="launcherPanel">
        <meta name="author" content="Leo HUBERT">

        <link rel="shortcut icon" href="/assets/images/favicon_1.ico">

        <title><?php echo $site;?> panel</title>

        <link href="/assets/plugins/jquery-circliful/css/jquery.circliful.css" rel="stylesheet" type="text/css" />
        <link href="/assets/plugins/sweetalert/dist/sweetalert.css" rel="stylesheet" type="text/css">

        <link href="/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="/assets/css/core.css" rel="stylesheet" type="text/css" />
        <link href="/assets/css/components.css" rel="stylesheet" type="text/css" />
        <link href="/assets/css/icons.css" rel="stylesheet" type="text/css" />
        <link href="/assets/css/pages.css" rel="stylesheet" type="text/css" />
        <link href="/assets/css/menu.css" rel="stylesheet" type="text/css" />
        <link href="/assets/css/responsive.css" rel="stylesheet" type="text/css" />

        <!-- DataTables -->
        <link href="/assets/plugins/datatables/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />
        <link href="/assets/plugins/datatables/buttons.bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="/assets/plugins/datatables/fixedHeader.bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="/assets/plugins/datatables/responsive.bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="/assets/plugins/datatables/scroller.bootstrap.min.css" rel="stylesheet" type="text/css" />

        <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->

        <script src="/assets/js/modernizr.min.js"></script>

    </head>

    <div class="wrapper">
        <div class="container">

            <!-- Page-Title -->
            <div class="col-xs-12" style="height:120px;"></div>
            <div class="row">
                <div class="col-lg-4">
                </div>

                <div class="col-lg-4">
                    <div class="card-box">
                        <div class="widget-chart text-center">
                            <h1 id="account_password" class="null">PLEASE TYPE YOUR PASSWORD</h1>
                        </div>
                    </div>

                </div>

                <div class="col-lg-4">
                </div>

            </div>
            <div class="col-xs-12" style="height:20px;"></div>
            <div class="row">
                <div class="col-lg-4">
                </div>

                <div class="col-lg-4">
                    <div class="card-box">
                        <div class="col-xs-12" style="height:10px;"></div>
                        <div class="widget-chart text-center">
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" onclick="addNumber(1)">1</button>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" onclick="addNumber(2)">2</button>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" onclick="addNumber(3)">3</button>
                                <span style="padding-left:20px"></span>
                                <a href="/intranet"><button type="button" class="btn btn-danger waves-effect" style="font-size : 20px; width: 30%; height: 100px;">CANCEL</button></a>
                                <br>
                                <div class="col-xs-12" style="height:4px;"></div>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" onclick="addNumber(4)">4</button>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" onclick="addNumber(5)">5</button>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" onclick="addNumber(6)">6</button>
                                <span style="padding-left:20px"></span>
                                <button type="button" class="btn btn-warning waves-effect" style="font-size : 20px; width: 30%; height: 100px;" onclick="clearPassword()">CLEAR</button>
                                <br>
                                <div class="col-xs-12" style="height:4px;"></div>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" onclick="addNumber(7)">7</button>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" onclick="addNumber(8)">8</button>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" onclick="addNumber(9)">9</button>
                                <span style="padding-left:20px"></span>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 30%; height: 100px;" disabled></button>
                                <br>
                                <div class="col-xs-12" style="height:4px;"></div>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" disabled></button>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" onclick="addNumber(0)">0</button>
                                <button type="button" class="btn btn-default waves-effect" style="font-size : 20px; width: 20%; height: 100px;" disabled></button>
                                <span style="padding-left:20px"></span>
                                <button type="button" class="btn btn-success waves-effect" style="font-size : 20px; width: 30%; height: 100px;" onclick="validPassword()">ENTER</button>
                        </div>
                    </div>

                </div>

                <div class="col-lg-4">
                </div>

            </div>

        </div> <!-- end container -->
    </div>

    <script type="application/javascript">
        function clearPassword() {
            var password_label = document.getElementById("account_password");

            password_label.className = "null";
            password_label.textContent = "PLEASE TYPE YOUR PASSWORD";
        }
        function addNumber(number) {
            var password_label = document.getElementById("account_password");
            if (password_label.className == "null")
            {
                password_label.textContent = "";
                password_label.className = "";
            }
            if (password_label.className.length == 4)
                return;
            password_label.className += number;
            password_label.textContent += "*";
        }
        function validPassword() {
            var password_label = document.getElementById("account_password");
            if (password_label.className == "null" || password_label.className.length < 4)
                return;
            window.location = "/intranet/bank/account";
        }
    </script>

    <body>

        <!-- Navigation Bar-->
        <?php include "pages/intranet/jointures/header_intranet.php";?>
        <!-- End Navigation Bar-->

        <!-- jQuery  -->
        <script src="/assets/js/jquery.min.js"></script>
        <script src="/assets/js/bootstrap.min.js"></script>
        <script src="/assets/js/detect.js"></script>
        <script src="/assets/js/fastclick.js"></script>
        <script src="/assets/js/jquery.blockUI.js"></script>
        <script src="/assets/js/waves.js"></script>
        <script src="/assets/js/wow.min.js"></script>
        <script src="/assets/js/jquery.nicescroll.js"></script>
        <script src="/assets/js/jquery.scrollTo.min.js"></script>

        <!-- Counter Up  -->
        <script src="/assets/plugins/waypoints/lib/jquery.waypoints.js"></script>
        <script src="/assets/plugins/counterup/jquery.counterup.min.js"></script>

        <!-- circliful Chart -->
        <script src="/assets/plugins/jquery-circliful/js/jquery.circliful.min.js"></script>
        <script src="/assets/plugins/jquery-sparkline/jquery.sparkline.min.js"></script>

        <!-- skycons -->
        <script src="/assets/plugins/skyicons/skycons.min.js" type="text/javascript"></script>

        <!-- Sweet-Alert  -->
        <script src="/assets/plugins/sweetalert/dist/sweetalert.min.js"></script>
        <script src="/assets/pages/jquery.sweet-alert.init.js"></script>

        <!-- Page js  -->
        <script src="/assets/pages/jquery.dashboard.js"></script>

        <!-- Custom main Js -->
        <script src="/assets/js/jquery.core.js"></script>
        <script src="/assets/js/jquery.app.js"></script>

        <!-- Datatables-->
        <script src="/assets/plugins/datatables/jquery.dataTables.min.js"></script>
        <script src="/assets/plugins/datatables/dataTables.bootstrap.js"></script>
        <script src="/assets/plugins/datatables/dataTables.buttons.min.js"></script>
        <script src="/assets/plugins/datatables/buttons.bootstrap.min.js"></script>
        <script src="/assets/plugins/datatables/jszip.min.js"></script>
        <script src="/assets/plugins/datatables/pdfmake.min.js"></script>
        <script src="/assets/plugins/datatables/vfs_fonts.js"></script>
        <script src="/assets/plugins/datatables/buttons.html5.min.js"></script>
        <script src="/assets/plugins/datatables/buttons.print.min.js"></script>
        <script src="/assets/plugins/datatables/dataTables.fixedHeader.min.js"></script>
        <script src="/assets/plugins/datatables/dataTables.keyTable.min.js"></script>
        <script src="/assets/plugins/datatables/dataTables.responsive.min.js"></script>
        <script src="/assets/plugins/datatables/responsive.bootstrap.min.js"></script>
        <script src="/assets/plugins/datatables/dataTables.scroller.min.js"></script>


        <!-- Datatable init js -->
        <script src="/assets/pages/datatables.init.js"></script>


    <!-- Notifications -->
        <script src="/assets/plugins/notifyjs/dist/notify.min.js"></script>
        <script src="/assets/plugins/notifications/notify-metro.js"></script>

    </body>
</html>