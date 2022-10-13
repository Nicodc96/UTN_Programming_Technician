<?php
    /*
        Practica Primer Parcial - Programación III

        Alumno: Díaz, Lautaro Nicolás
        División: 3°D
    */
    switch($_SERVER["REQUEST_METHOD"]){
        case "POST":
            switch(key($_POST)){
                case "hamburguesaCarga":
                    require "hamburguesaCarga.php";
                    echo HamburguesaCarga::Carga();
                    break;
                case "hamburguesaConsultar":
                    require "hamburguesaConsultar.php";
                    echo ConsultarHamburguesa::Consultar();
                    break;
                case "altaVenta":
                    require "altaVenta.php";
                    echo AltaVenta::RealizarVenta();
                    break;
                case "altaVenta2":
                    require "altaVenta.php";
                    echo AltaVenta::RealizarVentaCupon();
                    break;
                case "devolverHamburguesa":
                    require "devolverHamburguesa.php";
                    echo DevolverPedido::Devolver();
                    break;
            }
            break;
        case "GET":
            switch(key($_GET)){
                case "consultaVentas":
                    require "consultasVentas.php";
                    break;
                case "consultaDevoluciones":
                    require "consultarDevoluciones.php";
                    break;
            }            
            case "PUT":
                parse_str(file_get_contents("php://input"), $_PUT);
                switch(key($_PUT)){
                    case "modificarVenta":
                        require "modificarVenta.php";
                        echo ModificarVenta::Modificar();
                    break;
                }
                break;
            case "DELETE":
                parse_str(file_get_contents("php://input"), $_DELETE);
                switch(key($_DELETE)){
                    case "borrarVenta":
                        require "borrarVenta.php";
                        echo BorrarVenta::Borrar();
                        break;
                }
                break;
        default:
            echo "Petición inválida.";
    }
?>

