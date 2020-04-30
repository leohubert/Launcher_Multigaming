<?php
header("Content-Type: text/html");
$root_path = dirname(__FILE__);


ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ERROR);

include dirname(__FILE__) . '/class/Autoload.class.php';

$router = new AltoRouter();
$router->setBasePath('');
include dirname(__FILE__) . '/configs/config_general.php';
$encrypter = new Encryption($encrypt_key1, $encrypt_key2);
$GLOBALS['key1'] = $encrypt_key1;
$GLOBALS['key2'] = $encrypt_key2;

/* Setup the URL routing. This is production ready. */

// Main routes that non-customers see
session_start();

if (!file_exists("configs/config_mysql.php") || $is_config == null) {
    if (file_exists("configs/config_mysql.php"))
        include dirname(__FILE__) . '/configs/config_mysql.php';
    $router->map('GET', '/', 'install/index.php', 'install');
    $router->map('POST', '/test_mysql', 'install/mysql_test.php', 'install-mysql-test');
    $router->map('POST', '/inject_mysql', 'install/mysql_inject.php', 'install-mysql-inject');
    $router->map('POST', '/save_config', 'install/save_config.php', 'install-save-config');
    $router->map('POST', '/finish_install', 'install/finish_config.php', 'install-finish-config');
    $router->map('POST', '/save_server_mysql', 'install/mysql_server.php', 'install-save-server-mysql');
    $router->map('POST', '/switch_status', 'install/switch_status.php', 'install-switch-status');
} else {
    include dirname(__FILE__) . '/configs/config_mysql.php';
    include dirname(__FILE__) . '/configs/mysql_connect.php';
    if (!isset($_SESSION['token'])) {
        $router->map('GET', '/', 'pages/auth/login.php', 'home');
    } else {
        if (isset($_SESSION['session']) || isset($_COOKIE['session'])) {
            if (isset($_SESSION['session']) && $_SESSION['session'] < time()) {
                $_SESSION['locked'] = true;
                setcookie('locked', true, time() + (86400 * 30), "/");
            } else {
                if (isset($_COOKIE['session']) && $_COOKIE['session'] < time()) {
                    $_SESSION['locked'] = true;
                    setcookie('locked', true, time() + (86400 * 30), "/");
                } else {
                    $_SESSION['session'] = time() + (60 * 30);
                    setcookie('session', time() + (60 * 30), time() + (86400 * 30), "/");
                }
            }
        }
        if ((isset($_SESSION['locked']) && $_SESSION['locked'] == true) || (isset($_COOKIE['locked']) && $_COOKIE['locked'] == true)) {
            $router->map('GET', '/', 'pages/auth/locked.php', 'home');
        } else {
            $router->map('GET', '/refresh', 'pages/auth/actions/refresh.php', 'refresh');
            if ((int)$_SESSION['level'] >= 6) {
                if ((int)$_SESSION['level'] == 10) {
                    $router->map('GET', '/indexer/access', 'api/indexer.php', 'indexer-access');
                }
                $router->map('GET', '/profile/view', 'pages/admin/profile/view.php', 'profile-view');
                $router->map('GET', '/profile/edit', 'pages/admin/profile/edit.php', 'profile-edit');
                $router->map('GET', '/', 'pages/admin/index.php', 'home-admin');
                $router->map('GET', '/settings', 'pages/admin/settings/settings.php', 'settings-admin');
                $router->map('GET', '/settings1', 'pages/admin/settings/newsettings.php', 'settings-admin1');
                $router->map('GET', '/news', 'pages/admin/news/news.php', 'news-admin');
                $router->map('GET', '/news/view/[i:id]', 'pages/admin/news/view.php', 'news-admin-view');
                $router->map('GET', '/servers', 'pages/admin/servers/servers.php', 'servers-admin-list');
                $router->map('GET', '/servers/view/[i:id]', 'pages/admin/servers/view.php', 'servers-view-admin');
                $router->map('GET', '/servers/browse/[a:id]', 'pages/admin/servers/browser.php', 'servers-browse-admin');
                $router->map('GET', '/support/view/[i:id]', 'pages/admin/support/view.php', 'support-view-admin');
                $router->map('GET', '/users/all', 'pages/admin/users/all.php', 'users-all');
                $router->map('GET', '/users/admins', 'pages/admin/users/admins.php', 'users-admins');
                $router->map('GET', '/users/banned', 'pages/admin/users/banned.php', 'users-banned');
                $router->map('GET', '/users/view/[i:id]', 'pages/admin/users/view.php', 'users-view-admin');
            } else {
                $router->map('GET', '/profile/view', 'pages/client/profile/view.php', 'profile-view');
                $router->map('GET', '/profile/edit', 'pages/client/profile/edit.php', 'profile-edit');
                $router->map('GET', '/', 'pages/client/index.php', 'home-client');
                $router->map('GET', '/support/view/[i:id]', 'pages/client/support/view.php', 'support-view-client');
            }

            /** INTRANET */
            $router->map('GET', '/intranet', 'pages/intranet/index.php', 'intranet-index');
            $router->map('GET', '/intranet/login', 'pages/intranet/login.php', 'intranet-login');
            $router->map('GET', '/intranet/logout', 'pages/intranet/logout.php', 'intranet-logout');
            $router->map('GET', '/intranet/bank/authentication', 'pages/intranet/bank/authentication.php', 'intranet-bank-authentication');
            $router->map('GET', '/intranet/bank/account', 'pages/intranet/bank/account.php', 'intranet-bank-account');
        }
    }
}

