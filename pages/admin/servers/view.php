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
    <!-- jQuery  -->
    <script src="/assets/js/jquery.min.js"></script>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/waiting.js"></script>
    <script src="/assets/js/detect.js"></script>
    <script src="/assets/js/fastclick.js"></script>
    <script src="/assets/js/jquery.blockUI.js"></script>
    <script src="/assets/js/wow.min.js"></script>
    <script src="/assets/js/jquery.nicescroll.js"></script>
    <script src="/assets/js/jquery.scrollTo.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.5/jszip.js"></script>

</head>


<body onload="loadServer()">

<script>
    var path = null;
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
                    if (obj.locked == 1)
                    {
                        var button = document.getElementById("lock_button");
                        button.textContent = "UnLock Server";
                        button.value = "unlock";
                        button.className = "btn btn-success btn-custom waves-effect w-md waves-light m-b-5";
                    }
                    if (obj.haspass == 1)
                    {
                        var button = document.getElementById("server_button");
                        button.textContent = "UnSet Password";
                        button.value = "unpass";
                        button.className = "btn btn-success btn-custom waves-effect w-md waves-light m-b-5";
                    }

                    if (obj.taskforce == 1)
                    {
                        var button = document.getElementById("taskforce_button");
                        button.textContent = "Deactivate Taskforce";
                        button.value = "untaskforce";
                    }

                    if (obj.maintenance == 1)
                    {
                        var button = document.getElementById("maintenance_button");
                        button.textContent = "Deactivate Maintenance";
                        button.value = "unmaintenance";
                        button.className = "btn btn-success btn-custom waves-effect w-md waves-light m-b-5";
                    }

                    $('#server_name').val(obj.name);
                    $('#server_modpack').val(obj.modpack_name);
                    $('#server_teamspeak').val(obj.teamspeak);
                    $('#server_website').val(obj.website);
                    $('#server_ip2').val(obj.ip);
                    $('#server_port').val(obj.port);
                    $('#server_path').val(obj.local_path);
                    $('#server_game').val(obj.game);
                    $('#server_rank').val(obj.rank);
                    path = obj.local_path;
                    path = path.replace('games/', '');

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
        getDB();
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

    function createTaskForceUpdate()
    {
        $.post(
            '/api/server/admin/taskforce/update',
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
            },

            'text'
        );
    }

    function lockServer()
    {
        var button = document.getElementById("lock_button");

        if (button.value == "lock")
        {
            //MODAL
            Custombox.open({
                target: '#lock',
                effect: 'blur'
            });
        }
        else
        {
            $.post(
                '/api/server/admin/unlock',
                {
                    token : "<?php echo $_SESSION['token'];?>",
                    id : "<?php echo $id;?>"
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

    function serverPassword()
    {
        var button = document.getElementById("server_button");

        if (button.value == "pass")
        {
            //MODAL
            Custombox.open({
                target: '#password',
                effect: 'blur'
            });
        }
        else
        {
            $.post(
                '/api/server/admin/setpass/server',
                {
                    token : "<?php echo $_SESSION['token'];?>",
                    id : "<?php echo $id;?>",
                    password: "null"
                },

                function(data){
                    var obj = JSON.parse(data);
                    if (obj.status == 42)
                    {
                        $.Notification.notify('success','top right','Success !', "Server password set");
                        button.textContent = "Set server password";
                        button.value = "pass";
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
                        $.Notification.notify('success','top right','Server Maintenance', "Maintenance deactivated");
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

    function switch_taskforce()
    {
        var button = document.getElementById("taskforce_button");

        if (button.value == "taskforce")
        {
            $.post(
                '/api/server/admin/taskforce',
                {
                    token : "<?php echo $_SESSION['token'];?>",
                    id : "<?php echo $id;?>",
                    taskforce : 1
                },

                function(data){
                    var obj = JSON.parse(data);
                    if (obj.status == 42)
                    {
                        $.Notification.notify('warning','top right','Taskforce', "Taskforce activated");
                        button.textContent = "Deactivate Taskforce";
                        button.value = "untaskforce";
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
                '/api/server/admin/taskforce',
                {
                    token : "<?php echo $_SESSION['token'];?>",
                    id : "<?php echo $id;?>",
                    taskforce : 0
                },

                function(data){
                    var obj = JSON.parse(data);
                    if (obj.status == 42)
                    {
                        $.Notification.notify('success','top right','Taskforce', "Taskforce deactivated");
                        button.textContent = "Activate Taskforce";
                        button.value = "taskforce";
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

    function setLockPass()
    {
        $.post(
            '/api/server/admin/setpass/lock',
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

                    var button = document.getElementById("lock_button");

                    button.textContent = "UnLock Server";
                    button.value = "unlock";
                    button.className = "btn btn-success btn-custom waves-effect w-md waves-light m-b-5";
                }
                else if (obj.status == 41)
                    window.location="/logout";
                else
                    swal("Error...", obj.message, "error");
            },

            'text'
        );
    }


    function setServerPass()
    {
        $.post(
            '/api/server/admin/setpass/server',
            {
                token : "<?php echo $_SESSION['token'];?>",
                id : "<?php echo $id;?>",
                password : document.getElementById("server_password").value
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

                    var button = document.getElementById("server_button");

                    button.textContent = "UnSet Password";
                    button.value = "unpass";
                    button.className = "btn btn-success btn-custom waves-effect w-md waves-light m-b-5";
                }
                else if (obj.status == 41)
                    window.location="/logout";
                else
                    swal("Error...", obj.message, "error");
            },

            'text'
        );
    }

    
    function saveServer() {
        $.post(
            '/api/server/save',
            {
                token : "<?php echo $_SESSION['token'];?>",
                id : "<?php echo $id; ?>",
                name : $('#server_name').val(),
                local_path : $('#server_path').val(),
                modpack_name : $('#server_modpack').val(),
                ip : $('#server_ip2').val(),
                port : $('#server_port').val(),
                game : $('#server_game').val(),
                rank : $('#server_rank').val(),
                teamspeak : $('#server_teamspeak').val(),
                website : $('#server_website').val()
            },

            function(data){
                var obj = JSON.parse(data);

                if (obj.status == 42)
                {
                    $.Notification.notify('success','top right','Saved !', obj.message);
                }
                else if (obj.status == 41)
                    window.location="/logout";
                else
                    swal("Error...", obj.message, "error");
            },

            'text'
        );
    }
    function openBrowser() {
        window.location = "/servers/browse/" + path;
    }
    function showInfo(type) {
        if (type == 1)
        {
            $("#db_hostname").attr('type', 'text');
            $("#db_name").attr('type', 'text');
            $("#db_user").attr('type', 'text');
            $("#db_password").attr('type', 'text');

        }
        else
        {
            $("#db_hostname").attr('type', 'password');
            $("#db_name").attr('type', 'password');
            $("#db_user").attr('type', 'password');
            $("#db_password").attr('type', 'password');
        }
    }

    function saveDB() {
        $.post(
            '/api/server/admin/database/save',
            {
                token : "<?php echo $_SESSION['token'];?>",
                id : "<?php echo $id; ?>",
                db_host : $('#db_hostname').val(),
                db_name : $('#db_name').val(),
                db_user : $('#db_user').val(),
                db_pass : $('#db_password').val(),
                show_infos : $('#show_infos').val()
            },

            function(data){
                var obj = JSON.parse(data);

                if (obj.status == 42)
                {
                    $.Notification.notify('success','top right','Saved !', obj.message);
                }
                else if (obj.status == 41)
                    window.location="/logout";
                else
                    swal("Error...", obj.message, "error");
            },

            'text'
        );
    }

    function getDB() {
        $.post(
            '/api/server/admin/database/get',
            {
                token : "<?php echo $_SESSION['token'];?>",
                id : "<?php echo $id; ?>"
            },

            function(data){
                var obj = JSON.parse(data);

                if (obj.status == 42)
                {
                    $("#db_hostname").val(obj.db_host);
                    $("#db_name").val(obj.db_name);
                    $("#db_user").val(obj.db_user);
                    $("#db_password").val(obj.db_pass);
                    $("#show_infos option[value='" + obj.show_infos + "']").prop('selected', true);
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
        <div class="row">
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

                <div class="panel panel-border panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Mods control</h3>
                    </div>
                    <div class="panel-body text-center">
                        <button type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="createModUpdate()">Create an update</button>
                    </div>
                </div>

                <div class="panel panel-border panel-color">
                    <div class="panel-heading">
                        <h3 class="panel-title">Browse Files</h3>
                    </div>
                    <div class="panel-body text-center">
                        <button id="browse" type="button" class="btn btn-default btn-custom waves-effect w-md waves-light m-b-5" onclick="openBrowser()"  value="taskforce">Browse server</button>
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
                                <input type="text" class="form-control" id="server_name" placeholder="Server Name">
                            </div>
                            <label class="col-md-2 control-label">ModPack Name</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="server_modpack" placeholder="ModPack Name (exemple: @Server)">
                            </div>
                        </div>
                        <br><br>
                        <div class="form-group">
                            <label class="col-md-2 control-label">TeamSpeak</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="server_teamspeak" placeholder="TS3 server">
                            </div>
                            <label class="col-md-2 control-label">WebSite</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="server_website" placeholder="WebSite">
                            </div>
                        </div>
                        <br><br>
                        <div class="form-group">
                            <label class="col-md-2 control-label">IP</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="server_ip2" placeholder="Arma 3 IP">
                            </div>
                            <label class="col-md-2 control-label">PORT</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="server_port" placeholder="Arma 3 port (2302)">
                            </div>
                        </div>
                        <br><br>
                        <div class="form-group">
                            <label class="col-md-2 control-label">Local Path</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="server_path" placeholder="Path to local" disabled>
                            </div>
                            <label class="col-md-2 control-label">Game</label>
                            <div class="col-md-4">
                                <input type="text" class="form-control" id="server_game" placeholder="Arma3, CSGO" disabled>
                            </div>
                        </div>
                        <br><br>
                        <div class="form-group">
                            <label class="col-md-2 control-label">Rank</label>
                            <div class="col-md-10">
                                <input type="number" max="100" min="0" class="form-control" id="server_rank" placeholder="Rank">
                            </div>
                        </div>
                        <br><br><br>
                        <div class="text-right">
                            <button type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="saveServer()">Save</button>
                        </div>
                    </div>
                </div>
                <div class="panel panel-border panel-success">
                    <div class="panel-heading">
                        <h3 class="panel-title">In game config</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-md-2 control-label">DB Hostname</label>
                            <div class="col-md-4">
                                <input type="password" class="form-control" id="db_hostname" placeholder="Database hostname">
                            </div>
                            <label class="col-md-2 control-label">DB Name</label>
                            <div class="col-md-4">
                                <input type="password" class="form-control" id="db_name" placeholder="Database name">
                            </div>
                        </div>
                        <br><br>
                        <div class="form-group">
                            <label class="col-md-2 control-label">DB User</label>
                            <div class="col-md-4">
                                <input type="password" class="form-control" id="db_user" placeholder="Database user">
                            </div>
                            <label class="col-md-2 control-label">DB Password</label>
                            <div class="col-md-4">
                                <input type="password" class="form-control" id="db_password" placeholder="Database password">
                            </div>
                        </div>
                        <br><br>
                        <div class="form-group">
                            <label class="col-md-2 control-label">Show In-Game informations ?</label>
                            <div class="col-md-4">
                                <select class="form-control" id="show_infos">
                                    <option value="0">No</option>
                                    <option value="1">Yes</option>
                                </select>
                            </div>
                        </div>
                        <br><br><br>
                        <div class="text-right">
                            <button type="button" class="btn btn-primary btn-custom waves-effect w-md waves-light m-b-5" onmousedown="showInfo(1)" onmouseup="showInfo(0)" onmouseleave="showInfo(0)">Show info</button>
                            <button type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="saveDB()">Save</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end col -8 -->

            <div class="col-lg-3">

                <div class="panel panel-border panel-warning">
                    <div class="panel-heading">
                        <h3 class="panel-title">Server Access Control</h3>
                    </div>
                    <div class="panel-body text-center">
                        <button id="maintenance_button" type="button" class="btn btn-danger btn-custom waves-effect w-md waves-light m-b-5" onclick="maintenanceServer()" value="maintenance">Activate Maintenance</button>
                        <br>
                        <button id="lock_button" type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="lockServer()" value="lock">Lock Server</button>
                    </div>
                </div>

                <div class="panel panel-border panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Password Server Control</h3>
                    </div>
                    <div class="panel-body text-center">
                        <button type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="serverPassword()" value="pass" id="server_button">Set Server Password</button>
                    </div>
                </div>

                <div class="panel panel-border panel-purple">
                    <div class="panel-heading">
                        <h3 class="panel-title">Taskforce Radio Control</h3>
                    </div>
                    <div class="panel-body text-center">
                        <button id="taskforce_button" type="button" class="btn btn-purple btn-custom waves-effect w-md waves-light m-b-5" onclick="switch_taskforce()" value="taskforce">Activate Taskforce</button>
                    </div>

                    <div class="panel-body text-center">
                        <h3 class="panel-title text-warning">Taskforce Radio Update</h3>
                        <br>
                        <button id="taskforce_button_update" type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="createTaskForceUpdate()">Update Taskforce</button>
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
                    <h4 class="custom-modal-title">Set an lock password</h4>
                    <div class="custom-modal-text">
                        <input id="lock_password" type="text" class="form-control" placeholder="Server Password">
                        <br>
                        <div class="col-lg-12">
                            <div class="col-lg-6">
                                <button type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="Custombox.close();">Cancel</button>
                            </div>
                            <div class="col-lg-6">
                                <button type="button" class="btn btn-info btn-custom waves-effect w-md waves-light m-b-5" onclick="Custombox.close();setLockPass();">Lock server</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div id="password" class="modal-demo text-center ">
                    <button type="button" class="close" onclick="Custombox.close();">
                        <span>&times;</span><span class="sr-only">Close</span>
                    </button>
                    <h4 class="custom-modal-title">Set an server password</h4>
                    <div class="custom-modal-text">
                        <input id="server_password" type="text" class="form-control" placeholder="Server Password">
                        <br>
                        <div class="col-lg-12">
                            <div class="col-lg-6">
                                <button type="button" class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5" onclick="Custombox.close();">Cancel</button>
                            </div>
                            <div class="col-lg-6">
                                <button type="button" class="btn btn-info btn-custom waves-effect w-md waves-light m-b-5" onclick="Custombox.close();setServerPass();">Set Password</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</div>

<?php include "jointures/footer.php";?>

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
