<?php
if (isset($_SESSION['bank_authentication']))
{
    if ($_SESSION['bank_authentication'] == 0)
        header ("location: /intranet/bank/authentication");
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

    <script type="application/javascript">
        function loadAll()
        {
            $.post(
                '/api/server/client/players/get',
                {
                    token : "<?php echo $_SESSION['token']; ?>",
                    id : 1
                },

                function(data){
                    var obj = JSON.parse(data);

                    if (obj.status == 42) {
                        document.getElementById("bank").textContent = obj.bank;
                        document.getElementById("cash").textContent = obj.cash;
                    }
                    else if (obj.status == 40)
                        document.getElementById("bank").textContent = "Not found";
                    else if (obj.status == 41)
                        window.location = "/logout";
                },

                'text'
            );
        }
    </script>

    <body onload="loadAll()">

    <!-- Navigation Bar-->
    <?php include "pages/intranet/jointures/header_intranet.php";?>
    <!-- End Navigation Bar-->

    <div class="wrapper">
        <div class="container">
            <div class="row">
                <div class="col-sm-6 col-lg-3">
                    <div class="widget-simple text-center card-box">
                        <h3 class="text-primary counter">$ <span id="bank"></span></h3>
                        <p class="text-muted font-500">Total Bank</p>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-3">
                    <div class="widget-simple text-center card-box">
                        <h3 class="text-primary counter">$ <span id="cash"></span></h3>
                        <p class="text-muted font-500">Cash</p>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-3">
                    <div class="widget-simple text-center card-box">
                        <h3 class="text-pink">$ <span class="counter">12480</span></h3>
                        <p class="text-muted font-500">Total Earning</p>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-3">
                    <div class="widget-simple text-center card-box">
                        <h3 class="text-muted counter">62</h3>
                        <p class="text-muted font-500">Pending Orders</p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <div class="card-box">
                        <h4 class="header-title m-t-0 m-b-30">Total Account</h4>

                        <div class="widget-chart text-center">
                            <div id="sparkline1"><canvas height="165" width="535" style="display: inline-block; width: 535px; height: 165px; vertical-align: top;"></canvas></div>
                            <ul class="list-inline m-t-15">
                                <li>
                                    <h5 class="text-muted m-t-20">Target</h5>
                                    <h4 class="m-b-0">$1000</h4>
                                </li>
                                <li>
                                    <h5 class="text-muted m-t-20">Last week</h5>
                                    <h4 class="m-b-0">$523</h4>
                                </li>
                                <li>
                                    <h5 class="text-muted m-t-20">Last Month</h5>
                                    <h4 class="m-b-0">$965</h4>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card-box">
                        <h4 class="m-t-0 m-b-20 header-title"><b>Account history</b></h4>
                        <div tabindex="5001" style="overflow: hidden;" class="inbox-widget nicescroll mx-box">
                            <a href="#">
                                <div class="inbox-item">
                                    <p class="inbox-item-author">Chadengle</p>
                                    <p class="inbox-item-text">Hey! there I'm available...</p>
                                    <p class="inbox-item-date">13:40 PM</p>
                                </div>
                            </a>
                            <a href="#">
                                <div class="inbox-item">
                                    <p class="inbox-item-author">Tomaslau</p>
                                    <p class="inbox-item-text">I've finished it! See you so...</p>
                                    <p class="inbox-item-date">13:34 PM</p>
                                </div>
                            </a>
                            <a href="#">
                                 <div class="inbox-item">
                                    <p class="inbox-item-author">Stillnotdavid</p>
                                    <p class="inbox-item-text">This theme is awesome!</p>
                                    <p class="inbox-item-date">13:17 PM</p>
                                </div>
                            </a>
                            <a href="#">
                                <div class="inbox-item">
                                    <p class="inbox-item-author">Kurafire</p>
                                    <p class="inbox-item-text">Nice to meet you</p>
                                    <p class="inbox-item-date">12:20 PM</p>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card-box">
                        <h4 class="header-title m-t-0 m-b-30">Total Owned</h4>
                        <div class="widget-chart text-center">
                            <div id="sparkline3"><canvas height="165" width="165" style="display: inline-block; width: 165px; height: 165px; vertical-align: top;"></canvas></div>
                            <ul class="list-inline m-t-15">
                                <li>
                                    <h5 class="text-muted m-t-20">Target</h5>
                                    <h4 class="m-b-0">$1000</h4>
                                </li>
                                <li>
                                    <h5 class="text-muted m-t-20">Last week</h5>
                                    <h4 class="m-b-0">$523</h4>
                                </li>
                                <li>
                                    <h5 class="text-muted m-t-20">Last Month</h5>
                                    <h4 class="m-b-0">$965</h4>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <div class="card-box">
                        <h4 class="m-t-0 m-b-20 header-title"><b>Transfer to</b></h4>
                        <div class="todoapp">
                            <div class="row"></div>
                            <form name="todo-form" id="todo-form" role="form" class="m-t-20">
                                <div class="row">
                                    <div class="col-sm-0 todo-inputbar">
                                        <input id="todo-input-text" name="todo-input-text" class="form-control" placeholder="Who" type="text">
                                    </div>
                                    <br></br>
                                    <div class="col-sm-0 todo-inputbar">
                                        <input id="todo-input-text" name="todo-input-text" class="form-control" placeholder="Sum" type="text">
                                    </div>
                                    <br></br>
                                    <div class="col-sm-0 todo-inputbar">
                                        <input id="todo-input-text" name="todo-input-text" class="form-control" placeholder="Short commentary" type="text">
                                    </div>
                                    <br></br>
                                    <div class="col-sm-0 todo-send">
                                        <button class="btn-primary btn-md btn-block btn waves-effect waves-light" type="button" id="todo-btn-submit">Add</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card-box">
                        <h4 class="m-t-0 m-b-20 header-title"><b>Transfer</b></h4>
                        <div class="todoapp">
                            <div class="row"></div>
                            <form name="todo-form" id="todo-form" role="form" class="m-t-20">
                                <div class="row">
                                    <div class="col-sm-9 todo-inputbar">
                                        <input id="todo-input-text" name="todo-input-text" class="form-control" placeholder="Add new todo" type="text">
                                    </div>
                                    <div class="col-sm-3 todo-send">
                                        <button class="btn-primary btn-md btn-block btn waves-effect waves-light" type="button" id="todo-btn-submit">Add</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card-box">
                        <h4 class="m-t-0 m-b-20 header-title"><b>Ask for a transfer</b></h4>
                        <div class="todoapp">
                            <div class="row"></div>
                            <form name="todo-form" id="todo-form" role="form" class="m-t-20">
                                <div class="row">
                                    <div class="col-sm-0 todo-inputbar">
                                        <input id="todo-input-text" name="todo-input-text" class="form-control" placeholder="Who" type="text">
                                    </div>
                                    <br></br>
                                    <div class="col-sm-0 todo-inputbar">
                                        <input id="todo-input-text" name="todo-input-text" class="form-control" placeholder="Sum" type="text">
                                    </div>
                                    <br></br>
                                    <div class="col-sm-0 todo-inputbar">
                                        <input id="todo-input-text" name="todo-input-text" class="form-control" placeholder="Short commentary" type="text">
                                    </div>
                                    <br></br>
                                    <div class="col-sm-0 todo-send">
                                        <button class="btn-primary btn-md btn-block btn waves-effect waves-light" type="button" id="todo-btn-submit">Add</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div> <!-- end row -->
        </div> <!-- end container -->
    </div>

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

        <!-- Notifications -->
        <script src="/assets/plugins/notifyjs/dist/notify.min.js"></script>
        <script src="/assets/plugins/notifications/notify-metro.js"></script>

    </body>
</html>