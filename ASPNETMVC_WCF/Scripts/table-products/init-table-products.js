function init() {
    var urlInit = $("#urlInit").val();
    $.ajax({
        type: "GET",
        url: urlInit,
        dataType: "html",
        success: function (data) {
            $('div#partial_view_table_products').html(data);
        }
    });
}