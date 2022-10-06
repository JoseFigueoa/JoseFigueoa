var pathHost = window.location.origin;
var pathController = "/Persona";
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
    method: Obtiene los datos de un persona
    action: Editar
*/
function Obtener(id) {
    fetch(pathController + "/Obtener/" + id, {
        method: "POST",
    })
        .then((response) => response.json())
        .then((data) => {
            if (data.statusCode == 200) {
                // Bind a pais, departamento y municipio
                ObtenerUbicacionLoad(
                    data.data.ubicacion.departamento.id_pais,
                    data.data.ubicacion.id_departamento,
                    data.data.ubicacion.id
                );

                // Bind tipo persona
                ObtenerTipoPersonaLoad(data.data.tipoPersona.id);

                // Bind inputs
                let $txtID = document.querySelector("#txt_id");
                let $txtPrimerNombre = document.querySelector("#txt_primernombre");
                let $txtSegundoNombre = document.querySelector("#txt_segundonombre");
                let $txtTercerNombre = document.querySelector("#txt_tercernombre");
                let $txtPrimerApellido = document.querySelector("#txt_primerapellido");
                let $txtSegundoApellido = document.querySelector("#txt_segundoapellido");
                let $txtApellidoCasada = document.querySelector("#txt_apellidocasada");
                let $txtFechaNacimiento = document.querySelector("#txt_fechanacimiento");
                let $txtDireccion = document.querySelector("#txt_direccion");

                $txtPrimerNombre.value = data.data.primer_nombre;
                $txtSegundoNombre.value = data.data.segundo_nombre;
                $txtTercerNombre.value = data.data.tercer_nombre;
                $txtPrimerApellido.value = data.data.primer_apellido;
                $txtSegundoApellido.value = data.data.segundo_apellido;
                $txtApellidoCasada.value = data.data.apellido_casada;
                $txtFechaNacimiento.value = formatLocal(data.data.fecha_nacimiento);
                $txtDireccion.value = data.data.direccion;
                $txtID.value = data.data.id;

                // set radio
                const radios = document.getElementsByName("gridRadios");
                for (var i = 0; i < radios.length; i++) {
                    if (radios[i].value == data.data.id_genero) {
                        radios[i].checked = true;
                        break;
                    }
                }
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Ingresa el formulario
    action: Editar
*/
function Actualizar(e) {
    e.preventDefault();

    // select
    let $intMunicipio = document.querySelector("#cmb_municipio").value;
    let $intTipoPersona = document.querySelector("#cmb_tipopersona").value;

    // inputs
    let $txt_id = document.querySelector("#txt_id").value;
    let $txtPrimerNombre = document.querySelector("#txt_primernombre").value;
    let $txtSegundoNombre = document.querySelector("#txt_segundonombre").value;
    let $txtTercerNombre = document.querySelector("#txt_tercernombre").value;
    let $txtPrimerApellido = document.querySelector("#txt_primerapellido").value;
    let $txtSegundoApellido = document.querySelector("#txt_segundoapellido").value;
    let $txtApellidoCasada = document.querySelector("#txt_apellidocasada").value;
    let $txtFechaNacimiento = document.querySelector("#txt_fechanacimiento").value;
    let $txtDireccion = document.querySelector("#txt_direccion").value;

    //radios
    const radios = document.getElementsByName("gridRadios");
    let $txtGenero;
    for (var i = 0; i < radios.length; i++) {
        if (radios[i].checked) {
            $txtGenero = radios[i].value;
            break;
        }
    }

    // object
    var odata = {
        id: parseInt($txt_id),
        id_ubicacion: parseInt($intMunicipio),
        id_tipopersona: parseInt($intTipoPersona),
        id_genero: parseInt($txtGenero),
        primer_nombre: $txtPrimerNombre,
        segundo_nombre: $txtSegundoNombre,
        tercer_nombre: $txtTercerNombre,
        primer_apellido: $txtPrimerApellido,
        segundo_apellido: $txtSegundoApellido,
        apellido_casada: $txtApellidoCasada,
        fecha_nacimiento: formatRequest($txtFechaNacimiento),
        direccion: $txtDireccion,
    };

    // peticion
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
                window.location = pathController;
            } else {
                alert("No se pudo registrar.");
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Obtiene listado de paises para evento load
    action: Editar
*/
function ObtenerUbicacionLoad(id_pais, id_departamento, id_municipio) {
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
                    ObtenerDepartamentoLoad(id_pais, id_departamento, id_municipio);
                }
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Obtiene listado de departamento segun codigo pais
    action: Editar
*/
function ObtenerDepartamentoLoad(id_pais, id_departamento, id_municipio) {
    // elementos HTML
    let $cmbDepartamento = document.querySelector("#cmb_departamento");
    $cmbDepartamento.innerHTML = "";

    // Agregamos el evento change
    $cmbDepartamento.addEventListener("change", (event) => {
        ObtenerMunicipio(event.target.value);
    });

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
                    ObtenerMunicipioLoad(id_departamento, id_municipio);
                }
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Obtiene listado de municipio segun codigo pais
    action: Editar
*/
function ObtenerMunicipioLoad(id_departamento, id_municipio) {
    // elementos HTML
    let $cmbMunicipio = document.querySelector("#cmb_municipio");
    $cmbMunicipio.innerHTML = "";

    // Insertamos la opcion cero
    let $optionNull = document.createElement("option");
    $optionNull.value = 0;
    $optionNull.text = "Seleccione un municipio";

    // Agregamos el item
    $cmbMunicipio.appendChild($optionNull);

    // Verificamos el codigo de pais
    if (id_departamento == 0) {
        return;
    }

    fetch(pathHost + "/Municipio/ObtenerPorDepartamento/" + id_departamento, {
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
                        $option.text = item.municipio;

                        // insertamos en el elemento
                        $cmbMunicipio.appendChild($option);
                    });

                    //Select option
                    $cmbMunicipio.value = id_municipio;
                }
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Obtiene listado de tipo persona
    action: Editar
*/
function ObtenerTipoPersonaLoad(id_tipopersona) {
    // elementos HTML
    let $cmbPersona = document.querySelector("#cmb_tipopersona");

    fetch(pathHost + "/TipoPersona/Obtener", {
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
                        $option.text = item.tipo_persona;

                        // insertamos en el elemento
                        $cmbPersona.appendChild($option);
                    });

                    $cmbPersona.value = id_tipopersona;
                }
            } else {
                // message
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Obtiene listado de municipio segun codigo pais
    action: Editar
*/
function ObtenerDepartamento(id_pais) {
    // elementos HTML
    let $cmbDepartamento = document.querySelector("#cmb_departamento");
    $cmbDepartamento.innerHTML = "";

    // Agregamos el evento change
    $cmbDepartamento.addEventListener("change", (event) => {
        ObtenerMunicipio(event.target.value);
    });

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

/* 
    method: Obtiene listado de municipio segun codigo pais
    action: Editar
*/
function ObtenerMunicipio(id_departamento) {
    // elementos HTML
    let $cmbMunicipio = document.querySelector("#cmb_municipio");
    $cmbMunicipio.innerHTML = "";

    // Insertamos la opcion cero
    let $optionNull = document.createElement("option");
    $optionNull.value = 0;
    $optionNull.text = "Seleccione un municipio";

    // Agregamos el item
    $cmbMunicipio.appendChild($optionNull);

    // Verificamos el codigo de pais
    if (id_departamento == 0) {
        return;
    }

    fetch(pathHost + "/Municipio/ObtenerPorDepartamento/" + id_departamento, {
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
                        $option.text = item.municipio;

                        // insertamos en el elemento
                        $cmbMunicipio.appendChild($option);
                    });
                }
            }
        })
        .catch((error) => console.log(error));
}

/* 
    method: Formatea la fecha
    action: Editar
*/
function formatLocal(inputDate) {
    let dateFormat = moment(inputDate).format("DD/MM/YYYY");
    return dateFormat;
}

function formatRequest(inputDate) {
    let dateFormat = moment(inputDate).format("YYYY-MM-DD");
    return dateFormat;
}
