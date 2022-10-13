<?php
    require_once "hamburguesa.php";
    require_once "venta.php";
    class AltaVenta{
        public static function RealizarVenta(){
            // Primera parte
            $hamburguesaParam = new Hamburguesa($_POST["nombre"], 0.00, $_POST["tipo"], 0, 0);
            if (Hamburguesa::ConsultarExistencia($hamburguesaParam) == 1){
                $hamburguesaAux = Hamburguesa::ObtenerHamburguesa($hamburguesaParam);
                return Venta::RealizarVenta(new Venta($_POST["email"],
                intval($_POST["cantidad"]),
                $_POST["nombre"],
                $_POST["tipo"],
                date("Y-n-j"),
                Venta::UltimoIdRegistrado() + 1, "", false,
                Venta::GenerarImporteFinal(intval($_POST["cantidad"]), $hamburguesaAux->GetPrecio(), false)));
            }
            return "No se ha podido realizar la venta debido a la falta de stock";
        }
        public static function RealizarVentaCupon(){
            require_once "cupon.php";
            // Segunda Parte
            $hamburguesaParam = new Hamburguesa($_POST["nombre"], 0.00, $_POST["tipo"], 0, 0);
            if (Hamburguesa::ConsultarExistencia($hamburguesaParam) == 1){
                $hamburguesaAux = Hamburguesa::ObtenerHamburguesa($hamburguesaParam);
                return Venta::RealizarVenta(new Venta($_POST["email"],
                intval($_POST["cantidad"]),
                $_POST["nombre"],
                $_POST["tipo"],
                date("Y-n-j"),
                Venta::UltimoIdRegistrado() + 1, "", false,
                Venta::GenerarImporteFinal(intval($_POST["cantidad"]), $hamburguesaAux->GetPrecio(), Cupon::UtilizarCupon(intval($_POST["id_cupon"])))));
                /* Lo que hago en esta última parte es generar el importe final en donde el parámetro "descuento" será determinado por la
                   función estática "UtilizarCupon" que devolverá true o false dependiendo si existe el cupón y se pudo utilizar
                   y el resultado se utilizará en la función "GenerarImporteFinal" para calcular o no el descuento. */
            }
            return "No se ha podido realizar la venta debido a la falta de stock";
        }
    }
?>