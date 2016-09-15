<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 20:12
 */

    $id = $match['params']['id'];

?>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="launcherPanel">
    <meta name="author" content="Leo HUBERT">

    <link rel="shortcut icon" href="/assets/images/favicon_1.ico">

    <title><?php echo $site;?> panel</title>

    <link href="/assets/plugins/jquery-circliful/css/jquery.circliful.css" rel="stylesheet" type="text/css" />

    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/components.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/pages.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/menu.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/responsive.css" rel="stylesheet" type="text/css" />

    <link href="/assets/plugins/custombox/dist/custombox.min.css" rel="stylesheet">

    <link href="/assets/plugins/sweetalert/dist/sweetalert.css" rel="stylesheet" type="text/css">
    <link href="/assets/plugins/jquery-circliful/css/jquery.circliful.css" rel="stylesheet" type="text/css" />


    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->

    <script src="/assets/js/modernizr.min.js"></script>

</head>


<body onload="loadServer()">

<script>
    function loadServer() {
        $.post(
            '/api/server/admin/get',
            {
                token : "<?php echo $_SESSION['token'];?>",
                id : "<?php echo $id;?>"
            },

            function(data){
                var obj = JSON.parse(data);
                if (obj.status == 42)
                {
                    if (obj.can_play == 0)
                    {
                        var button = document.getElementById("lock_button");
                        button.textContent = "UnLock Server";
                        button.value = "unlock";
                        button.className = "btn btn-success btn-custom waves-effect w-md waves-light m-b-5";
                    }

                    if (obj.maintenance == 1)
                    {
                        var button = document.getElementById("maintenance_button");
                        button.textContent = "Deactivate Maintenance";
                        button.value = "unmaintenance";
                        button.className = "btn btn-success btn-custom waves-effect w-md waves-light m-b-5";
                    }

                    $.post(
                        '/api/server/status/get',
                        {
                            name : obj.name,
                            arma_ip : obj.ip + ":" + obj.port
                        },
                        function(data){
                            var obj = JSON.parse(data);

                            if (obj.status == 42)
                            {
                                if (obj.online == true)
                                {
                                    document.getElementById("server_status_color").className = "text-success";
                                    document.getElementById("server_status").textContent = "ONLINE";
                                    document.getElementById("server_ip").textContent = obj.server_ip + ":" + obj.server_port;
                                    document.getElementById("server_players").textContent = obj.server_onlineplayers + " / " + obj.server_maxplayers;
                                    document.getElementById("server_map").textContent = obj.server_map;
                                }
                                else
                                {
                                    document.getElementById("server_status_color").className = "text-danger";
                                    document.getElementById("server_status").textContent = "OFFLINE";
                                    document.getElementById("server_ip").textContent = "No found";
                                    document.getElementById("server_players").textContent = "No found";
                                    document.getElementById("server_map").textContent = "No found";
                                }
                            }
                            else if (obj.status == 41)
                                window.location="/logout";
                            else
                                swal("Error...", obj.message, "error");
                        },

                        'text'
                    );
                }
                else if (obj.status == 41)
                    window.location="/logout";
                else
                    swal("Error...", obj.message, "error");
            },

            'text'
        );
    }
    function saveUser() {
        $.post(
            '/api/users/admin/save',
            {
                token : "<?php echo $_SESSION['token'];?>",
                id : "<?php echo $id;?>",
                username : document.getElementById("control_username").value,
                email : document.getElementById("control_email").value,
                uid : document.getElementById("control_uid").value,
                picture : document.getElementById("control_picture").value,
                level : document.getElementById("control_level").value,
                banned : document.getElementById("control_banned").value
            },

            function(data){
                var obj = JSON.parse(data);
                if (obj.status == 42)
                {
                    loadUser();
                    $.Notification.notify('success','top right','Saved', obj.message);
                }
                else if (obj.status == 41)
                    window.location="/logout";
                else
                    swal("Error...", obj.message, "error");
            },

            'text'
        );
    }
    function deleteUser() {
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this user !",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel plx!",
            closeOnConfirm: false,
            closeOnCancel: false
        }, function(isConfirm){
            if (isConfirm) {
                $.post(
                    '/api/users/admin/remove',
                    {
                        token : "<?php echo $_SESSION['token'];?>",
                        id : "<?php echo $id;?>"
                    },

                    function(data){
                        var obj = JSON.parse(data);

                        if (obj.status == 42)
                        {
                            swal({
                                title: "Deleted !",
                                text: obj.message,
                                type: "success",
                                timer: 500
                            });
                            setInterval(function () {
                                location.reload();
                            }, 1500);
                        }
                        else if (obj.status == 41)
                            window.location="/logout";
                        else
                            swal("Error...", obj.message, "error");
                    },

                    'text'
                );
            } else {
                swal("Cancelled", "Deletion successfully canceled", "error");
            }
        });
    }
    
    function createModUpdate()
    {
        waitingDialog.show('Creating update in progress, don\'t refresh this page !', {progressType: 'warning'});
        $.post(
            '/api/games/arma3/create_update',
            {
                token : "<?php echo $_SESSION['token'];?>",
                id : "<?php echo $id;?>"
            },

            function(data){
                var obj = JSON.parse(data);

                if (obj.status == 42)
                {
                    swal({
                        title: "Success !",
                        text: obj.message,
                        type: "success",
                        timer: 1500
                    });
                }
                else if (obj.status == 41)
                    window.location="/logout";
                else
                    swal("Error...", obj.message, "error");
                waitingDialog.hide();
            },

            'text'
        );
    }

    function lockServer()
    {
        var button = document.getElementById("lock_button");

        if (button.value == "lock")
        {
            $.post(
                '/api/server/admin/lock',
                {
                    token : "<?php echo $_SESSION['token'];?>",
                    id : "<?php echo $id;?>",
                    lock : 0
                },

                function(data){
                    var obj = JSON.parse(data);
                    if (obj.status == 42)
                    {
                        $.Notification.notify('warning','top right','Server Locked', "Server as been locked");
                        button.textContent = "UnLock Server";
                        button.value = "unlock";
                        button.className = "btn btn-success btn-custom waves-effect w-md waves-light m-b-5";

                        //MODAL
                        Custombox.open({
                            target: '#lock',
                            effect: 'blur'
                        });
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
                '/api/server/admin/lock',
                {
                    token : "<?php echo $_SESSION['token'];?>",
                    id : "<?php echo $id;?>",
                    lock : 1
                },

                function(data){
                    var obj = JSON.parse(data);
                    if (obj.status == 42)
                    {
                        $.Notification.notify('success','top right','Server UnLocked', "Server as been unlocked");
                        button.textContent = "Lock Server";
                        button.value = "lock";
                        button.className = "btn btn-warning btn-custom waves-effect w-md waves-light m-b-5";
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

    function maintenanceServer()
    {
        var button = document.getElementById("maintenance_button");

        if (button.value == "maintenance")
        {
            $.post(
                '/api/server/admin/maintenance',
                {
                    token : "<?php echo $_SESSION['token'];?>",
                    id : "<?php echo $id;?>",
                    maintenance : 1
                },

                function(data){
                    var obj = JSON.parse(data);
                    if (obj.status == 42)
                    {
                        $.Notification.notify('warning','top right','Server Maintenance', "Maintenance activated");
                        button.textContent = "Deactivate Maintenance";
                        button.value = "unmaintenance";
                        button.className = "btn btn-success btn-custom waves-effect w-md waves-light m-b-5";
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
                '/api/server/admin/maintenance',
                {
                    token : "<?php echo $_SESSION['token'];?>",
                    id : "<?php echo $id;?>",
                    maintenance : 0
                },

                function(data){
                    var obj = JSON.parse(data);
                    if (obj.status == 42)
                    {
                        $.Notification.notify('success','top right','Server UnLocked', "Maintenance deactivated");
                        button.textContent = "Activate Maintenance";
                        button.value = "maintenance";
                        button.className = "btn btn-danger btn-custom waves-effect w-md waves-light m-b-5";
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
    function setPass()
    {
        $.post(
            '/api/server/admin/setpass',
            {
                token : "<?php echo $_SESSION['token'];?>",
                id : "<?php echo $id;?>",
                password : document.getElementById("lock_password").value
            },

            function(data){
                var obj = JSON.parse(data);

                if (obj.status == 42)
                {
                    swal({
                        title: "Success !",
                        text: obj.message,
                        type: "success",
                        timer: 1000
                    });
                }
                else if (obj.status == 41)
                    window.location="/logout";
                else
                    swal("Error...", obj.message, "error");
            },

            'text'
        );
    }
</script>

<?php include "jointures/header_admin.php"?>
<div class="wrapper">
    <div class="container">

        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">Server Control
                </h4>
            </div>
        </div>

        <div class="col-lg-12">
            <div class="col-lg-3">
                <div class="panel panel-border panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title">Server Status</h3>
                    </div>
                    <div class="panel-body">
                        <div class="wid-icon-info">
                            <div>
                                Status : <small class="text-warning" id="server_status_color"><b id="server_status">WAIT</b></small>
                            </div>
                            <div>
                                IP : <small class="text-primary"><b id="server_ip"></b></small>
                            </div>
                            <div>
                                Players : <small class="text-primary"><b id="server_players"></b></small>
                            </div>
                            <div>
                                Map : <small class="text-primary"><b id="server_map"></b></small>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="panel panel-border panel-success">
                    <div class="panel-heading">
                        <h3 class="panel-title">Server Control</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-md-2 control-label">Server Name</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" placeholder="Server Name">
                            </div>
                            <label class="col-md-2 control-label">ModPack Name</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" placeholder="ModPack Name (exemple: @Server)">
                            </div>
                        </div>
                        <br><br>
                        <div class="form-group">
                            <label class="col-md-2 control-label">TeamSpeak</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" placeholder="TS3 server">
                            </div>
                            <label class="col-md-2 control-label">WebSite</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" placeholder="WebSite">
                            </div>
                        </div>
                        <br><br>
                        <div class="form-group">
                            <label class="col-md-2 control-label">IP</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" placeholder="Arma 3 IP">
                            </div>
                            <label class="col-md-2 control-label">PORT</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" placeholder="Arma 3 port (2302)">
                            </div>
                        </div>
                        <br><br>
                        <div class="form-group">
                            <label class="col-md-2 control-label">Local Path</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" placeholder="Path to local" disabled>
                            </div>
                            <label class="col-md-2 control-label">Game</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" placeholder="Arma3, CSGO" disabled>
                            </div>
                        </div>
                        <br><br><br>
                        <div class="text-right">
                            <button type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5">Save</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="panel panel-border panel-warning">
                    <div class="panel-heading">
                        <h3 class="panel-title">Server Access Control</h3>
                    </div>
                    <div class="panel-body text-center">
                        <button id="maintenance_button" type="button" class="btn btn-danger btn-custom waves-effect w-md waves-light m-b-5" onclick="maintenanceServer()" value="maintenance">Activate Maintenance</button>
                        <br>
                        <button id="lock_button" type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="lockServer()" value="lock">Lock Server</button>
                        <br>
                        <a href="#lock" class="btn btn-primary waves-effect waves-light" data-animation="blur" data-plugin="custommodal"
                           data-overlaySpeed="200" data-overlayColor="#36404a">Set password</a>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="col-lg-3">
                    <div class="panel panel-border panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Mods control</h3>
                        </div>
                        <div class="panel-body text-center">
                            <button type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="createModUpdate()">Create an update</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div class="row">
        <div class="col-md-12">
            <div id="lock" class="modal-demo text-center ">
                <button type="button" class="close" onclick="Custombox.close();">
                    <span>&times;</span><span class="sr-only">Close</span>
                </button>
                <h4 class="custom-modal-title">Set an server password</h4>
                <div class="custom-modal-text">
                    <input id="lock_password" type="text" class="form-control" placeholder="Server Password">
                    <br>
                    <div class="col-lg-12">
                        <div class="col-lg-6">
                            <button type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="Custombox.close();">Cancel</button>
                        </div>
                        <div class="col-lg-6">
                            <button type="button" class="btn btn-info btn-custom waves-effect w-md waves-light m-b-5" onclick="Custombox.close();setPass();">Set Password</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</div>




<?php include "jointures/footer.php";?>

<!-- jQuery  -->
<script src="/assets/js/jquery.min.js"></script>
<script src="/assets/js/bootstrap.min.js"></script>
<script src="/assets/js/detect.js"></script>
<script src="/assets/js/fastclick.js"></script>
<script src="/assets/js/jquery.blockUI.js"></script>
<script src="/assets/js/waves.js"></script>
<script src="/assets/js/wow.min.js"></script>
<script src="/assets/js/jquery.nicescroll.js"></script>
<script src="/assets/js/jquery.scrollTo.min.js"></script>
<script src="/assets/js/waiting.js"></script>

<!-- Moment  -->
<script src="/assets/plugins/moment/moment.js"></script>

<!-- Sweet Alert  -->
<script src="/assets/plugins/sweetalert/dist/sweetalert.min.js"></script>

<!-- skycons -->
<script src="/assets/plugins/skyicons/skycons.min.js" type="text/javascript"></script>

<!-- Todojs  -->
<script src="/assets/pages/jquery.todo.js"></script>

<!-- chatjs  -->
<script src="/assets/pages/jquery.chat.js"></script>

<!-- Notifications -->
<script src="/assets/plugins/notifyjs/dist/notify.min.js"></script>
<script src="/assets/plugins/notifications/notify-metro.js"></script>

<script src="/assets/js/jquery.core.js"></script>
<script src="/assets/js/jquery.app.js"></script>

<script src="/assets/plugins/custombox/dist/custombox.min.js"></script>
<script src="/assets/plugins/custombox/dist/legacy.min.js"></script>


</body>
</html>
