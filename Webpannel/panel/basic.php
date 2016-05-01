<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 01/05/2016
 * Time: 00:38
 */

include "../config/config.php";
require "../class/Session.class.php";
require "../class/Request.class.php";

Session::start();

if (!isset($_SESSION['username']))
    header ("location: /");

$fields = array();
$options = request($apiUrl . "options.php", $fields);

?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title><?php echo $siteName; ?></title>

    <!-- Bootstrap core CSS -->

    <link href="css/bootstrap.min.css" rel="stylesheet">

    <link href="css/bootstrap-toggle.css" rel="stylesheet">

    <link href="fonts/css/font-awesome.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet">

    <!-- Custom styling plus plugins -->
    <link href="css/custom.css" rel="stylesheet">
    <link href="css/icheck/flat/green.css" rel="stylesheet">
    <!-- ion_range -->
    <link rel="stylesheet" href="css/normalize.css" />
    <link rel="stylesheet" href="css/ion.rangeSlider.css" />
    <link rel="stylesheet" href="css/ion.rangeSlider.skinFlat.css" />

    <!-- colorpicker -->
    <link href="css/colorpicker/bootstrap-colorpicker.min.css" rel="stylesheet">

    <script src="js/jquery.min.js"></script>
</head>


<body class="nav-md">
<div class="container body">


    <div class="main_container">

        <?php
            include "jointures/sidebar.php";
            include "jointures/header.php";
        ?>

        <!-- page content -->
        <div class="right_col" role="main">

            <div class="">
                <div class="page-title">
                    <div class="title_left">
                        <h3>
                            Launcher settings
                        </h3>
                    </div>
                </div>
                <div class="clearfix"></div>



                <div class="row">

                    <!-- form input mask -->
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Basic settings</h2>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <br />
                                <div class="col-md-6 col-sm-12 col-xs-12">
                                    <h2>Maintenance statut:
                                        <?php
                                            if ($options->{'maintenance'} == "1")
                                                echo '<button id="maintenancebtn" onclick="maintenance()" class="btn btn-success" >Actived</button>';
                                            else
                                                echo '<button id="maintenancebtn" onclick="maintenance()" class="btn btn-danger" >Deactivated</button>'
                                        ?>
                                    </h2>
                                    <h2>Maintenance message:</h2>
                                    <input type="text" id="maintenancemsg" size="35" value="<?php echo $options->{'maintenance_msg'};?>">
                                    <button id="maintenancerefresh" onclick="maintenance_msg()" class="btn btn-info" >Save</button>
                                    <h2>Staff message statut:
                                        <?php
                                        if ($options->{'news'} == "1")
                                            echo '<button id="newsbtn" onclick="news()" class="btn btn-success" >Actived</button>';
                                        else
                                            echo '<button id="newsbtn" onclick="news()" class="btn btn-danger" >Deactivated</button>'
                                        ?>
                                    </h2>
                                    <h2>Staff message:</h2>
                                    <input type="text" id="newsmsg" size="35" value="<?php echo $options->{'news_msg'};?>">
                                    <button id="newsrefresh" onclick="news_msg()" class="btn btn-info" >Save</button>
                                </div>
                                <div class="col-md-6 col-sm-12 col-xs-12">
                                     <h2>Login statut:
                                      <?php
                                        if ($options->{'login'} == "1")
                                           echo '<button id="loginbtn" onclick="login()" class="btn btn-success" >Actived</button>';
                                        else
                                            echo '<button id="loginbtn" onclick="login()" class="btn btn-danger" >Deactivated</button>'
                                      ?>
                                     </h2>
                                </div>

                            </div>
                        </div>
                    </div>
                    <!-- /form input mask -->
                    <script type="application/javascript">
                        function maintenance()
                        {
                            var button = document.getElementById("maintenancebtn");

                            if (button.className == "btn btn-success")
                            {
                                button.className = "btn btn-danger";
                                button.textContent = "Deactivated";
                            }
                            else
                            {
                                button.className = "btn btn-success";
                                button.textContent = "Actived";
                            }


                            var maintenance = new XMLHttpRequest();
                            maintenance.open("GET", "../class/Settings.class.php?action=swithMaintenance", true);
                            maintenance.send();
                        }
                        function maintenance_msg()
                        {
                            var button = document.getElementById("maintenancemsg");

                            var maintenance = new XMLHttpRequest();
                            maintenance.open("GET", "../class/Settings.class.php?action=maintenanceMsg&msg=" + button.value, true);
                            maintenance.send();
                        }
                        function login()
                        {
                            var button = document.getElementById("loginbtn");

                            if (button.className == "btn btn-success")
                            {
                                button.className = "btn btn-danger";
                                button.textContent = "Deactivated";
                            }
                            else
                            {
                                button.className = "btn btn-success";
                                button.textContent = "Actived";
                            }


                            var maintenance = new XMLHttpRequest();
                            maintenance.open("GET", "../class/Settings.class.php?action=switchLogin", true);
                            maintenance.send();
                        }
                        function news()
                        {
                            var button = document.getElementById("newsbtn");

                            if (button.className == "btn btn-success")
                            {
                                button.className = "btn btn-danger";
                                button.textContent = "Deactivated";
                            }
                            else
                            {
                                button.className = "btn btn-success";
                                button.textContent = "Actived";
                            }


                            var maintenance = new XMLHttpRequest();
                            maintenance.open("GET", "../class/Settings.class.php?action=swithNews", true);
                            maintenance.send();
                        }
                        function news_msg()
                        {
                            var button = document.getElementById("newsmsg");

                            var maintenance = new XMLHttpRequest();
                            maintenance.open("GET", "../class/Settings.class.php?action=newsMsg&msg=" + button.value, true);
                            maintenance.send();
                        }
                    </script>

                    <!-- form color picker -->
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>News gestion</h2>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <br />
                            </div>
                        </div>
                    </div>
                    <!-- /form color picker -->
                </div>
            </div>
        </div>

        <?php include "jointures/footer.php"; ?>

    </div>
