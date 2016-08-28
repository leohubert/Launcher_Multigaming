/**
 * Created by leohu on 13/08/2016.
 */

function loadUser() {
    var userUID = null;
    $.post(
        '/api/users/client/get',
        {
            token : $("meta[name='token']").attr("content")
        },

        function(data){
            var obj = JSON.parse(data);
            if (obj.status == 42)
            {
                document.getElementById("detail_username").textContent = obj.username;
                document.getElementById("detail_email").textContent = obj.email;
                document.getElementById("detail_picture").src = obj.picture;
                document.getElementById("control_username").value = obj.username;
                document.getElementById("control_email").value = obj.email;
                document.getElementById("control_picture").value = obj.picture;
                document.getElementById("control_last_ip").value = obj.last_ip;
                document.getElementById("control_uid").value = obj.uid;
                document.getElementById("level" + obj.level).selected = true;
                document.getElementById("banned" + obj.banned).selected = true;
                userUID = obj.user_uid;
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
        '/api/users/client/save',
        {
            token : $("meta[name='token']").attr("content"),
            id : $("meta[name='id']").attr("content"),
            email : document.getElementById("control_email").value,
            uid : document.getElementById("control_uid").value,
            picture : document.getElementById("control_picture").value
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
function changePassword() {
    $.post(
        '/api/users/client/changepass',
        {
            token : $("meta[name='token']").attr("content"),
            current_pass : document.getElementById("password_currentpassword").value,
            new_pass : document.getElementById("password_newpassword").value,
            confirm_pass : document.getElementById("password_confirmpassword").value
        },

        function(data){
            var obj = JSON.parse(data);
            if (obj.status == 42)
                $.Notification.notify('success','top right','Password changed !', obj.message);
            else if (obj.status == 41)
                window.location="/logout";
            else
                swal("Error...", obj.message, "error");
        },

        'text'
    );
}