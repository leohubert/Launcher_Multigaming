/**
 * Created by leohu on 13/08/2016.
 */

function loadNews() {
    $.post(
        '/api/news/admin/get',
        {
            token : $("meta[name='token']").attr("content"),
            id : $("meta[name='id']").attr("content")
        },

        function(data){
            var obj = JSON.parse(data);

            if (obj.status == 42)
            {
                document.getElementById("news_title").value = obj.title;
                document.getElementById("news_link").value = obj.link;
                document.getElementById("news_date").innerText = obj.date;
                document.getElementById("news_link_redirect").href = obj.link;
                document.getElementById("news_link_button").innerText = obj.link;
                document.getElementById("news_title_label").innerText = obj.title;
                document.getElementById("news_date_label").innerText = "Create at: " + obj.date;
            }
            else if (obj.status == 41)
                window.location="/logout";
            else
                swal("Error...", obj.message, "error");
        },

        'text'
    );
}
function saveNews() {
    $.post(
        '/api/news/admin/edit',
        {
            token :  $("meta[name='token']").attr("content"),
            title : document.getElementById("news_title").value,
            link : document.getElementById("news_link").value,
            id :  $("meta[name='id']").attr("content")
        },

        function(data){
            var obj = JSON.parse(data);

            if (obj.status == 42)
            {
                $.Notification.notify('success','top right','Saved !', obj.message);
                loadNews();
            }
            else if (obj.status == 41)
                window.location="/logout";
            else
                swal("Error...", obj.message, "error");
        },

        'text'
    );
}
function removeNews() {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this news!",
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
                '/api/news/admin/remove',
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
                            window.location = "/news";
                        }, 1000);
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