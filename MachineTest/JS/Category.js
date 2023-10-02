$(document).ready(function () {
    GetId();
    $('#formCategory').submit(function (e) {
        e.preventDefault();
        var CategoryName = $('#Category').val();
        if (CategoryName === '') {
            $("#msg").append("<span class='text-danger font' style='font-size:12px'>Please Enter CategoryName !!</span>");
            return false;
        } else {
            $('#formCategory').submit();
            return false;
        }
    });
})
$.ajax({
    type: "GET",
    dataType: "json",
    contentType: "application/json",
    url: "/Category/List",
    success: function (res) {
        console.log("SUCCESS DATA:", res);
        $('#tbleBodyContent').html('');
        var ht = "";
        for (var i = 0; i < res.length; i++) {
            ht += "<tr>";
            ht += "<td>" + (i + 1) + "</td>";
            ht += "<td>" + res[i].CategoryName + "</td>";
            ht += "<td>" + ((res[i].Status) == true ? '<span class="badge bg-success">Yes</span>' : '<span class="badge bg-danger">No</span>') + "</td>";
            ht += "<td onclick='GetId("+res[i].ID+")'><a href='/Category/Edit?id=" + (res[i].ID) + "'><i class='fa fa-edit'></i></a></td>";
            ht += "<td><a href='#'  onclick='RemoveData(" + res[i].ID + ")'><i class='fa fa-trash'></i></td>";
            ht += "</tr>";
        }
        $('#tbleBodyContent').html(ht);
    },
    error: function (res) {
        console.log("ERROR DATA : ", res);
    }
});
//add
function formSumbitAdd() {
    var obj = {
        CategoryName: $("#Category").val(),
        Status: $("#Active").is(":checked")
    };
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "/Category/Add",
        data: JSON.stringify(obj),
        success: function (res) {
            alert(res);
            window.location.href = "/Category/Index";
        },
        error: function (res) {
            alert("ERROR :" + res);
        }
    });
    return false;
}
//Update
function formSumbitUpdate() {
    var obj = {
        ID: $("#ID").val(),
        CategoryName: $("#Category").val(),
        Status: $("#Active").is(":checked")
    };
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "/Category/Update",
        data: JSON.stringify(obj),
        success: function (res) {
            alert(res);
            window.location.href = "/Category/Index"
        },
        error: function (res) {
            alert("ERROR :" + res);
        }
    });
    return false;
}
function GetId() {
    $.ajax({
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        url: "/Category/GetId?id=" + idFromController,
        success: function (res) {
            console.log(res);
            $("#ID").val(res.ID);
            $("#Category").val(res.CategoryName);
            $("#Active").is(":checked");
            if (res.Status == true) {
                $("#Active").prop("checked", true);
            } else {
                $("#Active").prop("checked", false);
            }
        },
        error: function (res) {
            alert("ERROR :" + res);
        }
    });
}


//Remove
function RemoveData(id) {
    console.log(id);
    var flag = confirm('Are you sure Want to Delete Your Data');
    if (flag == false) {
        return;
    } else {
        $.ajax({
            type: "GET",
            dataType: "json",
            contentType: "application/json",
            url: "/Category/Delete?id=" + id,
            success: function (res) {
                alert("Data has Been Removed !!!");
                window.location.href = "/Category/Index";
            },
            error: function (res) {
                alert("ERROR");
            }
        })
    }
    return false;
}

