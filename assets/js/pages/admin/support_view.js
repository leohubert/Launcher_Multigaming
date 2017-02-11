/**
 * Created by leohu on 13/08/2016.
 */

var init = null;
$(function() {
    var total_messages = null;

    afficheConversation();
    function afficheConversation()
    {
        $.post(
            '/api/support/admin/get',
            {
                token : $("meta[name='token']").attr("content"),
                id : $("meta[name='id']").attr("content")
            },

            function(data){
                var obj = JSON.parse(data);
                var chat = document.getElementById("chat");
                chat.innerHTML = "";
                if (obj.status == 42)
                {
                    var total = obj.total;
                    var i = 0;

                    if (total_messages != total)
                    {
                        if (total_messages != null)
                        {
                            var audio = new Audio('/assets/sounds/job-done.mp3');
                            audio.play();
                            $.Notification.notify('success','top right','New message', "You have a new message");
                        }
                        total_messages = total;
                    }
                    while (total > 0)
                    {
                        var date = new Date(obj.messages[i].send_at);
                        if (obj.messages[i].me == 1)
                            chat.innerHTML += '<li class="clearfix odd"> <div class="chat-avatar"> <img src="'+ obj.messages[i].sender_picture +'"> <i>'+ date.getHours() + ":" + date.getMinutes() +'</i> </div> <div class="conversation-text"> <div class="ctext-wrap"><i>'+ obj.messages[i].sender_name +'</i> <p>'+ obj.messages[i].message +'</p> </div> </div> </li>';
                        else
                            chat.innerHTML += '<li class="clearfix"> <div class="chat-avatar"> <img src="'+ obj.messages[i].sender_picture +'"> <i>'+ date.getHours() + ":" + date.getMinutes() +'</i> </div> <div class="conversation-text"> <div class="ctext-wrap"><i>'+ obj.messages[i].sender_name +'</i> <p>'+ obj.messages[i].message +'</p> </div> </div> </li>';
                        i++;
                        total--;
                    }
                    chat.scrollTop = 8000;
                    if (init == null)
                    {
                        document.getElementById("support_title").value = obj.support_title;
                        document.getElementById("support_status" + obj.support_status).selected = true;
                        init = 1;
                    }
                }
                else if (obj.status == 41)
                    window.location="/logout";
                else if (obj.status == 44)
                    sweetAlert("Missing permission", obj.message, "error");
                else if (obj.status ==  40)
                    sweetAlert("Little 4:04 error ...", "This conversation doesn't exits", "error");
                else
                    $.Notification.notify('error','bottom center','Internal Error', "Error: " + obj.status + " | " + obj.message);
            },

            'text'
        );
    }
    setInterval(afficheConversation, 4000);
});

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