</div>

<div id="custom_notifications" class="custom-notifications dsp_none">
    <ul class="list-unstyled notifications clearfix" data-tabbed_notifications="notif-group">
    </ul>
    <div class="clearfix"></div>
    <div id="notif-group" class="tabbed_notifications"></div>
</div>

<script src="js/bootstrap.min.js"></script>

<!-- bootstrap progress js -->
<script src="js/progressbar/bootstrap-progressbar.min.js"></script>

<!-- icheck -->
<script src="js/icheck/icheck.min.js"></script>
<script src="js/custom.js"></script>
<!-- daterangepicker -->
<script type="text/javascript" src="js/moment/moment.min.js"></script>
<script type="text/javascript" src="js/datepicker/daterangepicker.js"></script>
<!-- input mask -->
<script src="js/input_mask/jquery.inputmask.js"></script>
<!-- knob -->
<script src="js/knob/jquery.knob.min.js"></script>
<!-- range slider -->
<script src="js/ion_range/ion.rangeSlider.min.js"></script>
<!-- color picker -->
<script src="js/colorpicker/bootstrap-colorpicker.min.js"></script>
<script src="js/colorpicker/docs.js"></script>

<!-- image cropping -->
<script src="js/cropping/cropper.min.js"></script>
<script src="js/cropping/main2.js"></script>
<!-- pace -->
<script src="js/pace/pace.min.js"></script>
<script src="js/bootstrap-toggle.js"></script>

<!-- datepicker -->
<script type="text/javascript">
    $(document).ready(function() {

        var cb = function(start, end, label) {
            console.log(start.toISOString(), end.toISOString(), label);
            $('#reportrange_right span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            //alert("Callback has fired: [" + start.format('MMMM D, YYYY') + " to " + end.format('MMMM D, YYYY') + ", label = " + label + "]");
        }

        var optionSet1 = {
            startDate: moment().subtract(29, 'days'),
            endDate: moment(),
            minDate: '01/01/2012',
            maxDate: '12/31/2015',
            dateLimit: {
                days: 60
            },
            showDropdowns: true,
            showWeekNumbers: true,
            timePicker: false,
            timePickerIncrement: 1,
            timePicker12Hour: true,
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
            },
            opens: 'right',
            buttonClasses: ['btn btn-default'],
            applyClass: 'btn-small btn-primary',
            cancelClass: 'btn-small',
            format: 'MM/DD/YYYY',
            separator: ' to ',
            locale: {
                applyLabel: 'Submit',
                cancelLabel: 'Clear',
                fromLabel: 'From',
                toLabel: 'To',
                customRangeLabel: 'Custom',
                daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
                monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                firstDay: 1
            }
        };

        $('#reportrange_right span').html(moment().subtract(29, 'days').format('MMMM D, YYYY') + ' - ' + moment().format('MMMM D, YYYY'));

        $('#reportrange_right').daterangepicker(optionSet1, cb);

        $('#reportrange_right').on('show.daterangepicker', function() {
            console.log("show event fired");
        });
        $('#reportrange_right').on('hide.daterangepicker', function() {
            console.log("hide event fired");
        });
        $('#reportrange_right').on('apply.daterangepicker', function(ev, picker) {
            console.log("apply event fired, start/end dates are " + picker.startDate.format('MMMM D, YYYY') + " to " + picker.endDate.format('MMMM D, YYYY'));
        });
        $('#reportrange_right').on('cancel.daterangepicker', function(ev, picker) {
            console.log("cancel event fired");
        });

        $('#options1').click(function() {
            $('#reportrange_right').data('daterangepicker').setOptions(optionSet1, cb);
        });

        $('#options2').click(function() {
            $('#reportrange_right').data('daterangepicker').setOptions(optionSet2, cb);
        });

        $('#destroy').click(function() {
            $('#reportrange_right').data('daterangepicker').remove();
        });

    });
