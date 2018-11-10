<?php
$mysql = false;
if (file_exists("configs/config_mysql.php"))
    $mysql = true;
if (file_exists("configs/config_general.php"))
    $general = true;
?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="launcherPanel">
    <meta name="author" content="Leo HUBERT">

    <link rel="shortcut icon" href="assets/images/favicon_1.ico">

    <title><?php echo $site; ?> launcher install</title>

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/core.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/components.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/menu.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css"/>
    <link href="assets/plugins/switchery/switchery.min.css" rel="stylesheet"/>


    <link href="assets/plugins/sweetalert/dist/sweetalert.css" rel="stylesheet" type="text/css">
    <link href="assets/plugins/jquery-circliful/css/jquery.circliful.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->

    <script src="assets/js/modernizr.min.js"></script>

</head>

<script type="application/javascript">
    var inprogress = 0;

    function testMysql() {
        if (inprogress == 1) {
            sweetAlert("Test already in progress", "You can not run two tests simultaneously", "error");
            return;
        }
        inprogress = 1;
        var obj;
        var loading = document.getElementById("mysql_loading");
        var status = document.getElementById("mysql_status");
        var save_button = document.getElementById("mysql_save");

        save_button.innerHTML = "";

        loading.className = "md md-cached text-primary fa-spin";
        status.innerHTML = '<small class="text-info"><b>Test in progress</b></small>';
        $.post(
            '/test_mysql',
            {
                db_host: document.getElementById("mysql_host").value,
                db_name: document.getElementById("mysql_name").value,
                db_user: document.getElementById("mysql_user").value,
                db_pass: document.getElementById("mysql_pass").value
            },

            function (data) {
                obj = JSON.parse(data);
            },

            'text'
        );

        setTimeout(function () {
            loading.className = "md md-cached text-primary";
            switch (obj.status) {
                case 42:
                    status.innerHTML = '<small class="text-success"><b>Success</b></small>';
                    save_button.innerHTML = '<br><button onclick="saveMysql()" type="button" class="btn btn-success btn-rounded w-md waves-effect waves-light m-b-5">Save & inject</button>';
                    break;
                default:
                    status.innerHTML = '<small class="text-danger"><b>Error | ' + obj.message + '</b></small>';
                    break;
            }
            inprogress = 0;
        }, 2000);
    }

    function saveMysql() {
        $.post(
            '/inject_mysql',
            {
                db_host: document.getElementById("mysql_host").value,
                db_name: document.getElementById("mysql_name").value,
                db_user: document.getElementById("mysql_user").value,
                db_pass: document.getElementById("mysql_pass").value
            },

            function (data) {
                obj = JSON.parse(data)
                if (obj.status == 42)
                    sweetAlert("Save & Inject successfully", obj.message, "success");
                else
                    sweetAlert("Oops...", "Error | " + obj.message, "error");
            },

            'text'
        );
    }

    function finishInstall() {
        var token1 = "<?php echo base64_encode(openssl_random_pseudo_bytes(32)); ?>";
        var token2 = "<?php echo base64_encode(openssl_random_pseudo_bytes(64)) ?>";
        var obj;
        $.post(
            '/test_mysql',
            {
                db_host: document.getElementById("mysql_host").value,
                db_name: document.getElementById("mysql_name").value,
                db_user: document.getElementById("mysql_user").value,
                db_pass: document.getElementById("mysql_pass").value
            },

            function (data) {
                obj = JSON.parse(data);
                if (obj.status == 42) {
                    $.post(
                        '/finish_install',
                        {
                            user_email: document.getElementById("user_email").value,
                            user_name: document.getElementById("user_name").value,
                            user_password: document.getElementById("user_password").value,
                            user_confpassword: document.getElementById("user_confpassword").value,
                            token1: token1,
                            token2: token2,
                            db_host: document.getElementById("mysql_host").value,
                            db_name: document.getElementById("mysql_name").value,
                            db_user: document.getElementById("mysql_user").value,
                            db_pass: document.getElementById("mysql_pass").value
                        },

                        function (data) {
                            obj = JSON.parse(data);
                            if (obj.status == 42) {
                                $.post(
                                    '/save_config',
                                    {
                                        token1: token1,
                                        token2: token2,
                                        analytics: $('#analytics-checkbox').is(':checked'),
                                        server_name: document.getElementById("server_name").value,
                                        server_name_hide: document.getElementById("server_name_hide").value,
                                        db_host: document.getElementById("mysql_host").value,
                                        db_name: document.getElementById("mysql_name").value,
                                        db_user: document.getElementById("mysql_user").value,
                                        db_pass: document.getElementById("mysql_pass").value
                                    },

                                    function (data) {
                                        obj = JSON.parse(data);
                                        if (obj.status == 42) {
                                            window.location = "/install_finish";
                                        }
                                        else {
                                            sweetAlert("Oops...", "Error | " + obj.message, "error");
                                        }
                                    },

                                    'text'
                                );
                            }
                            else {
                                sweetAlert("Oops...", "Error | " + obj.message, "error");
                            }
                        },

                        'text'
                    );
                }
                else {
                    sweetAlert("Oops...", "Error | " + obj.message, "error");
                }
            },

            'text'
        );
    }

    function testMysqlArma() {
        if (inprogress == 1) {
            sweetAlert("Test already in progress", "You can not run two tests simultaneously", "error");
            return;
        }
        inprogress = 1;
        var obj;
        var loading = document.getElementById("mysql_arma_loading");
        var status = document.getElementById("mysql_arma_status");
        var save_button = document.getElementById("mysql_arma_save");

        save_button.innerHTML = "";

        loading.className = "md md-cached text-primary fa-spin";
        status.innerHTML = '<small class="text-info"><b>Test in progress</b></small>';
        $.post(
            '/test_mysql',
            {
                db_host: document.getElementById("mysql_arma_host").value,
                db_name: document.getElementById("mysql_arma_name").value,
                db_user: document.getElementById("mysql_arma_user").value,
                db_pass: document.getElementById("mysql_arma_pass").value
            },

            function (data) {
                obj = JSON.parse(data);
            },

            'text'
        );
    }
