@extends('layouts.app')

@php
    $user = Auth::user();
@endphp

@section('content')
    <div class="profile-env">

        <header class="row">

            <div class="col-sm-2">

                <a href="#" class="profile-picture">
                    <img src="/upload/avatars/{{ $user->avatar }}" class="img-responsive img-circle" />
                </a>

            </div>

            <div class="col-sm-7">

                <ul class="profile-info-sections">
                    <li>
                        <div class="profile-name">
                            <strong>
                                <a href="#">Art Ramadani</a>
                                <a href="#" class="user-status is-online tooltip-primary" data-toggle="tooltip" data-placement="top" data-original-title="Online"></a>
                                <!-- User statuses available classes "is-online", "is-offline", "is-idle", "is-busy" -->						</strong>
                            <span><a href="#">Co-Founder at Laborator</a></span>
                        </div>
                    </li>

                    <li>
                        <div class="profile-stat">
                            <h3>643</h3>
                            <span><a href="#">followers</a></span>
                        </div>
                    </li>

                    <li>
                        <div class="profile-stat">
                            <h3>108</h3>
                            <span><a href="#">following</a></span>
                        </div>
                    </li>
                </ul>

            </div>

            <div class="col-sm-3">

                <div class="profile-buttons">
                    <a href="#" class="btn btn-default">
                        <i class="entypo-user-add"></i>
                        Follow
                    </a>

                    <a href="#" class="btn btn-default">
                        <i class="entypo-mail"></i>
                    </a>
                </div>
            </div>

        </header>

        <section class="profile-info-tabs">

            <div class="row">

                <div class="col-sm-offset-2 col-sm-10">

                    <ul class="user-details">
                        <li>
                            <a href="#">
                                <i class="entypo-location"></i>
                                Prishtina
                            </a>
                        </li>

                        <li>
                            <a href="#">
                                <i class="entypo-suitcase"></i>
                                Works as <span>Laborator</span>
                            </a>
                        </li>

                        <li>
                            <a href="#">
                                <i class="entypo-calendar"></i>
                                16 October
                            </a>
                        </li>
                    </ul>


                    <!-- tabs for the profile links -->
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#profile-info">Profile</a></li>
                        <li><a href="#biography">Bio</a></li>
                        <li><a href="#profile-edit">Edit Profile</a></li>
                    </ul>

                </div>

            </div>

        </section>


        <section class="profile-feed">

            <!-- profile post form -->
            <form class="profile-post-form" method="post">

                <textarea class="form-control autogrow" placeholder="What's on your mind?"></textarea>

                <div class="form-options">

                    <div class="post-type">

                        <a href="#" class="tooltip-primary" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Upload a Picture">
                            <i class="entypo-camera"></i>
                        </a>

                        <a href="#" class="tooltip-primary" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Attach a file">
                            <i class="entypo-attach"></i>
                        </a>

                        <a href="#" class="tooltip-primary" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Check-in">
                            <i class="entypo-location"></i>
                        </a>
                    </div>

                    <div class="post-submit">
                        <button type="button" class="btn btn-primary">POST</button>
                    </div>

                </div>
            </form>

            <!-- profile stories -->
            <div class="profile-stories">

                <article class="story">

                    <aside class="user-thumb">
                        <a href="#">
                            <img src="assets/images/thumb-1@2x.png" width="44" alt="" class="img-circle" />
                        </a>
                    </aside>

                    <div class="story-content">

                        <!-- story header -->
                        <header>

                            <div class="publisher">
                                <a href="#">Art Ramadani</a> posted a status update
                                <em>3 hours ago</em>
                            </div>

                            <div class="story-type">
                                <i class="entypo-feather"></i>
                            </div>

                        </header>

                        <div class="story-main-content">
                            <p>Tolerably earnestly middleton extremely distrusts she boy now not. Add and offered prepare how cordial two promise. Greatly who affixed suppose but enquire compact prepare all put. Added forth chief trees but rooms think may. </p>
                        </div>

                        <!-- story like and comment link -->
                        <footer>
                            <a href="#" class="liked">
                                <i class="entypo-heart"></i>
                                Liked <span>(8)</span>
                            </a>

                            <a href="#">
                                <i class="entypo-comment"></i>
                                Comment <span>(12)</span>
                            </a>

                            <!-- story comments -->
                            <ul class="comments">

                                <li>
                                    <div class="user-comment-thumb">
                                        <img src="assets/images/thumb-2@2x.png" alt="" class="img-circle" width="30" />
                                    </div>

                                    <div class="user-comment-content">

                                        <a href="#" class="user-comment-name">
                                            Arlind Nushi
                                        </a>

                                        Tolerably earnestly middleton extremely distrusts she boy now not. Add and offered prepare how cordial two promise. Add and offered prepare how cordial two promise.

                                        <div class="user-comment-meta">

                                            <a href="#" class="comment-date">January 4 at 1:11am</a>
                                            -

                                            <a href="#">
                                                <i class="entypo-heart"></i>
                                                Like <span>(2)</span>
                                            </a>
                                            -

                                            <a href="#">
                                                <i class="entypo-comment"></i>
                                                Reply
                                            </a>
                                        </div>

                                    </div>
                                </li>

                                <li>
                                    <div class="user-comment-thumb">
                                        <img src="assets/images/thumb-1@2x.png" alt="" class="img-circle" width="30" />
                                    </div>

                                    <div class="user-comment-content">

                                        <a href="#" class="user-comment-name">
                                            Sherry William
                                        </a>

                                        Extremity direction existence as dashwoods do up. Securing marianne led welcomed offended but offering six raptures. Conveying concluded newspaper rapturous oh at.

                                        <div class="user-comment-meta">

                                            <a href="#" class="comment-date">January 3 at 6:42pm</a>
                                            -

                                            <a href="#" class="liked">
                                                <i class="entypo-heart"></i>
                                                Liked
                                            </a>
                                            -

                                            <a href="#">
                                                <i class="entypo-comment"></i>
                                                Reply
                                            </a>
                                        </div>

                                    </div>
                                </li>

                                <li>
                                    <div class="user-comment-thumb">
                                        <img src="assets/images/thumb-3@2x.png" alt="" class="img-circle" width="30" />
                                    </div>

                                    <div class="user-comment-content">

                                        <a href="#" class="user-comment-name">
                                            Harold Bella
                                        </a>

                                        Mean if he they been no hold mr. Is at much do made took held help. Latter person am secure of estate genius at.

                                        <div class="user-comment-meta">

                                            <a href="#" class="comment-date">January 2 at 3:25pm</a>
                                            -

                                            <a href="#">
                                                <i class="entypo-heart"></i>
                                                Like
                                            </a>
                                            -

                                            <a href="#">
                                                <i class="entypo-comment"></i>
                                                Reply
                                            </a>
                                        </div>

                                    </div>
                                </li>

                                <li class="comment-form">
                                    <div class="user-comment-thumb">
                                        <img src="assets/images/thumb-1@2x.png" alt="" class="img-circle" width="30" />
                                    </div>

                                    <div class="user-comment-content">

                                        <textarea class="form-control autogrow" placeholder="Write a comment..."></textarea>
                                        <button class="btn"><i class="entypo-chat"></i></button>

                                    </div>
                                </li>

                            </ul>

                        </footer>

                        <!-- separator -->
                        <hr />

                    </div>

                </article>


                <article class="story">

                    <aside class="user-thumb">
                        <a href="#">
                            <img src="assets/images/thumb-3@2x.png" width="44" alt="" class="img-circle" />
                        </a>
                    </aside>

                    <div class="story-content">

                        <!-- story header -->
                        <header>

                            <div class="publisher">
                                <a href="#">Daniel Smith</a> checked in at <a href="#">Laborator</a>
                                <em>Yesterday</em>
                            </div>

                            <div class="story-type">
                                <i class="entypo-location"></i>
                            </div>

                        </header>

                        <div class="story-main-content">

                            <div id="sample-checkin" class="map-checkin" style="height: 180px; width: 100%;"></div>

                        </div>

                        <!-- story like and comment link -->
                        <footer>
                            <a href="#">
                                <i class="entypo-heart"></i>
                                Like
                            </a>

                            <a href="#">
                                <i class="entypo-comment"></i>
                                Comment
                            </a>
                        </footer>

                        <hr />
                    </div>

                </article><article class="story">

                    <aside class="user-thumb">
                        <a href="#">
                            <img src="assets/images/thumb-2@2x.png" width="44" alt="" class="img-circle" />
                        </a>
                    </aside>

                    <div class="story-content">

                        <!-- story header -->
                        <header>

                            <div class="publisher">
                                <a href="#">Virginia Lacey</a> uploaded 4 new photos to album <a href="#">Timeline Photos</a>
                                <em>2 days ago</em>
                            </div>

                            <div class="story-type">
                                <i class="entypo-location"></i>
                            </div>

                        </header>

                        <div class="story-main-content">

                            <div class="row">
                                <div class="col-sm-5">
                                    <a href="#">
                                        <img src="assets/images/timeline-image-1.png" class="img-responsive img-rounded full-width" />
                                    </a>
                                </div>

                                <div class="col-sm-3">
                                    <a href="#">
                                        <img src="assets/images/timeline-image-1.png" class="img-responsive img-rounded full-width" />
                                    </a>
                                </div>

                                <div class="col-sm-4">

                                    <a href="#">
                                        <img src="assets/images/timeline-image-1.png" class="img-responsive img-rounded full-width margin-bottom" />
                                    </a>

                                    <a href="#">
                                        <img src="assets/images/timeline-image-1.png" class="img-responsive img-rounded full-width" />
                                    </a>
                                </div>
                            </div>


                        </div>

                        <!-- story like and comment link -->
                        <footer>
                            <a href="#">
                                <i class="entypo-heart"></i>
                                Like <span>(25)</span>
                            </a>

                            <a href="#">
                                <i class="entypo-comment"></i>
                                Comment <span>(13)</span>
                            </a>
                        </footer>

                    </div>

                </article>


                <div class="text-center">
                    <a href="#" class="btn btn-default btn-icon icon-left">
                        <i class="entypo-hourglass"></i>
                        Load More &hellip;
                    </a>
                </div>

            </div>

        </section>
    </div>

    <script type="text/javascript" src="//maps.google.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript">
        function initialize()
        {
            var $ = jQuery,
                map_canvas = $("#sample-checkin");

            var location = new google.maps.LatLng(36.738888, -119.783013),
                map = new google.maps.Map(map_canvas[0], {
                    center: location,
                    zoom: 14,
                    mapTypeId: google.maps.MapTypeId.ROADMAP,
                    scrollwheel: false
                });

            var marker = new google.maps.Marker({
                position: location,
                map: map
            });
        }

        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
@endsection