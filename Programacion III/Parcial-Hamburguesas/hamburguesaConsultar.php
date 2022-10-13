<?php
    require_once "hamburguesa.php";
    class ConsultarHamburguesa{
        public static function Consultar(){
            switch(Hamburguesa::ConsultarExistencia(new Hamburguesa($_POST["nombre"], 0.00, $_POST["tipo"], 0, 0))){
                case -1:
                    return "No existen hamburguesas registradas.";
                    break;
                case 1:
                    return "Si, hay.";
                    break;
                case 2:
                    return "No existe el tipo de hamburguesa con ese nombre.";
                    break;
                case 3:
                    return "No existe el nombre de la hamburguesa de ese tipo.";
                    break;
            }
        }
    }
?>