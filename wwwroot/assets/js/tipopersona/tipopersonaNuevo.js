var pathHost = window.location.origin;
var pathController = "/TipoPersona";
var pathRoot = pathHost + pathController;

// Validaciones
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

/* 
    method: Registra un item
    action: Nuevo
*/
function Ingresar(event) {
    event.preventDefault();

    let tipoPersona = document.querySelector("#txt_tipopersona").value;

    var odata = {
        id: 0,
        tipo_persona: tipoPersona,
    };

    fetch(pathHost + "/TipoPersona/Agregar", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(odata),
    })
        .then((response) => response.json())
        .then((data) => {
            if (data.statusCode == 200) {
                window.location = pathHost + "/TipoPersona";
            } else {
                alert("No se pudo registrar.");
            }
        })
        .catch((error) => console.log(error));
}
