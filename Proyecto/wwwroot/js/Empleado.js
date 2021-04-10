var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblEmpleados').DataTable({
        "ajax": {
            "url": "/Empleado/Listar"
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
                                <a href="/Empleado/EmpleadoUpsert/?id=${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Borrar("/Empleado/Borrar/?id=${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}
