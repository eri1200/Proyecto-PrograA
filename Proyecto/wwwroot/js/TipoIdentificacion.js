var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblTiposIdentificacion').DataTable({
        "ajax": {
            "url": "/TipoIdentificacion/Listar"
        },
        "columnDefs": [{
            "targets": 2,
            "render": function (data) {
                return moment(data).format('MM/DD/YYYY');
            }
        }],
        "columns": [
            { "data": "Descripcion", "width": "60%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/TipoIdentificacion/TipoIdentificacionUpsert/?id=${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Borrar("/TipoIdentificacion/Borrar/?id=${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}
