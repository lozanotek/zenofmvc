$(function() {
    $("#list1").jqGrid({
        url: 'people/list',
        datatype: "json",
        mtype: 'GET',
        height: 400,
        colNames: ['First Name', 'Last Name', 'Birth Date', '', ''],
        colModel: [{ name: 'FirstName', index: 'FirstName', width: 90 },
                            { name: 'LastName', index: 'LastName', width: 100 },
                            { name: 'BirthDate', index: 'BirthDate', width: 80 },
                            { name: 'Id', index: 'id', width: 50, formatter: editFormatter },
                            { name: 'Id', index: 'id', width: 50, formatter: deleteFormatter}],
        rowNum: 20,
        pager: $('#pager1'),
        sortname: 'id',
        viewrecords: false,
        autowidth: true,
        sortorder: "asc",
        caption: "People",
        jsonReader: { id: "Id", repeatitems: false }
    })
            .navGrid('#pager1',
                { edit: false,
                    add: false,
                    del: false
                });
});

var editFormatter = function(cellval, opts, rwdat, _act) {
    return "<div style='width:100%; height: 100%'><a href='people/edit/" + cellval + "'>Edit</a></div>";
}

var deleteFormatter = function(cellval, opts, rwdat, _act) {
    return "<div style='width:100%; height: 100%'><a href='people/delete/" + cellval + "'>Delete</a></div>";
}