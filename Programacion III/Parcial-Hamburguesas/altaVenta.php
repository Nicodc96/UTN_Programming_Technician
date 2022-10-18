<?php
    require_once "hamburguesa.php";
    require_once "venta.php";
    class AltaVenta{
        public static function RealizarVenta(){
            // Primera parte
            if (!empty($_POST["nombre"]) && !empty($_POST["tipo"]) && !empty($_POST["email"]) && !empty($_POST["cantidad"]))
            {
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
            return "No se ha podido realizar la venta por falta de datos.";
        }
        public static function RealizarVentaCupon(){
            if (!empty($_POST["nombre"]) && !empty($_POST["tipo"]) && !empty($_POST["email"]) && !empty($_POST["cantidad"])){
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
                }
                return "No se ha podido realizar la venta debido a la falta de stock";
            }
            return "No se ha podido realizar la venta por falta de datos.";
        }
    }
?>