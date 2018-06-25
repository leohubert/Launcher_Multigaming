<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width,initial-scale=1">
        <meta name="description" content="launcherPanel">
        <meta name="author" content="Leo HUBERT">

        <link rel="shortcut icon" href="assets/images/favicon_1.ico">

        <title><?php echo $site?> lockscreen</title>

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
                <a href="/" class="logo logo-lg"><i class="md md-equalizer"></i> <span><?php echo $site?> lockscreen</span> </a>
            </div>

            <form onsubmit="return login_function()" role="form" class="text-center m-t-20">
                <div class="user-thumb">
                    <img src="<?php echo $_SESSION['picture'];?>" class="img-responsive img-circle img-thumbnail"
                         alt="thumbnail">
                </div>
                <div class="form-group">
                    <h3><?php echo $_SESSION['username'];?></h3>
                    <p class="text-muted">Enter your password to access the admin.</p>
                    <div class="input-group m-t-30">
                        <input type="password" class="form-control" placeholder="Password" id="password">
                        <i class="md md-vpn-key form-control-feedback l-h-34" style="left:6px;"></i>
                        <span class="input-group-btn">
                            <button type="submit" class="btn btn-email btn-primary waves-effect waves-light">
                            Log In
                        </button> </span>
                    </div>
                </div>
                <div class="text-right">
                    <a href="/logout" class="text-muted">Not <?php echo $_SESSION['username'];?> ? </a>
                </div>
            </form>
        </div>

        <script type="text/javascript">
            function login_function()
            {
                $.post(
                    '/api/login',
                    {
                        login : "<?php echo $_SESSION['email'];?>",
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