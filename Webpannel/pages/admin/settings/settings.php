
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="launcherPanel">
        <meta name="author" content="Leo HUBERT">

        <link rel="shortcut icon" href="assets/images/favicon_1.ico">

        <title><?php echo $site;?> panel</title>

        <link href="assets/plugins/jquery-circliful/css/jquery.circliful.css" rel="stylesheet" type="text/css" />

        <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/menu.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />

        <link href="assets/plugins/sweetalert/dist/sweetalert.css" rel="stylesheet" type="text/css">
        <link href="assets/plugins/jquery-circliful/css/jquery.circliful.css" rel="stylesheet" type="text/css" />

        <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->

        <script src="assets/js/modernizr.min.js"></script>

    </head>



    <body onload="loadAll()">

        <!-- Navigation Bar-->
        <?php include "jointures/header_admin.php"?>
        <!-- End Navigation Bar-->

        <script>
            function loadAll()
            {
                $.get(
                    '/api/settings',
                    {
                        launcher : 0
                    },

                    function(data){
                        var obj = JSON.parse(data);

                            if (obj.maintenance == 0)
                            {
                                var button = document.getElementById("maintenance");
                                var label = document.getElementById("maintenance_state");

                                button.className = "btn btn-danger waves-effect w-md waves-light m-b-5";
                                button.textContent = "Active maintenance";
                                label.className = "label label-danger";
                                label.textContent = "Deactivated";
                            }
                            if (obj.login == 0)
                            {
                                var button = document.getElementById("login");
                                var label = document.getElementById("login_state");

                                button.className = "btn btn-success waves-effect w-md waves-light m-b-5";
                                button.textContent = "Active login";
                                label.className = "label label-danger";
                                label.textContent = "Deactivated";
                            }
                            if (obj.register == 0)
                            {
                                var button = document.getElementById("register");
                                var label = document.getElementById("register_state");

                                button.className = "btn btn-success waves-effect w-md waves-light m-b-5";
                                button.textContent = "Active register";
                                label.className = "label label-danger";
                                label.textContent = "Deactivated";
                            }
                            document.getElementById("maintenance_title").value= obj.maintenance_title;
                            document.getElementById("maintenance_content").value = obj.maintenance_content;
                            document.getElementById("msg_title").value= obj.msg_title;
                            document.getElementById("msg_content").value = obj.msg_content;
                            document.getElementById("vmod").textContent = obj.vmod;

                    },

                    'text'
                );
            }
        </script>

        <div class="wrapper">
            <div class="container">

                <!-- Page-Title -->
                <div class="row">
                    <div class="col-sm-12">
                        <h4 class="page-title">Launcher control</h4>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-3">
                        <div class="card-box">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="row">
                                        <div class="col-xs-6 text-center">
                                            <span>Login <div><span class="label label-success" id="login_state">Activated</span></div></span>
                                            <br>
                                            <button id="login" type="button" class="btn btn-danger waves-effect w-md waves-light m-b-5" onclick="switch_login()">Deactivate login</button>
                                        </div>
                                        <div class="col-xs-6 text-center">
                                            <span>Register <div><span class="label label-success" id="register_state">Activated</span></div></span>
                                            <br>
                                            <button id="register" type="button" class="btn btn-danger waves-effect w-md waves-light m-b-5" onclick="switch_register()">Deactivate register</button>
                                        </div>
                                    </div><!-- End row -->
                                </div>
                            </div><!-- end row -->
                        </div>
                    </div> <!-- end col -->
                    <div class="col-lg-3">
                        <div class="card-box">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <span>Mod version </span>
                                            <div style="line-height:50%;"><br></div>
                                            <span class="label label-info" id="vmod">0.000000</span>
                                            <div style="line-height:100%;"><br></div>
                                            <button id="login" type="button" class="btn btn-warning waves-effect w-md waves-light m-b-5" onclick="update_vmod()">Create an update</button>
                                        </div>
                                    </div><!-- End row -->
                                </div>
                            </div><!-- end row -->
                        </div>
                    </div> <!-- end col -->
                     <!-- end col -->
                </div>
                <div class="row">
                    <div class="col-lg-3">
                        <div class="card-box">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="row">
                                        <div class="col-xs-13 text-center ">
                                            <span>Maintenance <div><span class="label label-success" id="maintenance_state">Activated</span></div></span>
                                            <br>
                                            <button id="maintenance" type="button" class="btn btn-success waves-effect w-md waves-light m-b-5" onclick="switch_maintenance()">Deactivate maintenance</button>
                                        </div>
                                        <br>
                                        <div class="col-xs-13">
                                            <input type="text" id="maintenance_title" class="form-control" placeholder="Maintenance title ( write '{picture}' for image)">
                                            <br>
                                            <textarea class="form-control" rows="5" id="maintenance_content" placeholder="Maintenance message ( write image link if Maintenance title is '{picture}')"></textarea>
                                        </div>
                                        <br>
                                        <div class="col-xs-13 text-center ">
                                            <button id="maintenance_save" type="button" class="btn btn-info waves-effect w-md waves-light m-b-5" onclick="save_maintenance()">Save</button>
                                        </div>
                                    </div><!-- End row -->
                                </div>
                            </div><!-- end row -->
                        </div>
                    </div> <!-- end col -->
                    <div class="col-lg-3">
                        <div class="card-box">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="row">
                                        <div class="col-xs-13 text-center ">
                                            <span>Login news</span>
                                        </div>
                                        <br>
                                        <div class="col-xs-13">
                                            <input type="text" id="msg_title" class="form-control" placeholder="Login News title ( write '{picture}' for image)">
                                            <br>
                                            <textarea class="form-control" rows="5" id="msg_content" placeholder="Login news message ( write image link if Maintenance title is '{picture}')"></textarea>
                                        </div>
                                        <br>
                                        <div class="col-xs-13 text-center ">
                                            <button id="msg_save" type="button" class="btn btn-info waves-effect w-md waves-light m-b-5" onclick="save_loginNews()">Save</button>
                                        </div>
                                    </div><!-- End row -->
                                </div>
                            </div><!-- end row -->
                        </div>
                    </div> <!-- end col -->
                    <div class="col-lg-3">
                        <div class="card-box">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <span>Launcher update</span>
                                            <div style="line-height:50%;"><br></div>
                                            <span class="label label-info" id="vlauncher">a40c09c37f6000a5be88b5e717e88a3e</span>
                                            <div style="line-height:100%;"><br></div>
                                            <div class="container">
                                                <div class="page-header">
                                                    <h3>Upload a new launcher</h3>
                                                </div>
                                                <div class="row" style="padding-top:10px;">
                                                    <div class="col-xs-2">
                                                        <button id="uploadBtn" class="btn btn-large btn-primary" onclick="checkLevel()">Choose File</button>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        <div id="progressOuter" class="progress progress-striped active" style="display:none;">
                                                            <div id="progressBar" class="progress-bar progress-bar-success"  role="progressbar" aria-valuenow="45" aria-valuemin="0" aria-valuemax="100" style="width: 0%">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row" style="padding-top:10px;">
                                                    <div class="col-xs-10">
                                                        <div id="msgBox">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <script src="/assets/js/SimpleAjaxUploader.js"></script>
                                            <script>
                                                var level = "<?php echo $_SESSION['level'];?>";
                                                function checkLevel()
                                                {
                                                    if (level < 9)
                                                        sweetAlert("Missing permission", "Yon don't have right to upload a new launcher", "error");
                                                }
                                                function escapeTags( str ) {
                                                    return String( str )
                                                        .replace( /&/g, '&amp;' )
                                                        .replace( /"/g, '&quot;' )
                                                        .replace( /'/g, '&#39;' )
                                                        .replace( /</g, '&lt;' )
                                                        .replace( />/g, '&gt;' );
                                                }
                                                window.onload = function() {
                                                    if (level < 9)
                                                        disable();
                                                    var btn = document.getElementById('uploadBtn'),
                                                        progressBar = document.getElementById('progressBar'),
                                                        progressOuter = document.getElementById('progressOuter'),
                                                        msgBox = document.getElementById('msgBox');
                                                    var uploader = new ss.SimpleUpload({
                                                        button: btn,
                                                        url: '/api/arma3/upload_launcher.php',
                                                        name: 'uploadfile',
                                                        allowedExtensions: ['exe'],
                                                        multipart: true,
                                                        hoverClass: 'hover',
                                                        focusClass: 'focus',
                                                        responseType: 'json',
                                                        startXHR: function() {
                                                            progressOuter.style.display = 'block'; // make progress bar visible
                                                            this.setProgressBar( progressBar );
                                                        },
                                                        onSubmit: function() {
                                                            msgBox.innerHTML = ''; // empty the message box
                                                            btn.innerHTML = 'Uploading...'; // change button text to "Uploading..."
                                                        },
                                                        onComplete: function( filename, response ) {
                                                            btn.innerHTML = 'Choose Another File';
                                                            progressOuter.style.display = 'none'; // hide progress bar when upload is completed
                                                            if ( !response ) {
                                                                msgBox.innerHTML = 'Unable to upload file';
                                                                return;
                                                            }
                                                            if ( response.success === true ) {
                                                                msgBox.innerHTML = '<strong>' + escapeTags( filename ) + '</strong>' + ' successfully uploaded.';
                                                            } else {
                                                                if ( response.msg )  {
                                                                    msgBox.innerHTML = escapeTags( response.msg );
                                                                } else {
                                                                    msgBox.innerHTML = 'An error occurred and the upload failed.';
                                                                }
                                                            }
                                                        },
                                                        onError: function() {
                                                            progressOuter.style.display = 'none';
                                                            msgBox.innerHTML = 'Unable to upload file';
                                                        }
                                                    });
                                                };
                                            </script>
                                        </div>
                                    </div><!-- End row -->
                                </div>
                            </div><!-- end row -->
                        </div>
                    </div>
                </div>
                <!-- end row -->

                <script>
                    function switch_maintenance()
                    {
                        var button = document.getElementById("maintenance");
                        var label = document.getElementById("maintenance_state");

                        if (button.className == "btn btn-success waves-effect w-md waves-light m-b-5")
                        {
                            $.post(
                                '/api/switch/maintenance',
                                {
                                    token : "<?php echo $_SESSION['token'];?>",
                                    state : 0
                                },

                                function(data){
                                    var obj = JSON.parse(data);
                                    if (obj.status == 42)
                                    {
                                        $.Notification.notify('success','top right','Maintenance deactivate', "Maintenance was been deactivated");
                                        button.className = "btn btn-danger waves-effect w-md waves-light m-b-5";
                                        button.textContent = "Active maintenance";
                                        label.className = "label label-danger";
                                        label.textContent = "Deactivated";
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
                        else
                        {
                            $.post(
                                '/api/switch/maintenance',
                                {
                                    token : "<?php echo $_SESSION['token'];?>",
                                    state : 1
                                },

                                function(data){
                                    var obj = JSON.parse(data);
                                    if (obj.status == 42)
                                    {
                                        $.Notification.notify('warning','top right','Maintenance active', "Maintenance was been activated");
                                        button.className = "btn btn-success waves-effect w-md waves-light m-b-5";
                                        button.textContent = "Deactivate maintenance";
                                        label.className = "label label-success";
                                        label.textContent = "Activated";
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
                    }
                    function switch_login()
                    {
                        var button = document.getElementById("login");
                        var label = document.getElementById("login_state");

                        if (button.className == "btn btn-danger waves-effect w-md waves-light m-b-5")
                        {
                            $.post(
                                '/api/switch/login',
                                {
                                    token : "<?php echo $_SESSION['token'];?>",
                                    state : 0
                                },

                                function(data){
                                    var obj = JSON.parse(data);
                                    if (obj.status == 42)
                                    {
                                        $.Notification.notify('warning','top right','Login deactivate', "Login was been deactivated");
                                        button.className = "btn btn-success waves-effect w-md waves-light m-b-5";
                                        button.textContent = "Active login";
                                        label.className = "label label-danger";
                                        label.textContent = "Deactivated";
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
                        else
                        {
                            $.post(
                                '/api/switch/login',
                                {
                                    token : "<?php echo $_SESSION['token'];?>",
                                    state : 1
                                },

                                function(data){
                                    var obj = JSON.parse(data);
                                    if (obj.status == 42)
                                    {
                                        $.Notification.notify('success','top right','Login activate', "Login was been activated");
                                        button.className = "btn btn-danger waves-effect w-md waves-light m-b-5";
                                        button.textContent = "Deactivate login";
                                        label.className = "label label-success";
                                        label.textContent = "Activated";
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
                    }
                    function switch_register()
                    {
                        var button = document.getElementById("register");
                        var label = document.getElementById("register_state");

                        if (button.className == "btn btn-danger waves-effect w-md waves-light m-b-5")
                        {
                            $.post(
                                '/api/switch/register',
                                {
                                    token : "<?php echo $_SESSION['token'];?>",
                                    state : 0
                                },

                                function(data){
                                    var obj = JSON.parse(data);
                                    if (obj.status == 42)
                                    {
                                        $.Notification.notify('warning','top right','Register deactivate', "Register was been deactivated");
                                        button.className = "btn btn-success waves-effect w-md waves-light m-b-5";
                                        button.textContent = "Active register";
                                        label.className = "label label-danger";
                                        label.textContent = "Deactivated";
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
                        else
                        {
                            $.post(
                                '/api/switch/register',
                                {
                                    token : "<?php echo $_SESSION['token'];?>",
                                    state : 1
                                },

                                function(data){
                                    var obj = JSON.parse(data);
                                    if (obj.status == 42)
                                    {
                                        $.Notification.notify('success','top right','Register activate', "Register was been activated");
                                        button.className = "btn btn-danger waves-effect w-md waves-light m-b-5";
                                        button.textContent = "Deactivate register";
                                        label.className = "label label-success";
                                        label.textContent = "Activated";
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
                    }
                    function save_maintenance() {
                            $.post(
                                '/api/update/maintenance',
                                {
                                    token : "<?php echo $_SESSION['token'];?>",
                                    maintenance_title : document.getElementById("maintenance_title").value,
                                    maintenance_content : document.getElementById("maintenance_content").value
                                },

                                function(data){
                                    var obj = JSON.parse(data);
                                    if (obj.status == 42)
                                        $.Notification.notify('success','top right','Maintenance saved', obj.message);
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
                    function save_loginNews() {
                        $.post(
                            '/api/update/loginNews',
                            {
                                token : "<?php echo $_SESSION['token'];?>",
                                msg_title : document.getElementById("msg_title").value,
                                msg_content : document.getElementById("msg_content").value
                            },

                            function(data){
                                var obj = JSON.parse(data);
                                if (obj.status == 42)
                                    $.Notification.notify('success','top right','Login News saved', obj.message);
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
                    function update_vmod() {
                        var newVersion = parseFloat(document.getElementById("vmod").textContent) + 0.000001;
                        $.post(
                            '/api/update/vmod',
                            {
                                token : "<?php echo $_SESSION['token'];?>",
                                vmod : newVersion.toFixed(6)
                            },

                            function(data){
                                var obj = JSON.parse(data);
                                if (obj.status == 42)
                                {
                                    $.Notification.notify('success','top right','New update created', obj.message);
                                    document.getElementById("vmod").textContent = newVersion.toFixed(6);
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

                <?php include "jointures/footer.php";?>

            </div> <!-- end container -->
        </div>
        <!-- End wrapper -->



        <!-- jQuery  -->
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
        <script src="assets/js/detect.js"></script>
        <script src="assets/js/fastclick.js"></script>
        <script src="assets/js/jquery.blockUI.js"></script>
        <script src="assets/js/waves.js"></script>
        <script src="assets/js/wow.min.js"></script>
        <script src="assets/js/jquery.nicescroll.js"></script>
        <script src="assets/js/jquery.scrollTo.min.js"></script>

        <!-- circliful Chart -->
        <script src="assets/plugins/jquery-circliful/js/jquery.circliful.min.js"></script>
        <script src="assets/plugins/jquery-sparkline/jquery.sparkline.min.js"></script>

        <!-- skycons -->
        <script src="assets/plugins/skyicons/skycons.min.js" type="text/javascript"></script>

        <!-- Notifications -->
        <script src="assets/plugins/notifyjs/dist/notify.min.js"></script>
        <script src="assets/plugins/notifications/notify-metro.js"></script>

        <!-- Custom main Js -->
        <script src="assets/js/jquery.core.js"></script>
        <script src="assets/js/jquery.app.js"></script>

        <!-- Sweet-Alert  -->
        <script src="assets/plugins/sweetalert/dist/sweetalert.min.js"></script>
        <script src="assets/pages/jquery.sweet-alert.init.js"></script>

    </body>
</html>