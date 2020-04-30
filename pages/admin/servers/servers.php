
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="launcherPanel">
        <meta name="author" content="Leo HUBERT">

        <link rel="shortcut icon" href="assets/images/favicon_1.ico">

        <title><?php echo $site;?> panel</title>

        <link href="assets/plugins/jquery-circliful/css/jquery.circliful.css" rel="stylesheet" type="text/css" />

        <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/menu.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />

        <link href="assets/plugins/sweetalert/dist/sweetalert.css" rel="stylesheet" type="text/css">
        <link href="assets/plugins/jquery-circliful/css/jquery.circliful.css" rel="stylesheet" type="text/css" />

        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>

        <script src="assets/js/modernizr.min.js"></script>
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



    <body onload="loadServers()">

        <!-- Navigation Bar-->
        <?php include "jointures/header_admin.php"?>
        <!-- End Navigation Bar-->

        <div class="wrapper">
            <div class="container">

                <!-- Page-Title -->
                <div class="row">
                    <div class="col-sm-12">
                        <h4 class="page-title"><?php echo L::server_servers_title; ?></h4>
                    </div>
                </div>

                <div class="col-sm-8">
                    <div class="card-box table-responsive">

                        <h4 class="m-t-0 header-title"><b><?php echo L::server_servers_subtitle; ?></b></h4>
                        <p class="text-muted font-13 m-b-30">
                        <?php echo L::server_servers_subtitlecontent; ?>
                        </p>

                        <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                            <thead>
                            <tr>
                                <th><?php echo L::server_servers_row_id; ?></th>
                                <th><?php echo L::server_servers_row_name; ?></th>
                                <th><?php echo L::server_servers_row_ip; ?></th>
                                <th><?php echo L::server_servers_row_game; ?></th>
                                <th><?php echo L::server_servers_row_actions; ?></th>
                            </tr>
                            </thead>
                            <tbody id="servers">

                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-sm-1"></div>
                <div class="col-sm-4 col-lg-4">
                    <form onsubmit="return addServer()">
                    <div class="panel panel-color panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title"><?php echo L::server_servers_createserver; ?></h3>
                        </div>

                            <div class="panel-body">
                                <p>
                                <div id="banned_pop"></div>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <input type="text" class="form-control"  placeholder="Server name" id="server_name" required>
                                    </div>
                                    <br>
                                    <br>
                                    <div class="col-sm-12">
                                        <input type="text" class="form-control"  placeholder="ModPack Name (exemple = @YourServerName)" id="server_modpack_name" required>
                                    </div>
                                    <br>
                                    <br>
                                    <div class="col-sm-12">
                                        <input type="text" class="form-control"  placeholder="Server IP" id="server_ip" required>
                                    </div>
                                    <br>
                                    <br>
                                    <div class="col-sm-12">
                                        <input type="number" class="form-control"  placeholder="Server Port" id="server_port" required>
                                    </div>
                                    <br>
                                    <br>
                                    <div class="col-sm-12">
                                        <input type="text" class="form-control"  placeholder="Server Game" id="server_game" value="arma3" disabled>
                                    </div>
                                    <br>
                                    <br>
                                    <div class="col-sm-12">
                                        <input type="number" min="0" max="100" class="form-control"  placeholder="Server Rank (0 = first, 1 = second etc...)" id="server_rank" required>
                                    </div>
                                </div>
                            </div>
                        <div class="panel-footer">
                            <button type="submit" class="btn btn-success btn-custom waves-effect w-md waves-light m-b-5"><?php echo L::submit; ?></button>
                        </div>
                    </div>
                    </form>
                </div>
                <?php include "jointures/footer.php";?>
            </div>
        </div>


        <script type="text/javascript">
            function loadServers() {
                $.get(
                    '/api/server/list',
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
                                var table = document.getElementById('servers');
                                var row = table.insertRow(table.rows.length);
                                row.id = i;
                                var id = row.insertCell(0);
                                var name = row.insertCell(1);
                                var ip = row.insertCell(2);
                                var game = row.insertCell(3);
                                var action = row.insertCell(4);
                                id.innerHTML = i;
                                name.innerHTML = obj.servers[i].name;
                                game.innerHTML = obj.servers[i].game;
                                ip.innerHTML = obj.servers[i].ip + ":" +obj.servers[i].port;
                                action.innerHTML = '<a href="/servers/view/'+ obj.servers[i].id +'"> <button class="btn btn-icon waves-effect waves-light btn-primary m-b-5"> <i class="fa fa-eye"></i> </button></a>  <button class="btn btn-icon waves-effect waves-light btn-danger m-b-5" onclick="removeServer('+ i +','+ obj.servers[i].id + ')"> <i class="fa fa-remove"></i></button>';
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
            }
            function addServer() {
                    $.post(
                        '/api/server/create',
                        {
                            token : "<?php echo $_SESSION['token'];?>",
                            name : $('#server_name').val(),
                            modpack_name : $('#server_modpack_name').val(),
                            ip : $('#server_ip').val(),
                            port : $('#server_port').val(),
                            game : $('#server_game').val(),
                            rank : $('#server_rank').val()
                        },

                        function(data){
                            var obj = JSON.parse(data);

                            if (obj.status == 42)
                            {
                                $.Notification.notify('success','top right','Created !', obj.message);
                                document.getElementById("servers").innerHTML = "";
                                window.location = "servers/view/" + obj.server_id;
                                loadServers();
                            }
                            else if (obj.status == 41)
                                window.location="/logout";
                            else
                                swal("Error...", obj.message, "error");
                        },

                        'text'
                    );
                return false;
            }
            function removeServer(table_id, server_id) {
                var remove_folder = 1;
                swal({
                    title: "Are you sure?",
                    text: "You will not be able to recover this server!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes, delete it!",
                    cancelButtonText: "No, cancel plx!",
                    closeOnConfirm: false,
                    showLoaderOnConfirm: true,
                    closeOnCancel: false
                }, function(isConfirm){
                    if (isConfirm) {
                        setTimeout(function(){
                            $.post(
                                '/api/server/remove',
                                {
                                    token : "<?php echo $_SESSION['token'];?>",
                                    id : server_id,
                                    remove_folder : remove_folder
                                },

                                function(data){
                                    var obj = JSON.parse(data);

                                    if (obj.status == 42)
                                    {
                                        swal({
                                            title: "Deleted !",
                                            text: obj.message,
                                            type: "success",
                                            timer: 500
                                        });
                                        document.getElementById(table_id).remove();
                                    }
                                    else if (obj.status == 41)
                                        window.location="/logout";
                                    else
                                        swal("Error...", obj.message, "error");
                                },

                                'text'
                            );
                        }, 1300);
                    } else {
                        swal("Cancelled", "Deletion successfully canceled", "error");
                    }
                });
            }

        </script>

        <!-- circliful Chart -->
        <script src="assets/plugins/jquery-circliful/js/jquery.circliful.min.js"></script>
        <script src="assets/plugins/jquery-sparkline/jquery.sparkline.min.js"></script>

        <!-- skycons -->
        <script src="assets/plugins/skyicons/skycons.min.js" type="text/javascript"></script>

        <!-- Notifications -->
        <script src="assets/plugins/notifyjs/dist/notify.min.js"></script>
        <script src="assets/plugins/notifications/notify-metro.js"></script>

        <!-- Custom main Js -->
        <script src="assets/js/jquery.core.js"></script>
        <script src="assets/js/jquery.app.js"></script>

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

        <!-- Sweet-Alert  -->
        <script src="assets/plugins/sweetalert/dist/sweetalert.min.js"></script>
        <script src="assets/pages/jquery.sweet-alert.init.js"></script>

    </body>
</html>