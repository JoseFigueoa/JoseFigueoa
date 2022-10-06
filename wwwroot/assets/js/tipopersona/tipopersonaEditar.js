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
    fetch(pathRoot + "/Obtener/" + id, {
        method: "POST",
    })
        .then((response) => response.json())
        .then((data) => {
            if (data.statusCode == 200) {
                let txtTipoPersona = document.querySelector("#txt_tipopersona");
                let txtID = document.querySelector("#txt_id");

                txtTipoPersona.value = data.data.tipo_persona;
                txtID.value = data.data.id;
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Actualiza un item
    action: Editar
*/
function Actualizar(event) {
    event.preventDefault();

    let _tipoPersona = document.querySelector("#txt_tipopersona").value;
    let _id = document.querySelector("#txt_id").value;

    let odata = {
        id: parseInt(_id),
        tipo_persona: _tipoPersona,
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
                window.location = pathHost + "/TipoPersona";
            } else {
                alert("No se pudo registrar.");
            }
        })
        .catch((error) => console.log(error));
}
