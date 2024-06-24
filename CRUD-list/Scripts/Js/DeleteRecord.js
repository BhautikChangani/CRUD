function deleteSelectedRows() {
    var grid = $("#grid").data("kendoGrid");
    var selectedRows = grid.select();
    var dataItems = selectedRows.map(function (index, row) {
        return grid.dataItem(row);
    }).toArray();
    if (dataItems.length === 0) {
        alert("Please select at least one row to delete.");
        return;
    }

    if (confirm("Are you sure you want to delete the selected rows?")) {
        var dataToSend = {
            selectedItems: dataItems
        };

        $.ajax({
            url: '/User/DeleteAll',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(dataToSend),
            success: function (response) {
                console.log('Deleted successfully:', response);
                grid.dataSource.read();
            },
            error: function (xhr, status, error) {
                console.error('Error deleting:', error);
            }
        });

    }
}