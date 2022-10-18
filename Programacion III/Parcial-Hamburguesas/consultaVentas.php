<?php
    require_once "venta.php";
    function Info($arrayParam){
        $strVentas = "<h4 align='center'> Ventas </h4>";
        $strVentas .= "<table align='center'><thead><tr><th>Fecha de Venta</th><th>Cantidad</th><th>Tipo</th><th>Nombre</th><th>Cliente</th></tr><tbody>";
        if (count($arrayParam) > 0){
            foreach($arrayParam as $venta){
                $strVentas .= "<tr align='center'>" .
                "<td>" . $venta->GetFecha() . "</td>" .
                "<td>" . $venta->GetCantidad() . "</td>" .
                "<td>" . $venta->GetTipo() . "</td>" .
                "<td>" . $venta->GetNombre() . "</td>" .
                "<td>" . $venta->GetEmail() . "</td></tr>";
            }
        }
        $strVentas .= "</tbody></table>";
        return $strVentas;
    }
    function VentasFechaParticular($fecha){
        return Info(Venta::VentaFechaEspecifica($fecha));
    }
    function VentasEntreFechas($fechaInicio, $fechaFin){   
        $array =  Venta::VentasSegunFecha($fechaInicio, $fechaFin);
        usort($array, "OrdenarPorNombre");   
        return Info($array);
    }
    function OrdenarPorNombre($venta1, $venta2){
        if (is_a($venta1, "Venta") && is_a($venta2, "Venta")){
            return strcmp($venta1->GetNombre(), $venta2->GetNombre());
        } else return false;
    }
    function VentasDeUsuario($email){
        return Info(Venta::VentasSegunUsuario($email));
    }
    function VentasPorTipo($tipo){
        return Info(Venta::VentasSegunTipo($tipo));
    }
    switch($_GET["consultaVentas"]){
        case "fechaParticular":
            echo call_user_func("VentasFechaParticular", $_GET["fecha"]);
            break;
        case "entreFechas":
            echo call_user_func("VentasEntreFechas", $_GET["fechaInicio"], $_GET["fechaFin"]);
            break;
        case "deUsuario":
            echo call_user_func("VentasDeUsuario", $_GET["email"]);
            break;
        case "porTipo":
            echo call_user_func("VentasPorTipo", $_GET["tipo"]);
            break;
        default:
            return "Consulta incorrecta.";
    }
?>