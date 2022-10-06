<?php
// Simulacro parcial - Diaz Lautaro Nicolas
switch($_SERVER["REQUEST_METHOD"]){
    case "GET":
        switch($_GET["peticion"]){
            case "pizzaCarga":
                require "pizzaCarga.php";
                echo CargaPizza::CargaGET();
                break;
            case "cantidadPizzasVendidas":
                require "consultaVentas.php";
                echo ConsultaVentas::CantidadPizzasVendidas();
                break;
            case "ventasEntreFechas":
                require "consultaVentas.php";
                echo ConsultaVentas::VentasEntreDosFechas();
                break;
            case "ventasDeUsuario":
                require "consultaVentas.php";
                echo ConsultaVentas::VentasDeUsuario();
                break;
            case "ventasPorSabor":
                require "consultaVentas.php";
                echo ConsultaVentas::VentasPorSabor();
                break;
            default:
            echo "Peticion GET no valida";
        }
        break;
    case "POST":
        switch(key($_POST)){
            case "consultaPizza";
                require "pizzaConsultar.php";
                echo PizzaConsulta::Consulta();
            break;
            case "altaVenta":
                require "altaVenta.php";
                echo AltaVenta::Venta();
                break;
            case "cargarPizza":
                require "pizzaCarga.php";
                echo CargaPizza::CargaPOST();
                break;
            default:
            echo "Peticion POST no valida.";
        }
        break;
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
        echo "Peticion no valida.";
}

?>