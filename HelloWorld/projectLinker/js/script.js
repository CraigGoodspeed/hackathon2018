function showEntryPoint() {
   var dat = $("#showContent").dialog(
        {
            autoOpen: true,
            buttons: {
                "Ok": function () {
                    $(this).dialog("close");
                    processResult(true);
                }
           },
        }
    );
    dat.dialog("open");
}

function processResult() {
    var selectedItem = $('#ddlType').val() * 1;
    var func = null;
    var href = null;
    switch (selectedItem) {
        case 1:
            {
                func = function (rowid) { doOrgClick(rowid); };
                href = '/../api/projects';
                break;
            }
        case 2:
            {
                func = function (rowid) { doContractorClick(rowid); };
                href = '/../api/contractor';
                break;
            }
        case 3:
            {
                func = function (rowid) { doComClick(rowid); };
                break;
            }
    }
    $("#projects").jqGrid({
        url: $(location).attr('href') + href,
        datatype: "json",
        colNames: ['ProjectID','ProjectName', 'ProjectDescription', 'dateCreated', 'CommunityDescription', 'ContractorName', 'Status', 'Price', 'Priority'],
        colModel: [
            { name: 'ProjectID', index: 'id',hidden:true, key:true},
            { name: 'ProjectName', index: 'ProjectName', width: 300, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;"' } },
            { name: 'ProjectDescription', index: 'ProjectDescription', width: 500, cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style="white-space: normal;"' } },
            { name: 'dateCreated', index: 'dateCreated', width: 200 },
            { name: 'CommunityDescription', index: 'CommunityDescription', width: 200 },
            { name: 'ContractorName', index: 'ContractorName', width: 200 },
            { name: 'Status', index: 'Status', width: 200 },
            { name: 'projectAmount', index: 'projectAmount', width: 55 },
            { name: 'projectPriority', index: 'projectPriority', width: 55 }
        ],
        rowNum: 20,
        onSelectRow : func

    });

}
function doOrgClick(id) {
    //this is the event that will be fired when an organisation is active
}

function doContractorClick(id) {
}

function doComClick(id) {
}