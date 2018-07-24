/**
 * Created by leohu on 13/08/2016.
 */

function loadUser() {
    var userUID = null;
    $.post(
        '/api/users/admin/get',
        {
            token :  $("meta[name='token']").attr("content"),
            id :  $("meta[name='id']").attr("content")
        },

        function(data){
            var obj = JSON.parse(data);
            if (obj.status == 42)
            {
                document.getElementById("detail_username").textContent = obj.user_username;
                document.getElementById("support_username").textContent = obj.user_username;
                document.getElementById("control_username").value = obj.user_username;
                document.getElementById("detail_email").textContent = obj.user_email;
                document.getElementById("support_email").textContent = obj.user_email;
                document.getElementById("control_email").value = obj.user_email;
                document.getElementById("detail_picture").src = obj.user_picture;
                document.getElementById("support_picture").src = obj.user_picture;
                document.getElementById("control_picture").value = obj.user_picture;
                document.getElementById("user_uid").innerHTML = obj.user_uid;
                document.getElementById("control_last_ip").value = obj.user_last_ip;
                document.getElementById("control_uid").value = obj.user_uid;
                document.getElementById("level" + obj.user_level).selected = true;
                document.getElementById("banned" + obj.user_banned).selected = true;
                userUID = obj.user_uid;
                if (obj.user_banned == "1")
                    document.getElementById("banned_pop").innerHTML = '<div class="alert alert-warning"> <strong>Warning !</strong> This user is banned !</div>';
                else
                    document.getElementById("banned_pop").innerHTML = '';
                var status = document.getElementById("detail_status");
                switch (obj.user_level) {
                    case "1":
                        status.innerHTML = '<small class="text-primary"><b>Player</b></small>';
                        break;
                    case "2":
                        status.innerHTML = '<small class="text-info"><b>Policeman</b></small>';
                        break;
                    case "3":
                        status.innerHTML = '<small class="text-success"><b>Medic</b></small>';
                        break;
                    case "4":
                        status.innerHTML = '<small class="text-danger"><b>Rebel</b></small>';
                        break;
                    case "5":
                        status.innerHTML = '<small class="text-purple"><b>VIP</b></small>';
                        break;
                    case "6":
                        status.innerHTML = '<small class="text-purple"><b>Support</b></small>';
                        break;
                    case "7":
                        status.innerHTML = '<small class="text-warning"><b>Moderator</b></small>';
                        break;
                    case "8":
                        status.innerHTML = '<small class="text-danger"><b>Admin</b></small>';
                        break;
                    case "9":
                        status.innerHTML = '<small class="text-primary"><b>Developer</b></small>';
                        break;
                    case "10":
                        status.innerHTML = '<small class="text-info"><b>Founder</b></small>';
                        break;
                    default:
                        status.innerHTML = '<small class="text-danger"><b>AnY</b></small>';
                        break;
                }
                $.post(
                    '/api/server/client/players/get',
                    {
                        token :  $("meta[name='token']").attr("content"),
                        id : 64,
                        user : $("meta[name='id']").attr("content")
                    },

                    function(data){
                        var obj = JSON.parse(data);
                        if (obj.status == 42) {
                            document.getElementById("player_cash").innerText = obj.cash;
                            document.getElementById("player_bank").innerText = obj.bank;
                            document.getElementById("player_name").innerText = obj.name;
                            document.getElementById("player_adminlevel").innerText = obj.adminlevel;
                            document.getElementById("player_mediclevel").innerText = obj.mediclevel;
                            document.getElementById("player_coplevel").innerText = obj.coplevel;
                        }
                        else if (obj.status == 40)
                        {
                            document.getElementById("player_cash").innerText = "Not found";
                            document.getElementById("player_bank").innerText = "Not found";
                            document.getElementById("player_name").innerText = "Not found";
                            document.getElementById("player_adminlevel").innerText = "Not found";
                            document.getElementById("player_mediclevel").innerText = "Not found";
                            document.getElementById("player_coplevel").innerText = "Not found";
                        }
                        else if (obj.status == 41)
                            window.location="/logout";
                    },

                    'text'
                );
                $.post(
                    '/api/server/client/players/get',
                    {
                        token :  $("meta[name='token']").attr("content"),
                        id : 64,
                        user : $("meta[name='id']").attr("content"),
                        type : 'yes'
                    },

                    function(data){
                        var obj = JSON.parse(data);
                        if (obj.status == 42) {
                            document.getElementById("vehicle").innerText = obj.vehicles;
                            document.getElementById("helicopter").innerText = obj.helicopters;
                        }
                        else if (obj.status == 40)
                        {
                            document.getElementById("vehicle").innerText = "Not found";
                            document.getElementById("helicopter").innerText = "Not found";
                        }
                        else if (obj.status == 41)
                            window.location="/logout";
                    },

                    'text'
                );

            }
            else if (obj.status == 41)
                window.location="/logout";
            else
                swal("Error...", obj.message, "error");
        },

        'text'
    );
}
function saveUser() {
    $.post(
        '/api/users/admin/save',
        {
            token :  $("meta[name='token']").attr("content"),
            id :  $("meta[name='id']").attr("content"),
            username : document.getElementById("control_username").value,
            email : document.getElementById("control_email").value,
            uid : document.getElementById("control_uid").value,
            picture : document.getElementById("control_picture").value,
            level : document.getElementById("control_level").value,
            banned : document.getElementById("control_banned").value
        },

        function(data){
            var obj = JSON.parse(data);
            if (obj.status == 42)
            {
                loadUser();
                $.Notification.notify('success','top right','Saved', obj.message);
            }
            else if (obj.status == 41)
                window.location="/logout";
            else
                swal("Error...", obj.message, "error");
        },

        'text'
    );
}
function deleteUser() {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this user !",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel plx!",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function(isConfirm){
        if (isConfirm) {
            $.post(
                '/api/users/admin/remove',
                {
                    token :  $("meta[name='token']").attr("content"),
                    id :  $("meta[name='id']").attr("content")
                },

                function(data){
                    var obj = JSON.parse(data);

                    if (obj.status == 42)
                    {
                        swal("Deleted!", obj.message , "success");
                        setInterval(function () {
                            window.location = "/users/all";
                        }, 1500);
                    }
                    else if (obj.status == 41)
                        window.location="/logout";
                    else
                        swal("Error...", obj.message, "error");
                },

                'text'
            );
        } else {
            swal("Cancelled", "Deletion successfully canceled", "error");
        }
    });
}

function createSupport() {
    $.post(
        '/api/support/admin/create',
        {
            token :  $("meta[name='token']").attr("content"),
            title : document.getElementById("createSupport_title").value,
            message : document.getElementById("createSupport_message").value,
            user_id :  $("meta[name='id']").attr("content")
        },

        function(data){
            var obj = JSON.parse(data);
            if (obj.status == 42)
            {
                sweetAlert("Support request created !", obj.message, "success");
                window.location = "/support/view/" + obj.support_id;
            }
            else if (obj.status == 41)
                window.location="/logout";
            else if (obj.status == 44)
                sweetAlert("Missing permission", obj.message, "error");
            else
                $.Notification.notify('error','bottom center','Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}