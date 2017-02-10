<div class="sidebar-menu">

    <div class="sidebar-menu-inner">

        <header class="logo-env">

            <!-- logo -->
            <div class="logo">
                <a href="/">
                    <img src="assets/images/logo@2x.png" width="120" alt="" />
                </a>
            </div>

            <!-- logo collapse icon -->
            <div class="sidebar-collapse">
                <a href="#" class="sidebar-collapse-icon"><!-- add class "with-animation" if you want sidebar to have animation during expanding/collapsing transition -->
                    <i class="entypo-menu"></i>
                </a>
            </div>


            <!-- open/close menu icon (do not remove if you want to enable menu on mobile devices) -->
            <div class="sidebar-mobile-menu visible-xs">
                <a href="#" class="with-animation"><!-- add class "with-animation" to support animation -->
                    <i class="entypo-menu"></i>
                </a>
            </div>

        </header>

        <div class="sidebar-user-info">

            <div class="sui-normal">
                <a href="#" class="user-link">
                    <img src="/upload/avatars/{{ Auth::user()->avatar }}" width="55" alt="" class="img-circle" />

                    <span>{{ trans('global.welcome') }},</span>
                    <strong>{{ Auth::user()->username }}</strong>
                </a>
            </div>

            <div class="sui-hover inline-links animate-in"><!-- You can remove "inline-links" class to make links appear vertically, class "animate-in" will make A elements animateable when click on user profile -->
                <center>
                    <a href="/account">
                        <i class="entypo-users"></i>
                        {{ trans('global.account') }}
                    </a>

                    <a href="extra-lockscreen.html">
                        <i class="entypo-lock"></i>
                        {{ trans('global.lock') }}
                    </a>
                </center>
                <span class="close-sui-popup">&times;</span><!-- this is mandatory -->				</div>
        </div>


        <ul id="main-menu" class="main-menu">
            <li class="opened active has-sub">
                <a href="/">
                    <i class="entypo-gauge"></i>
                    <span class="title">Users control</span>
                </a>
                <ul class="visible">
                    <li>
                        <a href="/users">
                            <span class="title">Search an user</span>
                        </a>
                    </li>
                    <li>
                        <a href="dashboard-2.html">
                            <span class="title">Dashboard 2</span>
                        </a>
                    </li>
                    <li>
                        <a href="dashboard-3.html">
                            <span class="title">Dashboard 3</span>
                        </a>
                    </li>
                    <li class="opened active has-sub">
                        <a href="skin-black.html">
                            <span class="title">Skins</span>
                        </a>
                        <ul class="visible">
                            <li>
                                <a href="skin-black.html">
                                    <span class="title">Black Skin</span>
                                </a>
                            </li>
                            <li>
                                <a href="skin-white.html">
                                    <span class="title">White Skin</span>
                                </a>
                            </li>
                            <li>
                                <a href="skin-purple.html">
                                    <span class="title">Purple Skin</span>
                                </a>
                            </li>
                            <li class="active">
                                <a href="skin-cafe.html">
                                    <span class="title">Cafe Skin</span>
                                </a>
                            </li>
                            <li>
                                <a href="skin-red.html">
                                    <span class="title">Red Skin</span>
                                </a>
                            </li>
                            <li>
                                <a href="skin-green.html">
                                    <span class="title">Green Skin</span>
                                </a>
                            </li>
                            <li>
                                <a href="skin-yellow.html">
                                    <span class="title">Yellow Skin</span>
                                </a>
                            </li>
                            <li>
                                <a href="skin-blue.html">
                                    <span class="title">Blue Skin</span>
                                </a>
                            </li>
                            <li>
                                <a href="skin-facebook.html">
                                    <span class="title">Facebook Skin</span>
                                    <span class="badge badge-secondary badge-roundless">New</span>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="highlights.html">
                            <span class="title">What's New</span>
                            <span class="badge badge-success badge-roundless">v2.0</span>
                        </a>
                    </li>
                </ul>
            </li>
        </ul>

    </div>

</div>