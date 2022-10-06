<?php
require_once "pizza.php";
class CargaPizza{
    public static function CargaGET(){
        return Pizza::GuardarPizza(new Pizza($_GET["sabor"],
        floatval($_GET["precio"]),
        $_GET["tipo"],
        intval($_GET["cantidad"]),
        Pizza::UltimoIdRegistrado() + 1));
    }
    public static function CargaPOST(){
        return Pizza::GuardarPizza(new Pizza($_POST["sabor"],
        floatval($_POST["precio"]),
        $_POST["tipo"],
        intval($_POST["cantidad"]),
        Pizza::UltimoIdRegistrado() + 1));
    }
}
?>