<?php
    require_once "venta.php";
    require_once "devolucion.php";
    class DevolverPedido{
        public static function Devolver(){
            if (Venta::VerificarPedido(intval($_POST["numero_pedido"]))){
                $nuevaIdDevolucion = Devolucion::UltimoIdRegistrado() + 1;
                return Devolucion::GuardarDevolucion(
                new Devolucion($nuevaIdDevolucion,
                intval($_POST["numero_pedido"]),
                $_POST["motivo"],
                Devolucion::GenerarCupon($nuevaIdDevolucion)));
            } else return "El pedido solicitado no existe.";
        }
    }
?>