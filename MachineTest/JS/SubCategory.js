$(document).ready(function () {
    GetId();
    $('#FromSubCategory').submit(function (e) {
        e.preventDefault();
        var subCategory = $('#SubCategory').val();
        if (subCategory === '') {
            $("#msg").append("<span class='text-danger font' style='font-size:12px'>Please Enter CategoryName !!</span>");
            return false;
        }
        $('#FromSubCategory').submit();
    });
});
//List Bind-----------
$.ajax({
    type: "GET",
    dataType: "json",
    contentType: "application/json",
    url: "/SubCategory/List",
    success: function (res) {
        console.log("SUCCESS DATA:", res);
        $('#tbleBodyContent').html('');
        var ht = "";
        for (var i = 0; i < res.length; i++) {
            ht += "<tr>";
            ht += "<td>" + (i + 1) + "</td>";
            ht += "<td>" + res[i].CategoryName + "</td>";
            ht += "<td>" + res[i].SubCategoryName + "</td>";
            ht += "<td>" + ((res[i].Status) == true ? '<span class="badge bg-success">Yes</span>' : '<span class="badge bg-danger">No</span>') + "</td>";
            ht += "<td><a href='/SubCategory/Edit?id=" + (res[i].ID) + "'><i class='fa fa-edit'></i></a></td>";
            ht += "<td><a href='#' onclick='RemoveData(" + res[i].ID + ")'><i class='fa fa-trash'></i></td>";
            ht += "</tr>";
        }
        $('#tbleBodyContent').html(ht);
    },
    error: function (res) {
        console.log("ERROR DATA : ", res);
    }
});
//-----Add-------------
function formSumbitAdd() {
    var obj = {
        SubCategoryName: $("#SubCategory").val(),
        CategoryName: $("#Category").val(),
        Status: $("#Active").is(":checked")
    };
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "/SubCategory/Add",
        data: JSON.stringify(obj),
        success: function (res) {
            alert(res);
            window.location.href = "/SubCategory/Index";
        },
        error: function (res) {
            alert("ERROR :" + res);
        }
    });
    return false;
}
//----------------Update-------------
function formSumbitUpdate() {
    var obj = {
        ID: $("#ID").val(),
        SubCategoryName: $("#SubCategory").val(),
        CategoryName: $("#Category").val(),
        Status: $("#Active").is(":checked")
    };
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "/SubCategory/Update",
        data: JSON.stringify(obj),
        success: function (res) {
            alert(res);
            window.location.href = "/SubCategory/Index";
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
        url: "/SubCategory/GetId?id=" + idFromController,
        success: function (res) {
            console.log(res);
            $("#ID").val(res.ID);
            $("#Category").val(res.CategoryName);
            $("#SubCategory").val(res.SubCategoryName);
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
///------------Remove---------------
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
            url: "/SubCategory/Remove?id=" + id,
            success: function (res) {
                alert("Data has Been Removed !!!");
                window.location.href = "/SubCategory/Index";
            },
            error: function (res) {
                alert("ERROR");
            }
        })
    }
    return false;
}

///---CategoryDroDowen------------
$.ajax({
    type: "GET",
    dataType: "json",
    contentType: "application/json",
    url: "/Category/CategoryDrop",
    success: function (data) {
        console.log("SUCCESS DATA:", data);
        var dropdown = $('#Category');
        $.each(data, function (index, item) {
            dropdown.append($('<option value="' + item.ID + '">'+item.CategoryName+'</option>'));
        });
    },
    error: function (data) {
        console.log("ERROR DATA : ", data);
    }
});



