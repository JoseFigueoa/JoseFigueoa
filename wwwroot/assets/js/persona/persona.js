var pathHost = window.location.origin;
var pathController = "/Persona";
var pathRoot = pathHost + pathController;

/* Load */
this.ObtenerListado();

/* 
    method: Obtiene todos los datos
    action: /
*/
function ObtenerListado() {
    fetch(pathRoot + "/Obtener", {
        method: "GET",
    })
        .then((response) => response.json())
        .then((data) => {
            let tbBody = document.querySelector("#tb-persona tbody");

            data.data.forEach((item) => {
                const row = document.createElement("tr");
                row.id = "tr-" + item.id;
                row.innerHTML = `
                        <td>${item.primer_nombre}</td>
                        <td>${item.segundo_nombre == null ? "" : item.segundo_nombre}</td>
                        <td>${item.primer_apellido == null ? "" : item.primer_apellido}</td>
                        <td>${item.segundo_apellido == null ? "" : item.segundo_apellido}</td>                        
                        <td>${item.tipoPersona.tipo_persona == null ? "" : item.tipoPersona.tipo_persona}</td>
                        <td>                        
                            <a href="${pathController}/Editar/${
                    item.id
                }" class="btn btn-sm btn-primary"><i class="bx bxs-edit-alt"></i></a>
                            <button type="button" onclick=Eliminar(${
                                item.id
                            }); class="btn btn-sm btn-danger" ><i class="bx bxs-trash"></i></button>
                            <button type="button" onclick=reporteDetalle(${
                                item.id
                            }); class="btn btn-sm btn-secondary"><i class="bx bxs-report"></i></button>
                        </td>
                `;

                tbBody.appendChild(row);
            });
        })
        .catch((error) => console.log(error));
}

/* 
    method: Eliminar registro
    action: /
*/
function Eliminar(id) {
    fetch(pathRoot + "/Eliminar/" + id, {
        method: "POST",
    })
        .then((response) => response.json())
        .then((data) => {
            let tbBody = document.querySelector("#tb-persona tbody");
            let tbRow = document.querySelector("#tb-persona tbody #tr-" + id);

            if (data.statusCode == 200) {
                tbBody.removeChild(tbRow);
            } else {
                alert(data.message);
            }
        })
        .catch((error) => console.log(error));
}

function reporte() {
    window.open(pathHost + "/Reporte/Persona");
}

function reporteDetalle(id) {
    window.open(pathHost + "/Reporte/PersonaDetalle/" + id);
}
