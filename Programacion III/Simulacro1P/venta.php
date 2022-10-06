<?php
require_once "json.php";
class Venta{
    public $emailUsuario;
    public $saborPizza;
    public $tipoPizza;
    public $cantidadPizza;
    public $fechaVenta;
    public $id;
    private $nombreFoto;

    public function __construct($emailU, $saborP, $tipoP, $cantidadP, $fecha, $id = 0){
        if (is_string($emailU)){
            $this->emailUsuario = $emailU;
        }
        if (is_string($saborP)){
            $this->saborPizza = $saborP;
        }
        if (is_string($tipoP)){
            $this->tipoPizza = $tipoP;
        }
        if (is_int($cantidadP)){
            $this->cantidadPizza = $cantidadP;
        }
        if (date_parse($fecha))
        {
            $this->fechaVenta = $fecha;
        } else $this->fechaVenta = date("Y-n-j");
        $this->id = $id;
    }

    public function getId(){
        return $this->id;
    }

    public function SetNombreFoto(){
        $this->nombreFoto = $this->tipoPizza . "-" . $this->saborPizza . "-" . explode("@", $this->emailUsuario)[0] . '-' . strval($this->fechaVenta);
    }

    public static function RealizarVenta($venta){
        if (is_a($venta, "Venta")){
            $arrayDeVentas = self::LeerVentasJson();
            array_push($arrayDeVentas, $venta);
            JSON::EscrituraJson("venta.json", $arrayDeVentas);
            $pizzaAModificar = Pizza::ObtenerPizza(new Pizza($venta->saborPizza, 0.00, $venta->tipoPizza, 0, 0));
            if (!is_null($pizzaAModificar)){
                $pizzaAModificar->SetStock($venta->cantidadPizza * -1);
                Pizza::GuardarPizza($pizzaAModificar);
                if($venta->GuardarImagenVenta()){
                    return "Se ha realizado la venta correctamente.";
                }
            }
            return "No se ha podido registrar la venta.";
        } else return "El objeto enviado no es una venta.";
    }

    public static function LeerVentasJson($arrayDeVentas = array()){
        $datosJson = JSON::LecturaJson("venta.json");
        if (!empty($datosJson)){
            for ($i = 0; $i < count($datosJson); $i++){
                $venta = new Venta(
                $datosJson[$i]["emailUsuario"],
                $datosJson[$i]["saborPizza"],
                $datosJson[$i]["tipoPizza"],
                intval($datosJson[$i]["cantidadPizza"]),
                $datosJson[$i]["fechaVenta"],
                intval($datosJson[$i]["id"])
                );
                array_push($arrayDeVentas, $venta);
            }
        }
        return $arrayDeVentas;
    }

    public function GuardarImagenVenta(){
        $dir = 'ImagenesDeLaVenta/';
        if (!file_exists($dir)){
            mkdir($dir, 0777, true);
        }
        $this->SetNombreFoto();
        $extension = pathinfo($_FILES["image"]["name"], PATHINFO_EXTENSION);
        $destino = $dir . $this->nombreFoto . "." . $extension;
        $tipoArchivo = pathinfo($destino, PATHINFO_EXTENSION);
        if ($tipoArchivo != 'jpg' && $tipoArchivo != 'png' && $tipoArchivo != 'bmp'){
            echo 'Sólo se aceptan imagenes JPG, PNG y BMP!';
            return false;
        } else{
            return move_uploaded_file($_FILES["image"]["tmp_name"], $destino);
        }
    }

    public static function UltimoIdRegistrado(){
        $arrayDeVentas = self::LeerVentasJson();
        $maximo = 0;
        if (count($arrayDeVentas) > 0){
            foreach($arrayDeVentas as $ventaArray){
                if ($ventaArray->getId() > $maximo){
                    $maximo = $ventaArray->getId();
                }
            }
        }
        return $maximo;
    }

    public static function CantidadTotalVendidas(){
        $arrayDeVentas = self::LeerVentasJson();
        $cantidad = 0;
        if (count($arrayDeVentas) > 0){
            foreach($arrayDeVentas as $ventaArray){
                $cantidad += $ventaArray->cantidadPizza;
            }
        }
        return $cantidad;
    }

    public static function VentasEntreDosFechas($fechaInicio, $fechaFin){
        $arrayDeVentas = self::LeerVentasJson();
        $ventasFiltradas = array();
        if (count($arrayDeVentas) > 0){
            foreach($arrayDeVentas as $ventaArray){
                if ($ventaArray->fechaVenta >= $fechaInicio && $ventaArray->fechaVenta <= $fechaFin){
                    array_push($ventasFiltradas, $ventaArray);
                }
            }
        }
        return $ventasFiltradas;
    }

