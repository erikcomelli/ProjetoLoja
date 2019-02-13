$(function () {
    $("#categoriesDT").dataTable({
        "oLanguage": { "sUrl": "../../lib/datatables/portuguese.txt" },
        "processing": true,
        "serverSide": true,
        "filter": true,
        "orderMulti": false,
        "ajax": {
            "url": "Category/GetAllCategories",
            "type": "POST",
            "dataType": "json"
        },
        "columnDefs": [
        //{
            //"targets": [0],
            //"visible": false,
            //"searcheble": false
        //},
        {
            "className": "align-center", "targets": [0,2,3]
        }
        ],
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "name", "name": "Nome", "autoWidth": true },
            {
                "render": function (data, type, full, meta) {
                    return '<a class="btn  btn-outline btn-outline-secondary" href="/Category/CreateOrEdit/' + full.Id + '"><span class="glyphicon glyphicon-pencil"></span></a>';
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-outline btn-outline-secondary' onclick=ConfirmDelete('" + row.Id + "'); ><span class='glyphicon glyphicon-remove'></span></a>";
                }
            }
        ]
    });

    function ConfirmDelete(id) {
        //confirm if user wants to exclude data
        Delete(id);
    }

    function Delete(id) {
        //call js to delete
    }

});