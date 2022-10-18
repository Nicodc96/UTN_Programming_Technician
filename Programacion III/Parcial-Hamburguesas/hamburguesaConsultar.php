<?php
    require_once "hamburguesa.php";
    class ConsultarHamburguesa{
        public static function Consultar(){
            if (!empty($_POST["nombre"]) && !empty($_POST["tipo"])){
                switch(Hamburguesa::ConsultarExistencia(new Hamburguesa($_POST["nombre"], 0.00, $_POST["tipo"], 0, 0))){
                    case -1:
                        return "No existen hamburguesas registradas.";
                    case 1:
                        return "Si, hay.";
                    case 2:
                        return "No existe el tipo de hamburguesa con ese nombre.";
                    case 3:
                        return "No existe el nombre de la hamburguesa de ese tipo.";
                }
            }
            return "No se ha podido realizar la consulta por falta de datos.";
        }
    }
?>