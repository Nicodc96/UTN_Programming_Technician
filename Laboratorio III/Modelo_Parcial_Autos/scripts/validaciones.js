const verificarDatosForm = (precio, cantPuertas, kilometraje, potencia) => {
    if (parseInt(precio.value) >= 100
    && parseInt(kilometraje.value) >= 0
    && parseInt(potencia.value) >= 25
    && parseInt(cantPuertas.value) >= 2
    && parseInt(cantPuertas.value) <= 8){
        return true;
    } else return false;
}

export { verificarDatosForm }