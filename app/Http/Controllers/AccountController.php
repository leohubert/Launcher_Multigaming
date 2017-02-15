<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class AccountController extends Controller
{
    function __construct()
    {
        $this->middleware('auth');
    }

    function updateLang(Request $request, $lang)
    {
        $languages = config('custom.languages');
        if (isset($languages[$lang])) {
            $user = $request->user();
            $user->lang = $lang;
            $user->save();
            return redirect()->back();
        }
        // Not sure what you planned on doing here when the lang was not in the config
//        return redirect()->back()->withErrors();
    }

    function myAccount()
    {
        return view('users.profile',['me' => true, 'user' => Auth::user()]);
    }
}
