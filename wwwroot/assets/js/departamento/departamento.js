var pathHost = window.location.origin;
var pathController = "/Departamento";
var pathRoot = pathHost + pathController;

/* Load */

this.ObtenerListado();

/* Methods */

function ObtenerListado() {
    fetch(pathRoot + "/Obtener", {
        method: "GET",
    })
        .then((response) => response.json())
        .then((data) => {
            let tbBody = document.querySelector("#tb-departamento tbody");

            data.data.forEach((item) => {
                const row = document.createElement("tr");
                row.id = "tr-" + item.id;
                row.innerHTML = `
                        <td>
                            ${item.pais.pais}
                        </td>
                        <td>${item.departamento}</td>
                        <td>                        
                            <a href="Departamento/Editar/${item.id}" class="btn btn-sm btn-primary"><i class="bx bxs-edit-alt"></i></a>
                            <button type="button" onclick=Eliminar(${item.id}); class="btn btn-sm btn-danger" ><i class="bx bxs-trash"></i></button>
                        </td>
                `;

                tbBody.appendChild(row);
            });
        })
        .catch((error) => console.log(error));
}

function Obtener(id) {
    fetch(pathRoot + "/Obtener/" + id, {
        method: "POST",
    })
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
        })
        .catch((error) => console.log(error));
}

function Eliminar(id) {
    fetch(pathRoot + "/Eliminar/" + id, {
        method: "POST",
    })
        .then((response) => response.json())
        .then((data) => {
            let tbBody = document.querySelector("#tb-departamento tbody");
            let tbRow = document.querySelector("#tb-departamento tbody #tr-" + id);

            if (data.statusCode == 200) {
                tbBody.removeChild(tbRow);
            }
        })
        .catch((error) => console.log(error));
}

function reporte() {
    window.open(pathHost + "/Reporte/Departamento");
}
