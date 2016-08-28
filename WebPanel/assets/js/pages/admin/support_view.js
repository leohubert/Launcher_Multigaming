/**
 * Created by leohu on 13/08/2016.
 */

var init = null;

function sendMessage()
{
    $.post(
        '/api/support/admin/send',
        {
            token : $("meta[name='token']").attr("content"),
            support_id : $("meta[name='id']").attr("content"),
            message : document.getElementById("chat_message").value
        },

        function(data){
            var obj = JSON.parse(data);
            var chat = document.getElementById("chat");
            if (obj.status == 41)
                window.location="/logout";
            else if (obj.status == 42)
                total_messages++;
            else if (obj.status == 44)
                sweetAlert("Missing permission", obj.message, "error");
            else if (obj.status != 42)
                $.Notification.notify('error','bottom center','Internal Error', "Error: " + obj.status + " | " + obj.message);
        },
        'text'
    );
}
function assign_support() {
    $.post(
        '/api/support/admin/assign',
        {
            token : $("meta[name='token']").attr("content"),
            id : $("meta[name='id']").attr("content")
        },

        function(data){
            var obj = JSON.parse(data);

            if (obj.status == 42)
            {
                $.Notification.notify('success','top right','Assigned !', obj.message);
            }
            else if (obj.status == 41)
                window.location="/logout";
            else if (obj.status == 44)
                sweetAlert("Missing permission", obj.message, "error");
            else
                swal("Error...", obj.message, "error");
        },

        'text'
    );
}
function save_support()
{
    init = null;
    $.post(
        '/api/support/admin/save',
        {
            token : $("meta[name='token']").attr("content"),
            support_id : $("meta[name='id']").attr("content"),
            status : document.getElementById("support_status").value,
            title: document.getElementById("support_title").value
        },

        function(data){
            var obj = JSON.parse(data);

            if (obj.status == 42)
                $.Notification.notify('success','top right','Saved !', obj.message);
            else if (obj.status == 41)
                window.location="/logout";
            else if (obj.status == 44)
                sweetAlert("Missing permission", obj.message, "error");
            else
                swal("Error...", obj.message, "error");
        },

        'text'
    );
}