var dataRow     = {}; 

$(function() {
    $("#invoiceSell").submit(function (eventObj) {

        var grid = $("#gridContainer").dxDataGrid("instance");
        var data = JSON.stringify(grid.option("dataSource").store._array);

        $("input[name='Rows']").val(data); 
    });
});

function CreateInvoiceSell      () {
    window.location.href = "/Invoice/Create";
};

function onEditorPrepared       (e) {

    if (e.row && e.row.rowType != "data")
        return;

    var eventName = "keyUp";
    var option = 'text';

         if (e.dataField == "price") {
             $(e.editorElement).dxNumberBox("instance").on(eventName, function (args) {
                try {

                    var grid        = $("#gridContainer").dxDataGrid("instance");
                    var thisText    = $(e.editorElement).dxNumberBox("instance").option(option);
                    dataRow.price   = ConvertToNumber(thisText);
                    var total       = ConvertNaNObject(dataRow.quantity) * dataRow.price - ConvertNaNObject(dataRow.discount);

                    RefreshAllAmounts(grid, total, e.row.rowIndex, dataRow);
                } catch (e) {
                    console.log(e);
                }
        });
    }//
    else if (e.dataField == "quantity") {
             $(e.editorElement).dxNumberBox("instance").on(eventName, function (args) {
                try {

                    var grid            = $("#gridContainer").dxDataGrid("instance"); 
                    var thisText        = $(e.editorElement).dxNumberBox("instance").option(option);
                    dataRow.quantity    = ConvertToNumber(thisText); 
                    var total           = ConvertNaNObject(dataRow.price) * dataRow.quantity - ConvertNaNObject(dataRow.discount);

                    RefreshAllAmounts(grid, total, e.row.rowIndex, dataRow);
                } catch (e) {
                    console.log(e);
                } 
        });
    }
    else if (e.dataField == "discount") {
             $(e.editorElement).dxNumberBox("instance").on(eventName, function (args) {
                try {
                    var grid            = $("#gridContainer").dxDataGrid("instance");
                    var thisText        = $(e.editorElement).dxNumberBox("instance").option(option);
                    dataRow.discount    = ConvertToNumber(thisText);
                    var total           = ConvertNaNObject(dataRow.price) * ConvertNaNObject(dataRow.quantity) - dataRow.discount;

                    RefreshAllAmounts(grid, total, e.row.rowIndex, dataRow);
                } catch (e) {
                    console.log(e);
                } 
        });
    }
    else if (e.dataField == "taxRate1_Percentage") {
             $(e.editorElement).dxNumberBox("instance").on(eventName, function (args) {
                 try {

                     var grid               = $("#gridContainer").dxDataGrid("instance");
                     var thisText           = $(e.editorElement).dxNumberBox("instance").option(option);
                     dataRow.taxRate1_Percentage = ConvertToNumber(thisText);
                     var totalTax           = dataRow.taxRate1_Percentage * ConvertNaNObject(dataRow.total) / 100;

                     RefreshTaxesAmounts(grid, totalTax, e.row.rowIndex, dataRow);
                 } catch (e) {
                     console.log(e);
                 }
             });
         }
};
function OnInitNewRow           (e) { 
    dataRow = {}; 

};

function RefreshAllAmounts      (grid, total, index, data) {
     
    var taxTotal    = ConvertNaNObject(data.taxRate1_Percentage) * total / 100;
    data.total      = total;

    grid.cellValue(index, "total", total ?? 0);

    RefreshTaxesAmounts(grid, taxTotal, index, data);
};
function RefreshTaxesAmounts    (grid, taxTotal, index, data) {

    var totalPlusTax    = ConvertNaNObject(dataRow.total) + taxTotal;
    data.taxRate1_Total = taxTotal;
    data.totalPlusTax   = totalPlusTax; 

    grid.cellValue(index, "taxRate1_Total", taxTotal ?? 0);
    grid.cellValue(index, "totalPlusTax", totalPlusTax ?? 0);

};

function ConvertNaNObject       (number) {
    return number ? number : 0;
};
function ConvertToNumber        (strNum) {

    if (checkIfEmpty(strNum))
        return 0;

    return parseFloat(strNum) ?? 0;
};
function checkIfEmpty           (str) {
    if (str?.trim()) {
        return false;
    } else {
        return true;
    }
}
 