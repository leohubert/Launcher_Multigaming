
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

        <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->

        <script src="assets/js/modernizr.min.js"></script>

    </head>



    <body onload="loadNews()">

        <!-- Navigation Bar-->
        <?php include "jointures/header_admin.php"?>
        <!-- End Navigation Bar-->

        <div class="wrapper">
            <div class="container">

                <!-- Page-Title -->
                <div class="row">
                    <div class="col-sm-12">
                        <h4 class="page-title">News control</h4>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="card-box table-responsive">

                        <h4 class="m-t-0 header-title"><b>All news</b></h4>
                        <p class="text-muted font-13 m-b-30">
                            Table of all news.
                        </p>

                        <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                            <thead>
                            <tr>
                                <th>#</th>
                                <th>Title</th>
                                <th>Date</th>
                                <th>Link</th>
                                <th>Actions</th>
                            </tr>
                            </thead>
                            <tbody id="news">

                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-sm-1"></div>
                <div class="col-sm-3 col-lg-3">
                    <div class="panel panel-color panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Add news</h3>
                        </div>
                        <div class="panel-body">
                            <p>
                            <div id="banned_pop"></div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <input type="text" class="form-control"  placeholder="News tittle" id="news_title">
                                </div>
                                <br>
                                <br>
                                <div class="col-sm-12">
                                    <input type="text" class="form-control"  placeholder="News redirect link" id="news_link">
                                </div>
                            </div>

                            </p>
                        </div>
                        <div class="panel-footer">
                            <button type="button" class="btn btn-success btn-custom waves-effect w-md waves-light m-b-5" onclick="addNews()">Submit</button>
                        </div>
                    </div>
                </div>


                <?php include "jointures/footer.php";?>

            </div> <!-- end container -->
        </div>
        <!-- End wrapper -->


        <script type="text/javascript">
            function loadNews() {
                $.post(
                    '/api/news/admin/list',
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
                                var table = document.getElementById('news');
                                var row = table.insertRow(table.rows.length);
                                row.id = i;
                                var id = row.insertCell(0);
                                var title = row.insertCell(1);
                                var date = row.insertCell(2);
                                var link = row.insertCell(3);
                                var action = row.insertCell(4);
                                id.innerHTML = i;
                                title.innerHTML = obj.news[i].title;
                                date.innerHTML = obj.news[i].date;
                                link.innerHTML = obj.news[i].link;
                                action.innerHTML = '<a href="/news/view/'+ obj.news[i].id+'"> <button class="btn btn-icon waves-effect waves-light btn-primary m-b-5"> <i class="fa fa-eye"></i> </button></a>  <button class="btn btn-icon waves-effect waves-light btn-danger m-b-5" onclick="removeNews('+ i +','+ obj.news[i].id + ')"> <i class="fa fa-remove"></i></button>';
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
            function addNews() {
                    $.post(
                        '/api/news/admin/create',
                        {
                            token : "<?php echo $_SESSION['token'];?>",
                            title : document.getElementById("news_title").value,
                            link : document.getElementById("news_link").value
                        },

                        function(data){
                            var obj = JSON.parse(data);

                            if (obj.status == 42)
                            {
                                $.Notification.notify('success','top right','Created !', obj.message);
                                document.getElementById("news").innerHTML = "";
                                loadNews();
                            }
                            else if (obj.status == 41)
                                window.location="/logout";
                            else
                                swal("Error...", obj.message, "error");
                        },

                        'text'
                    );
            }
            function removeNews(table_id, news_id) {
                swal({
                    title: "Are you sure?",
                    text: "You will not be able to recover this news!",
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
                            '/api/news/admin/remove',
                            {
                                token : "<?php echo $_SESSION['token'];?>",
                                id : news_id
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

        </script>


        <!-- jQuery  -->
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
        <script src="assets/js/detect.js"></script>
        <script src="assets/js/fastclick.js"></script>
        <script src="assets/js/jquery.blockUI.js"></script>
        <script src="assets/js/waves.js"></script>
        <script src="assets/js/wow.min.js"></script>
        <script src="assets/js/jquery.nicescroll.js"></script>
        <script src="assets/js/jquery.scrollTo.min.js"></script>

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

        <!-- Sweet-Alert  -->
        <script src="assets/plugins/sweetalert/dist/sweetalert.min.js"></script>
        <script src="assets/pages/jquery.sweet-alert.init.js"></script>

    </body>
</html>