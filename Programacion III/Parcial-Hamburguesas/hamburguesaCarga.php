<?php
    require_once "hamburguesa.php";
    class HamburguesaCarga{
        public static function Carga(){
            return Hamburguesa::GuardarHamburguesa(new Hamburguesa($_POST["nombre"],
            floatval($_POST["precio"]),
            $_POST["tipo"],
            intval($_POST["cantidad"]),
            Hamburguesa::UltimoIdRegistrado() + 1));
        }
    }
?>