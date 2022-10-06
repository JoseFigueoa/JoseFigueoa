var pathHost = window.location.origin;
var pathController = "/Departamento";
var pathRoot = pathHost + pathController;

/* Evento */
(() => {
    "use strict";

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll(".needs-validation");

    // Loop over them and prevent submission
    Array.from(forms).forEach((form) => {
        form.addEventListener(
            "submit",
            (event) => {
                if (!form.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                } else {
                    Actualizar(event);
                }
                form.classList.add("was-validated");
            },
            false
        );
    });
})();

/* Methods */

/* 
    method: Obtiene los datos de departamento
    action: Editar
*/
function Obtener(id) {
    fetch(pathController + "/Obtener/" + id, {
        method: "POST",
    })
        .then((response) => response.json())
        .then((data) => {
            if (data.statusCode == 200) {
                if (data.data != null) {
                    let $txtDepartamento = document.querySelector("#txt_departamento");
                    let $txtID = document.querySelector("#txt_id");

                    // Bind a pais y departamento
                    ObtenerInformacion(data.data.pais.id);

                    // Bind
                    $txtDepartamento.value = data.data.departamento;
                    $txtID.value = data.data.id;
                }
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Obtiene listado de paises
    action: Editar
*/
function ObtenerInformacion(id_pais) {
    // elementos HTML
    let $cmbPais = document.querySelector("#cmb_pais");

    // Obtener paises
    fetch(pathHost + "/Pais/Obtener", {
        method: "GET",
    })
        .then((response) => response.json())
        .then((data) => {
            // Verificamos estado
            if (data.statusCode == 200) {
                // Verificamos data
                if (data.data != null) {
                    // Obtenermos listado de pais
                    data.data.forEach((item) => {
                        // Creamos elemento opcion
                        let $option = document.createElement("option");
                        $option.value = item.id;
                        $option.text = item.pais;

                        // insertamos en el elemento
                        $cmbPais.appendChild($option);
                    });

                    // Seteamos el paais
                    $cmbPais.value = id_pais;
                }
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Registra un item
    action: Nuevo
*/
function Actualizar(event) {
    event.preventDefault();

    let $intId = document.querySelector("#txt_id").value;
    let $intPais = document.querySelector("#cmb_pais").value;
    let $strDepartamento = document.querySelector("#txt_departamento").value;

    var odata = {
        id: parseInt($intId),
        id_pais: parseInt($intPais),
        departamento: $strDepartamento,
    };

    fetch(pathRoot + "/Actualizar", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(odata),
    })
        .then((response) => response.json())
        .then((data) => {
            if (data.statusCode == 200) {
                window.location = pathRoot;
            } else {
                alert("No se pudo registrar.");
            }
        })
        .catch((error) => console.log(error));
}
