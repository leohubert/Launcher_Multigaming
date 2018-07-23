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



    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>

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
                    document.getElementById("user_uid").innerHTML = obj.uid;
                    userUID = obj.uid;
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
                    $.post(
                        '/api/server/client/players/get',
                        {
                            token : "<?php echo $_SESSION['token'];?>",
                            id : 64
                        },

                        function(data){
                            var obj = JSON.parse(data);
                            if (obj.status == 42) {
                                document.getElementById("player_cash").innerText = obj.cash;
                                document.getElementById("player_bank").innerText = obj.bank;
                                document.getElementById("player_name").innerText = obj.name;
                                document.getElementById("player_adminlevel").innerText = obj.adminlevel;
                                document.getElementById("player_mediclevel").innerText = obj.mediclevel;
                                document.getElementById("player_coplevel").innerText = obj.coplevel;
                            }
                            else if (obj.status == 40) {
                                document.getElementById("player_cash").innerText = "Not found";
                                document.getElementById("player_bank").innerText = "Not found";
                                document.getElementById("player_name").innerText = "Not found";
                                document.getElementById("player_adminlevel").innerText = "Not found";
                                document.getElementById("player_mediclevel").innerText = "Not found";
                                document.getElementById("player_coplevel").innerText = "Not found";
                            }
                            else if (obj.status == 41)
                                window.location="/logout";
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
</script>

<?php include "jointures/header_client.php"?>
<div class="wrapper">
    <div class="container">

        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">Profile view
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
        <div class="col-sm-5 col-lg-4">
            <div class="widget-simple text-center card-box">
                <p class="text-muted font-500">Steam UID</p>
                <h3 class="text-info" id="user_uid">...</h3>
                <div class="widget-simple text-center card-box">
                    <p class="text-muted font-500">In game money</p>
                    <div class="row">
                        <div class="col-sm-6">
                            <p class="text-muted font-500">CASH</p>
                            <h3 class="text-warning">$ <span class="counter" id="player_cash">0</span></h3>
                        </div>
                        <div class="col-sm-6">
                            <p class="text-muted font-500">BANK</p>
                            <h3 class="text-primary">$ <span class="counter" id="player_bank">0</span></h3>
                        </div>
                    </div>
                </div>
                <div class="widget-simple text-center card-box">
                    <p class="text-muted font-500">In game information</p>
                    <div class="row">
                        <div class="col-sm-6">
                            <p class="text-muted font-500">Username</p>
                            <h3 class="text-info" id="player_name">.</h3>
                        </div>
                        <div class="col-sm-6">
                            <p class="text-muted font-500">Admin level</p>
                            <h3 class="text-info"><span class="counter" id="player_adminlevel">0</span></h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <p class="text-muted font-500">Cop level</p>
                            <h3 class="text-info" id="player_coplevel">0</h3>
                        </div>
                        <div class="col-sm-6">
                            <p class="text-muted font-500">Medic level</p>
                            <h3 class="text-info"><span class="counter" id="player_mediclevel">0</span></h3>
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

<script src="assets/plugins/custombox/dist/custombox.min.js"></script>
<script src="assets/plugins/custombox/dist/legacy.min.js"></script>


</body>
</html>
