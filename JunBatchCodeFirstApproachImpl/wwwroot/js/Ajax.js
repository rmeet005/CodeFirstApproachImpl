

$(document).ready(function () {
    console.log("ready");
    fetchemp();
    getmanager();
});

$("#btn").click(function () {
    $("#exampleModal").modal('show');
    $("#savebtn").show();
    $("#updatebtn").hide();
    $("#exampleModal")[0].reset();

});

$("#clsbtn").click(function () {
    $("#exampleModal").modal('hide');
})

$("#savebtn").click(function () {
    var obj = $("#addemployee").serialize();
    console.log(obj);
    $.ajax({
        url: '/Employee/Index',
        method: 'Post',
        dataType: 'json',
        data: obj,
        contentType: 'application/x-www-form-urlencoded;charset=utf=8',
        success: function () {
            fetchemp();
            $("#exampleModal").modal('hide');
            toastr.success('Employee data added successfully')
            $("#exampleModal")[0].reset();
        },
        error: function () {
            alert('Not Added');
        }
    });
});

function fetchemp()
{
    $.ajax({
        url: '/Employee/getemp',
        method: "Get",
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response)
        {
            var obj = '';
            $.each(response, function (Index, item) {
                obj += '<tr>'
                obj += `<td>${item.id}</td>`
                obj += `<td>${item.name}</td>`
                obj += `<td>${item.email}</td>`
                obj += `<td>${item.role}</td>`
                obj += `<td>${item.salary}</td>`
                obj += `<td>${item.mid}</td>`
                obj += `<td>${item.mname}</td>`
                obj += '<td><a class="btn btn-sm btn-danger" onclick="delemp(' + item.id + ')">Delete</a> <a class="btn btn-sm btn-success" onclick="editemp(' + item.id + ')">Edit</a></td>'
                obj += '</tr>'
            });
        $("#mydata").html(obj)
    },
        error: function (){
        alert('error')
        }
    })
}

function delemp(id) {
    if (confirm("are you sure?")) {
        $.ajax({
            url: "/Employee/delemp?empid=" + id,
            dataType: 'json',
            success: function () {
                alert('Employee deleted succesfully');
                fetchemp();
            },
            error: function() {
                alert('sorrrrryryryryryryryryyr')
            }
        })
    }
}

function getmanager() {
    $.ajax({
        url: '/Manager/fetchmanager',
        method: "Get",
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            var obj = '';
            $.each(response, function (Index, item) {
                obj += '<tr>'
                obj += `<td>${item.mid}</td>`;
                obj += `<td>${item.mname}</td>`;
                obj += '<td><a class="btn btn-sm btn-danger" onclick="delmanager(' + item.mid + ')">Delete</a></td>';
                obj += '</tr>';
            });
            $("#managerdata").html(obj)
        },
        error: function () {
            alert('error')
        }
    })
}

function delmanager(id) {
    if (confirm("are you sure?")) {
        $.ajax({
            url: "/Manager/delmanager?mid=" + id,
            dataType: 'json',
            success: function () {
                alert('Employee deleted succesfully');
                fetchemp();
            },
            error: function () {
                toastr.error('can not delete manager it is assigned to employees')
            }
        })
    }
}

function editemp(id)
{
    $.ajax({
        url: '/Employee/editemp?empid=' + id,
        method: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            $("#exampleModal").modal('show');
            $("#savebtn").hide();
            
            $("#updatebtn").show();
            $("#Id").val(response.id);
            $("#Name").val(response.name);
            $("#Email").val(response.email);
            $("#Role").val(response.role);
            $("#Salary").val(response.salary);
            $("#Mid").val(response.mid);
        },
        error: function () {
            alert("not found");
        }
    })
}

$("#updatebtn").click(function () {

    var obj = $("#addemployee").serialize();
    console.log(obj);
    $.ajax({
        url: '/Employee/updateEmp',
        method: 'Post',
        dataType: 'json',
        data: obj,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        success: function () {
            fetchemp();
            $("#exampleModal").modal('hide');
            toastr.success('Employee data updated successfully')
            $("#exampleModal")[0].reset();
        },
        error: function () {
            alert('Not Added');
        }
    });
});