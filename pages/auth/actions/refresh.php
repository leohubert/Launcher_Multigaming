<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 29/06/2016
 * Time: 22:30
 */
if (isset($_GET['page']))
{
    if (isset($_GET['auto']) && $_GET['auto'] == "true" && isset($_GET['token']))
        echo "<body onload='connectWithToken(\"" . $_GET['token'] ."\",\"" . $_GET['page'] ."\")';>";
    else if (isset($_COOKIE['token']))
        echo "<body onload='connectWithToken(\"" . $_COOKIE['token'] ."\",\"" . $_GET['page'] ."\")';>";
    else
        header('location: /');
}
else
    header('location: /');
?>
<script>
    function connectWithToken(token, page)
    {
        $.post(
            '/api/login',
            {
                token : token
            },

            function(data){
                var obj = JSON.parse(data);

                if (obj.status == 42)
                    window.location = page;
                else
                    windows.location = "/logout";
            },

            'text'
        );
        return false;
    }
</script>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <meta name="description" content="launcherPanel">
    <meta name="author" content="Leo HUBERT">

    <link rel="shortcut icon" href="assets/images/favicon_1.ico">

    <title><?php echo $site;?> refresh</title>

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="assets/css/core.css" rel="stylesheet" type="text/css">
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css">
    <link href="assets/css/components.css" rel="stylesheet" type="text/css">
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css">
    <link href="assets/css/menu.css" rel="stylesheet" type="text/css">
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css">
</head>
<body>


<div class="wrapper-page">
</div>
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

</body>
</html>