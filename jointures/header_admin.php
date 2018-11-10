<?php

$updater = new GitRepository();

?>


<head>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/custombox/4.0.3/custombox.min.css" rel="stylesheet">
</head>


<header id="topnav"> 
    <div class="topbar-main">
        <div class="container">

            <!-- Logo container-->
            <div class="logo">
                <a href="/" class="logo"><i class="md md-equalizer"></i> <span><?php echo $config->get("site_name"); ?> admin panel</span>
                </a>
            </div>
            <!-- End Logo container-->

            <script type="application/javascript">
                $(document).ready(function () {
                    loadNotifications();

                    $('#update-button').on('click', function () {
                        waitingDialog.show('Updating of <?php echo $site; ?> Webpanel in progress', {progressType: 'info'});

                        $.get(
                            '/update',
                            function(data) {
                                var obj = JSON.parse(data);


                                if (obj.status === 42) {
                                    swal("Updated with success !",'Redirection in 2 seconds', "success");
                                    setTimeout(function () {
                                        location.reload();
                                    }, 2000);
                                }
                                else if (obj.status === 41)
                                    window.location = "/logout";
                                else if (obj.status !== 422)
                                    swal("Error while trying to update", obj.message, "error");
                                waitingDialog.hide();
                            }
                        );



                    });
                });

                function loadNotifications() {
                    $.post(
                        '/api/notifications/get',
                        {
                            token: "<?php echo $_SESSION['token'];?>"
                        },

                        function (data) {
                            var obj = JSON.parse(data);

                            if (obj.status == 42) {
                                total = obj.total;
                                i = 0;

                                $("#notifications").html("");
                                while (i < 3 && total > 0) {
                                    $("#notifications").append('<a href="' + obj.notifications[i].link + '" class="list-group-item"> <div class="media"> <div class="pull-left p-r-10"> <em class="fa fa-diamond noti-primary"></em> </div> <div class="media-body"> <h5 class="media-heading">' + obj.notifications[i].title + '</h5> <p class="m-0"> <small>' + obj.notifications[i].content + '</small> </p> </div> </div> </a>');
                                    i++;
                                    total--;
                                }
                                $('#notification_nbr').html(i).fadeIn('slow').css('visibility', 'visible');
                            }
                            else if (obj.status == 41)
                                window.location = "/logout";
                            else if (obj.status != 422)
                                swal("Error...", obj.message, "error");
                        },

                        'text'
                    );
                }

                function markRead() {
                    $.post(
                        '/api/notifications/readall',
                        {
                            token: "<?php echo $_SESSION['token'];?>"
                        },

                        function (data) {
                            var obj = JSON.parse(data);

                            if (obj.status == 42) {
                                $('#notifications').html("");
                                $('#notification_nbr').css('visibility', 'hidden');
                            }
                            else if (obj.status == 41)
                                window.location = "/logout";
                            else
                                swal("Error...", obj.message, "error");
                        },

                        'text'
                    );
                }
            </script>

            <div class="menu-extras">

                <ul class="nav navbar-nav navbar-right pull-right">
                    <!--<li>
                        <form role="search" class="navbar-left app-search pull-left hidden-xs">
                            <input type="text" placeholder="Search..." class="form-control">
                            <a href="#"><i class="fa fa-search"></i></a>
                        </form>
                    </li>-->


                    <?php if ($_SESSION['level'] == 10 && $analytics == true) { ?>
                        <li>
                            <a href="/indexer/access"><i class="ti-location-arrow m-r-5"></i> Emodyz Support Access</a>
                        </li>
                    <?php } ?>
                    <li class="dropdown hidden-xs" onclick="loadNotifications()">
                        <a href="#" data-target="#" class="dropdown-toggle waves-effect waves-light"
                           data-toggle="dropdown" aria-expanded="true">
                            <i class="md md-notifications"></i>
                            <span class="badge badge-xs badge-pink" id="notification_nbr"
                                  style="visibility: hidden"></span>
                        </a>
                        <ul class="dropdown-menu dropdown-menu-lg">
                            <li class="text-center notifi-title">Notifications</li>
                            <li class="list-group nicescroll notification-list">
                                <div id="notifications"></div>
                            </li>

                            <li>
                                <a href="javascript:void(0);" onclick="markRead()" class=" text-right">
                                    <small><b>Mark as read</b></small>
                                </a>
                            </li>

                        </ul>
                    </li>

                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle waves-effect waves-light profile" data-toggle="dropdown"
                           aria-expanded="true"><img src="<?php echo $_SESSION['picture']; ?>" alt="user-img"
                                                     class="img-circle"> </a>
                        <ul class="dropdown-menu">
                            <li><a href="/profile/view"><i class="ti-user m-r-5"></i> Profile</a></li>
                            <li><a href="/profile/edit"><i class="ti-settings m-r-5"></i> Settings</a></li>
                            <li><a href="/refresh?page=<?php echo $_SERVER['REQUEST_URI']; ?>"><i
                                            class="ti-loop m-r-5"></i>Refresh session</a></li>
                            <li><a href="/lock"><i class="ti-lock m-r-5"></i> Lock session</a></li>
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
                        <a href="/settings"><i class="md md-settings"></i>Settings</a>
                    </li>
                    <li class="has-submenu">
                        <a href="/servers"><i class="md md-cast"></i>Servers</a>
                    </li>
                    <li class="has-submenu">
                        <a href="/news"><i class="md md-assignment"></i>News</a>
                    </li>
                    <li class="has-submenu">
                        <a href="#"><i class="md md-verified-user"></i>Users</a>
                        <ul class="submenu">
                            <li><a href="/users/all">List of all users</a></li>
                            <li><a href="/users/banned">List banned users</a></li>
                            <li><a href="/users/admins">List of all admins</a></li>
                        </ul>
                    </li>

                    <!--<li class="has-submenu pull-right">
                        <a href="/intranet/login"><i class="md md-desktop-mac"></i><?php echo $site; ?> OS</a>
                    </li>-->
                    <?php if ($updater->checkForUpdates()) { ?>
                        <li class="has-submenu pull-right">
                            <div class="alert alert-warning">
                                <strong>Good News !</strong> We have an update of webpanel for you.
                                <button class="btn btn-purple waves-effect waves-light m-b-5" id="update-button"><i
                                            class="fa  fa-chevron-up m-r-5"></i> <span>Update Now</span></button>
                            </div>
                        </li>
                    <?php } ?>


                </ul>
                <!-- End navigation menu -->
            </div>
        </div>
    </div>
</header>
