/**
 * Created by leohu on 13/08/2016.
 */

function refresh() {
    setTimeout(function() {
        location.reload();
    }, 100);
};

async function getTranslation(key) {
    let lll = getCookie('lang');
    let klkey = key;

    if (lll) {
        if (klkey) {
            let data = new FormData();
            data.append('lang', lll);
            data.append('var', klkey);
            return (await (await fetch("api/utility/language.php", { method: "POST", body: data })).json()).message;
        };
    };
};

function getCookie(name) {
    let re = new RegExp(name + "=([^;]+)");
    let value = re.exec(document.cookie);
    return (value != null) ? unescape(value[1]) : null;
}

/*async function turnOffMaintenance() {
    let data = new FormData(); 
    data.append('token', $("meta[name='token']").attr("content"));
    data.append(state, 0);
    return (await (await fetch("/api/switch/maintenance", { method: "POST", body: data})).json()).message;
}*/

function switch_maintenance() {
    var button = document.getElementById("maintenance");
    var label = document.getElementById("maintenance_state");

    if (label.textContent == "Activated") {
        $.post(
            '/api/switch/maintenance', {
                token: $("meta[name='token']").attr("content"),
                state: 0
            },

            function(data) {
                var obj = JSON.parse(data);
                if (obj.status == 42) {
                    $.Notification.notify('success', 'top right', 'Maintenance deactivate', "Maintenance was been deactivated");
                    button.textContent = "Active maintenance";
                    label.className = "label label-danger";
                    label.textContent = "Deactivated";
                } else if (obj.status == 41)
                    window.location = "/logout";
                else if (obj.status == 44)
                    swal({ title: "Missing permission", text: obj.message, type: "error" },
                        function() {
                            window.location = "/logout";
                        }
                    );
                else
                    $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
            },

            'text'
        );
    } else {
        $.post(
            '/api/switch/maintenance', {
                token: $("meta[name='token']").attr("content"),
                state: 1
            },

            function(data) {
                var obj = JSON.parse(data);
                if (obj.status == 42) {
                    $.Notification.notify('warning', 'top right', 'Maintenance active', "Maintenance was been activated");
                    button.textContent = "Deactivate maintenance";
                    label.className = "label label-success";
                    label.textContent = "Activated";
                } else if (obj.status == 41)
                    window.location = "/logout";
                else if (obj.status == 44)
                    swal({ title: "Missing permission", text: obj.message, type: "error" },
                        function() {
                            window.location = "/logout";
                        }
                    );
                else
                    $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);

            },

            'text'
        );
    }
}

function switch_login() {
    var button = document.getElementById("login");
    var label = document.getElementById("login_state");

    if (label.textContent == "Activated") {
        $.post(
            '/api/switch/login', {
                token: $("meta[name='token']").attr("content"),
                state: 0
            },

            function(data) {
                var obj = JSON.parse(data);
                if (obj.status == 42) {
                    $.Notification.notify('warning', 'top right', 'Login deactivate', "Login was been deactivated");
                    button.textContent = "Active login";
                    label.className = "label label-danger";
                    label.textContent = "Deactivated";
                } else if (obj.status == 41)
                    window.location = "/logout";
                else if (obj.status == 44)
                    swal({ title: "Missing permission", text: obj.message, type: "error" },
                        function() {
                            window.location = "/logout";
                        }
                    );
                else
                    $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);

            },

            'text'
        );
    } else {
        $.post(
            '/api/switch/login', {
                token: $("meta[name='token']").attr("content"),
                state: 1
            },

            function(data) {
                var obj = JSON.parse(data);
                if (obj.status == 42) {
                    $.Notification.notify('success', 'top right', 'Login activate', "Login was been activated");
                    button.textContent = "Deactivate login";
                    label.className = "label label-success";
                    label.textContent = "Activated";
                } else if (obj.status == 41)
                    window.location = "/logout";
                else if (obj.status == 44)
                    swal({ title: "Missing permission", text: obj.message, type: "error" },
                        function() {
                            window.location = "/logout";
                        }
                    );
                else
                    $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);

            },

            'text'
        );
    }
}

