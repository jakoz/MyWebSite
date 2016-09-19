$(document).ready(function () {
    var dayOfNewRoutine = null;
    $(".btn-newRoutine").on("click", function () {
        dayOfNewRoutine = $(this).attr("id").substr(3);
    });

    $(".list-group-item-routines").hover(function () {
    });

    $(".routine-icon-img").on("click", function () {
        if ( confirm("Remove routine?") )
        {
            var id = $(this).attr("id");
            $.ajax({
                url: '/Routine/DeleteRoutine/?' + id,
                type: "POST",
                data: { "id": id },
                success: function (data) {
                    $("body").html(data);
                },
                error: function (exception) {
                    alert('Exeption:'+exception.statusText);
                }
            });
        }
    });

    $("#btnCreateAnotherActivity").on("click", function () {
        //$("#divAnotherActivity").append("<input type='textbox' id='ActivityId' class='form-control'/>");
        var marker = $('<span />').insertBefore('#NameOfNewActivity');

        $("#NameOfNewActivity").detach().attr('type', 'text').insertAfter(marker);
        marker.remove();
        debugger;
        $(this).addClass(".btn-blocked");
        $(this).prop("disabled", true);
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