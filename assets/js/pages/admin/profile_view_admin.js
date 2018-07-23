/**
 * Created by leohu on 13/08/2016.
 */

function loadUser() {
    var userUID = null;
    $.post(
        '/api/users/client/get',
        {
            token :  $("meta[name='token']").attr("content")
        },

        function(data){
            var obj = JSON.parse(data);
            if (obj.status == 42)
            {
                document.getElementById("detail_username").textContent = obj.username;
                document.getElementById("detail_email").textContent = obj.email;
                document.getElementById("detail_picture").src = obj.picture;
                document.getElementById("user_uid").innerHTML = obj.uid;
                userUID = obj.uid;
                var status = document.getElementById("detail_status");
                switch (obj.level) {
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
                        id : 64
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
                        else if (obj.status == 40) {
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