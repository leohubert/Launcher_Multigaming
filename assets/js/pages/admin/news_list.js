/**
 * Created by leohu on 13/08/2016.
 */
function loadNews() {
    $.post(
        '/api/news/admin/list',
        {
            token : $("meta[name='token']").attr("content"),
            show : 1000
        },

        function(data){
            var obj = JSON.parse(data);
            if (obj.status == 42)
            {
                var total = obj.total;
                var i = 0;

                while (total > 0)
                {
                    var table = document.getElementById('news');
                    var row = table.insertRow(table.rows.length);
                    row.id = i;
                    var id = row.insertCell(0);
                    var title = row.insertCell(1);
                    var server = row.insertCell(2);
                    var date = row.insertCell(3);
                    var link = row.insertCell(4);
                    var action = row.insertCell(5);
                    id.innerHTML = i;
                    title.innerHTML = obj.news[i].title;
                    server.innerHTML = obj.news[i].server_id;
                    date.innerHTML = obj.news[i].date;
                    link.innerHTML = obj.news[i].link;
                    action.innerHTML = '<a href="/news/view/'+ obj.news[i].id+'"> <button class="btn btn-icon waves-effect waves-light btn-primary m-b-5"> <i class="fa fa-eye"></i> </button></a>  <button class="btn btn-icon waves-effect waves-light btn-danger m-b-5" onclick="removeNews('+ i +','+ obj.news[i].id + ')"> <i class="fa fa-remove"></i></button>';
                    i++;
                    total--;
                }

                $(document).ready(function() {
                    $('#datatable').dataTable();
                    $('#datatable-keytable').DataTable( { keys: true } );
                    $('#datatable-responsive').DataTable();
                    var table = $('#datatable-fixed-header').DataTable( { fixedHeader: true } );
                } );
                TableManageButtons.init();
            }
            else if (obj.status == 44 || obj.status == 41)
                window.location="/logout";
            else
                $.Notification.notify('error','bottom center','Internal Error', "Error: " + obj.status + " | " + obj.message);
        },

        'text'
    );
    loadServers();
}

function loadServers() {
    $.get(
        '/api/server/list',
        {
            token : $("meta[name='token']").attr("content"),
            show : 1000
        },

        function(data){
            var obj = JSON.parse(data);
            if (obj.status == 42)
            {
                var total = obj.total;
                var i = 0;
                var servers = document.getElementById("news_servers");

                while (total > 0)
                {
                    var option = document.createElement("option");
                    option.text = obj.servers[i].game + ' | ' + obj.servers[i].name;
                    option.value = obj.servers[i].id;
                    servers.add(option, servers[i + 1]);
                    i++;
                    total--;
                }

            }
            else if (obj.status == 44 || obj.status == 41)
                window.location="/logout";
            else
                $.Notification.notify('error','bottom center','Internal Error', "Error: " + obj.status + " | " + obj.message);
        },

        'text'
    );
}

function addNews() {
    var selected_server = document.getElementById("news_servers");
    if (selected_server.value == "null")
    {
        $.Notification.notify('warning','top right','Be Careful', "Select a server before !");
        return;
    }
    $.post(
        '/api/news/admin/create',
        {
            token : $("meta[name='token']").attr("content"),
            title : document.getElementById("news_title").value,
            link : document.getElementById("news_link").value,
            server_id : selected_server.value,
            content : document.getElementById("news_content").value
        },

        function(data){
            var obj = JSON.parse(data);

            if (obj.status == 42)
            {
                $.Notification.notify('success','top right','Created !', obj.message);
                document.getElementById("news").innerHTML = "";
                document.getElementById("news_servers").innerHTML = "";
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
function removeNews(table_id, news_id) {
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
                    token : $("meta[name='token']").attr("content"),
                    id : news_id
                },

                function(data){
                    var obj = JSON.parse(data);

                    if (obj.status == 42)
                    {
                        swal("Deleted!", obj.message , "success");
                        document.getElementById(table_id).remove();
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