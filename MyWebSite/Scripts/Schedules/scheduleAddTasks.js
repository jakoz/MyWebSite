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

$(document).ready(function () {
    $('#myModal').on('shown.bs.modal', function () {
        $("modal").show();
        $('#myInput').focus();
    })

    $("#btnCreateSchedule").on("click", function () {
        window.location.href = $(this).attr("href");
    })
})
