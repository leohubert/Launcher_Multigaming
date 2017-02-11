<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Auth::routes();

Route::get('/', 'HomeController@index');

Route::group(['prefix' => 'account'], function ()
{
    Route::get('/', "AccountController@myAccount");
    Route::group(['prefix' => "update"], function ()
    {
        Route::get('/lang/{lang}', ["uses" => "AccountController@updateLang", "as" => "lang"]);
    });
});

Route::group(['prefix' => 'users'], function()
{
    Route::get('/{id}', ['uses' => 'UsersController@profile', 'as' => 'id']);
});