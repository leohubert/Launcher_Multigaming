<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <meta name="description" content="launcherPanel">
    <meta name="author" content="Leo HUBERT">

    <link rel="shortcut icon" href="assets/images/favicon_1.ico">

    <title><?php echo $site; ?> register</title>

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="assets/css/core.css" rel="stylesheet" type="text/css">
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css">
    <link href="assets/css/components.css" rel="stylesheet" type="text/css">
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css">
    <link href="assets/css/menu.css" rel="stylesheet" type="text/css">
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css">

    <link href="assets/plugins/sweetalert/dist/sweetalert.css" rel="stylesheet" type="text/css">
    <link href="assets/plugins/jquery-circliful/css/jquery.circliful.css" rel="stylesheet" type="text/css"/>

    <script src="assets/js/modernizr.min.js"></script>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->


</head>
<body>
<script>
        function register_function() {
            $.post(
                '/api/register',
                {
                    email: $("#email").val(),
                    username: $("#username").val(),
                    password: $("#password").val(),
                    confirm_password: $("#confirm_password").val()
                },

                function (data) {
                    var obj = JSON.parse(data);
                    if (obj.status == "000") {
                        $.Notification.notify('success', 'top right', 'Registered with success', obj.message);
                        setTimeout(function () {
                            window.location = "/";
                        }, 1500);
                    }
                    else
                        $.Notification.notify('error', 'top right', obj.title, obj.message);
                },

                'text'
            );
            return false;
        }
</script>

<div class="wrapper-page">

    <div class="text-center">
        <a href="/" class="logo logo-lg"><i class="md md-equalizer"></i> <span><?php echo $site; ?> register</span> </a>
    </div>

    <form class="form-horizontal m-t-20" onsubmit="return register_function()">
        <div class="form-group">
            <div class="col-xs-12">
                <input class="form-control" type="email" id="email" required="" placeholder="Email">
                <i class="md md-email form-control-feedback l-h-34"></i>
            </div>
        </div>

        <div class="form-group">
            <div class="col-xs-12">
                <input class="form-control" type="text" id="username" required="" placeholder="Username">
                <i class="md md-account-circle form-control-feedback l-h-34"></i>
            </div>
        </div>

        <div class="form-group">
            <div class="col-xs-12">
                <input class="form-control" type="password" id="password" required="" placeholder="Password">
                <i class="md md-vpn-key form-control-feedback l-h-34"></i>
            </div>
        </div>

        <div class="form-group">
            <div class="col-xs-12">
                <input class="form-control" type="password" id="confirm_password" required=""
                       placeholder="Confirm password">
                <i class="md md-vpn-key form-control-feedback l-h-34"></i>
            </div>
        </div>

        <div class="form-group">
            <div class="col-xs-12">
                <div class="checkbox checkbox-primary">
                    <input id="checkbox-signup" type="checkbox" required>
                    <label for="checkbox-signup">
                        I accept <a href="/terms">Terms and Conditions</a>
                    </label>
                </div>

            </div>
        </div>

        <div class="form-group text-right m-t-20">
            <div class="col-xs-12">
                <button class="btn btn-primary btn-custom waves-effect waves-light w-md" type="submit">Register</button>
            </div>
        </div>

        <div class="form-group m-t-30">
            <div class="col-sm-12 text-center">
                <a href="/login" class="text-muted">Already have account?</a>
            </div>
        </div>
    </form>

</div>


<script>
    var resizefunc = [];
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

<!-- Custom main Js -->
<script src="assets/js/jquery.core.js"></script>
<script src="assets/js/jquery.app.js"></script>

<!-- Notifications -->
<script src="assets/plugins/notifyjs/dist/notify.min.js"></script>
<script src="assets/plugins/notifications/notify-metro.js"></script>
<script src="assets/plugins/sweetalert/dist/sweetalert.min.js"></script>

</body>
</html>