
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


<body onload="loadSupport()">

<!-- Navigation Bar-->
<?php include "jointures/header_admin.php"?>


<!-- =======================
     ===== START PAGE ======
     ======================= -->

<div class="wrapper">
    <div class="container">

        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">All admins users</h4>
            </div>
        </div>
        <!-- Page-Title -->

        <script>
            function loadSupport()
            {
                $.post(
                    '/api/users/admin/admins',
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
                                var table = document.getElementById('users');
                                var row = table.insertRow(table.rows.length);
                                row.id = i;
                                var id = row.insertCell(0);
                                var username = row.insertCell(1);
                                var email = row.insertCell(2);
                                var banned = row.insertCell(3);
                                var level = row.insertCell(4);
                                var last_ip = row.insertCell(5);
                                var picture = row.insertCell(6);
                                var action = row.insertCell(7);
                                id.innerHTML = i;
                                username.innerHTML = obj.users[i].username;
                                email.innerHTML = obj.users[i].email;
                                banned.innerHTML = obj.users[i].banned;
                                level.innerHTML = obj.users[i].level;
                                last_ip.innerHTML = obj.users[i].last_ip;
                                picture.innerHTML = obj.users[i].picture;
                                action.innerHTML = '<a href="/users/view/'+ obj.users[i].id+'"> <button class="btn btn-icon waves-effect waves-light btn-primary m-b-5"> <i class="fa fa-eye"></i> </button></a>';
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

            function remove_support(table_id, support_id)
            {
                swal({
                    title: "Are you sure?",
                    text: "You will not be able to recover this imaginary file!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes, delete it!",
                    cancelButtonText: "No, cancel plx!",
                    closeOnConfirm: false,
                    closeOnCancel: false
                }, function(isConfirm){
                    if (isConfirm) {
                        $.post(
                            '/api/support/admin/remove',
                            {
                                token : "<?php echo $_SESSION['token'];?>",
                                id : support_id
                            },

                            function(data){
                                var obj = JSON.parse(data);

                                if (obj.status == 42)
                                {
                                    swal("Deleted!", obj.message , "success");
                                    document.getElementById(table_id).remove();
                                }
                                else if (obj.status == 41)
                                    window.location="/logout";
                                else
                                    swal("Error...", obj.message, "error");
                            },

                            'text'
                        );
                    } else {
                        swal("Cancelled", "Deletion successfully canceled", "error");
                    }
                });
            }

            function assign_support(support_id, button_id) {
                $.post(
                    '/api/support/admin/assign',
                    {
                        token : "<?php echo $_SESSION['token'];?>",
                        id : support_id
                    },

                    function(data){
                        var obj = JSON.parse(data);

                        if (obj.status == 42)
                        {
                            $.Notification.notify('success','top right','Assigned !', obj.message);
                            document.getElementById(button_id).remove();
                            document.getElementById('support').innerHTML = "";
                            loadSupport();
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

                        <h4 class="m-t-0 header-title"><b>All users</b></h4>
                        <p class="text-muted font-13 m-b-30">
                            Table with all users.
                        </p>

                        <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                            <thead>
                            <tr>
                                <th>#</th>
                                <th>Username</th>
                                <th>Email</th>
                                <th>Banned</th>
                                <th>Level</th>
                                <th>Last ip</th>
                                <th>Picture</th>
                                <th>Actions</th>
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