<?php
require_once "pizza.php";
require_once "venta.php";
class AltaVenta{
    public static function Venta(){
        if (Pizza::ConsultarExistencia(new Pizza($_POST["sabor"], 0.00, $_POST["tipo"],0, 0)) == 1){
            return Venta::RealizarVenta(new Venta($_POST["email"], $_POST["sabor"], $_POST["tipo"], intval($_POST["cantidad"]), date("Y-n-j"), Venta::UltimoIdRegistrado() + 1));
        } else return "No se ha podido realizar la venta debido a la falta de stock";
    }
}
?>