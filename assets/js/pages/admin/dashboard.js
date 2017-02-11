/**
 * Created by leohu on 13/08/2016.
 */

function loadAll()
{
    $.get(
        '/api/stats/dashboard',
        {
        },

        function(data){
            var obj = JSON.parse(data);
            if (obj.status == 42)
            {
                document.getElementById("total_7days").textContent = obj.total_7days;
                document.getElementById("total_new7days").textContent = obj.total_new7days;
                document.getElementById("total_users").textContent = obj.nbUsers;
                document.getElementById("total_admins").textContent = obj.nbAdmins;
            }
        },

        'text'
    );
    loadSupport();
}

function loadSupport()
{
    $.post(
        '/api/support/admin/list',
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
                    var table = document.getElementById('support');
                    var row = table.insertRow(table.rows.length);
                    row.id = i;
                    var id = row.insertCell(0);
                    var create_by = row.insertCell(1);
                    var title = row.insertCell(2);
                    var create_at = row.insertCell(3);
                    var update_at = row.insertCell(4);
                    var status = row.insertCell(5);
                    var assign_to = row.insertCell(6);
                    var action = row.insertCell(7);
                    id.innerHTML = i;
                    create_by.innerHTML = obj.support[i].started_by;
                    title.innerHTML = obj.support[i].title;
                    create_at.innerHTML = obj.support[i].started_at;
                    update_at.innerHTML = obj.support[i].updated_at
                    action.innerHTML =  '<a href="/support/view/' + obj.support[i].support_id +'"><button class="btn btn-icon waves-effect waves-light btn-info m-b-5"> <i class="fa fa-edit"></i></button></a> ' +
                        '<button class="btn btn-icon waves-effect waves-light btn-danger m-b-5" onclick="remove_support('+ i +','+ obj.support[i].support_id + ')"> <i class="fa fa-remove"></i></button>';
                    if (obj.support[i].status == "0")
                        assign_to.innerHTML = "No one";
                    else
                        assign_to.innerHTML = obj.support[i].assign_to;
                    switch (obj.support[i].status)
                    {
                        case "0":
                            status.innerHTML = '<span class="label label-primary">No assigned</span>';
                            action.innerHTML += ' <button id="assign_button'+ i +'" class="btn btn-icon waves-effect waves-light btn-success m-b-5" onclick="assign_support('+ obj.support[i].support_id +',this.id)"> <i class="fa fa-check"></i> </button>';

                            break;
                        case "1":
                            status.innerHTML = '<span class="label label-info">Assigned</span>';
                            break;
                        case "2":
                            status.innerHTML = '<span class="label label-purple">In progress</span>';
                            break;
                        case "3":
                            status.innerHTML = '<span class="label label-success">Done</span>';
                            break;
                        case "4":
                            status.innerHTML = '<span class="label label-danger">Closed</span>';
                            break;
                    }
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
        text: "You will not be able to recover this conversation!",
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