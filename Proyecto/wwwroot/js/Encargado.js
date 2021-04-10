var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblEncargados').DataTable({
        "ajax": {
            "url": "/Encargado/Listar"
        },
        "columnDefs": [{
            "targets": 2,
            "render": function (data) {
                return moment(data).format('MM/DD/YYYY');
            }
        }],
        "columns": [
            { "data": "Identificacion", "width": "15%" },
            { "data": "Nombre", "width": "15%" },
            { "data": "Apellidos", "width": "15%" },
            { "data": "Telefono", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Encargado/EncargadoUpsert/?id=${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Borrar("/Encargado/Borrar/?id=${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}
