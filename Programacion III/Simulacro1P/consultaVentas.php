<?php
require_once "venta.php";
class ConsultaVentas{
    public static function CantidadPizzasVendidas(){
        return "Cantidad de pizzas vendidas: " . Venta::CantidadTotalVendidas();
    }
    public static function VentasEntreDosFechas(){
        $ventasSegunFechas = Venta::VentasEntreDosFechas($_GET["fechaInicio"], $_GET["fechaFin"]);
        $strVentas = "<h4 align='center'> Ventas </h4>";
        $strVentas .= "<table align='center'><thead><tr><th>Fecha de Venta</th><th>Cantidad</th><th>Tipo</th><th>Sabor</th><th>Cliente</th></tr><tbody>";
        foreach($ventasSegunFechas as $venta){
            $strVentas .= "<tr align='center'>" .
            "<td>" . $venta->fechaVenta . "</td>" .
            "<td>" . $venta->cantidadPizza . "</td>" .
            "<td>" . $venta->tipoPizza . "</td>" .
            "<td>" . $venta->saborPizza . "</td>" .
            "<td>" . $venta->emailUsuario . "</td></tr>";
        }  
        $strVentas .= "</tbody></table>";
        return $strVentas;
    }
    public static function VentasDeUsuario(){
        $ventasDeUsuario = Venta::VentasDeUsuario($_GET["email"]);
        $strVentas = "<h4 align='center'> Ventas </h4>";
        $strVentas .= "<table align='center'><thead><tr><th>Fecha de Venta</th><th>Cantidad</th><th>Tipo</th><th>Sabor</th><th>Cliente</th></tr><tbody>";
        foreach($ventasDeUsuario as $venta){
            $strVentas .= "<tr align='center'>" .
            "<td>" . $venta->fechaVenta . "</td>" .
            "<td>" . $venta->cantidadPizza . "</td>" .
            "<td>" . $venta->tipoPizza . "</td>" .
            "<td>" . $venta->saborPizza . "</td>" .
            "<td>" . $venta->emailUsuario . "</td></tr>";
        }  
        $strVentas .= "</tbody></table>";
        return $strVentas;
    }
    public static function VentasPorSabor(){
        $ventasPorSabor = Venta::VentasPorSabor($_GET["sabor"]);
        $strVentas = "<h4 align='center'> Ventas </h4>";
        $strVentas .= "<table align='center'><thead><tr><th>Fecha de Venta</th><th>Cantidad</th><th>Tipo</th><th>Sabor</th><th>Cliente</th></tr><tbody>";
        foreach($ventasPorSabor as $venta){
            $strVentas .= "<tr align='center'>" .
            "<td>" . $venta->fechaVenta . "</td>" .
            "<td>" . $venta->cantidadPizza . "</td>" .
            "<td>" . $venta->tipoPizza . "</td>" .
            "<td>" . $venta->saborPizza . "</td>" .
            "<td>" . $venta->emailUsuario . "</td></tr>";
        }  
        $strVentas .= "</tbody></table>";
        return $strVentas;
    }
}
?>