var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblNinoes').DataTable({
        "ajax": {
            "url": "/Nino/Listar"
        },
        "columnDefs": [{
            "targets": 2,
            "render": function (data) {
                return moment(data).format('MM/DD/YYYY');
            }
        }],
        "columns": [
            { "data": "Encargado", "width": "15%" },
            { "data": "Nino.NombreCompleto", "width": "15%" },
            { "data": "fechaNacimiento", "width": "15%" },
            { "data": "Horario", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Nino/NinoUpsert/?id=${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Borrar("/Nino/Borrar/?id=${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}
