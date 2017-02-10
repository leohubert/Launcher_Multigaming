<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="{{ config('app.name') }} Admin Panel" />
    <meta name="author" content="" />

    <link rel="icon" href="/assets/images/favicon.ico">

    <title>{{ config('app.name') }} | Admin Panel</title>

    <link rel="stylesheet" href="/assets/js/jquery-ui/css/no-theme/jquery-ui-1.10.3.custom.min.css">
    <link rel="stylesheet" href="/assets/css/font-icons/entypo/css/entypo.css">
    <link rel="stylesheet" href="//fonts.googleapis.com/css?family=Noto+Sans:400,700,400italic">
    <link rel="stylesheet" href="/assets/css/bootstrap.css">
    <link rel="stylesheet" href="/assets/css/neon-core.css">
    <link rel="stylesheet" href="/assets/css/neon-theme.css">
    <link rel="stylesheet" href="/assets/css/neon-forms.css">
    <link rel="stylesheet" href="/assets/css/custom.css">
    <link rel="stylesheet" href="assets/css/skins/cafe.css">

    <script src="/assets/js/jquery-1.11.3.min.js"></script>

    <!--[if lt IE 9]><script src="/assets/js/ie8-responsive-file-warning.js"></script><![endif]-->

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->


</head>
<body class="page-body page-fade" data-url="/">

<div class="page-container"><!-- add class "sidebar-collapsed" to close sidebar by default, "chat-visible" to make chat appear always -->

    @include('inc.sidebar')

    <div class="main-content">

        @include('inc.header')


        <hr />

        @yield('content')

        @include('inc.footer')

    </div>


    @include('inc.chat')


</div>


<!-- Imported styles on this page -->
<link rel="stylesheet" href="/assets/js/jvectormap/jquery-jvectormap-1.2.2.css">
<link rel="stylesheet" href="/assets/js/rickshaw/rickshaw.min.css">

<!-- Bottom scripts (common) -->
<script src="/assets/js/gsap/TweenMax.min.js"></script>
<script src="/assets/js/jquery-ui/js/jquery-ui-1.10.3.minimal.min.js"></script>
<script src="/assets/js/bootstrap.js"></script>
<script src="/assets/js/joinable.js"></script>
<script src="/assets/js/resizeable.js"></script>
<script src="/assets/js/neon-api.js"></script>
<script src="/assets/js/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>


<!-- Imported scripts on this page -->
<script src="/assets/js/jvectormap/jquery-jvectormap-europe-merc-en.js"></script>
<script src="/assets/js/jquery.sparkline.min.js"></script>
<script src="/assets/js/rickshaw/vendor/d3.v3.js"></script>
<script src="/assets/js/rickshaw/rickshaw.min.js"></script>
<script src="/assets/js/raphael-min.js"></script>
<script src="/assets/js/morris.min.js"></script>
<script src="/assets/js/toastr.js"></script>
<script src="/assets/js/neon-chat.js"></script>


<!-- JavaScripts initializations and stuff -->
<script src="/assets/js/neon-custom.js"></script>


<!-- Demo Settings -->
<script src="/assets/js/neon-demo.js"></script>

</body>
</html>