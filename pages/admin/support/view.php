<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="launcherPanel">
    <meta name="author" content="Leo HUBERT">
    <meta name="token" content="<?php echo $_SESSION['token'];?>">
    <meta name="id" content="<?php echo $match['params']['id'];?>">

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


<body>

    <?php include "jointures/header_admin.php"?>



<div class="wrapper">
    <div class="container">

        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title"><?php echo L::support_title; ?></h4>
            </div>
        </div>

        <div class="col-lg-7">
            <div class="card-box">
                <h4 class="m-t-0 m-b-20 header-title"><b><?php echo L::support_chat; ?></b></h4>

                <div class="chat-conversation">
                    <ul id="chat" class="conversation-list nicescroll" tabindex="5002">

                    </ul>
                    <div class="row">
                        <div class="col-sm-9 chat-inputbar">
                            <input id="chat_message" type="text" class="form-control chat-input" placeholder="Enter your text">
                        </div>
                        <div class="col-sm-3 chat-send">
                            <button type="submit" class="btn btn-md btn-primary btn-block waves-effect waves-light"><?php echo L::support_send; ?></button>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="col-lg-5">
            <div class="panel panel-color panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><?php echo L::support_title; ?></h3>
                </div>
                <div class="panel-body">
                    <p>
                        <input id="support_title" type="text" name="state-success" class="form-control" placeholder="Support title ...">
                        <br>
                        <select id="support_status" class="form-control">
                            <option selected id="support_status0" value="0"><?php echo L::support_status_notassign; ?></option>
                            <option id="support_status1" value="1"><?php echo L::support_status_assign; ?></option>
                            <option id="support_status2" value="2"><?php echo L::support_status_inprogress; ?></option>
                            <option id="support_status3" value="3"><?php echo L::support_status_done; ?></option>
                            <option id="support_status4" value="4"><?php echo L::support_status_close; ?></option>
                        </select>
                    </p>
                </div>
                <div class="panel-footer">
                    <button type="button" class="btn btn-success btn-custom waves-effect w-md waves-light m-b-5" onclick="assign_support(<?php echo $id;?>)"><?php echo L::support_assigntome; ?></button>
                    <button type="button" class="btn btn-primary btn-custom waves-effect w-md waves-light m-b-5" onclick="save_support(<?php echo $id;?>)"><?php echo L::support_save; ?></button>
                </div>
            </div>
        </div>

        <?php include "jointures/footer.php";?>
    
        </div> <!-- end container -->
    </div>
    <!-- End wrapper -->
    
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
    
    <!-- Load Pages Script -->
    <script src="/assets/js/pages/admin/support_view.js"></script>
    
    </body>
</html>
