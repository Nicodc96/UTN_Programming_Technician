<?php
    require_once "devolucion.php";
    require_once "cupon.php";
    switch($_GET["consultaDevoluciones"]){
        case "devoluciones":
            echo Devolucion::MostrarTablaDevoluciones();
            break;
        case "cupones":
            echo Cupon::MostrarTablaCupones();
            break;
        case "todo":
            echo Devolucion::MostrarTablaDevoluciones();
            echo Cupon::MostrarTablaCupones();
            break;
        default:
            return "Consulta incorrecta.";
    }
?>