$router->map('GET', '/test', 'api/test.php', 'test');
$router->map('GET', '/update', 'api/update.php', 'update-webpanel');
$router->map('GET', '/encrypt', 'api/encrypt.php', 'encrypt');
$router->map('GET', '/terms', 'pages/auth/terms.php', 'terms');
$router->map('GET', '/login', 'pages/auth/login.php', 'login');
$router->map('GET', '/register', 'pages/auth/register.php', 'register');
$router->map('GET', '/recover', 'pages/auth/recover.php', 'recover');
$router->map('GET', '/recoveru', 'pages/auth/recover-final.php', 'recover-final');
$router->map('GET', '/logout', 'pages/auth/actions/logout.php', 'logout');
$router->map('GET', '/lock', 'pages/auth/actions/lock.php', 'lock');
$router->map('GET', '/install_finish', 'install/install_finish.php', 'install-finish');

/** @var API route */
$router->map('POST', '/api/login', 'api/login.php', 'api-login');
$router->map('POST', '/api/register', 'api/register.php', 'api-register');
$router->map('GET', '/api/settings', 'api/settings.php', 'api-settings');
$router->map('POST', '/api/config', 'api/config.php', 'api-config');
$router->map('POST', '/api/recoveryrequest', 'api/recovery-request.php', 'api-recovery-request');
$router->map('POST', '/api/recovery', 'api/recovery.php', 'api-recovery');

/** @var API news route */
$router->map('POST', '/api/news/launcher', 'api/news/news_launcher.php', 'api-news');
$router->map('POST', '/api/news/admin/list', 'api/news/admin/list.php', 'api-news-admin-list');
$router->map('POST', '/api/news/admin/get', 'api/news/admin/get.php', 'api-news-admin-get');
$router->map('POST', '/api/news/admin/edit', 'api/news/admin/edit.php', 'api-news-admin-edit');
$router->map('POST', '/api/news/admin/create', 'api/news/admin/create.php', 'api-news-admin-create');
$router->map('POST', '/api/news/admin/remove', 'api/news/admin/remove.php', 'api-news-admin-remove');

/** @var API switch route */
$router->map('POST', '/api/switch/maintenance', 'api/switch/maintenance.php', 'api-switch-maintenance');
$router->map('POST', '/api/switch/login', 'api/switch/login.php', 'api-switch-login');
$router->map('POST', '/api/switch/register', 'api/switch/register.php', 'api-switch-register');
$router->map('POST', '/api/switch/taskforce', 'api/switch/taskforce.php', 'api-switch-taskforce');
$router->map('POST', '/api/switch/uuid', 'api/switch/uuid.php', 'api-switch-uuid');

/** @var API update route */
$router->map('POST', '/api/update/maintenance', 'api/update/maintenance.php', 'api-update-maintenance');
$router->map('POST', '/api/update/loginNews', 'api/update/loginNews.php', 'api-update-loginNews');
$router->map('POST', '/api/update/vtaskforce', 'api/update/vtaskforce.php', 'api-update-vtaksforce');

/** @var API stats route */
$router->map('GET', '/api/stats/dashboard', 'api/stats/dashboard.php', 'api-stats-dashboard');
$router->map('GET', '/testlogin', 'test.php', 'Test-FlashModz');
$router->map('GET', '/theme', 'theme/*', 'theme-FlashModz');

/** @var API support admin route */
$router->map('POST', '/api/support/admin/list', 'api/support/admin/list.php', 'api-support-admin-list');
$router->map('POST', '/api/support/admin/create', 'api/support/admin/create.php', 'api-support-admin-create');
$router->map('POST', '/api/support/admin/get', 'api/support/admin/get.php', 'api-support-admin-get');
$router->map('POST', '/api/support/admin/remove', 'api/support/admin/remove.php', 'api-support-admin-remove');
$router->map('POST', '/api/support/admin/send', 'api/support/admin/send.php', 'api-support-admin-send');
$router->map('POST', '/api/support/admin/assign', 'api/support/admin/assign.php', 'api-support-admin-assign');
$router->map('POST', '/api/support/admin/save', 'api/support/admin/save.php', 'api-support-admin-save');

/** @var API support client route */
$router->map('POST', '/api/support/client/list', 'api/support/client/list.php', 'api-support-client-list');
$router->map('POST', '/api/support/client/get', 'api/support/client/get.php', 'api-support-client-get');
$router->map('POST', '/api/support/client/send', 'api/support/client/send.php', 'api-support-client-send');
$router->map('POST', '/api/support/client/create', 'api/support/client/create.php', 'api-support-client-create');

