<?php
    header("Content-Type: text/html");
    $root_path = dirname(__FILE__);

    include dirname(__FILE__) . '/class/altoRooter.class.php';
    include dirname(__FILE__) . '/class/encryption.php';
    include dirname(__FILE__) . '/configs/config_general.php';


    $router = new AltoRouter();
    $router->setBasePath('');
    /* Setup the URL routing. This is production ready. */

    // Main routes that non-customers see
    session_start();

    if (!file_exists("configs/config_mysql.php") || $is_config == null)
    {
        if (file_exists("configs/config_mysql.php"))
            include dirname(__FILE__) . '/configs/config_mysql.php';
        $router->map('GET', '/', 'install/index.php', 'install');
        $router->map('POST', '/test_mysql', 'install/mysql_test.php', 'install-mysql-test');
        $router->map('POST', '/inject_mysql', 'install/mysql_inject.php', 'install-mysql-inject');
        $router->map('POST', '/save_config', 'install/save_config.php', 'install-save-config');
        $router->map('POST', '/finish_install', 'install/finish_config.php', 'install-finish-config');
    }
    else {
        include dirname(__FILE__) . '/configs/config_mysql.php';
        include dirname(__FILE__) . '/configs/mysql_connect.php';
        if (!isset($_SESSION['token'])) {
            $router->map('GET', '/', 'pages/auth/login.php', 'home');
        } else {
            if ((int)$_SESSION['level'] >= 6) {
                $router->map('GET', '/', 'pages/admin/index.php', 'home-admin');
                $router->map('GET', '/settings', 'pages/admin/settings/settings.php', 'settings-admin');
                $router->map('GET', '/support/view/[i:id]', 'pages/admin/support/view.php', 'support-view-admin');
                $router->map('GET', '/users/all', 'pages/admin/users/all.php', 'users-all');
                $router->map('GET', '/users/admins', 'pages/admin/users/admins.php', 'users-admins');
                $router->map('GET', '/users/banned', 'pages/admin/users/banned.php', 'users-banned');
                $router->map('GET', '/users/view/[i:id]', 'pages/admin/users/view.php', 'users-view-admin');
            } else {
                $router->map('GET', '/', 'pages/client/index.php', 'home-client');
                $router->map('GET', '/support/view/[i:id]', 'pages/client/support/view.php', 'support-view-client');
            }
        }
    }

    $router->map('GET','/login', 'pages/auth/login.php', 'login');
    $router->map('GET','/logout', 'pages/auth/logout.php', 'logout');
    $router->map('GET','/register', 'pages/auth/register.php', 'register');
    $router->map('GET','/recover', 'pages/auth/recover.php', 'recover');
    $router->map('GET', '/install_finish', 'install/install_finish.php', 'install-finish');

    /** @var API route */
    $router->map('POST','/api/login', 'api/login.php', 'api-login');
    $router->map('POST','/api/register', 'api/register.php', 'api-register');
    $router->map('GET','/api/settings', 'api/settings.php', 'api-settings');
    $router->map('GET','/api/news', 'api/news.php', 'api-news');

    /** @var API switch route */
    $router->map('POST','/api/switch/maintenance', 'api/switch/maintenance.php', 'api-switch-maintenance');
    $router->map('POST','/api/switch/login', 'api/switch/login.php', 'api-switch-login');
    $router->map('POST','/api/switch/register', 'api/switch/register.php', 'api-switch-register');

    /** @var API update route */
    $router->map('POST','/api/update/maintenance', 'api/update/maintenance.php', 'api-update-maintenance');
    $router->map('POST','/api/update/loginNews', 'api/update/loginNews.php', 'api-update-loginNews');
    $router->map('POST','/api/update/vmod', 'api/update/vmod.php', 'api-update-vmod');

    /** @var API stats route */
    $router->map('GET','/api/stats/dashboard', 'api/stats/dashboard.php', 'api-stats-dashboard');

    /** @var API support admin route */
    $router->map('POST','/api/support/admin/list', 'api/support/admin/list.php', 'api-support-admin-list');
    $router->map('POST','/api/support/admin/create', 'api/support/admin/create.php', 'api-support-admin-create');
    $router->map('POST','/api/support/admin/get', 'api/support/admin/get.php', 'api-support-admin-get');
    $router->map('POST','/api/support/admin/remove', 'api/support/admin/remove.php', 'api-support-admin-remove');
    $router->map('POST','/api/support/admin/send', 'api/support/admin/send.php', 'api-support-admin-send');
    $router->map('POST','/api/support/admin/assign', 'api/support/admin/assign.php', 'api-support-admin-assign');
    $router->map('POST','/api/support/admin/save', 'api/support/admin/save.php', 'api-support-admin-save');

    /** @var API support client route */
    $router->map('POST','/api/support/client/list', 'api/support/client/list.php', 'api-support-client-list');
    $router->map('POST','/api/support/client/get', 'api/support/client/get.php', 'api-support-client-get');
    $router->map('POST','/api/support/client/send', 'api/support/client/send.php', 'api-support-client-send');
    $router->map('POST','/api/support/client/create', 'api/support/client/create.php', 'api-support-client-create');

    /** @var API users admin route $match */
    $router->map('POST','/api/users/admin/all', 'api/users/admin/all.php', 'api-users-admin-all');
    $router->map('POST','/api/users/admin/admins', 'api/users/admin/admins.php', 'api-users-admin-admins');
    $router->map('POST','/api/users/admin/banned', 'api/users/admin/banned.php', 'api-users-admin-banned');
    $router->map('POST','/api/users/admin/get', 'api/users/admin/get.php', 'api-users-admin-get');
    $router->map('POST','/api/users/admin/save', 'api/users/admin/save.php', 'api-users-admin-save');

    /** @var API users client route $match */
    $router->map('POST','/api/users/client/get', 'api/users/client/get.php', 'api-users-client-get');

    /** @var API arma3 route $match */
    $router->map('GET','/api/arma3/addons', 'api/arma3/addons.php', 'api-addons');
    $router->map('GET','/api/arma3/launcher/download', 'api/arma3/download_launcher.php', 'api-launcher-download');
    $router->map('GET','/api/arma3/addons/download/[*:addons]', 'api/arma3/download.php', 'api-arma3-addons');
    $router->map('GET','/api/arma3/cpps/download/[*:cpps]', 'api/arma3/download.php', 'api-arma3-cpps');
    $router->map('GET','/api/arma3/userconfigs/download/[*:userconfigs]', 'api/arma3/download.php', 'api-arma3-userconfigs');


    /* Match the current request */
    $match = $router->match();
    if($match) {
        require $match['target'];
    }
    else
    {
        header("HTTP/1.0 404 Not Found");
        require 'errors/404.php';
    }
?>