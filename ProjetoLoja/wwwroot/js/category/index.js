var selectedIdForExclusion = null;

$(function () {    
    CheckResponse();
    PageBinds();    
    SetDatatables();
});

function PageBinds() {
    $("body").on("click", ".btnDeleteCategory", function () {
        selectedIdForExclusion = this.id;
        $('#deleteCategoryModal').modal();
    });

    $("body").on("click", "#btnConfirmModal", function () {
        selectedIdForExclusion = selectedIdForExclusion.split("_")[1];
        $.post("/Category/DeleteCategory", { categoryId: selectedIdForExclusion }, function (data) {
            var returnMessage = data.response.message;
            var success = data.response.success;
            LoadMessageModal(success, returnMessage);
        });
    });
}

function CheckResponse() {    
    if (Response) {
        if (Response.Success)
            SetToastr(1, Response.Message);
        else
            SetToastr(4, Response.Message);
    }
}

function SetDatatables() {
    $("#categoriesDT").dataTable({
        "oLanguage": { "sUrl": "../../lib/datatables/portuguese.txt" },
        "processing": true,
        "serverSide": true,
        "pageLength": 10,
        "filter": true,
        "order": [[1, "asc"]],
        "ordering": true,
        "orderMulti": false,
        "bLengthChange": false,
        "ajax": {
            "url": "/Category/GetAllCategories",
            "type": "POST",
            "dataType": "json"
        },
        "columnDefs": [
            //{
            //"targets": [0],
            //"visible": false,
            //"searcheble": false
            //},
            { orderable: false, targets: [2, 3] },
            {
                "className": "align-center", "targets": [0, 2, 3]
            }
        ],
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "name", "name": "Name", "autoWidth": true },
            {
                "render": function (data, type, full, meta) {
                    return '<a class="btn  btn-outline btn-outline-secondary" href="/Category/CreateOrEdit/' + full.id + '"><span class="glyphicon glyphicon-pencil"></span></a>';
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-outline btn-outline-secondary btnDeleteCategory' id='btnDeleteCategory_" + row.id + "' ><span class='glyphicon glyphicon-remove'></span></a>";
                }
            }
        ]
    });
}

function SetToastr(type, message) {
    ConfigureToastr();
    switch (type) {
        case 1:
            toastr.success(message);
            break;
        case 2:
            toastr.info(message);
            break;
        case 3:
            toastr.warning(message);
            break;
        case 4:
            toastr.error(message);
            break;
        default:
            toastr.info(message);
            break;
    }
}

function ConfigureToastr() {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-margin-top-center",
        "preventDuplicates": false,
        "showDuration": "300",
        "hideDuration": "3000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
}

function LoadMessageModal(success, message) {
    $('#deleteCategoryModal').modal('toggle');
    SetMessageModalMessage(message);
    $("#messageModal").modal();
    if (success)
        $("#categoriesDT").DataTable().ajax.reload();
}

function SetMessageModalMessage(message) {
    $("#spanMessageModal").text(message);
}