

$(document).ready(function () {
    debugger;
    var _data = GetList();
    debugger;
    var tb = $("#table_todo").DataTable({
        destroy: true,
        retrieve: true,
        paging: true,
        pageLength: 5,
        lengthMenu: [[5, 10, 20, -1], [5, 10, 20, 'All']],
        "order": [[1, "desc"]],
        data: _data,
        "columns": [
            { data: "taskTitle", "autoWidth": true },
            { data: "taskDateString", "autoWidth": true },
            { data: "createdString", "autoWidth": true },
            { data: "updateString", "autowidth": true, },

            {
                "render": function (data, type, row) {
                    return "<a  class='btn btn-info text-light mr-2' onclick=ViewTask('" + row.id + "')><i class='fas fa-eye'></i></a>" +
                        "<a href='#' class='btn btn-warning text-light mr-2' onclick=UpdateSendTask('" + row.id + "'); ><i class='fas fa-pen-square mr-1'></i></a>" +
                        "<a class='btn btn-danger text-light' onclick=DeleteTask('" + row.id + "') > <i class=\"fas fa-trash-alt mr-1\"></i></a>";
                       
                }
            },
           
            {
                "render": function (data, type, row) {

                    if (row.isDone == true) {
                        return "<button class='btn btn-secondary complete' disabled><i class='fas fa-th-list mr-1'></i>Completed</button>"
                    }
                    else {
                        return "<a href='#' class='btn btn-success complete'   onclick=Complete('" + row.id + "'); ><i class='fas fa-th-list mr-1'></i>Complete</a>";
                    }

                }
            },
            {
                "render": function (data, type, row) {
                    if (row.isDone == true) {
                        return "<span class='badge badge-success complete'><i class='fas fa-check mr-1'></i>Complete</span>"
                    }
                    else {
                        return "<span class='badge badge-danger complete'><i class='fas fa-times mr-1'></i>Not Complete</span>"
                    }

                }
            },
           
        ]

    });
    debugger;
});
function ViewTask(id) {
    var Id = Number(id);
    debugger;
    $.ajax({
        type: "POST",
        url: "https://localhost:44307/api/Task/GetTask",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "Id": Id }),
        success: function (data) {
            debugger;
            $('#view_task_title').text(data.taskTitle);
            $('#view_task_description').text(data.taskContent);
            $('#ViewTaskModal').modal('show');
        },
        fail: {
            ////////Bakkkkk////
        }
    });
   
       
}
function GetList() {
    var _data;
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/api/Task/GetAllTask",
        datatype: "json",
        async:false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            _data = data;
        },
        fail:{
    }
    });
    return _data
}
function LoadTb() {
    $('#table_todo').dataTable().fnClearTable();
    var _data = GetList();
    if (_data.length != 0) {
        $("#table_todo").dataTable().fnAddData(_data);

    }
}
function DeleteTask(id) {
    var Id = Number(id);
    debugger;
    swal({
        title: "Are You Sure To Remove This ?",
        text: "Task will delete..",
        icon: "warning",
        buttons: ["Close", "Delete"],
    })
        .then((willDelete) => {
            if (willDelete) {
                debugger;
                $.ajax({
                    type: "DELETE",
                    url: "https://localhost:44307/api/Task/RemoveTask",
                    datatype: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ "Id": Id }),
                    success: function (data) {
                        if (data == true) {
                            swal({
                                title: "Successfully Removed",
                                icon: "success",
                                button: "Ok",
                            });

                            LoadTb();

                            
                        }
                        else {
                            swal({
                                title: "Removed Failed",
                                text: "Please Try Again..",
                                icon: "error",
                                button: "Ok",
                            });
                        }
                    }
                });
            }
        });
}
function AddTask() {
    var Title = $('#add_task_tittle').val();
    var Description = $('#add_task_description').val();
    var date = $('#date-time-add').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "https://localhost:44307/api/Task/AddTask",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'TaskTitle': Title, 'TaskContent': Description, 'TaskDateString': date }),
        success: function (data) {
            if (data == true) {
                swal({
                    title: "Task Added Successfully",
                    icon: "success",
                    button: "Ok",
                });

                LoadTb();
            }
            else {
                swal({
                    title: "Task Added Failed",
                    text: "Please Try Again..",
                    icon: "error",
                    button: "Ok",
                });
            }
        }
    });
    
    $("#add_task_modal .close").click();

}
function UpdateSendTask(id) {
    debugger;
    var Id = Number(id);
    $.ajax({
        type: "POST",
        url: "https://localhost:44307/api/Task/GetTask",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'Id': Id}),
        success: function (data) {
            debugger;
            $('#update_id').val(id);
            $('#update_task_tittle').val(data.taskTitle);
            $('#update_task_description').val(data.taskContent);
            var test =data.taskDate;
            $('#date-time-update').val(test);
            $('#update_task_modal').modal('show');
            debugger;
        },
        fail: {
            ////////////////////////Tamamla///////////////////////////////
        }
    });
    
}
function UpdateTask() {
        
    var id = $('#update_id').val();
    var Id = Number(id);
    var Title = $('#update_task_tittle').val();
    var Description = $('#update_task_description').val();
    var date = $('#date-time-update').val();
    debugger;
    debugger;
    $.ajax({
        type: "POST",
        url: "https://localhost:44307/api/Task/UpdateTask",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'Id': Id, 'TaskTitle': Title, 'TaskContent': Description, 'TaskDateString': date }),
        success: function (data) {
            if (data == true) {
                swal({
                    title: "Task Updated Successfullly",
                    icon: "success",
                    button: "Ok",
                });
                $('#table_todo').dataTable().fnClearTable();
                var _data = GetList();
                $("#table_todo").dataTable().fnAddData(_data);
            }
            else {
                swal({
                    title: "Task Updated Successfullly",
                    text: "Please Try Again",
                    icon: "error",
                    button: "Ok",
                });
            }
        }
    });
    $("#update_task_modal .close").click()

}
function Complete(id) {
    var Id = Number(id);
    debugger;
    $.ajax({
        type: "POST",
        url: "https://localhost:44307/api/Task/CompleteTask",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'Id': Id, }),
        success: function (data) {
            if (data == true) {
                swal({
                    title: "Task Done",
                    icon: "success",
                    button: "Ok",
                });

                LoadTb();
            }
            else {
                swal({
                    title: "Task Done Failed",
                    text: "Please Try again..",
                    icon: "error",
                    button: "Ok",
                });
            }
        }
    });

}