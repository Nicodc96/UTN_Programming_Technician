<?php
    require_once "venta.php";
    class ModificarVenta{
        public static function Modificar(){
            parse_str(file_get_contents("php://input"), $_PUT);
            if (!empty($_PUT["numero_pedido"]) && !empty($_PUT["email"]) && !empty($_PUT["nombre"]) && !empty($_PUT["tipo"]) && !empty($_PUT["cantidad"])){
                return Venta::ModificarVenta(intval($_PUT["numero_pedido"]), $_PUT["email"], $_PUT["nombre"], $_PUT["tipo"], intval($_PUT["cantidad"]));
            }
            return "No se ha podido modificar la venta por falta de datos.";
        }
    }
?>