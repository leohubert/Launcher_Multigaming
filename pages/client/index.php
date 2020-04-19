
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="launcherPanel">
        <meta name="author" content="Leo HUBERT">

        <link rel="shortcut icon" href="/assets/images/favicon_1.ico">

        <title><?php echo $config->get("site_name");?> panel</title>

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


    <body onload="loadAll()">

    <!-- Navigation Bar-->
    <?php include "jointures/header_client.php"?>
    <!-- End Navigation Bar-->

    <script>
        function loadAll()
        {
            $.get(
                '/api/stats/dashboard',
                {
                },

                function(data){
                    var obj = JSON.parse(data);
                    if (obj.status == 42)
                    {
                        document.getElementById("total_7days").textContent = obj.total_7days;
                        document.getElementById("total_new7days").textContent = obj.total_new7days;
                        document.getElementById("total_users").textContent = obj.nbUsers;
                        document.getElementById("total_admins").textContent = obj.nbAdmins;
                    }
                },

                'text'
            );
            loadSupport();
        }
    </script>
        <!-- End Navigation Bar-->


        <!-- =======================
             ===== START PAGE ======
             ======================= -->

        <div class="wrapper">
            <div class="container">

                <!-- Page-Title -->
                <div class="row">
                    <div class="col-sm-12">
                        <h4 class="page-title">Welcome !</h4>
                    </div>
                </div>
                <!-- Page-Title -->

                <div class="row">
                    <div class="col-sm-6 col-lg-3">
                        <div class="card-box widget-icon">
                            <div>
                                <i class="md md-account-child text-primary"></i>
                                <div class="wid-icon-info">
                                    <p class="text-muted m-b-5 font-13 text-uppercase">Total connections during 7 days</p>
                                    <h4 class="m-t-0 m-b-5 counter"><div id="total_7days">.</div></h4>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-3">
                        <div class="card-box widget-icon">
                            <div>
                                <i class="md md-account-child text-primary"></i>
                                <div class="wid-icon-info">
                                    <p class="text-muted m-b-5 font-13 text-uppercase">New User during 7 days</p>
                                    <h4 class="m-t-0 m-b-5 counter"><div id="total_new7days">.</div></h4>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-3">
                        <div class="card-box widget-icon">
                            <div>
                                <i class="md md-account-child text-primary"></i>
                                <div class="wid-icon-info">
                                    <p class="text-muted m-b-5 font-13 text-uppercase">Total users</p>
                                    <h4 class="m-t-0 m-b-5 counter"><div id="total_users">.</div></h4>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-3">
                        <div class="card-box widget-icon">
                            <div>
                                <i class="md md-account-child text-primary"></i>
                                <div class="wid-icon-info">
                                    <p class="text-muted m-b-5 font-13 text-uppercase">Total admins</p>
                                    <h4 class="m-t-0 m-b-5 counter"><div id="total_admins">.</div></h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <center><iframe src="https://www.instant-gaming.com/affgames/igr2812450/250x250" scrolling="no" frameborder="0" style="border-radius: 10px; overflow:hidden; width:250px; height:250px;" allowTransparency="true"></iframe></center>

                <script>
                    function loadSupport()
                    {
                        $.post(
                            '/api/support/client/list',
                            {
                                token : "<?php echo $_SESSION['token'];?>",
                                show : 1000
                            },

                            function(data){
                                var obj = JSON.parse(data);
                                if (obj.status == 42)
                                {
                                    var total = obj.total;
                                    var i = 0;

                                    while (total > 0)
                                    {
                                        var table = document.getElementById('support');
                                        var row = table.insertRow(table.rows.length);
                                        row.id = i;
                                        var id = row.insertCell(0);
                                        var create_by = row.insertCell(1);
                                        var title = row.insertCell(2);
                                        var create_at = row.insertCell(3);
                                        var update_at = row.insertCell(4);
                                        var status = row.insertCell(5);
                                        var assign_to = row.insertCell(6);
                                        var action = row.insertCell(7);
                                        id.innerHTML = i;
                                        create_by.innerHTML = obj.support[i].started_by;
                                        title.innerHTML = obj.support[i].title;
                                        create_at.innerHTML = obj.support[i].started_at;
                                        update_at.innerHTML = obj.support[i].updated_at
                                        action.innerHTML =  '<a href="/support/view/' + obj.support[i].support_id +'"><button class="btn btn-icon waves-effect waves-light btn-info m-b-5"> <i class="fa fa-edit"></i></button></a> ';
                                        if (obj.support[i].status == "0")
                                            assign_to.innerHTML = "No one";
                                        else
                                            assign_to.innerHTML = obj.support[i].assign_to;
                                        switch (obj.support[i].status)
                                        {
                                            case "0":
                                                status.innerHTML = '<span class="label label-primary">No assigned</span>';
                                                break;
                                            case "1":
                                                status.innerHTML = '<span class="label label-info">Assigned</span>';
                                                break;
                                            case "2":
                                                status.innerHTML = '<span class="label label-purple">In progress</span>';
                                                break;
                                            case "3":
                                                status.innerHTML = '<span class="label label-success">Done</span>';
                                                break;
                                            case "4":
                                                status.innerHTML = '<span class="label label-danger">Closed</span>';
                                                break;
                                        }
                                        i++;
                                        total--;
                                    }

                                    $(document).ready(function() {
                                        $('#datatable').dataTable();
                                        $('#datatable-keytable').DataTable( { keys: true } );
                                        $('#datatable-responsive').DataTable();
                                        var table = $('#datatable-fixed-header').DataTable( { fixedHeader: true } );
                                    } );
                                    TableManageButtons.init();
                                }
                                else if (obj.status == 44 || obj.status == 41)
                                    window.location="/logout";
                                else
                                    $.Notification.notify('error','bottom center','Internal Error', "Error: " + obj.status + " | " + obj.message);
                            },

                            'text'
                        );
                        $.get(
                            '/api/server/status/get',{},
                            function(data){
                                var obj = JSON.parse(data);

                                if (obj.status == 42)
                                {
                                    if (obj.online == true)
                                    {
                                        document.getElementById("server_status_color").className = "text-success";
                                        document.getElementById("server_status").textContent = "ONLINE";
                                        document.getElementById("server_ip").textContent = obj.server_ip + ":" + obj.server_port;
                                        document.getElementById("server_players").textContent = obj.server_onlineplayers + " / " + obj.server_maxplayers;
                                        document.getElementById("server_map").textContent = obj.server_map;
                                    }
                                    else
                                    {
                                        document.getElementById("server_status_color").className = "text-danger";
                                        document.getElementById("server_status").textContent = "OFFLINE";
                                        document.getElementById("server_ip").textContent = "No found";
                                        document.getElementById("server_players").textContent = "No found";
                                        document.getElementById("server_map").textContent = "No found";
                                    }
                                }
                                else if (obj.status == 41)
                                    window.location="/logout";
                                else
                                    swal("Error...", obj.message, "error");
                            },

                            'text'
                        );
                    }
                    
                </script>

                <div class="row">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box table-responsive">

                                <h4 class="m-t-0 header-title"><b>Support</b></h4>
                                <p class="text-muted font-13 m-b-30">
                                    All support request.
                                </p>

                                <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                                    <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Create by</th>
                                        <th>Title</th>
                                        <th>Start Date</th>
                                        <th>Last Date</th>
                                        <th>Status</th>
                                        <th>Assigned to</th>
                                        <th>Actions</th>
                                    </tr>
                                    </thead>
                                    <tbody id="support">

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