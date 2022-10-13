<?php
    require_once "venta.php";
    class ModificarVenta{
        public static function Modificar(){
            parse_str(file_get_contents("php://input"), $_PUT);
            return Venta::ModificarVenta(intval($_PUT["numero_pedido"]), $_PUT["email"], $_PUT["nombre"], $_PUT["tipo"], intval($_PUT["cantidad"]));
        }
    }
?>