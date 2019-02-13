$(function () {
    $("#categoriesDT").dataTable({
        "oLanguage": {"sUrl": "../../lib/datatables/portuguese.txt"},
        "processing": true,
        "serverSide": true,
        "filter": true,
        "orderMulti": false,
        "ajax": {
            "url": "Category/GetAllCategories",
            "type": "POST",
            "dataType":"json"
        },
        //"columnsDefs": [{
        //    "targets": [0],
        //    "visible": false,
        //    "searcheble":false
        //}],
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "name", "name": "Nome", "autoWidth": true },
            {
                "render": function (data, type, full, meta)
                {
                    return '<a class="btn btn-info" href="/Category/CreateOrEdit/' + full.Id + '">Editar</a>';
                }
            },
            {
                data: null, render: function (data, type, row)
                {
                    return "<a href='#' class='btn btn-danger' onclick=ConfirmDelete('" + row.Id + "'); >Excluir</a>";
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