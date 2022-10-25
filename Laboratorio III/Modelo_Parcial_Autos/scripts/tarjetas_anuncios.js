import { crearTarjeta } from "./card.js";

const $contenedorTarjetas = document.querySelector(".tarjetas");
const entidades = JSON.parse(localStorage.getItem("autos")) || [];

if (entidades.length > 0){
    entidades.forEach((vehiculo) => {
        $contenedorTarjetas.appendChild(crearTarjeta(vehiculo.titulo,
            vehiculo.descripcion,
            vehiculo.precio.toString(),
            vehiculo.cantPuertas.toString(),
            vehiculo.kilometraje.toString(),
            vehiculo.potencia.toString()));
    });
}
