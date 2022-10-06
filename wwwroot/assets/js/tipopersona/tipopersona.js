var pathHost = window.location.origin;
var pathController = "/TipoPersona";
var pathRoot = pathHost + pathController;

/* Load */
this.ObtenerListado();

/* Methods */

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
            let tbBody = document.querySelector("#tb-tipopersona tbody");

            data.data.forEach((item) => {
                const row = document.createElement("tr");
                row.id = "tr-" + item.id;
                row.innerHTML = `
                        <td>${item.tipo_persona}</td>
                        <td>                        
                            <a href="TipoPersona/Editar/${item.id}" class="btn btn-sm btn-primary"><i class="bx bxs-edit-alt"></i></a>
                            <button type="button" onclick=Eliminar(${item.id}); class="btn btn-sm btn-danger" ><i class="bx bxs-trash"></i></button>
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
            let tbBody = document.querySelector("#tb-tipopersona tbody");
            let tbRow = document.querySelector("#tb-tipopersona tbody #tr-" + id);

            if (data.statusCode == 200) {
                tbBody.removeChild(tbRow);
            }
        })
        .catch((error) => console.log(error));
}

function reporte() {
    window.open(pathHost + "/Reporte/TipoPersona");
}