function switch_register() {
    var button = document.getElementById("register");
    var label = document.getElementById("register_state");

    if (label.textContent == "Activated") {
        $.post(
            '/api/switch/register', {
                token: $("meta[name='token']").attr("content"),
                state: 0
            },

            function(data) {
                var obj = JSON.parse(data);
                if (obj.status == 42) {
                    $.Notification.notify('warning', 'top right', 'Register deactivate', "Register was been deactivated");
                    button.textContent = "Active register";
                    label.className = "label label-danger";
                    label.textContent = "Deactivated";
                } else if (obj.status == 41)
                    window.location = "/logout";
                else if (obj.status == 44)
                    swal({ title: "Missing permission", text: obj.message, type: "error" },
                        function() {
                            window.location = "/logout";
                        }
                    );
                else
                    $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);

            },

            'text'
        );
    } else {
        $.post(
            '/api/switch/register', {
                token: $("meta[name='token']").attr("content"),
                state: 1
            },

            function(data) {
                var obj = JSON.parse(data);
                if (obj.status == 42) {
                    $.Notification.notify('success', 'top right', 'Register activate', "Register was been activated");
                    button.textContent = "Deactivate register";
                    label.className = "label label-success";
                    label.textContent = "Activated";
                } else if (obj.status == 41)
                    window.location = "/logout";
                else if (obj.status == 44)
                    swal({ title: "Missing permission", text: obj.message, type: "error" },
                        function() {
                            window.location = "/logout";
                        }
                    );
                else
                    $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);

            },

            'text'
        );
    }
}

function switch_taskforce() {
    var button = document.getElementById("taskforce");
    var label = document.getElementById("taskforce_state");

    if (label.textContent == "Activated") {
        $.post(
            '/api/switch/taskforce', {
                token: $("meta[name='token']").attr("content"),
                state: 0
            },

            function(data) {
                var obj = JSON.parse(data);
                if (obj.status == 42) {
                    $.Notification.notify('warning', 'top right', 'Taskforce deactivate', "Taskforce was been deactivated");
                    button.textContent = "Active register";
                    label.className = "label label-danger";
                    label.textContent = "Deactivated";
                } else if (obj.status == 41)
                    window.location = "/logout";
                else if (obj.status == 44)
                    swal({ title: "Missing permission", text: obj.message, type: "error" },
                        function() {
                            window.location = "/logout";
                        }
                    );
                else
                    $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);

            },

            'text'
        );
    } else {
        $.post(
            '/api/switch/taskforce', {
                token: $("meta[name='token']").attr("content"),
                state: 1
            },

            function(data) {
                var obj = JSON.parse(data);
                if (obj.status == 42) {
                    $.Notification.notify('success', 'top right', 'Taskforce activate', "Taskforce was been activated");
                    button.textContent = "Deactivate register";
                    label.className = "label label-success";
                    label.textContent = "Activated";
                } else if (obj.status == 41)
                    window.location = "/logout";
                else if (obj.status == 44)
                    swal({ title: "Missing permission", text: obj.message, type: "error" },
                        function() {
                            window.location = "/logout";
                        }
                    );
                else
                    $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);

            },

            'text'
        );
    }
}

