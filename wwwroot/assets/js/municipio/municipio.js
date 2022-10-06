var pathHost = window.location.origin;
var pathController = "/Municipio";
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
            let tbBody = document.querySelector("#tb-municipio tbody");

            data.data.forEach((item) => {
                const row = document.createElement("tr");
                row.id = "tr-" + item.id;
                row.innerHTML = `
                        <td>${item.departamento.pais.pais}</td>
                        <td>${item.departamento.departamento}</td>
                        <td>${item.municipio}</td>
                        <td>                        
                            <a href="${pathController}/Editar/${item.id}" class="btn btn-sm btn-primary"><i class="bx bxs-edit-alt"></i></a>
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
            let tbBody = document.querySelector("#tb-municipio tbody");
            let tbRow = document.querySelector("#tb-municipio tbody #tr-" + id);

            if (data.statusCode == 200) {
                tbBody.removeChild(tbRow);
            }
        })
        .catch((error) => console.log(error));
}

function reporte() {
    window.open(pathHost + "/Reporte/Municipio");
}
