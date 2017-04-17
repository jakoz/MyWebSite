$(document).ready(function () {
    $(".dayOfTheSchedule").val(getCurrentDate());

    $('#myModal').on('shown.bs.modal', function () {
        $("modal").show();
        $('#myInput').focus();
    });

    $("#btnCreateSchedule").on("click", function () {
        window.location.href = $(this).attr("href");
    });

    $(".schedule-icon-img").on("click", function () {
        if (confirm("Remove schedule?")) {
            var id = $(this).attr("id");
            $.ajax({
                url: '/Schedule/DeleteRoutine/?' + id,
                type: "POST",
                data: { "id": id },
                success: function (data) {
                    $("body").html(data);
                },
                error: function (exception) {
                    alert('Exeption:' + exception.statusText);
                }
            });
        }
    });
});

$(document).on("click", ".calendar-body", function (e) {
    e.preventDefault();
    var date = $(this).html();
    date = date.replace(/(\r\n|\n|\r)/gm, "");
    $.ajax({
        url: '/Schedule/EditSchedule/?' + date,
        type: 'GET',
        data: { "id": date },
        success: function (data) {
            $("body").html(data);
        },
        error: function () {
            alert("Failure");
        }
    });
})

function getCurrentDate() {
    var date = new Date();
    var day = date.getUTCDate();

    if (day < 10) {
        day = '0' + day;
    }
    var month = date.getMonth() + 1;
    if (month < 10) {
        month = '0' + month;
    }
    var year = date.getFullYear();

    var time = year + "-" + month + "-" + day;
    return time;
}