function save_maintenance() {
    $.post(
        '/api/update/maintenance', {
            token: $("meta[name='token']").attr("content"),
            maintenance_title: document.getElementById("maintenance_title").value,
            maintenance_content: document.getElementById("maintenance_content").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                $.Notification.notify('success', 'top right', 'Maintenance saved', obj.message);
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function save_loginNews() {
    $.post(
        '/api/update/loginNews', {
            token: $("meta[name='token']").attr("content"),
            msg_title: document.getElementById("msg_title").value,
            msg_content: document.getElementById("msg_content").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                $.Notification.notify('success', 'top right', 'Login News saved', obj.message);
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function updatewebsite() {
    $.post(
        '/api/config', {
            token: $("meta[name='token']").attr("content"),
            name: "site_name",
            send: document.getElementById("sitename").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                swal({ title: "Success", text: obj.message, type: "success" },
                    function() {
                        location.reload();
                    }
                );
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else if (obj.status == 40)
                swal({ title: "Problem with the core", text: obj.message, type: "error" });
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function updatemaccount() {
    $.post(
        '/api/config', {
            token: $("meta[name='token']").attr("content"),
            name: "max_account",
            send: document.getElementById("maxaccount").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                swal({ title: "Success", text: obj.message, type: "success" });
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else if (obj.status == 40)
                swal({ title: "Problem with the core", text: obj.message, type: "error" });
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function updateurlwebsite() {
    $.post(
        '/api/config', {
            token: $("meta[name='token']").attr("content"),
            name: "url_website",
            send: document.getElementById("url_website").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                swal({ title: "Success", text: obj.message, type: "success" });
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else if (obj.status == 40)
                swal({ title: "Problem with the core", text: obj.message, type: "error" });
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function updatemailhost() {
    $.post(
        '/api/config', {
            token: $("meta[name='token']").attr("content"),
            name: "host_mail",
            send: document.getElementById("mailhost").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                swal({ title: "Success", text: obj.message, type: "success" });
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else if (obj.status == 40)
                swal({ title: "Problem with the core", text: obj.message, type: "error" });
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function updatemailusername() {
    $.post(
        '/api/config', {
            token: $("meta[name='token']").attr("content"),
            name: "username_mail",
            send: document.getElementById("mailusername").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                swal({ title: "Success", text: obj.message, type: "success" });
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else if (obj.status == 40)
                swal({ title: "Problem with the core", text: obj.message, type: "error" });
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function updatemailpassword() {
    $.post(
        '/api/config', {
            token: $("meta[name='token']").attr("content"),
            name: "password_mail",
            send: document.getElementById("mailpassword").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                swal({ title: "Success", text: obj.message, type: "success" });
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else if (obj.status == 40)
                swal({ title: "Problem with the core", text: obj.message, type: "error" });
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function updatemailsecure() {
    $.post(
        '/api/config', {
            token: $("meta[name='token']").attr("content"),
            name: "secure_mail",
            send: document.getElementById("mailsecure").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                swal({ title: "Success", text: obj.message, type: "success" });
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else if (obj.status == 40)
                swal({ title: "Problem with the core", text: obj.message, type: "error" });
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function updatemailport() {
    $.post(
        '/api/config', {
            token: $("meta[name='token']").attr("content"),
            name: "ports_mail",
            send: document.getElementById("mailport").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                swal({ title: "Success", text: obj.message, type: "success" });
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else if (obj.status == 40)
                swal({ title: "Problem with the core", text: obj.message, type: "error" });
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function updatemailsender() {
    $.post(
        '/api/config', {
            token: $("meta[name='token']").attr("content"),
            name: "sender_mail",
            send: document.getElementById("mailsender").value
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42)
                swal({ title: "Success", text: obj.message, type: "success" });
            else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else if (obj.status == 40)
                swal({ title: "Problem with the core", text: obj.message, type: "error" });
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function update_vmod() {
    var newVersion = parseFloat(document.getElementById("vmod").textContent) + 0.000001;
    $.post(
        '/api/update/vmod', {
            token: $("meta[name='token']").attr("content"),
            vmod: newVersion.toFixed(6)
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42) {
                $.Notification.notify('success', 'top right', 'New update created', obj.message);
                document.getElementById("vmod").textContent = newVersion.toFixed(6);
            } else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

function update_vtaskforce() {
    var newVersion = parseFloat(document.getElementById("vtaskforce").textContent) + 0.000001;
    $.post(
        '/api/update/vtaskforce', {
            token: $("meta[name='token']").attr("content"),
            vtaskforce: newVersion.toFixed(6)
        },

        function(data) {
            var obj = JSON.parse(data);
            if (obj.status == 42) {
                $.Notification.notify('success', 'top right', 'New taskforce update created', obj.message);
                document.getElementById("vtaskforce").textContent = newVersion.toFixed(6);
            } else if (obj.status == 41)
                window.location = "/logout";
            else if (obj.status == 44)
                swal({ title: "Missing permission", text: obj.message, type: "error" },
                    function() {
                        window.location = "/logout";
                    }
                );
            else
                $.Notification.notify('error', 'bottom center', 'Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}

/*
# ######################### #
# UPDATED BY : FLASHMODZ    #
# UPDATED AT : 04/29/2020   #
# REASON : REMOVE FEATURE   #
# ######################### #
*/

function openLauncherconfig() {

    swal({ title: "Not Yet", text: "Feature has reserved for V6, please check Discord", type: "warning" });
}

async function testmssg() {
    const _close = await getTranslation('close');
    const _title = await getTranslation('settings.title');
    swal({ title: _title, text: _close, type: "warning" });
}

/*
FUTUR FOR I18N ** DONT DELETE **
function testCookies(name, value) {
    var today = new Date();
    var expiry = new Date(today.getTime() + 30 * 24 * 3600 * 1000); // plus 30 days
    document.cookie = name + "=" + escape(value) + "; path=/; expires=" + expiry.toGMTString();
    refresh();
}
*/

var level = $("meta[name='level']").attr("content");

function checkLevel() {
    if (level < 9)
        swal({ title: "Missing permission", text: obj.message, type: "error" },
            function() {
                window.location = "/logout";
            }
        );
}

function escapeTags(str) {
    return String(str)
        .replace(/&/g, '&amp;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#39;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;');
}
window.onload = function() {
    $.get(
        '/api/settings', {
            launcher: 0
        },

        function(data) {
            var obj = JSON.parse(data);

            if (obj.maintenance == 0) {
                var button = document.getElementById("maintenance");
                var label = document.getElementById("maintenance_state");

                button.textContent = "Active maintenance";
                label.className = "label label-danger";
                label.textContent = "Deactivated";
            }
            if (obj.taskforce == 0) {
                var button = document.getElementById("taskforce");
                var label = document.getElementById("taskforce_state");

                button.textContent = "Active taskforce";
                label.className = "label label-danger";
                label.textContent = "Deactivated";
            }
            if (obj.login == 0) {
                var button = document.getElementById("login");
                var label = document.getElementById("login_state");

                button.textContent = "Active login";
                label.className = "label label-danger";
                label.textContent = "Deactivated";
            }
            if (obj.register == 0) {
                var button = document.getElementById("register");
                var label = document.getElementById("register_state");

                button.textContent = "Active register";
                label.className = "label label-danger";
                label.textContent = "Deactivated";
            }

            if (obj.indexer == 0) {
                var label = document.getElementById("indexer_state");

                label.className = "label label-danger";
                label.textContent = "No Support for your Product";
            }

            document.getElementById("maintenance_title").value = obj.maintenance_title;
            document.getElementById("maintenance_content").value = obj.maintenance_content;
            document.getElementById("msg_title").value = obj.msg_title;
            document.getElementById("msg_content").value = obj.msg_content;
            document.getElementById("vlauncher").textContent = obj.vlauncher;
        },

        'text'
    );


    if (level < 9)
        swal({ title: "Missing permission", text: "You are not Admin !", type: "error" },
            function() {
                window.location = "/logout";
            }
        );
    var btn = document.getElementById('uploadBtn'),
        progressBar = document.getElementById('progressBar'),
        progressOuter = document.getElementById('progressOuter'),
        msgBox = document.getElementById('msgBox');
    var uploader = new ss.SimpleUpload({
        button: btn,
        url: '/api/games/upload_launcher.php',
        name: 'uploadfile',
        allowedExtensions: ['exe'],
        multipart: true,
        maxSize: false,
        hoverClass: 'hover',
        focusClass: 'focus',
        responseType: 'json',
        startXHR: function() {
            progressOuter.style.display = 'block'; // make progress bar visible
            this.setProgressBar(progressBar);
        },
        onSubmit: function() {
            msgBox.innerHTML = ''; // empty the message box
            btn.innerHTML = 'Uploading...'; // change button text to "Uploading..."
        },
        onComplete: function(filename, response) {
            btn.innerHTML = 'Choose Another File';
            progressOuter.style.display = 'none'; // hide progress bar when upload is completed
            if (!response) {
                msgBox.innerHTML = 'Unable to upload file';
                return;
            }
            if (response.success === true) {
                msgBox.innerHTML = '<strong>' + escapeTags(filename) + '</strong>' + ' successfully uploaded.';
            } else {
                if (response.msg) {
                    msgBox.innerHTML = escapeTags(response.msg);
                } else {
                    msgBox.innerHTML = 'An error occurred and the upload failed.';
                }
            }
        },
        onError: function() {
            progressOuter.style.display = 'none';
            msgBox.innerHTML = 'Unable to upload file';
        }
    });
};