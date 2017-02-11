<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\User;

class UsersController extends Controller
{
    function __construct()
    {
        $this->middleware('auth');
    }

    function profile(Request $request, $id)
    {
        $user = User::findOrFail($id);
        return view('users.profile', ['me' => false, 'user' => $user]);
    }
}
