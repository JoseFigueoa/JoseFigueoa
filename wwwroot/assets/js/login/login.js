var pathHost = window.location.origin;
var pathController = "/Login";
var pathRoot = pathHost + pathController;

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
                    Validar(event);
                }
                form.classList.add("was-validated");
            },
            false
        );
    });
})();

/* 
    method: Ingresa el formulario
    action: Nuevo
*/
function Validar(event) {
    event.preventDefault();

    // select
    let usuario = document.querySelector("#txt_usuario").value;
    let password = document.querySelector("#txt_password").value;

    // object
    var odata = {
        usuario: usuario,
        password: password,
    };

    // peticion
    fetch(pathRoot + "/ValidarUsuario", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(odata),
    })
        .then((response) => response.json())
        .then((data) => {
            if (data.statusCode == 200) {
                window.location = pathHost;
            }
            if (data.statusCode == 210) {
                alert("Credenciales no validas.", "danger");
            }
        })
        .catch((error) => {
            alert("Error al conectar. Motivo: " + error, "danger");
        });
}

const alertPlaceholder = document.getElementById("message-container");

const alert = (message, type) => {
    const wrapper = document.createElement("div");
    wrapper.innerHTML = [
        `<div class="alert alert-${type} alert-dismissible" role="alert">`,
        `   <div>${message}</div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
        "</div>",
    ].join("");

    alertPlaceholder.innerHTML = "";
    alertPlaceholder.append(wrapper);
};
