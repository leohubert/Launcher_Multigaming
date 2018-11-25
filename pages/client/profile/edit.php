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


<body onload="loadUser()">

<script>
    function loadUser() {
        var userUID = null;
        $.post(
            '/api/users/client/get',
            {
                token : "<?php echo $_SESSION['token'];?>"
            },

            function(data){
                var obj = JSON.parse(data);
                if (obj.status == 42)
                {
                    document.getElementById("detail_username").textContent = obj.username;
                    document.getElementById("detail_email").textContent = obj.email;
                    document.getElementById("detail_picture").src = obj.picture;
                    document.getElementById("control_username").value = obj.username;
                    document.getElementById("control_email").value = obj.email;
                    document.getElementById("control_picture").value = obj.picture;
                    document.getElementById("control_last_ip").value = obj.last_ip;
                    document.getElementById("control_uid").value = obj.uid;
                    document.getElementById("level" + obj.level).selected = true;
                    document.getElementById("banned" + obj.banned).selected = true;
                    userUID = obj.user_uid;
                    var status = document.getElementById("detail_status");
                    switch (obj.level) {
                        case "1":
                            status.innerHTML = '<small class="text-primary"><b>Player</b></small>';
                            break;
                        case "2":
                            status.innerHTML = '<small class="text-info"><b>Policeman</b></small>';
                            break;
                        case "3":
                            status.innerHTML = '<small class="text-success"><b>Medic</b></small>';
                            break;
                        case "4":
                            status.innerHTML = '<small class="text-danger"><b>Rebel</b></small>';
                            break;
                        case "5":
                            status.innerHTML = '<small class="text-purple"><b>VIP</b></small>';
                            break;
                        case "6":
                            status.innerHTML = '<small class="text-purple"><b>Support</b></small>';
                            break;
                        case "7":
                            status.innerHTML = '<small class="text-warning"><b>Moderator</b></small>';
                            break;
                        case "8":
                            status.innerHTML = '<small class="text-danger"><b>Admin</b></small>';
                            break;
                        case "9":
                            status.innerHTML = '<small class="text-primary"><b>Developer</b></small>';
                            break;
                        case "10":
                            status.innerHTML = '<small class="text-info"><b>Founder</b></small>';
                            break;
                        default:
                            status.innerHTML = '<small class="text-danger"><b>AnY</b></small>';
                            break;
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
    function saveUser() {
        $.post(
            '/api/users/client/save',
            {
                token : "<?php echo $_SESSION['token'];?>",
                id : "<?php echo $id;?>",
                email : document.getElementById("control_email").value,
                uid : document.getElementById("control_uid").value,
                picture : document.getElementById("control_picture").value
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
    function changePassword() {
        $.post(
            '/api/users/client/changepass',
            {
                token : "<?php echo $_SESSION['token'];?>",
                current_pass : document.getElementById("password_currentpassword").value,
                new_pass : document.getElementById("password_newpassword").value,
                confirm_pass : document.getElementById("password_confirmpassword").value
            },

            function(data){
                var obj = JSON.parse(data);
                if (obj.status == 42)
                    $.Notification.notify('success','top right','Password changed !', obj.message);
                else if (obj.status == 41)
                    window.location="/logout";
                else
                    swal("Error...", obj.message, "error");
            },

            'text'
        );
    }
</script>

<?php include "jointures/header_client.php"?>
<div class="wrapper">
    <div class="container">

        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">Account editor
                </h4>
            </div>
        </div>
        <div class="col-sm-2 col-lg-2"></div>
        <div class="col-sm-6 col-lg-3">
            <div class="card-box widget-user">
                <div>
                    <img src="/assets/images/default_user.png" id="detail_picture" class="img-responsive img-circle" alt="user">
                    <div class="wid-u-info">
                        <h4 class="m-t-0 m-b-5" id="detail_username"></h4>
                        <p class="text-muted m-b-5 font-13" id="detail_email"></p>
                        <div id="detail_status"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-5 col-lg-5">
            <div class="panel panel-color panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Account control</h3>
                </div>
                <div class="panel-body">
                    <p>
                    <div id="banned_pop"></div>
                    <div class="form-group">
                        <div class="col-sm-6">
                            <input type="text" class="form-control"  placeholder="Username" id="control_username" disabled>
                        </div>
                        <div class="col-sm-6">
                            <input type="text" class="form-control"  placeholder="Email" id="control_email">
                        </div>
                    </div>
                    <br><br>
                    <div class="form-group">
                        <div class="col-sm-6">
                            <input type="text" class="form-control"  placeholder="IP" id="control_last_ip" readonly>
                        </div>
                        <div class="col-sm-6">
                            <input type="text" class="form-control"  placeholder="Steam UID" id="control_uid">
                        </div>
                    </div>
                    <br><br>
                    <div class="form-group">
                        <div class="col-sm-12">
                            <input type="text" class="form-control"  placeholder="Picture" id="control_picture">
                        </div>
                    </div>
                    <br>
                    <br>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <select id="control_level" class="form-control" disabled>
                                <option id="level0" value="0" selected>No valided</option>
                                <option id="level1" value="1">Player</option>
                                <option id="level2" value="2">Policeman</option>
                                <option id="level3" value="3">Medic</option>
                                <option id="level4" value="4">Rebel</option>
                                <option id="level5" value="5">VIP</option>
                                <option id="level6" value="6">Support</option>
                                <option id="level7" value="7">Moderator</option>
                                <option id="level8" value="8">Admin</option>
                                <option id="level9" value="9">Developer</option>
                                <option id="level10" value="10">Founder</option>
                            </select>
                        </div>
                        <div class="col-sm-2 text-center">
                            Banned ?
                        </div>
                        <div class="col-sm-4">
                            <select id="control_banned" class="form-control" disabled>
                                <option id="banned0" value="0" selected>No</option>
                                <option id="banned1" value="1">Yes</option>
                            </select>
                        </div>
                    </div>
                    </p>
                </div>
                <div class="panel-footer">
                    <button data-toggle="modal" data-target="#PasswordChange" type="button"  class="btn btn-warning btn-custom waves-effect w-md waves-light m-b-5">Change password</button>
                    <button type="button" class="btn btn-success btn-custom waves-effect w-md waves-light m-b-5" onclick="saveUser()">Save</button>
                </div>
            </div>
        </div>
    </div>
</div>

<div id="PasswordChange" class="modal fade" role="dialog" style="display: none;">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title">Change password</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="field-1" class="control-label">Current password</label>
                            <input type="password" class="form-control" id="password_currentpassword" placeholder="Current password">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="field-1" class="control-label">New password</label>
                            <input type="password" class="form-control" id="password_newpassword" placeholder="New password">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="field-1" class="control-label">Confirm password</label>
                            <input type="password" class="form-control" id="password_confirmpassword" placeholder="Confirm password">
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-info waves-effect waves-light" onclick="changePassword()">Change password</button>
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

<script src="../../assets/plugins/custombox/dist/custombox.min.js"></script>
<script src="/assets/plugins/custombox/dist/legacy.min.js"></script>


</body>
</html>
