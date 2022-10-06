var pathHost = window.location.origin;
var pathController = "/Departamento";
var pathRoot = pathHost + pathController;

/* Evento */
this.ObtenerPaises();

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

/* Methods */

function Ingresar(event) {
    event.preventDefault();

    let $intPais = document.querySelector("#cmb_pais").value;
    let $strDepartamento = document.querySelector("#txt_departamento").value;

    var odata = {
        id: parseInt(0),
        id_pais: parseInt($intPais),
        departamento: $strDepartamento,
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
                window.location = pathRoot;
            } else {
                alert("No se pudo registrar.");
            }
        })
        .catch((error) => console.log(error));
}

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
