<img class="loading" id="picture_logout" src="http://smashinghub.com/wp-content/uploads/2014/08/cool-loading-animated-gif-8.gif" alt="" style="display: none;">

<script>
    function logOut() {
        window.onscroll = function () { window.scrollTo(0, 0); };
        $("#picture_logout").fadeIn(2000);
        var audio = new Audio('/assets/sounds/login_sound.mp3');
        audio.play();
        setInterval(function () {
            window.location = "/";
        }, 6000);
    }

</script>

<header id="topnav">
    <div class="menu-extras">
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
    <div class="navbar-custom">
        <div class="container">
            <div id="navigation">
                <!-- Navigation Menu-->
                <ul class="navigation-menu">
                    <li class="has-submenu active">
                        <a href="/intranet"><i class="md md-dashboard"></i>Dashboard</a>
                    </li>
                    <li class="has-submenu">
                        <a href="/intranet/bank/authentication"><i class="ion ion-social-usd"></i>Bank</a>
                    </li>
                    <li class="has-submenu pull-right">
                        <a href="#" onclick="logOut()"><i class="md md-settings-power"></i></a>
                    </li>
                </ul>
                <!-- End navigation menu -->
            </div>
        </div>
    </div>
</header>