
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="launcherPanel">
    <meta name="author" content="Leo HUBERT">
    <meta name="token" content="<?php echo $_SESSION['token'];?>">

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
    <!-- jQuery  -->
        <script src="/assets/js/jquery.min.js"></script>
        <script src="/assets/js/bootstrap.min.js"></script>
        <script src="/assets/js/waiting.js"></script>
        <script src="/assets/js/detect.js"></script>
        <script src="/assets/js/fastclick.js"></script>
        <script src="/assets/js/jquery.blockUI.js"></script>
        <script src="/assets/js/wow.min.js"></script>
        <script src="/assets/js/jquery.nicescroll.js"></script>
        <script src="/assets/js/jquery.scrollTo.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.5/jszip.js"></script>

</head>


<body onload="loadSupport()">

<!-- Navigation Bar-->
<?php include "jointures/header_admin.php"?>

<div class="wrapper">
    <div class="container">

        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title"><?php echo L::adminuser_bannedp_title; ?></h4>
            </div>
        </div>
        <!-- Page-Title -->
        <div class="row">
            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">

                        <h4 class="m-t-0 header-title"><b><?php echo L::adminuser_bannedp_title; ?></b></h4>
                        <p class="text-muted font-13 m-b-30">
                        <?php echo L::adminuser_bannedp_subtitle; ?>
                        </p>

                        <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                            <thead>
                            <tr>
                                <th><?php echo L::adminuser_rows_id; ?></th>
                                <th><?php echo L::adminuser_rows_username; ?></th>
                                <th><?php echo L::adminuser_rows_mail; ?></th>
                                <th><?php echo L::adminuser_rows_banned; ?></th>
                                <th><?php echo L::adminuser_rows_level; ?></th>
                                <th><?php echo L::adminuser_rows_lastip; ?></th>
                                <th><?php echo L::adminuser_rows_steamuuid; ?></th>
                                <th><?php echo L::adminuser_rows_actions; ?></th>
                            </tr>
                            </thead>
                            <tbody id="users">

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

        </div>
        <!-- end row -->

        <?php include "jointures/footer.php";?>

        </div> <!-- end container -->
    </div>
    <!-- End wrapper -->

    <!-- circliful Chart -->
    <script src="/assets/plugins/jquery-circliful/js/jquery.circliful.min.js"></script>
    <script src="/assets/plugins/jquery-sparkline/jquery.sparkline.min.js"></script>

    <!-- skycons -->
    <script src="/assets/plugins/skyicons/skycons.min.js" type="text/javascript"></script>

    <!-- Sweet-Alert  -->
    <script src="/assets/plugins/sweetalert/dist/sweetalert.min.js"></script>
    <script src="/assets/pages/jquery.sweet-alert.init.js"></script>

    <!-- Custom main Js -->
    <script src="/assets/js/jquery.core.js"></script>
    <script src="/assets/js/jquery.app.js"></script>

    <!-- Datatables-->
    <script src="/assets/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/assets/plugins/datatables/dataTables.bootstrap.js"></script>
    <script src="/assets/plugins/datatables/dataTables.buttons.min.js"></script>
    <script src="/assets/plugins/datatables/buttons.bootstrap.min.js"></script>
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

    <!-- Load Pages Script -->
    <script src="/assets/js/pages/admin/users_banned.js"></script>


    </body>
</html>