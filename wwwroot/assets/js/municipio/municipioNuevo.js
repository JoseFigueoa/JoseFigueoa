var pathHost = window.location.origin;
var pathController = "/Municipio";
var pathRoot = pathHost + pathController;

/* Load */
this.ObtenerPaises();

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
                    Ingresar(event);
                }
                form.classList.add("was-validated");
            },
            false
        );
    });
})();

/* 
    method: Registra un item
    action: Nuevo
*/
function Ingresar(event) {
    event.preventDefault();

    let intPais = document.querySelector("#cmb_pais").value;
    let intDepartamento = document.querySelector("#cmb_departamento").value;
    let strMunicipio = document.querySelector("#txt_municipio").value;

    var odata = {
        id: parseInt(0),
        id_departamento: parseInt(intDepartamento),
        municipio: strMunicipio,
    };

    fetch(pathRoot + "/Agregar", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(odata),
    })
        .then((response) => response.json())
        .then((data) => {
            if (data.statusCode == 200) {
                window.location = pathHost + pathController;
            } else {
                alert("No se pudo registrar.");
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Obtiene listado de paises
    action: Nuevo
*/
function ObtenerPaises() {
    fetch(pathHost + "/Pais/Obtener", {
        method: "GET",
    })
        .then((response) => response.json())
        .then((data) => {
            // Verificamos estado
            if (data.statusCode == 200) {
                // Verificamos data
                if (data.data != null) {
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

                    // Obtenermos listado de pais
                    data.data.forEach((item) => {
                        // Creamos elemento opcion
                        let $option = document.createElement("option");
                        $option.value = item.id;
                        $option.text = item.pais;

                        // insertamos en el elemento
                        $cmbPais.appendChild($option);
                    });
                }
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Obtiene listado de municipio segun codigo pais
    action: Nuevo
*/
function ObtenerDepartamento(id_pais) {
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
                }
            }
        })
        .catch((error) => console.log(error));
}
