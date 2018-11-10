<?php
    if (isset($_GET['auto']) && $_GET['auto'] == "true" && isset($_GET['token']))
        echo "<body onload='connectWithToken(\"" . $_GET['token'] ."\")';>";
    if (isset($_COOKIE['token']))
        echo "<body onload='connectWithToken(\"" . $_COOKIE['token'] ."\")';>";
?>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width,initial-scale=1">
        <meta name="description" content="launcherPanel">
        <meta name="author" content="Leo HUBERT">

        <link rel="shortcut icon" href="assets/images/favicon_1.ico">

        <title><?php echo $config->get("site_name");?> login</title>

        <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css">
        <link href="assets/css/core.css" rel="stylesheet" type="text/css">
        <link href="assets/css/icons.css" rel="stylesheet" type="text/css">
        <link href="assets/css/components.css" rel="stylesheet" type="text/css">
        <link href="assets/css/pages.css" rel="stylesheet" type="text/css">
        <link href="assets/css/menu.css" rel="stylesheet" type="text/css">
        <link href="assets/css/responsive.css" rel="stylesheet" type="text/css">


        <link href="assets/plugins/sweetalert/dist/sweetalert.css" rel="stylesheet" type="text/css">
        <link href="assets/plugins/jquery-circliful/css/jquery.circliful.css" rel="stylesheet" type="text/css" />

        <script src="assets/js/modernizr.min.js"></script>

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->

        
    </head>
    <body>


        <div class="wrapper-page">

            <div class="text-center">
                <a href="/" class="logo logo-lg"><i class="md md-equalizer"></i> <span><?php echo $config->get("site_name");?> login</span> </a>
            </div>
                <div class="form-horizontal m-t-20">
                    <form id="loginForm" onsubmit="return login_function()">
                        <div class="form-group">
                            <div class="col-xs-12">
                                <input id="login" class="form-control" type="text" required="" placeholder="Username or Email">
                                <i class="md md-account-circle form-control-feedback l-h-34"></i>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <input id="password" class="form-control" type="password" required="" placeholder="Password">
                                <i class="md md-vpn-key form-control-feedback l-h-34"></i>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="checkbox checkbox-primary">
                                    <input id="checkbox-signup" type="checkbox" checked>
                                    <label for="checkbox-signup">
                                        Remember me
                                    </label>
                                </div>

                            </div>
                        </div>

                        <div class="form-group text-right m-t-20">
                            <div class="col-xs-12">
                                <button type="submit" class="btn btn-primary btn-custom w-md waves-effect waves-light">Log In</button>
                            </div>
                        </div>
                    </form>

                    <div class="form-group m-t-30">
                        <div class="col-sm-7">
                            <a href="/recover" class="text-muted"><i class="fa fa-lock m-r-5"></i> Forgot your password?</a>
                        </div>
                        <div class="col-sm-5 text-right">
                            <a href="/register" class="text-muted">Create an account</a>
                        </div>
                    </div>
                </div>
        </div>

        <script>
            function login_function()
            {
                $.post(
                    '/api/login',
                    {
                        login : $("#login").val(),
                        password : $("#password").val(),
                        launcher : "0"
                    },

                    function(data){
                        var obj = JSON.parse(data);

                        if (obj.status == 42)
                        {

                            $.Notification.notify('success','top right','Login success', obj.message);
                            window.location="/";
                        }
                        else if (obj.status == 43)
                            sweetAlert("Oops...", "Your are banned", "error");
                        else
                            $.Notification.notify('error','top right', 'Login error', obj.message);
                    },

                    'text'
                );
                return false;
            }

            function connectWithToken(token)
            {
                $.post(
                    '/api/login',
                    {
                        token : token
                    },

                    function(data){
                        var obj = JSON.parse(data);

                        if (obj.status == 42)
                        {

                            $.Notification.notify('success','top right','Login success', obj.message);
                            window.location="/";
                        }
                        else if (obj.status == 43)
                            sweetAlert("Oops...", "Your are banned", "error");
                        else
                            $.Notification.notify('error','top right', 'Login error', obj.message);
                    },

                    'text'
                );
                return false;
            }
        </script>

        <!-- Main  -->
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
        <script src="assets/js/detect.js"></script>
        <script src="assets/js/fastclick.js"></script>
        <script src="assets/js/jquery.slimscroll.js"></script>
        <script src="assets/js/jquery.blockUI.js"></script>
        <script src="assets/js/waves.js"></script>
        <script src="assets/js/wow.min.js"></script>
        <script src="assets/js/jquery.nicescroll.js"></script>
        <script src="assets/js/jquery.scrollTo.min.js"></script>


        <!-- Notifications -->
        <script src="assets/plugins/notifyjs/dist/notify.min.js"></script>
        <script src="assets/plugins/notifications/notify-metro.js"></script>
        <script src="assets/plugins/sweetalert/dist/sweetalert.min.js"></script>

        <!-- Custom main Js -->
        <script src="assets/js/jquery.core.js"></script>
        <script src="assets/js/jquery.app.js"></script>
	
	</body>
</html>