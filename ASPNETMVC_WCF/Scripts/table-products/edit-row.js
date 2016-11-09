function onSuccess() {
    $("#product_name").val("");
    $("#description").val("");
}

var rowIndex;
$('td').on('click', function (e) {
    rowIndex = $(this).parent().index();
});

var delayedFn, blurredFrom;
$('table tr').on('blur', 'div', function (event) {
    blurredFrom = event.delegateTarget;
    var urlEdit = $("#urlUpdateListProducts").val();
    delayedFn = setTimeout(function () {

    var productID = document.getElementById("table_products").rows[rowIndex].cells.item(0).textContent;
    var newName = document.getElementById("table_products").rows[rowIndex].cells.item(1).textContent;
    var newDescription = document.getElementById("table_products").rows[rowIndex].cells.item(2).textContent;
        $.ajax({
        type: "POST",
        url: urlEdit,

        data: {
            productID: productID,
            name: newName,
            description: newDescription
        },
        dataType: "html",
        success: function (data) {
            $('#table').html(data);
        }
    });
    }, 0);
});