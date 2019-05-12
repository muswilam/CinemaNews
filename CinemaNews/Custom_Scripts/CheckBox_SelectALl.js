

$(function () {
    $("#checkAll").click(function () {
        $("input[name='CheckDelete']").prop("checked", this.checked);
    });
    $("input[name='CheckDelete']").click(function () {
        if ($("input[name='CheckDelete']").length === $("input[name='CheckDelete']:checked").length) {
            $("#checkAll").prop("checked", true);
        }
        else {
            $("#checkAll").removeProp("checked");
        }
    });
    $("#btnDeleteAll").click(function () {
        var count = $("input[name='CheckDelete']:checked").length;
        if (count === 0) {
            alert("No Actor is Selected to Delete.");
            return false;
        }
        else {
            return confirm(count + " Actor(s) will be Deleted.");
        }
    });
    $("#btnSelect").click(function () {
        var Toggle = $(this).val() === "Select";
        $(this).val(Toggle ? "Cancel" : "Select");

        $("#checkAll").toggle();
        $("#txtAll").toggle();
        $("input[name='CheckDelete']").toggle();
        $("#btnDeleteAll").toggle();
        $("a[name='link']").toggle();
    });
});