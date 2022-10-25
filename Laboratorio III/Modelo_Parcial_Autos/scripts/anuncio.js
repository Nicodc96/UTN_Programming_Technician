class Anuncio{
    constructor(id, titulo, descripcion, precio, transaccion){
        this.id = parseInt(id);
        this.titulo = titulo;
        this.descripcion = descripcion;
        this.precio = parseFloat(precio);
        this.transaccion = transaccion;
    }
}

export default Anuncio;