</script>

<body>
<header id="topnav">
    <div class="topbar-main">
        <div class="container">

            <!-- Logo container-->
            <div class="logo">
                <a href="/" class="logo"><i class="md md-equalizer"></i> <span><?php echo $site; ?>
                        launcher install</span> </a>
            </div>
            <!-- End Logo container-->

            <div class="menu-extras">

                <ul class="nav navbar-nav navbar-right pull-right">
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle waves-effect waves-light profile" data-toggle="dropdown"
                           aria-expanded="true"><img src="/install/images/install_logo.png" alt="user-img"
                                                     class="img-circle"> </a>
                    </li>
                </ul>
            </div>
        </div>

    </div>
    <div class="navbar-custom">

        <!-- Navigation Menu-->
        <div class="col-lg-12">

            <div id="progressbarwizard" class="pull-in">
                <ul>
                    <li><a href="#mysql" data-toggle="tab">Mysql</a></li>
                    <li><a href="#analytics" data-toggle="tab">Analytics <span
                                    class="label label-purple">NEW !</span></a></li>
                    <li><a href="#useradmin" data-toggle="tab">Admin</a></li>
                </ul>

                <div class="tab-content bx-s-0 m-b-0">

                    <div id="bar" class="progress progress-striped active">
                        <div class="bar progress-bar progress-bar-primary"></div>
                    </div>

                    <div class="tab-pane p-t-10 fade" id="mysql">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group clearfix">
                                    <label class="col-md-2 control-label " for="server_name">Server name</label>
                                    <div class="col-md-5">
                                        <input class="form-control required" id="server_name" name="server_name"
                                               type="text" <?php if (!empty($site) && $general == true){
                                            echo 'placeholder="' . $site . '"';
                                            echo 'value="' . $site . '"';
                                        }else{
                                            echo 'placeholder="Insert here your Community Name"';
                                            echo 'value="Insert here your Community Name"';
                                        }; ?>>

                                        <input class="form-control required" id="server_name_hide" name="server_name_hide"
                                               type="hidden" <?php if ($general == true) {
                                            echo 'placeholder="' . $site . '"';
                                            echo 'value="' . $site . '"';
                                        }else{
                                            echo 'placeholder="Insert here your Community Name"';
                                            echo 'value="Insert here your Community Name"';
                                        }; ?> required>
                                    </div>
                                </div>
                                <br><br>
                                <div class="form-group clearfix">
                                    <label class="col-md-2 control-label " for="mysql_host">MySql host</label>
                                    <div class="col-md-5">
                                        <input class="form-control required" id="mysql_host" name="mysql_host"
                                               type="text" <?php if ($mysql == true) {
                                            echo 'value="' . $mysql_host . '"';
                                        }; ?>>
                                    </div>
                                </div>
                                <div class="form-group clearfix">
                                    <label class="col-md-2 control-label " for="mysql_name">MySql database name</label>
                                    <div class="col-md-5">
                                        <input id="mysql_name" name="mysql_name" type="text"
                                               class="required form-control" <?php if ($mysql == true) {
                                            echo 'value="' . $mysql_dbname . '"';
                                        }; ?>>
                                    </div>
                                </div>

                                <div class="form-group clearfix">
                                    <label class="col-md-2 control-label " for="mysql_user">MySql username</label>
                                    <div class="col-md-5">
                                        <input id="mysql_user" name="mysql_user" type="text"
                                               class="required form-control" <?php if ($mysql == true) {
                                            echo 'value="' . $mysql_user . '"';
                                        }; ?>>
                                    </div>
                                </div>

                                <div class="form-group clearfix">
                                    <label class="col-md-2 control-label " for="mysql_pass">MySql password</label>
                                    <div class="col-md-5">
                                        <input id="mysql_pass" name="mysql_pass" type="password"
                                               class="required form-control" <?php if ($mysql == true) {
                                            echo 'value="' . $mysql_pass . '"';
                                        }; ?>>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-md-7">
                                    <div class="card-box widget-icon">
                                        <div>
                                            <i class="md md-cached text-primary" id="mysql_loading"></i>
                                            <div class="wid-icon-info">
                                                <p class="text-muted m-b-5 font-13 text-uppercase">Mysql status</p><br>
                                                <button onclick="testMysql()" type="button"
                                                        class="btn btn-primary btn-rounded w-md waves-effect waves-light m-b-5">
                                                    Test connection
                                                </button>
                                                <br><br>
                                                <div id="mysql_status"><?php if ($mysql == true) {
                                                        echo '<small class="text-success">Already configured<b></b>';
                                                    } else {
                                                        echo '<small class="text-pink"><b>No set</b>';
                                                    }; ?></small></div>
                                                <div id="mysql_save"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane p-t-10 fade" id="analytics">
                        <div class="row">
                            <div class="form-group clearfix">
                                <div class="col-lg-12">
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card-box widget-icon">
                                            <div>
                                                <i class="md md-help text-default"></i>
                                                <div class="wid-icon-info">
                                                    <h1> Emodyz Support </h1>

                                                    <div class="col-md-12">
                                                                <span id="FR-ANALYTICS">
                                                                    <b>Français :<br><br></b>

