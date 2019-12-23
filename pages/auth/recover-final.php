<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width,initial-scale=1">
        <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc.">
        <meta name="author" content="Coderthemes">

        <link rel="shortcut icon" href="assets/images/favicon_1.ico">

        <title><?php echo $config->get("site_name");?> - Password lost</title>

        <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css">
        <link href="assets/css/core.css" rel="stylesheet" type="text/css">
        <link href="assets/css/icons.css" rel="stylesheet" type="text/css">
        <link href="assets/css/components.css" rel="stylesheet" type="text/css">
        <link href="assets/css/pages.css" rel="stylesheet" type="text/css">
        <link href="assets/css/menu.css" rel="stylesheet" type="text/css">
        <link href="assets/css/responsive.css" rel="stylesheet" type="text/css">

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
                <a href="index-2.html" class="logo logo-lg"><i class="md md-equalizer"></i> <span><?php echo $config->get("site_name");?></span> - Recovery </a>
            </div>

            <form id="recoveryForm" onsubmit="return recovery_function()">
                <div class="alert alert-success alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    Enter your <b>Code</b> and your new password !
                </div>
                <div class="form-group m-b-0">
                    <div class="input-group">
                        <input id="code" type="text" class="form-control" placeholder="Enter your code" required="">
                    </div></br>
                    <div class="input-group">
                    <input id="password" type="password" class="form-control" placeholder="Enter new password" required="yes">
                    </div></br>
                    <div class="input-group">
                    <input id="retype_password" type="password" class="form-control" placeholder="Retype new password" required="yes">
                    </div></br>
                    <div class="input-group">
                        <span class="input-group-btn"> <button id="rest" type="submit" class="btn btn-email btn-primary waves-effect waves-light">Reset</button> </span>
                    </div>
                </div>

            </form>
        </div>

        
    	<script>
            var resizefunc = [];

            function recovery_function() {
            $.post(
                '/api/recovery',
                {
                    code: $("#code").val(),
                    password: $("#password").val(),
                    retype_password: $("#retype_password").val(),
                },

                function (data) {
                    var obj = JSON.parse(data);
                    if (obj.status == 20) {
                        $.Notification.notify('success', 'top right', 'Password has been successfully modified', obj.message);
                        setTimeout(function () {
                            window.location = "/";
                        }, 2500);
                    }else if (obj.status == 30) {
                        $.Notification.notify('error', 'top right', 'Your code has used ..', obj.message);
                    }else
                        $.Notification.notify('error', 'top right', 'password change error', obj.message);
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
