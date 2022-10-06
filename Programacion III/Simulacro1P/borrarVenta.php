<?php
require_once "venta.php";
class BorrarVenta{
    public static function Borrar(){
        parse_str(file_get_contents("php://input"), $_DELETE);
        return Venta::EliminarVenta($_DELETE["id_pedido"]);
    }
}
?>