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

    var time = year + "-" + month + "-" + day; debugger;
    return time;
}

$(document).ready(function () {
    $(".dayOfTheSchedule").val(getCurrentDate());
});