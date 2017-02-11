/**
 * Created by leohu on 13/08/2016.
 */

function loadSupport()
{
    $.post(
        '/api/users/admin/banned',
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
                    var table = document.getElementById('users');
                    var row = table.insertRow(table.rows.length);
                    row.id = i;
                    var id = row.insertCell(0);
                    var username = row.insertCell(1);
                    var email = row.insertCell(2);
                    var banned = row.insertCell(3);
                    var level = row.insertCell(4);
                    var last_ip = row.insertCell(5);
                    var uid = row.insertCell(6);
                    var action = row.insertCell(7);
                    id.innerHTML = i;
                    username.innerHTML = obj.users[i].username;
                    email.innerHTML = obj.users[i].email;
                    banned.innerHTML = obj.users[i].banned;
                    level.innerHTML = obj.users[i].level;
                    last_ip.innerHTML = obj.users[i].last_ip;
                    if (jQuery.isNumeric(obj.users[i].uid))
                        uid.innerHTML = "<a href='http://steamcommunity.com/profiles/" + obj.users[i].uid + "'>" + obj.users[i].uid + "</a>";
                    else
                        uid.innerHTML = obj.users[i].uid;
                    action.innerHTML = '<a href="/users/view/'+ obj.users[i].id+'"> <button class="btn btn-icon waves-effect waves-light btn-primary m-b-5"> <i class="fa fa-eye"></i> </button></a>';
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
}

function remove_support(table_id, support_id)
{
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
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
                '/api/support/admin/remove',
                {
                    token : $("meta[name='token']").attr("content"),
                    id : support_id
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

function assign_support(support_id, button_id) {
    $.post(
        '/api/support/admin/assign',
        {
            token : $("meta[name='token']").attr("content"),
            id : support_id
        },

        function(data){
            var obj = JSON.parse(data);

            if (obj.status == 42)
            {
                $.Notification.notify('success','top right','Assigned !', obj.message);
                document.getElementById(button_id).remove();
                document.getElementById('support').innerHTML = "";
                loadSupport();
            }
            else if (obj.status == 41)
                window.location="/logout";
            else
                swal("Error...", obj.message, "error");
        },

        'text'
    );
}