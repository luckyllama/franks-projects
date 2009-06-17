
var CityRow_OnClick = function(id) {
    $("#CityMoreDetails_" + id).toggle();
    $("#CityNotes_" + id).toggle();
};

var SpyReportsSelect_OnChange = function(id) {
    var reportToShowId = $("#SpyReportsSelect_" + id).val();
    if (reportToShowId != "") {
        $("#" + reportToShowId).show();
    }
}

$(function() {
    $(".Tooltip").tooltip();
});