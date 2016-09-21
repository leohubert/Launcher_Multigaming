<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 20/09/2016
 * Time: 09:11
 */


header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']))
{
    $token = $_POST['token'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned`,`password` FROM users WHERE id = :id'))
    {
        $id = $res['user_id'];
        $userLevel->execute(array('id' => $res['user_id']));
        $my = $userLevel->fetch();
        if ((int)$my['level'] != 0 && (int)$my['banned'] != 1)
        {
            $request = $database->prepare('SELECT `last_notif` FROM `users` WHERE id= :id');
            $request->execute(array('id' => $id));
            $last_notif = $request->fetch()['last_notif'];

            $request = $database->prepare('SELECT * FROM `notifications` WHERE created_at >= :last_notif');
            $request->execute(array('last_notif' => $last_notif));

            if ($request->rowCount() != 0)
            {
                $total = 0;
                $result['notifications'] = array();
                while ($res = $request->fetch())
                {
                    $users = explode(',', $res['users']);
                    foreach ($users as $user)
                    {
                        if ((int)$user == (int)$id || ((int)$user == -42 && (int)$my['level'] >= 6) || (int)$user == -24)
                        {
                            $result['notifications'][$total] = array();
                            $result['notifications'][$total]['title'] = $res['title'];
                            $result['notifications'][$total]['link'] = $res['link'];
                            $result['notifications'][$total]['content'] = $res['content'];
                            $total++;
                        }
                    }
                }


                if ($total == 0)
                {
                    $result['status'] = 422;
                    $result['message'] = "No news";
                }
                else
                {
                    $result['status'] = 42;
                    $result['message'] = "User notifications get";
                    $result['total'] = $total;

                }
            }
            else
            {
                $result['status'] = 422;
                $result['message'] = "No news";
            }

        }
        else
        {
            $result['status'] = 44;
            $result['message'] = "You don't have right to create this request !";
        }
    }
    else
    {
        $result['status'] = 41;
        $result['message'] = "Token invalid";
    }
}
else
{
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";
}



echo json_encode($result);
