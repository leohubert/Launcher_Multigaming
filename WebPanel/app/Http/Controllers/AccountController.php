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
        $user = $request->user();

        foreach (config('languages') as $item)
        {
            if ($item['flag'] == $lang)
            {
                $user->lang = $lang;
                $user->save();
            }
        }
        return redirect()->back();
    }

    function myAccount()
    {
        return view('users.profile',['my' => true, 'user' => Auth::user()]);
    }
}
