<?php
require_once "pizza.php";
class PizzaConsulta{
    public static function Consulta(){
        $mensaje = "";
        switch(Pizza::ConsultarExistencia(new Pizza($_POST["sabor"], 0.00, $_POST["tipo"], 0, -1))){
            case -1:
                $mensaje = "No existen pizzas registradas.";
                break;
            case 1:
                $mensaje = "Si, hay.";
                break;
            case 2:
                $mensaje = "No existe el tipo de pizza con ese sabor.";
                break;
            case 3:
                $mensaje = "No existe el sabor de la pizza de ese tipo.";
                break;
        }
        return $mensaje;
    }
}
?>