<?php

use Illuminate\Database\Seeder;

class SeederAccounts extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('users')->insert([
            'username' => "MrDarkSkil",
            'email' => 'leohub@live.fr',
            'password' => Hash::make('secret'),
            'name' => "bite",
        ]);
	DB::table('users')->insert([
            'username' => "FrenChQWerTy",
            'email' => 'frenchqwerty@gmail.com',
            'password' => Hash::make('secret'),
            'name' => "ArabeSauvage"
        ]);
    }
}
