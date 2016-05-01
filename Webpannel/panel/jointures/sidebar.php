<div class="col-md-3 left_col">
    <div class="left_col scroll-view">

        <div class="navbar nav_title" style="border: 0;">
            <a href="index.php" class="site_title"><i class="fa fa-paw"></i> <span><?php echo $siteName; ?> Panel</span></a>
        </div>
        <div class="clearfix"></div>

        <!-- menu prile quick info -->
        <div class="profile">
            <div class="profile_pic">
                <img src="images/img.jpg" alt="..." class="img-circle profile_img">
            </div>
            <div class="profile_info">
                <span>Welcome,</span>
                <h2><?php echo $_SESSION['username']; ?></h2>
            </div>
        </div>
        <!-- /menu prile quick info -->


        <br />
        <br />

        <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">

            <div class="menu_section">
              <h3>General</h3>
              <ul class="nav side-menu">
                <li><a><i class="fa fa-cog fa-spin fa-3x fa-fw margin-bottom"></i> Launcher settings<span class="fa fa-chevron-down"></span></a>
                  <ul class="nav child_menu" style="display: none">
                    <li><a href="basic.php">Basic settings</a>
                    </li>
                  </ul>
                </li>
              </ul>
            </div>

          </div>

<div class="sidebar-footer hidden-small">
    <a data-toggle="tooltip" data-placement="top" title="Lock">
        <span class="glyphicon glyphicon-eye-close" aria-hidden="true"></span>
    </a>
    <a data-toggle="tooltip" data-placement="top">
        <span class="glyphicon" aria-hidden="true"></span>
    </a>
    <a data-toggle="tooltip" data-placement="top">
        <span class="glyphicon aria-hidden="true"></span>
    </a>
    <a href="../../class/Session.class.php?action=logOut" data-toggle="tooltip" data-placement="top" title="Logout">
        <span class="glyphicon glyphicon-off" aria-hidden="true"></span>
    </a>
</div>
</div>
</div>