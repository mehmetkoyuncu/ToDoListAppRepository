

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
            {
                "render": function (data, type, row) {
                    if (row.isDone == false && row.isRemind == false) {
                        var taskTArray = row.taskTitle.split(' ');
                        taskTArray.forEach(loop);
                        var result;
                        function loop(item, index) {
                            if (index != 0)
                                result += "&npsb" + item;
                            else
                                result = item;
                        }
                        return "<a href='#' class='btn btn-danger complete' onclick=Remind('" + row.id + "-" + row.taskDate + "!" + result + "'); > <i class='fas fa-th-list mr-1'></i>Reminder</a >"
                        
                    }
                    else {
                        return "<button h class='btn btn-secondary complete' disabled > <i class='fas fa-th-list mr-1'></i>Reminder</button >"
                    }

                }
            }
           
        ]

    });
        //setInterval(function () {
        //    RemindControl();
        //}, 1000);
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
var dateList = [];

function GetList() {
    var _data;
    $.ajax({
        type: "GET",
        url: "https://localhost:44307/api/Task/GetAllTask",
        datatype: "json",
        async:false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var ReadyList = [];
            _data = data;
            _data.forEach(dateLoop);
            debugger;
            function dateLoop(item) {
                if (item.isRemind == true && item.isDone == false) {
                    var now = new Date();
                    now.setMilliseconds(0);
                    now.setSeconds(0);
                    var nw = now.getTime();
                    var taskDate = new Date(Date.parse(item.taskDate));
                    taskDate.setSeconds(0);
                    taskDate.setMilliseconds(0);
                    if (taskDate.getTime() < nw) {
                        var obj = { date: item.taskDateString, title: item.taskTitle };
                        ReadyList.push(obj);
                        debugger;
                        LoadRemindAlert(ReadyList);
                    }
                    else {
                        var obj = { title: item.taskTitle, date: item.taskDate };
                        dateList.push(obj);
                    }
                    debugger;
                }
            }
            debugger;
            ShowRemindAlerts(ReadyList);


        },
        fail:{
    }
    });
    return _data
}
function ShowRemindAlerts(readyList) {
    debugger;
    if (Array.isArray(readyList)) {
        $('#alerts').html("");
        readyList.forEach(AlertItem);
        function AlertItem(item) {
            debugger;
            $('#alerts').append("<div class='alert alert-danger'><a class='close' data-dismiss='alert'>×</a>" + "The task named <b class='bolder'>" + item.title + "</b>, should be completed on <b class='bolder'>" + item.date + "</b>, has not been completed.Please complete the task.." + "</div>");
        }
    }
    else {
        $('#alerts').append("<div class='alert alert-danger'><a class='close' data-dismiss='alert'>×</a>" + "The task named <b class='bolder'>" + readyList.title + "</b>, should be completed on <b class='bolder'>" + readyList.date + "</b>, has not been completed.Please complete the task.." + "</div>");
    }

   
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
function Remind(info) {
    debugger;
    var data = info;
    var firstInd = info.indexOf('-');
    var lastInd = info.indexOf('!');
    var disticntion = lastInd - firstInd;
    var date = data.substr(firstInd + 1, disticntion - 1);
    var title = info.substr(lastInd + 1);
    var array = title.split('&npsb');
    debugger;
    titleResult = array.join(' ');
    debugger;
    var idDist = firstInd - 0;
    debugger;
    var id = data.substr(0, idDist);
    debugger;
    var elementDate = new Date(Date.parse(date));
    var obj = {
        date: elementDate,
        title: title
    }
    dateList.push(obj);
    var id = Number(id);
    debugger;
    $.ajax({
        type: "POST",
        url: "https://localhost:44307/api/Task/RemindTask",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'Id': id }),
        success: function (data) {
            if (data == true) {
                swal({
                    title: "Reminder Created Successfully",
                    icon: "success",
                    button: "Ok",
                });

                LoadTb();
            }
            else {
                swal({
                    title: "Remainder Created Failed..",
                    text: "Please Try again..",
                    icon: "error",
                    button: "Ok",
                });
            }
        }
    });
    LoadTb();
}
function LoadRemindAlert(obj) {
    ShowRemindAlerts(obj);
}
function RemindControl() {
    var now = new Date();
    now.setMilliseconds(0);
    var nw = now.getTime();
    dateList.forEach(control);
    debugger;
    function control(item, index) {
        var itemDate = new Date(item.date);
        itemDate.setMilliseconds(0);
        if (itemDate.getTime() == nw) {
            ShowRemindAlerts(item);
            debugger;
        }
    }  
}
