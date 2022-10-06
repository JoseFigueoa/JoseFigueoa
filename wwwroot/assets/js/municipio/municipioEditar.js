var pathHost = window.location.origin;
var pathController = "/Municipio";
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

/* 
    method: Obtiene los datos ed un tipopersona
    action: Editar
*/
function Obtener(id) {
    fetch(pathController + "/Obtener/" + id, {
        method: "POST",
    })
        .then((response) => response.json())
        .then((data) => {
            if (data.statusCode == 200) {
                let $txtMunicipio = document.querySelector("#txt_municipio");
                let $txtID = document.querySelector("#txt_id");

                // Bind a pais y departamento
                ObtenerInformacion(data.data.departamento.pais.id, data.data.id_departamento);

                // Bind
                $txtMunicipio.value = data.data.municipio;
                // Bind
                $txtID.value = data.data.id;
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Actualiza un item
    action: Editar
*/
function Actualizar(e) {
    e.preventDefault();

    let _id_pais = document.querySelector("#cmb_pais").value;
    let _id_departamento = document.querySelector("#cmb_departamento").value;
    let _municipio = document.querySelector("#txt_municipio").value;
    let _id = document.querySelector("#txt_id").value;

    let odata = {
        id: parseInt(_id),
        id_departamento: parseInt(_id_departamento),
        municipio: _municipio,
    };

    fetch(pathController + "/Actualizar", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(odata),
    })
        .then((response) => response.json())
        .then((data) => {
            if (data.statusCode == 200) {
                window.location = pathHost + pathController + "/";
            } else {
                alert("No se pudo registrar.");
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Obtiene listado de paises
    action: Editar
*/
function ObtenerInformacion(id_pais, id_departamento) {
    // elementos HTML
    let $cmbPais = document.querySelector("#cmb_pais");

    // Agregamos el evento change
    $cmbPais.addEventListener("change", (event) => {
        ObtenerDepartamento(event.target.value);
    });

    // Insertamos la opcion cero
    let $optionNull = document.createElement("option");
    $optionNull.value = 0;
    $optionNull.text = "Seleccione un pais";

    // Agregamos el item
    $cmbPais.appendChild($optionNull);

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
                    ObtenerDepartamentoEditar(id_pais, id_departamento);
                }
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Obtiene listado de municipio segun codigo pais
    action: Editar
*/
function ObtenerDepartamentoEditar(id_pais, id_departamento) {
    // elementos HTML
    let $cmbDepartamento = document.querySelector("#cmb_departamento");
    $cmbDepartamento.innerHTML = "";

    // Insertamos la opcion cero
    let $optionNull = document.createElement("option");
    $optionNull.value = 0;
    $optionNull.text = "Seleccione un departamento";

    // Agregamos el item
    $cmbDepartamento.appendChild($optionNull);

    // Verificamos el codigo de pais
    if (id_pais == 0) {
        return;
    }

    fetch(pathHost + "/Departamento/ObtenerPorPais/" + id_pais, {
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
                        $option.text = item.departamento;

                        // insertamos en el elemento
                        $cmbDepartamento.appendChild($option);
                    });

                    $cmbDepartamento.value = id_departamento;
                }
            }
        })
        .catch((error) => console.log(error));
}
