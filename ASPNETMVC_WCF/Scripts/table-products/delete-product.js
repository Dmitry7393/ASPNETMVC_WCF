$(document).off('click').on('click', '.btnRemoveProduct', function () {

    var urlDelete = $("#urlRemoveProduct").val();
    var index = $(this).closest("tr")[0].rowIndex;
    var id = document.getElementById("table_products").rows[index].cells.item(0).textContent;

    $.ajax({
        type: "POST",
        url: urlDelete,
        data: {
            productID: id
        },
        dataType: "html",
        success: function (data) {
            $('div#partial_view_table_products').html(data);
        }
    });
});