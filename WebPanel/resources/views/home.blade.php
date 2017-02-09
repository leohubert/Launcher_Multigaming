@extends('layouts.app')

@section('content')

            <script type="text/javascript">
                jQuery(document).ready(function($)
                {
                    // Sample Toastr Notification
                    setTimeout(function()
                    {
                        var opts = {
                            "closeButton": true,
                            "debug": false,
                            "positionClass": rtl() || public_vars.$pageContainer.hasClass('right-sidebar') ? "toast-top-left" : "toast-top-right",
                            "toastClass": "black",
                            "onclick": null,
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "extendedTimeOut": "1000",
                            "showEasing": "swing",
                            "hideEasing": "linear",
                            "showMethod": "fadeIn",
                            "hideMethod": "fadeOut"
                        };

                        toastr.success("You have been awarded with 1 year free subscription. Enjoy it!", "Account Subcription Updated", opts);
                    }, 3000);


                    // Sparkline Charts
                    $('.inlinebar').sparkline('html', {type: 'bar', barColor: '#ff6264'} );
                    $('.inlinebar-2').sparkline('html', {type: 'bar', barColor: '#445982'} );
                    $('.inlinebar-3').sparkline('html', {type: 'bar', barColor: '#00b19d'} );
                    $('.bar').sparkline([ [1,4], [2, 3], [3, 2], [4, 1] ], { type: 'bar' });
                    $('.pie').sparkline('html', {type: 'pie',borderWidth: 0, sliceColors: ['#3d4554', '#ee4749','#00b19d']});
                    $('.linechart').sparkline();
                    $('.pageviews').sparkline('html', {type: 'bar', height: '30px', barColor: '#ff6264'} );
                    $('.uniquevisitors').sparkline('html', {type: 'bar', height: '30px', barColor: '#00b19d'} );


                    $(".monthly-sales").sparkline([1,2,3,5,6,7,2,3,3,4,3,5,7,2,4,3,5,4,5,6,3,2], {
                        type: 'bar',
                        barColor: '#485671',
                        height: '80px',
                        barWidth: 10,
                        barSpacing: 2
                    });


                    // JVector Maps
                    var map = $("#map");

                    map.vectorMap({
                        map: 'europe_merc_en',
                        zoomMin: '3',
                        backgroundColor: '#383f47',
                        focusOn: { x: 0.5, y: 0.8, scale: 3 }
                    });



                    // Line Charts
                    var line_chart_demo = $("#line-chart-demo");

                    var line_chart = Morris.Line({
                        element: 'line-chart-demo',
                        data: [
                            { y: '2006', a: 100, b: 90 },
                            { y: '2007', a: 75,  b: 65 },
                            { y: '2008', a: 50,  b: 40 },
                            { y: '2009', a: 75,  b: 65 },
                            { y: '2010', a: 50,  b: 40 },
                            { y: '2011', a: 75,  b: 65 },
                            { y: '2012', a: 100, b: 90 }
                        ],
                        xkey: 'y',
                        ykeys: ['a', 'b'],
                        labels: ['October 2013', 'November 2013'],
                        redraw: true
                    });

                    line_chart_demo.parent().attr('style', '');


                    // Donut Chart
                    var donut_chart_demo = $("#donut-chart-demo");

                    donut_chart_demo.parent().show();

                    var donut_chart = Morris.Donut({
                        element: 'donut-chart-demo',
                        data: [
                            {label: "Download Sales", value: getRandomInt(10,50)},
                            {label: "In-Store Sales", value: getRandomInt(10,50)},
                            {label: "Mail-Order Sales", value: getRandomInt(10,50)}
                        ],
                        colors: ['#707f9b', '#455064', '#242d3c']
                    });

                    donut_chart_demo.parent().attr('style', '');


                    // Area Chart
                    var area_chart_demo = $("#area-chart-demo");

                    area_chart_demo.parent().show();

                    var area_chart = Morris.Area({
                        element: 'area-chart-demo',
                        data: [
                            { y: '2006', a: 100, b: 90 },
                            { y: '2007', a: 75,  b: 65 },
                            { y: '2008', a: 50,  b: 40 },
                            { y: '2009', a: 75,  b: 65 },
                            { y: '2010', a: 50,  b: 40 },
                            { y: '2011', a: 75,  b: 65 },
                            { y: '2012', a: 100, b: 90 }
                        ],
                        xkey: 'y',
                        ykeys: ['a', 'b'],
                        labels: ['Series A', 'Series B'],
                        lineColors: ['#303641', '#576277']
                    });

                    area_chart_demo.parent().attr('style', '');




                    // Rickshaw
                    var seriesData = [ [], [] ];

                    var random = new Rickshaw.Fixtures.RandomData(50);

                    for (var i = 0; i < 50; i++)
                    {
                        random.addData(seriesData);
                    }

                    var graph = new Rickshaw.Graph( {
                        element: document.getElementById("rickshaw-chart-demo"),
                        height: 193,
                        renderer: 'area',
                        stroke: false,
                        preserve: true,
                        series: [{
                            color: '#73c8ff',
                            data: seriesData[0],
                            name: 'Upload'
                        }, {
                            color: '#e0f2ff',
                            data: seriesData[1],
                            name: 'Download'
                        }
                        ]
                    } );

                    graph.render();

                    var hoverDetail = new Rickshaw.Graph.HoverDetail( {
                        graph: graph,
                        xFormatter: function(x) {
                            return new Date(x * 1000).toString();
                        }
                    } );

                    var legend = new Rickshaw.Graph.Legend( {
                        graph: graph,
                        element: document.getElementById('rickshaw-legend')
                    } );

                    var highlighter = new Rickshaw.Graph.Behavior.Series.Highlight( {
                        graph: graph,
                        legend: legend
                    } );

                    setInterval( function() {
                        random.removeData(seriesData);
                        random.addData(seriesData);
                        graph.update();

                    }, 500 );
                });


                function getRandomInt(min, max)
                {
                    return Math.floor(Math.random() * (max - min + 1)) + min;
                }
            </script>


            <div class="row">
                <div class="col-sm-3 col-xs-6">

                    <div class="tile-stats tile-red">
                        <div class="icon"><i class="entypo-users"></i></div>
                        <div class="num" data-start="0" data-end="83" data-postfix="" data-duration="1500" data-delay="0">0</div>

                        <h3>Registered users</h3>
                        <p>so far in our blog, and our website.</p>
                    </div>

                </div>

                <div class="col-sm-3 col-xs-6">

                    <div class="tile-stats tile-green">
                        <div class="icon"><i class="entypo-chart-bar"></i></div>
                        <div class="num" data-start="0" data-end="135" data-postfix="" data-duration="1500" data-delay="600">0</div>

                        <h3>Daily Visitors</h3>
                        <p>this is the average value.</p>
                    </div>

                </div>

                <div class="clear visible-xs"></div>

                <div class="col-sm-3 col-xs-6">

                    <div class="tile-stats tile-aqua">
                        <div class="icon"><i class="entypo-mail"></i></div>
                        <div class="num" data-start="0" data-end="23" data-postfix="" data-duration="1500" data-delay="1200">0</div>

                        <h3>New Messages</h3>
                        <p>messages per day.</p>
                    </div>

                </div>

                <div class="col-sm-3 col-xs-6">

                    <div class="tile-stats tile-blue">
                        <div class="icon"><i class="entypo-rss"></i></div>
                        <div class="num" data-start="0" data-end="52" data-postfix="" data-duration="1500" data-delay="1800">0</div>

                        <h3>Subscribers</h3>
                        <p>on our site right now.</p>
                    </div>

                </div>
            </div>

            <br />

            <div class="row">
                <div class="col-sm-8">

                    <div class="panel panel-primary" id="charts_env">

                        <div class="panel-heading">
                            <div class="panel-title">Site Stats</div>

                            <div class="panel-options">
                                <ul class="nav nav-tabs">
                                    <li class=""><a href="#area-chart" data-toggle="tab">Area Chart</a></li>
                                    <li class="active"><a href="#line-chart" data-toggle="tab">Line Charts</a></li>
                                    <li class=""><a href="#pie-chart" data-toggle="tab">Pie Chart</a></li>
                                </ul>
                            </div>
                        </div>

                        <div class="panel-body">

                            <div class="tab-content">

                                <div class="tab-pane" id="area-chart">
                                    <div id="area-chart-demo" class="morrischart" style="height: 300px"></div>
                                </div>

                                <div class="tab-pane active" id="line-chart">
                                    <div id="line-chart-demo" class="morrischart" style="height: 300px"></div>
                                </div>

                                <div class="tab-pane" id="pie-chart">
                                    <div id="donut-chart-demo" class="morrischart" style="height: 300px;"></div>
                                </div>

                            </div>

                        </div>

                        <table class="table table-bordered table-responsive">

                            <thead>
                            <tr>
                                <th width="50%" class="col-padding-1">
                                    <div class="pull-left">
                                        <div class="h4 no-margin">Pageviews</div>
                                        <small>54,127</small>
                                    </div>
                                    <span class="pull-right pageviews">4,3,5,4,5,6,5</span>

                                </th>
                                <th width="50%" class="col-padding-1">
                                    <div class="pull-left">
                                        <div class="h4 no-margin">Unique Visitors</div>
                                        <small>25,127</small>
                                    </div>
                                    <span class="pull-right uniquevisitors">2,3,5,4,3,4,5</span>
                                </th>
                            </tr>
                            </thead>

                        </table>

                    </div>

                </div>

                <div class="col-sm-4">

                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h4>
                                    Real Time Stats
                                    <br />
                                    <small>current server uptime</small>
                                </h4>
                            </div>

                            <div class="panel-options">
                                <a href="#sample-modal" data-toggle="modal" data-target="#sample-modal-dialog-1" class="bg"><i class="entypo-cog"></i></a>
                                <a href="#" data-rel="collapse"><i class="entypo-down-open"></i></a>
                                <a href="#" data-rel="reload"><i class="entypo-arrows-ccw"></i></a>
                                <a href="#" data-rel="close"><i class="entypo-cancel"></i></a>
                            </div>
                        </div>

                        <div class="panel-body no-padding">
                            <div id="rickshaw-chart-demo">
                                <div id="rickshaw-legend"></div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>


            <br />

            <div class="row">

                <div class="col-sm-4">

                    <div class="panel panel-primary">
                        <table class="table table-bordered table-responsive">
                            <thead>
                            <tr>
                                <th class="padding-bottom-none text-center">
                                    <br />
                                    <br />
                                    <span class="monthly-sales"></span>
                                </th>
                            </tr>
                            </thead>
                            <tbody>
                            <tr>
                                <td class="panel-heading">
                                    <h4>Monthly Sales</h4>
                                </td>
                            </tr>
                            </tbody>
                        </table>
                    </div>

                </div>

                <div class="col-sm-8">

                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="panel-title">Latest Updated Profiles</div>

                            <div class="panel-options">
                                <a href="#sample-modal" data-toggle="modal" data-target="#sample-modal-dialog-1" class="bg"><i class="entypo-cog"></i></a>
                                <a href="#" data-rel="collapse"><i class="entypo-down-open"></i></a>
                                <a href="#" data-rel="reload"><i class="entypo-arrows-ccw"></i></a>
                                <a href="#" data-rel="close"><i class="entypo-cancel"></i></a>
                            </div>
                        </div>

                        <table class="table table-bordered table-responsive">
                            <thead>
                            <tr>
                                <th>#</th>
                                <th>Name</th>
                                <th>Position</th>
                                <th>Activity</th>
                            </tr>
                            </thead>

                            <tbody>
                            <tr>
                                <td>1</td>
                                <td>Art Ramadani</td>
                                <td>CEO</td>
                                <td class="text-center"><span class="inlinebar">4,3,5,4,5,6</span></td>
                            </tr>

                            <tr>
                                <td>2</td>
                                <td>Ylli Pylla</td>
                                <td>Font-end Developer</td>
                                <td class="text-center"><span class="inlinebar-2">1,3,4,5,3,5</span></td>
                            </tr>

                            <tr>
                                <td>3</td>
                                <td>Arlind Nushi</td>
                                <td>Co-founder</td>
                                <td class="text-center"><span class="inlinebar-3">5,3,2,5,4,5</span></td>
                            </tr>

                            </tbody>
                        </table>
                    </div>

                </div>

            </div>

            <br />


            <script type="text/javascript">
                // Code used to add Todo Tasks
                jQuery(document).ready(function($)
                {
                    var $todo_tasks = $("#todo_tasks");

                    $todo_tasks.find('input[type="text"]').on('keydown', function(ev)
                    {
                        if(ev.keyCode == 13)
                        {
                            ev.preventDefault();

                            if($.trim($(this).val()).length)
                            {
                                var $todo_entry = $('<li><div class="checkbox checkbox-replace color-white"><input type="checkbox" /><label>'+$(this).val()+'</label></div></li>');
                                $(this).val('');

                                $todo_entry.appendTo($todo_tasks.find('.todo-list'));
                                $todo_entry.hide().slideDown('fast');
                                replaceCheckboxes();
                            }
                        }
                    });
                });
            </script>

            <div class="row">

                <div class="col-sm-3">
                    <div class="tile-block" id="todo_tasks">

                        <div class="tile-header">
                            <i class="entypo-list"></i>

                            <a href="#">
                                Tasks
                                <span>To do list, tick one.</span>
                            </a>
                        </div>

                        <div class="tile-content">

                            <input type="text" class="form-control" placeholder="Add Task" />


                            <ul class="todo-list">
                                <li>
                                    <div class="checkbox checkbox-replace color-white">
                                        <input type="checkbox" />
                                        <label>Website Design</label>
                                    </div>
                                </li>

                                <li>
                                    <div class="checkbox checkbox-replace color-white">
                                        <input type="checkbox" id="task-2" checked />
                                        <label>Slicing</label>
                                    </div>
                                </li>

                                <li>
                                    <div class="checkbox checkbox-replace color-white">
                                        <input type="checkbox" id="task-3" />
                                        <label>WordPress Integration</label>
                                    </div>
                                </li>

                                <li>
                                    <div class="checkbox checkbox-replace color-white">
                                        <input type="checkbox" id="task-4" />
                                        <label>SEO Optimize</label>
                                    </div>
                                </li>

                                <li>
                                    <div class="checkbox checkbox-replace color-white">
                                        <input type="checkbox" id="task-5" checked="" />
                                        <label>Minify &amp; Compress</label>
                                    </div>
                                </li>
                            </ul>

                        </div>

                        <div class="tile-footer">
                            <a href="#">View all tasks</a>
                        </div>

                    </div>
                </div>

                <div class="col-sm-9">

                    <script type="text/javascript">
                        jQuery(document).ready(function($)
                        {
                            var map = $("#map-2");

                            map.vectorMap({
                                map: 'europe_merc_en',
                                zoomMin: '3',
                                backgroundColor: '#383f47',
                                focusOn: { x: 0.5, y: 0.8, scale: 3 }
                            });
                        });
                    </script>

                    <div class="tile-group">

                        <div class="tile-left">
                            <div class="tile-entry">
                                <h3>Map</h3>
                                <span>top visitors location</span>
                            </div>

                            <div class="tile-entry">
                                <img src="assets/images/sample-al.png" alt="" class="pull-right op" />

                                <h4>Albania</h4>
                                <span>25%</span>
                            </div>

                            <div class="tile-entry">
                                <img src="assets/images/sample-it.png" alt="" class="pull-right op" />

                                <h4>Italy</h4>
                                <span>18%</span>
                            </div>

                            <div class="tile-entry">
                                <img src="assets/images/sample-au.png" alt="" class="pull-right op" />

                                <h4>Austria</h4>
                                <span>15%</span>
                            </div>
                        </div>

                        <div class="tile-right">

                            <div id="map-2" class="map"></div>

                        </div>

                    </div>

                </div>

    </div>
@endsection