/** @var API users admin route $match */
$router->map('POST', '/api/users/admin/all', 'api/users/admin/all.php', 'api-users-admin-all');
$router->map('POST', '/api/users/admin/admins', 'api/users/admin/admins.php', 'api-users-admin-admins');
$router->map('POST', '/api/users/admin/banned', 'api/users/admin/banned.php', 'api-users-admin-banned');
$router->map('POST', '/api/users/admin/get', 'api/users/admin/get.php', 'api-users-admin-get');
$router->map('POST', '/api/users/admin/save', 'api/users/admin/save.php', 'api-users-admin-save');
$router->map('POST', '/api/users/admin/remove', 'api/users/admin/remove.php', 'api-users-admin-delete');

/** @var API users client route $match */
$router->map('POST', '/api/users/client/get', 'api/users/client/get.php', 'api-users-client-get');
$router->map('POST', '/api/users/client/save', 'api/users/client/save.php', 'api-users-client-save');
$router->map('POST', '/api/users/client/changepass', 'api/users/client/changepass.php', 'api-users-client-changepass');

/** @var API games route $match */
/** ARMA 3 */
$router->map('POST', '/api/games/arma3/addons', 'api/games/arma3/addons.php', 'api-games-arma3-addons');
$router->map('POST', '/api/games/arma3/create_update', 'api/games/arma3/create_update.php', 'api-games-arma3-create_update');
$router->map('POST', '/api/games/arma3/taskforce/list', 'api/games/arma3/taskforce/list.php', 'api-games-arma3-taskforce');

/** @var API servers admin route $match */
$router->map('POST', '/api/server/admin/get', 'api/server/admin/get.php', 'api-server-admin-get');
$router->map('POST', '/api/server/admin/unlock', 'api/server/admin/unlock.php', 'api-server-admin-unlock');
$router->map('POST', '/api/server/admin/taskforce', 'api/server/admin/taskforce.php', 'api-server-admin-taskforce');
$router->map('POST', '/api/server/admin/taskforce/update', 'api/server/admin/taskforce_update.php', 'api-server-admin-taskforce-update');
$router->map('POST', '/api/server/admin/maintenance', 'api/server/admin/maintenance.php', 'api-server-admin-maintenance');
$router->map('POST', '/api/server/admin/setpass/lock', 'api/server/admin/setLockPass.php', 'api-server-admin-setpass-lock');
$router->map('POST', '/api/server/admin/setpass/server', 'api/server/admin/setServerPass.php', 'api-server-admin-setpass-server');
$router->map('POST', '/api/server/admin/database/save', 'api/server/admin/database/save.php', 'api-server-admin-database-save');
$router->map('POST', '/api/server/admin/database/get', 'api/server/admin/database/get.php', 'api-server-admin-database-get');

/** @var API users ingames route $match */
$router->map('POST', '/api/server/client/players/get', 'api/server/client/players/get.php', 'api-server-client-player-get');

/** API server */
$router->map('POST', '/api/server/status/get', 'api/server/status/index.php', 'api-server-status');
$router->map('POST', '/api/server/get', 'api/server/get.php', 'api-server-get');
$router->map('POST', '/api/server/auth', 'api/server/auth.php', 'api-server-auth');
$router->map('POST', '/api/server/create', 'api/server/create.php', 'api-server-create');
$router->map('POST', '/api/server/save', 'api/server/save.php', 'api-server-save');
$router->map('POST', '/api/server/remove', 'api/server/remove.php', 'api-server-remove');
$router->map('GET', '/api/server/list', 'api/server/list.php', 'api-server-list');

/** @var API Notifications  $match */
$router->map('POST', '/api/notifications/get', 'api/notifications/get.php', 'api-notifications-get');
$router->map('POST', '/api/notifications/readall', 'api/notifications/readall.php', 'api-notifications-readall');

/* Match the current request */
$match = $router->match();

/* Mount All Class */
$config = new Config($database);
$mail = new Mail($database);
$utility = new Activity();
$user = new User($database);
$srvs = new Listing($database);

/*
# ######################### #
# UPDATED BY : FLASHMODZ    #
# UPDATED AT : 04/29/2020   #
# REASON : ADD I18N         #
# ######################### #
*/
$deflang = 'en';
$lang = new i18n();
$lang->init();
if (!isset($_COOKIE['lang'])){
    setcookie('lang', $deflang, time() + (86400 * 30), "/");
}else{
    setcookie('lang', $_COOKIE['lang'], time() + (86400 * 30), "/");
}

/* Only Work if Website Has been Installed */
/* Reason to mount completely after install */
if ($is_config === true){
    $indexer = new Indexer($config->get("site_name"), $analytics, $database);
}else{
    $indexer = new Indexer($site, $analytics, $database);
}

/* Now, All are ready */
if ($match) {
    require $match['target'];
} else {
    if (!isset($_SESSION['token'])) {
        header('location: /');
        exit();
    }
    header("HTTP/1.0 404 Not Found");
    require 'errors/404.php';
}
?>