</script>
<!-- datepicker -->
<script type="text/javascript">
    $(document).ready(function() {

        var cb = function(start, end, label) {
            console.log(start.toISOString(), end.toISOString(), label);
            $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            //alert("Callback has fired: [" + start.format('MMMM D, YYYY') + " to " + end.format('MMMM D, YYYY') + ", label = " + label + "]");
        }

        var optionSet1 = {
            startDate: moment().subtract(29, 'days'),
            endDate: moment(),
            minDate: '01/01/2012',
            maxDate: '12/31/2015',
            dateLimit: {
                days: 60
            },
            showDropdowns: true,
            showWeekNumbers: true,
            timePicker: false,
            timePickerIncrement: 1,
            timePicker12Hour: true,
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
            },
            opens: 'left',
            buttonClasses: ['btn btn-default'],
            applyClass: 'btn-small btn-primary',
            cancelClass: 'btn-small',
            format: 'MM/DD/YYYY',
            separator: ' to ',
            locale: {
                applyLabel: 'Submit',
                cancelLabel: 'Clear',
                fromLabel: 'From',
                toLabel: 'To',
                customRangeLabel: 'Custom',
                daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
                monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                firstDay: 1
            }
        };
        $('#reportrange span').html(moment().subtract(29, 'days').format('MMMM D, YYYY') + ' - ' + moment().format('MMMM D, YYYY'));
        $('#reportrange').daterangepicker(optionSet1, cb);
        $('#reportrange').on('show.daterangepicker', function() {
            console.log("show event fired");
        });
        $('#reportrange').on('hide.daterangepicker', function() {
            console.log("hide event fired");
        });
        $('#reportrange').on('apply.daterangepicker', function(ev, picker) {
            console.log("apply event fired, start/end dates are " + picker.startDate.format('MMMM D, YYYY') + " to " + picker.endDate.format('MMMM D, YYYY'));
        });
        $('#reportrange').on('cancel.daterangepicker', function(ev, picker) {
            console.log("cancel event fired");
        });
        $('#options1').click(function() {
            $('#reportrange').data('daterangepicker').setOptions(optionSet1, cb);
        });
        $('#options2').click(function() {
            $('#reportrange').data('daterangepicker').setOptions(optionSet2, cb);
        });
        $('#destroy').click(function() {
            $('#reportrange').data('daterangepicker').remove();
        });
    });
</script>
<!-- /datepicker -->
<script type="text/javascript">
    $(document).ready(function() {
        $('#single_cal1').daterangepicker({
            singleDatePicker: true,
            calender_style: "picker_1"
        }, function(start, end, label) {
            console.log(start.toISOString(), end.toISOString(), label);
        });
        $('#single_cal2').daterangepicker({
            singleDatePicker: true,
            calender_style: "picker_2"
        }, function(start, end, label) {
            console.log(start.toISOString(), end.toISOString(), label);
        });
        $('#single_cal3').daterangepicker({
            singleDatePicker: true,
            calender_style: "picker_3"
        }, function(start, end, label) {
            console.log(start.toISOString(), end.toISOString(), label);
        });
        $('#single_cal4').daterangepicker({
            singleDatePicker: true,
            calender_style: "picker_4"
        }, function(start, end, label) {
            console.log(start.toISOString(), end.toISOString(), label);
        });
    });
