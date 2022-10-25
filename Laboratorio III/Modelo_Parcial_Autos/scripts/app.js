import crearTabla from "./tablaDinamica.js";
import Anuncio_Auto from "./anuncio_auto.js";
import { verificarDatosForm } from "./validaciones.js";

const entidades = JSON.parse(localStorage.getItem("autos")) || [];
const $container = document.querySelector("#lista-entidades");
const $frmEntidad = document.forms[0];
const $titulo = document.querySelector("#titulo-form");
const $btnSubmit = document.querySelector("#btnGuardar");
const $btnEliminar = document.querySelector("#btnEliminar");
const $spinner = document.createElement("img");
$spinner.setAttribute("src", "./images/loading.gif");
$spinner.setAttribute("height", "64px");
$spinner.setAttribute("width", "64px");

actualizarStorage(entidades);
actualizarTabla(entidades, $container);  
limpiarForm();

$frmEntidad.addEventListener("submit", (e) => {
    e.preventDefault();
    const { txtId, txtTitulo, txtDescripcion, txtPrecio, rdoTransaccion, txtCantPuertas, txtCantKm, txtCantPotencia} = $frmEntidad;
    console.log(txtId.value);
    if (verificarDatosForm(txtPrecio, txtCantPuertas, txtCantKm, txtCantPotencia)){
        if (txtId.value == ""){
            const newAuto = new Anuncio_Auto(
                Anuncio_Auto.ultimoIdRegistrado(entidades) + 1, txtTitulo.value, txtDescripcion.value, txtPrecio.value,
                rdoTransaccion.value, txtCantPuertas.value, txtCantKm.value, txtCantPotencia.value
            );
            if (Anuncio_Auto.verificarAnuncioRegistrado(entidades, newAuto) == -1){
                entidades.push(newAuto);
                actualizarStorage(entidades);
                limpiarForm();
            }
        } else{
            const autoModify = new Anuncio_Auto(txtId.value, txtTitulo.value, txtDescripcion.value, txtPrecio.value,
                rdoTransaccion.value, txtCantPuertas.value, txtCantKm.value, txtCantPotencia.value
            );
            if (Anuncio_Auto.modificarElemento(entidades, autoModify)){
                limpiarForm();
                actualizarStorage(entidades);
            }
        }
    } else{
        alert("Error en los datos. Verifique que:\n- El precio sea mínimo $100\n- La cantidad de puertas sea mínimo 2\n- Potencia mayor o igual a 25\n- Kilometraje no negativo");
    }
    actualizarTabla(entidades, $container);
});

window.addEventListener("click", (e) => {
    const target = e.target;
    if(target.matches("tr td")){
        const id = e.target.parentElement.dataset.id;
        cargarDatos(Anuncio_Auto.obtenerElemento(entidades, parseInt(id)));
        $titulo.textContent = "Modificación del anuncio";
        $btnEliminar.removeAttribute("disabled");
        $btnSubmit.setAttribute("id", "btnModificar");
        $btnSubmit.childNodes[2].textContent = "MODIFICAR";
    }
    if (target.matches("#btnCancelar") || target.parentElement.matches("#btnCancelar")){
        e.preventDefault();
        limpiarForm();
    }
    if (target.matches("#btnEliminar") || target.parentElement.matches("#btnEliminar")){
        if(Anuncio_Auto.eliminarElemento(entidades, parseInt($frmEntidad.txtId.value))){
            limpiarForm();
            actualizarStorage(entidades);
            actualizarTabla(entidades, $container);
        }
    }
});
/* Funciones para el formulario */
function cargarDatos(elemento){
    if (elemento instanceof Object){
        const { txtId, txtTitulo, txtDescripcion, txtPrecio, txtCantPuertas, txtCantKm, txtCantPotencia, rdoTransaccion} = $frmEntidad;
        txtId.value = elemento.id;
        txtTitulo.value = elemento.titulo;
        txtDescripcion.value = elemento.descripcion;
        txtPrecio.value = elemento.precio;
        rdoTransaccion.value = elemento.transaccion;
        txtCantPuertas.value = elemento.cantPuertas;
        txtCantKm.value = elemento.kilometraje;
        txtCantPotencia.value = elemento.potencia;
    } else{
        alert("El elemento seleccionado no es un anuncio!");
    }
}

function limpiarForm(){
    $titulo.textContent = "Complete el formulario según corresponda:";
    $btnSubmit.setAttribute("id", "btnGuardar");
    $btnSubmit.childNodes[2].textContent = "GUARDAR";
    $btnEliminar.setAttribute("disabled", "");
    $frmEntidad.reset();
    $frmEntidad.txtId.value = "";
}
/* ------------------------------------------ */

/* Funciones para la tabla y el local storage */
function actualizarStorage(lista){
    localStorage.setItem("autos", JSON.stringify(lista));
}

function actualizarTabla(lista, contenedor){
    let anuncioContainer = document.querySelector(".entidad-container");
    while(contenedor.hasChildNodes()){
        contenedor.removeChild(contenedor.firstElementChild);
    }
    anuncioContainer.appendChild($spinner);
    setTimeout(() => {
        anuncioContainer.removeChild($spinner);
        let data = document.querySelector("#lista-entidades");
        if (data){
            contenedor.appendChild(crearTabla(lista));
        }
    }, 3000);
}
/* ------------------------------------------ */