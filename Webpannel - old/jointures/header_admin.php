<header id="topnav">
    <div class="topbar-main">
        <div class="container">

            <!-- Logo container-->
            <div class="logo">
                <a href="/" class="logo"><i class="md md-equalizer"></i> <span><?php echo $site;?> admin panel</span> </a>
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
                            <li><a href="/refresh?page=<?php echo $_SERVER[REQUEST_URI];?>"><i class="ti-loop m-r-5"></i>Refresh session</a></li>
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
                </ul>
                <!-- End navigation menu -->
            </div>
        </div>
    </div>
</header>