Support Emodyz, qu'est-ce que c'est?<br>
<br>
Emodyz Support est un système mis en place dans le Panel du Launcher qui nous permet d'avoir un retour des bugs, des fonctionnalités utilisées etc ... À savoir qu'aucune information personnelle telle que les emails, Steam UID ou autre n'est récupérée.<br>
<br>
Vous pouvez accéder à vos donnée depuis le panel du launcher grâce au bouton "Emodyz Support Access" (visible uniquement si Analytics activé)<br>
<br>
Nous collectons uniquement le nombre de joueurs que vous avez, le nombre de serveurs que vous avez et les fonctionnalités les plus utilisées.<br>
<br>
Voici une liste des données collectées:<br>
<br>
Nom du serveur<br>
Version Panel & Launcher<br>
Nombre de joueurs<br>
Nombre de serveurs<br><br>
En plus de cela, nous récupérons les crash du Panel pour le réparer.<br>

Si vous ne souhaitez pas faire partie d'Emodyz Support lors de l'installation, vous avez la possibilité de le désactiver dans l'onglet Analytics.<br>
                                                                </span>
                                                    </div>
                                                    <div class="col-md-12">
                                                                <span id="EN-ANALYTICS">
                                                                    What is Emodyz support? <br>
<br>
Emodyz Support is a system set up in the Launcher's Panel that allows us to have a return of the bugs, the functionalities used etc ... To know that no personal information such as emails, Steam UID or other is recovered. <br>
<br>
You can access your data from the launcher panel with the "Emodyz Support Access" button (visible only if Analytics enabled) <br>
<br>
We only collect the number of players you have, the number of servers you have and the most used features. <br>
<br>
Here is a list of the data collected: <br>
<br>
Server name <br>
Panel & Launcher Version <br>
Number of players <br>
Number of servers <br> <br>
In addition to that, we recover the Panel's crashes to fix it. <br>

