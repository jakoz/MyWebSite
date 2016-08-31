$(document).ready(function () {
    var dayOfNewRoutine = null;
    $(".btn-newRoutine").on("click", function () {
        dayOfNewRoutine = $(this).attr("id").substr(3);
    })

    $('#myModal').on('shown.bs.modal', function () {
        $("modal").show();
        $('#myInput').focus();
    })

    $(".newRoutineSubmit").on("click", function () {
        var updateTarget = ".list-" + dayOfNewRoutine;
        $.ajax({
            url: '/Routine/EditRoutine/?' + dayOfNewRoutine,
            type: 'GET',
            data: { "id": dayOfNewRoutine },
            success: function (data) {
                $(updateTarget).html(data);
            },
            error: function () {
                alert("Failure");
            }
        });
    })
})