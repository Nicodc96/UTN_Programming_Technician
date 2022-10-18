<?php
    require_once "venta.php";
    class BorrarVenta{
        public static function Borrar(){
            parse_str(file_get_contents("php://input"), $_DELETE);
            if (!empty($_DELETE["numero_pedido"])){
                return Venta::BorrarVenta(intval($_DELETE["numero_pedido"]));
            }
            return "No se ha podido eliminar la venta por falta de datos.";
        }
    }
?>