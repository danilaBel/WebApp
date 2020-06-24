var isVisible = true;
$(document).ready(function () {
    $("#IsDoctorCheck").click(function () {
        if (isVisible) {
            isVisible = false;
            $(".img_Loader").css("visibility", "visible");
        }
        else {
            isVisible = true;
            $(".img_Loader").css("visibility","hidden");
        }
    });
});