    public static function VentasDeUsuario($email){
        $arrayDeVentas = self::LeerVentasJson();
        $ventasFiltradas = array();
        if (count($arrayDeVentas) > 0){
            foreach($arrayDeVentas as $ventaArray){
                if ($ventaArray->emailUsuario == $email){
                    array_push($ventasFiltradas, $ventaArray);
                }
            }
        }
        return $ventasFiltradas;
    }

    public static function VentasPorSabor($sabor){
        $arrayDeVentas = self::LeerVentasJson();
        $ventasFiltradas = array();
        if (count($arrayDeVentas) > 0){
            foreach($arrayDeVentas as $ventaArray){
                if ($ventaArray->saborPizza == $sabor){
                    array_push($ventasFiltradas, $ventaArray);
                }
            }
        }
        return $ventasFiltradas;
    }

    public static function ModificarVenta($id_pedido, $email_usuario, $sabor_pizza, $tipo_pizza, $cantidad_pizza){
        $modificacion = false;
        $arrayDeVentas = self::LeerVentasJson();
        if (count($arrayDeVentas) > 0){
            foreach($arrayDeVentas as $ventaArray){
                if ($ventaArray->getId() == $id_pedido){
                    $datosAuxPizza = ["sabor" => $ventaArray->saborPizza, "tipo" => $ventaArray->tipoPizza, "cantidad" => $ventaArray->cantidadPizza];
                    $ventaArray->emailUsuario = $email_usuario;
                    $ventaArray->saborPizza = $sabor_pizza;
                    $ventaArray->tipoPizza = $tipo_pizza;
                    $ventaArray->cantidadPizza = $cantidad_pizza;
                    $modificacion = true;
                    break;
                }
            }
            if ($modificacion){
                JSON::EscrituraJson("venta.json", $arrayDeVentas);
                require_once "pizza.php";
                $arrayDePizzas = Pizza::LeerPizzasJson();
                if (count($arrayDePizzas) > 0){
                    foreach($arrayDePizzas as $pizzaArray){
                        if ($pizzaArray->sabor == $datosAuxPizza["sabor"] && $pizzaArray->tipo == $datosAuxPizza["tipo"]){
                            $pizzaArray->SumarStock($datosAuxPizza["cantidad"]);
                            break;
                        }
                    }
                    foreach($arrayDePizzas as $pizzaArray){
                        if ($pizzaArray->sabor == $sabor_pizza && $pizzaArray->tipo == $tipo_pizza){
                            $pizzaArray->SumarStock($cantidad_pizza * -1);
                            break;
                        }
                    }
                    JSON::EscrituraJson("pizza.json", $arrayDePizzas);
                }
                return "Se ha modificado la venta exitosamente. Se han actualizado el stock de pizzas.";
            }
        }
        return "No se ha podido realizar la modificación.";
    }

    public static function EliminarVenta($id_pedido){
        $eliminacion = false;
        $arrayDeVentas = self::LeerVentasJson();
        if (count($arrayDeVentas) > 0){
            for ($i = 0; $i < count($arrayDeVentas); $i++){
                if ($arrayDeVentas[$i]->id == $id_pedido){
                    $arrayDeVentas[$i]->SetNombreFoto();
                    $auxNombreFoto = $arrayDeVentas[$i]->nombreFoto;
                    array_splice($arrayDeVentas, $i, 1);
                    $eliminacion = true;
                    break;
                }
            }
            if ($eliminacion && self::BackupImagenes($auxNombreFoto)){
                JSON::EscrituraJson("venta.json", $arrayDeVentas);
                return "Se ha eliminado correctamente la venta.";
            }
        }
        return "No se ha podido eliminar la venta.";
    }

    private static function BackupImagenes($nombreFotoAntigua){
        $dirAntigua = "./ImagenesDeLaVenta/" . $nombreFotoAntigua;
        $dirNueva = "./BACKUPVENTAS/";
        if (!file_exists($dirNueva)){
            mkdir($dirNueva, 0777, true);
        }
        if (file_exists($dirAntigua . ".bmp")){
            $nombreFotoAntigua .= ".bmp";
        } else if (file_exists($dirAntigua . ".png")){
            $nombreFotoAntigua .= ".png";
        } else{
            $nombreFotoAntigua .= ".jpg";
        }
        return rename("./ImagenesDeLaVenta/" . $nombreFotoAntigua, $dirNueva . $nombreFotoAntigua);
    }
}
?>