If you do not want to be part of Emodyz Support during the installation, you have the option to disable it in the Analytics tab. <br>
                                                                </span>
                                                    </div>
                                                    <br><br><br><br>
                                                    <div class="checkbox checkbox-purple">
                                                        <input id="analytics-checkbox" type="checkbox" checked>
                                                        <label for="analytics-checkbox">
                                                            Accepter le support d'Emodyz ?
                                                        </label>
                                                    </div>
                                                    <br><br><br>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane p-t-10 fade" id="useradmin">
                        <div class="row">
                            <div class="form-group clearfix">
                                <div class="col-lg-12">
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card-box widget-icon">
                                            <div>
                                                <i class="md md-accessibility text-primary"></i>
                                                <div class="wid-icon-info">
                                                    <label class="col-md-4 control-label " for="user_email">User
                                                        email *</label>
                                                    <input class="form-control required" id="user_email"
                                                           name="user_email" type="text">
                                                    <label class="col-md-4 control-label " for="user_name">User
                                                        name *</label>
                                                    <input class="form-control required" id="user_name"
                                                           name="user_name" type="text">
                                                    <label class="col-md-4 control-label " for="user_password">User
                                                        password *</label>
                                                    <input class="form-control required" id="user_password"
                                                           name="user_password" type="password">
                                                    <label class="col-md-4 control-label "
                                                           for="user_confpassword">Confirm password *</label>
                                                    <input class="form-control required" id="user_confpassword"
                                                           name="user_confpassword" type="password"><br>
                                                    <center>
                                                        <button type="button"
                                                                class="btn btn-success btn-rounded w-md waves-effect waves-light m-b-5"
                                                                onclick="finishInstall()">Finish install
                                                        </button>
                                                    </center>
                                                    <br>
                                                    <h4>*: required</h4>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <ul class="pager m-b-0 wizard">
                        <li class="previous"><a href="#" class="btn btn-primary waves-effect waves-light">Previous</a>
                        </li>
                        <li class="next"><a href="#" class="btn btn-primary waves-effect waves-light">Next</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- End navigation menu -->
    </div>
    <!-- End topbar -->
</header>
<!-- =======================
     ===== START PAGE ======
     ======================= -->

<div class="wrapper">
    <div class="container">


        <?php include "jointures/footer.php"; ?>
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

<script src="assets/plugins/bootstrap-wizard/jquery.bootstrap.wizard.js"></script>
<script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>

<!-- Custom main Js -->
<script src="assets/js/jquery.core.js"></script>
<script src="assets/js/jquery.app.js"></script>

<!-- Sweet-Alert  -->
<script src="assets/plugins/sweetalert/dist/sweetalert.min.js"></script>
<script src="assets/pages/jquery.sweet-alert.init.js"></script>


<script type="text/javascript">
    $(document).ready(function () {
        $('#basicwizard').bootstrapWizard({'tabClass': 'nav nav-tabs navtab-custom nav-justified'});

        var userLang = navigator.language || navigator.userLanguage;

        if (userLang == "fr-FR") {
            $('#EN-ANALYTICS').hide();
        }  else {
            $('#FR-ANALYTICS').hide();
        }
        $('#progressbarwizard').bootstrapWizard({
            onTabShow: function (tab, navigation, index) {
                var $total = navigation.find('li').length;
                var $current = index + 1;
                var $percent = ($current / $total) * 100;
                $('#progressbarwizard').find('.bar').css({width: $percent + '%'});
            },
            'tabClass': 'nav nav-tabs navtab-custom nav-justified'
        });

        $('#btnwizard').bootstrapWizard({
            'tabClass': 'nav nav-tabs navtab-custom nav-justified',
            'nextSelector': '.button-next',
            'previousSelector': '.button-previous',
            'firstSelector': '.button-first',
            'lastSelector': '.button-last'
        });

        var $validator = $("#commentForm").validate({
            rules: {
                emailfield: {
                    required: true,
                    email: true,
                    minlength: 3
                },
                namefield: {
                    required: true,
                    minlength: 3
                },
                urlfield: {
                    required: true,
                    minlength: 3,
                    url: true
                }
            }
        });

        $('#rootwizard').bootstrapWizard({
            'tabClass': 'nav nav-tabs navtab-custom nav-justified',
            'onNext': function (tab, navigation, index) {
                var $valid = $("#commentForm").valid();
                if (!$valid) {
                    $validator.focusInvalid();
                    return false;
                }
            }
        });
    });

</script>


</body>
</html>