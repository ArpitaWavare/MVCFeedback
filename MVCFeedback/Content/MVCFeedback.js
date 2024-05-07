
$(document).ready(function () {
    GetMVCFeedbackList();
    getMVCFeedbackbyId();
    RedirectDetails();
});
var Savereg = function () {
    var id = $("#txthdn").val();
    var first_name = $("#txtName").val();
    var last_name = $("#txtLname").val();
    var age = $("#txtAge").val();
    var email_id = $("#txtEmail").val();
    var address = $("#txtAdd").val();
    var model = { Id: id,First_Name: first_name, Last_Name:last_name, Age:age, Email_Id:email_id, Address: address };
    $.ajax({
        url: "/MVCFeedback/Savereg",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        success: function (response) {
            alert("Successfull");
            GetMVCFeedbackList();
        },
        Error: function (response) {
            alert("error Accord by This Page");
        },
    })
}

var GetMVCFeedbackList = function () {
    debugger;
    $.ajax({
        url: "/MVCFeedback/GetMVCFeedbackList",
        method: "post",
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        async: false,
        success: function (response) {
            var html = "";
            $("#MVCFeedback tbody").empty();

            $.each(response.model, function (index, elementValue) {

                html += "<tr><td>" + elementValue.Srno +
                    "</td><td>" + elementValue.Id +
                    "</td><td>" + elementValue.First_Name +
                    "</td><td>" + elementValue.Last_Name +
                    "</td><td>" + elementValue.Age +
                    "</td><td>" + elementValue.Email_id +
                    "</td><td>" + elementValue.Address + "</td><td><input type='button' value='Delete' onclick='deleteMVCFeedback(" + elementValue.Id + ")' class='btn btn-danger'/> &nbsp <input type='button' value='Edit' onclick='getMVCFeedbackbyId(" + elementValue.Id + ")'class='btn btn-success'/> <input type='button' value='RedirectDetails' onclick='Details(" + elementValue.Id + ")' class='btn btn-info'/></td></tr>";

            });
            $("#MVCFeedback tbody").append(html);
        }

    });
}

var deleteMVCFeedback = function (Id) {
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/MVCFeedback/deleteMVCFeedback",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        success: function (response) {
            alert(response.model);


        }
    });

}

var getMVCFeedbackbyId = function (Id) {
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/MVCFeedback/getMVCFeedbackbyId",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        success: function (response) {
            $("#txthdn").val(response.model.Id);
            $("#txtName").val(response.model.First_Name);
            $("#txtLname").val(response.model.Last_Name);
            $("#txtAge").val(response.model.Age);
            $("#txtEmail").val(response.model.Email_id);
            $("#txtAdd").val(response.model.Address);
           
        }
    });

}

var Details = function (Id) {
    window.location.href = "/MVCFeedback/DetailsIndex?Id=" + Id;

}

var RedirectDetails = function () {
    debugger;
    var Id = $("#txthdn").val();
    model = { Id: Id }
    $.ajax({
        url: "/MVCFeedback/getMVCFeedbackbyId",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        success: function (response) {
            $("#txthdn").text(response.model.Id);
            $("#txtName").text(response.model.First_Name);
            $("#txtLname").text(response.model.Last_Name);
            $("#txtAge").text(response.model.Age);
            $("#txtEmail").text(response.model.Email_id);
            $("#txtAdd").text(response.model.Address);

        }
    });

}