</script>
<script type="text/javascript">
    $(document).ready(function() {
        $('#reservation').daterangepicker(null, function(start, end, label) {
            console.log(start.toISOString(), end.toISOString(), label);
        });
    });
</script>
<!-- /datepicker -->
<!-- input_mask -->
<script>
    $(document).ready(function() {
        $(":input").inputmask();
    });
</script>
<!-- /input mask -->
<!-- ion_range -->
<script>
    $(function() {
        $("#range_27").ionRangeSlider({
            type: "double",
            min: 1000000,
            max: 2000000,
            grid: true,
            force_edges: true
        });
        $("#range").ionRangeSlider({
            hide_min_max: true,
            keyboard: true,
            min: 0,
            max: 5000,
            from: 1000,
            to: 4000,
            type: 'double',
            step: 1,
            prefix: "$",
            grid: true
        });
        $("#range_25").ionRangeSlider({
            type: "double",
            min: 1000000,
            max: 2000000,
            grid: true
        });
        $("#range_26").ionRangeSlider({
            type: "double",
            min: 0,
            max: 10000,
            step: 500,
            grid: true,
            grid_snap: true
        });
        $("#range_31").ionRangeSlider({
            type: "double",
            min: 0,
            max: 100,
            from: 30,
            to: 70,
            from_fixed: true
        });
        $(".range_min_max").ionRangeSlider({
            type: "double",
            min: 0,
            max: 100,
            from: 30,
            to: 70,
            max_interval: 50
        });
        $(".range_time24").ionRangeSlider({
            min: +moment().subtract(12, "hours").format("X"),
            max: +moment().format("X"),
            from: +moment().subtract(6, "hours").format("X"),
            grid: true,
            force_edges: true,
            prettify: function(num) {
                var m = moment(num, "X");
                return m.format("Do MMMM, HH:mm");
            }
        });
    });
</script>
<!-- /ion_range -->
<!-- knob -->
<script>
    $(function($) {

        $(".knob").knob({
            change: function(value) {
                //console.log("change : " + value);
            },
            release: function(value) {
                //console.log(this.$.attr('value'));
                console.log("release : " + value);
            },
            cancel: function() {
                console.log("cancel : ", this);
            },
            /*format : function (value) {
             return value + '%';
             },*/
            draw: function() {

                // "tron" case
                if (this.$.data('skin') == 'tron') {

                    this.cursorExt = 0.3;

                    var a = this.arc(this.cv) // Arc
                        ,
                        pa // Previous arc
                        , r = 1;

                    this.g.lineWidth = this.lineWidth;

                    if (this.o.displayPrevious) {
                        pa = this.arc(this.v);
                        this.g.beginPath();
                        this.g.strokeStyle = this.pColor;
                        this.g.arc(this.xy, this.xy, this.radius - this.lineWidth, pa.s, pa.e, pa.d);
                        this.g.stroke();
                    }

                    this.g.beginPath();
                    this.g.strokeStyle = r ? this.o.fgColor : this.fgColor;
                    this.g.arc(this.xy, this.xy, this.radius - this.lineWidth, a.s, a.e, a.d);
                    this.g.stroke();

                    this.g.lineWidth = 2;
                    this.g.beginPath();
                    this.g.strokeStyle = this.o.fgColor;
                    this.g.arc(this.xy, this.xy, this.radius - this.lineWidth + 1 + this.lineWidth * 2 / 3, 0, 2 * Math.PI, false);
                    this.g.stroke();

                    return false;
                }
            }
        });

        // Example of infinite knob, iPod click wheel
        var v, up = 0,
            down = 0,
            i = 0,
            $idir = $("div.idir"),
            $ival = $("div.ival"),
            incr = function() {
                i++;
                $idir.show().html("+").fadeOut();
                $ival.html(i);
            },
            decr = function() {
                i--;
                $idir.show().html("-").fadeOut();
                $ival.html(i);
            };
        $("input.infinite").knob({
            min: 0,
            max: 20,
            stopper: false,
            change: function() {
                if (v > this.cv) {
                    if (up) {
                        decr();
                        up = 0;
                    } else {
                        up = 1;
                        down = 0;
                    }
                } else {
                    if (v < this.cv) {
                        if (down) {
                            incr();
                            down = 0;
                        } else {
                            down = 1;
                            up = 0;
                        }
                    }
                }
                v = this.cv;
            }
        });
    });
</script>
<!-- /knob -->
</body>

</html>

