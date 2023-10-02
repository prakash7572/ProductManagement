
$(document).ready(function () {
    GetId();
    $('#formProduct').submit(function (e) {
        e.preventDefault();
        var ProductName = $('#ProductName').val();
        if (ProductName === '') {
            $("#msg").append("<span class='text-danger font' style='font-size:12px'>Please Enter ProductName !!</span>");
            return false;
        }
        $('#formProduct').submit();
    });
   
})
////List Bind
$.ajax({
    type: "GET",
    dataType: "json",
    contentType: "application/json",
    url: "/Product/List",
    success: function (res) {
        console.log("SUCCESS DATA:", res);
        $('#tblContent').html('');
        var ht = "";
        for (var i = 0; i < res.length; i++) {
            ht += "<tr>";
            ht += "<td>" + (i + 1) + "</td>";
            ht += "<td>" + res[i].CategoryName + "</td>";
            ht += "<td>" + res[i].SubCategoryName + "</td>";
            ht += "<td>" + res[i].ProductName + "</td>";
            ht += "<td>" + res[i].ShorDescription + "</td>";
            ht += "<td>" + res[i].FullDescription + "</td>";
            ht += "<td>" + ((res[i].Status) == true ? '<span class="badge bg-success">Yes</span>' : '<span class="badge bg-danger">No</span>') + "</td>";
            ht += "<td onclick='GetId(" + res[i].ID + ")'><a href='/Product/Edit?id=" + (res[i].ID) + "'><i class='fa fa-edit'></i></a></td>";
            ht += "<td><a href='#'  onclick='RemoveData(" + res[i].ID + ")'><i class='fa fa-trash'></i></td>";
            ht += "</tr>";
        }
        $('#tblContent').html(ht);
    },
    error: function (res) {
        console.log("ERROR DATA : ", res);
    }
});
//------------Add Function----------------
function formSumbitAdd() {
    var obj = {
        CategoryName: $("#CategoryName").val(),
        SubCategoryName: $("#SubCategoryName").val(),
        ProductName: $("#ProductName").val(),
        ShorDescription: $("#ShorDescription").val(),
        FullDescription: $("#FullDescription").val(),
        Status: $("#Status").is(":checked")
    };
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "/Product/Add",
        data: JSON.stringify(obj),
        success: function (res) {
            alert(res);
            window.location.href = "/Product/Index";
        },
        error: function (res) {
            alert("ERROR :" + res);
        }
    });
    return false;
}
//--------------UpdateFunction---------------
function formSumbitUpdate() {
    var obj = {
        ID: $("#ID").val(),
        CategoryName: $("#CategoryName").val(),
        SubCategoryName: $("#SubCategoryName").val(),
        ProductName: $("#ProductName").val(),
        ShorDescription: $("#ShorDescription").val(),
        FullDescription: $("#FullDescription").val(),
        Status: $("#Status").is(":checked")
    };
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "/Product/Update",
        data: JSON.stringify(obj),
        success: function (res) {
            alert(res);
            window.location.href = "/Product/Index";
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
        url: "/Product/GetId?id=" + idFromController,
        success: function (res) {
            console.log(res);
                $("#ID").val(res.ID),
                $("#CategoryName").val(res.CategoryName),
                $("#SubCategoryName").val(res.SubCategoryName),
                $("#ProductName").val(res.ProductName),
                $("#ShorDescription").val(res.ShorDescription),
                $("#FullDescription").val(res.FullDescription),
                $("#Status").is(":checked")
            if (res.Status == true) {
                $("#Status").prop("checked", true);
            } else {
                $("#Status").prop("checked", false);
            }
        },
        error: function (res) {
            alert("ERROR :" + res);
        }
    });
}
//--------------Remove-Function-----------
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
            url: "/Product/Delete?id=" + id,
            success: function (res) {
                alert("Data has Been Removed !!!");
                window.location.href = "/Product/Index";
            },
            error: function (res) {
                alert("ERROR");
            }
        })
    }
    return false;
}
//---CategoryDroDown------------
$.ajax({
    type: "GET",
    dataType: "json",
    contentType: "application/json",
    url: "/Category/CategoryDrop",
    success: function (data) {
        console.log("SUCCESS DATA:", data);
        var dropdown = $('#CategoryName');
        $.each(data, function (index, item) {
            dropdown.append($('<option value="' + item.ID + '" multiple="multiple">' + item.CategoryName + '</option>'));
        });
    },
    error: function (data) {
        console.log("ERROR DATA : ", data);
    }
});
//--------SubCategoryDroDown---------

$.ajax({
    type: "GET",
    dataType: "json",
    contentType: "application/json",
    url: "/Category/SubCategoryDrop",
    success: function (data) {
        console.log("SUCCESS DATA:", data);
        var dropdown = $('#SubCategoryName');
        $.each(data, function (index, item) {
            dropdown.append($('<option value="' + item.ID +'" multiple="multiple">'+item.SubCategoryName+'</option>'));
        });
    },
    error: function (data) {
        console.log("ERROR DATA : ", data);
    }
});
//$("#CategroyName").change(function () {
//    var CountryId = parseInt($(this).val());
//    if (!isNaN(CountryId)) {
//        var ddlState = $('#SubCategoryName');
//        ddlState.empty();
//        ddlState.append($("<option></option>").val('').html('Please wait ...'));
//        $.ajax({
//            url: 'Category/SubCategoryDrop',
//            type: 'GET',
//            dataType: 'json',
//            data: { SubCategoryName: CountryId },
//            success: function (d) {
//                ddlState.empty(); // Clear the please wait  
//                ddlState.append($("<option></option>").val('').html('Select State'));
//                $.each(d, function (i, states) {
//                    ddlState.append($("<option></option>").val(states.StateId).html(states.StateName));
//                });
//            },
//            error: function () {
//                alert('Error!');
//            }
//        });
//    }
//});
