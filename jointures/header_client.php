<head>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/custombox/4.0.3/custombox.min.css" rel="stylesheet">
</head>


<header id="topnav">
    <div class="topbar-main">
        <div class="container">

            <!-- Logo container-->
            <div class="logo">
                <a href="/" class="logo"><i class="md md-equalizer"></i> <span><?php echo $config->get("site_name");?> client panel</span> </a>
            </div>
            <!-- End Logo container-->

            <div class="menu-extras">

                <ul class="nav navbar-nav navbar-right pull-right">
                    <li>
                        <form role="search" class="navbar-left app-search pull-left hidden-xs">
                            <input type="text" placeholder="Search..." class="form-control">
                            <a href="#"><i class="fa fa-search"></i></a>
                        </form>
                    </li>
                    <li class="dropdown hidden-xs">
                        <a href="#" data-target="#" class="dropdown-toggle waves-effect waves-light"
                           data-toggle="dropdown" aria-expanded="true">
                            <i class="md md-notifications"></i>
                            <!--<span class="badge badge-xs badge-pink">3</span>-->
                        </a>
                        <ul class="dropdown-menu dropdown-menu-lg">
                            <li class="text-center notifi-title">Notification</li>
                            <li class="list-group nicescroll notification-list">
                                <!-- list item-->
                                <!--<a href="javascript:void(0);" class="list-group-item">
                                    <div class="media">
                                        <div class="pull-left p-r-10">
                                            <em class="fa fa-diamond noti-primary"></em>
                                        </div>
                                        <div class="media-body">
                                            <h5 class="media-heading">A new order has been placed A new
                                                order has been placed</h5>
                                            <p class="m-0">
                                                <small>There are new settings available</small>
                                            </p>
                                        </div>
                                    </div>
                                </a>-->
                                <a href="javascript:void(0);" class="list-group-item">
                                    <div class="media">
                                        <div class="pull-left p-r-10">
                                            <em class="fa fa-diamond noti-primary"></em>
                                        </div>
                                        <div class="media-body">
                                            <h5 class="media-heading">Any notification</h5>
                                            <p class="m-0">
                                                <small>You have 0 notification</small>
                                            </p>
                                        </div>
                                    </div>
                                </a>
                            </li>

                            <li>
                                <a href="javascript:void(0);" class=" text-right">
                                    <small><b>See all notifications</b></small>
                                </a>
                            </li>

                        </ul>
                    </li>

                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle waves-effect waves-light profile" data-toggle="dropdown" aria-expanded="true"><img src="<?php echo $_SESSION['picture'];?>" alt="user-img" class="img-circle"> </a>
                        <ul class="dropdown-menu">
                            <li><a href="/profile/view"><i class="ti-user m-r-5"></i> Profile</a></li>
                            <li><a href="/profile/edit"><i class="ti-settings m-r-5"></i> Settings</a></li>
                            <li><a href="/refresh?page=<?php echo $_SERVER['REQUEST_URI'];?>"><i class="ti-loop m-r-5"></i>Refresh session</a></li>
                            <li><a href="/lock"><i class="ti-lock m-r-5"></i>Lock session</a></li>
                            <li><a href="/logout"><i class="ti-power-off m-r-5"></i> Logout</a></li>
                        </ul>
                    </li>
                </ul>

                <div class="menu-item">
                    <!-- Mobile menu toggle-->
                    <a class="navbar-toggle">
                        <div class="lines">
                            <span></span>
                            <span></span>
                            <span></span>
                        </div>
                    </a>
                    <!-- End mobile menu toggle-->
                </div>
            </div>

        </div>
    </div>
    <!-- End topbar -->


    <!-- Navbar Start -->
    <div class="navbar-custom">
        <div class="container">
            <div id="navigation">
                <!-- Navigation Menu-->
                <ul class="navigation-menu">
                    <li class="has-submenu active">
                        <a href="/"><i class="md md-dashboard"></i>Dashboard</a>
                    </li>
                    <li class="has-submenu">
                        <a data-toggle="modal" data-target="#con-close-modal"><i class="md md-live-help"></i>Support request</a>
                    </li>
                </ul>
                <!-- End navigation menu -->
            </div>
        </div>
    </div>
</header>

<div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title">Create a support request</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card-box widget-user">
                            <div>
                                <img src="<?php echo $_SESSION['picture'];?>" class="img-responsive img-circle" alt="user">
                                <div class="wid-u-info">
                                    <h4 class="m-t-0 m-b-5"><?php echo $_SESSION['username'];?></h4>
                                    <p class="text-muted m-b-5 font-13"><?php echo $_SESSION['email'];?></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="field-1" class="control-label">Support title</label>
                            <input type="text" class="form-control" id="createSupport_title" placeholder="Ban request...">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group no-margin">
                            <label for="field-7" class="control-label">Message</label>
                            <textarea class="form-control autogrow" id="createSupport_message" placeholder="Write something about your request" style="overflow: hidden; word-wrap: break-word; resize: horizontal; height: 104px;"></textarea>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-info waves-effect waves-light" onclick="createSupport()">Send request</button>
            </div>
        </div>
    </div>
</div>


<script>
    function createSupport() {
        $.post(
            '/api/support/client/create',
            {
                token : "<?php echo $_SESSION['token'];?>",
                title : document.getElementById("createSupport_title").value,
                message : document.getElementById("createSupport_message").value
            },

            function(data){
                var obj = JSON.parse(data);
                if (obj.status == 42)
                {
                    sweetAlert("Support request created !", obj.message, "success");
                    window.location = "/support/view/" + obj.support_id;
                }
                else if (obj.status == 41)
                    window.location="/logout";
                else if (obj.status == 44)
                    sweetAlert("Missing permission", obj.message, "error");
                else
                    $.Notification.notify('error','bottom center','Internal Error', "Error: " + obj.status + " | " + obj.message);
            },
            'text'
        );
    }
</script>

<script src="assets/plugins/custombox/dist/custombox.min.js"></script>
<script src="assets/plugins/custombox/dist/legacy.min.js"></script>