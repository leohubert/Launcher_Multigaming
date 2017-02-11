@extends('layouts.app')

@section('content')
    <div class="profile-env">

        <header class="row">

            <div class="col-sm-2">

                <a href="#" class="profile-picture">
                    <img src="/upload/avatars/{{ $user->avatar }}" class="img-responsive img-circle"/>
                </a>

            </div>

            <div class="col-sm-7">

                <ul class="profile-info-sections">
                    <li>
                        <div class="profile-name">
                            <strong>
                                <a href="#">{{ $user->username }}</a>
                                <a href="#" class="user-status is-online tooltip-primary" data-toggle="tooltip"
                                   data-placement="top" data-original-title="Online"></a>
                                <!-- User statuses available classes "is-online", "is-offline", "is-idle", "is-busy" -->
                            </strong>
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

            @if ($me == false)
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
            @endif

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
                        <li class="active"><a data-toggle="tab" href="#profile">Profile</a></li>
                        <li><a data-toggle="tab" href="#games">Games</a></li>
                        <li><a data-toggle="tab" href="#notifications">Notifications</a></li>
                        <li><a data-toggle="tab" href="#settings">Settings</a></li>
                    </ul>

                </div>

            </div>

        </section>


        <section class="profile-feed">

            <div class="tab-content">
                <div id="profile" class="tab-pane fade in active">
                    <h3>Profile</h3>
                    <p>Some content.</p>
                </div>
                <div id="games" class="tab-pane fade">
                    <h3>Games view</h3>
                    <p>Some content in menu 1.</p>
                </div>
                <div id="notifications" class="tab-pane fade">
                    <h3>Notications view</h3>
                    <p>Some content in menu 1.</p>
                </div>
                <div id="settings" class="tab-pane fade">
                    <h3>Settings View</h3>
                    <p>Some content in menu 2.</p>
                </div>
            </div>
        </section>
    </div>
@endsection